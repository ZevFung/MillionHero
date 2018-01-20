using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;

namespace MillionHerosHelper
{
    public partial class MainForm : Form
    {
        public static int CutX { get; set; }
        public static int CutY { get; set; }
        public static int CutHeight { get; set; }
        public static int CutWidth { get; set; }

        private ConfigForm configForm;
        private BrowserForm browserForm;
        private Thread solveProblemThread;
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ServicePointManager.MaxServicePoints = 512;
            ServicePointManager.DefaultConnectionLimit = 512;
            System.Net.ServicePointManager.DefaultConnectionLimit = 64;
            Control.CheckForIllegalCrossThreadCalls = false;

            CutX = 80;
            CutY = 250;
            CutHeight = 1000;
            CutWidth = 900;

            BaiDuOCR.InitBaiDuOCR("0kEPZddCBO5cUD0Lf1yTN91O", "fEkXWR4CINttqCQVAQejX5cXgQKrVbnW");
            browserForm = new BrowserForm();
            browserForm.Show();
        }

        private void button_Config_Click(object sender, EventArgs e)
        {
            if (configForm == null || configForm.IsDisposed)
            {
                configForm = new ConfigForm();
                configForm.Show();
                configForm.Focus();
            }
            else
            {
                configForm.WindowState = FormWindowState.Normal;
                configForm.Focus();
            }
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            button_Config.Enabled = false;
            button_Start.Enabled = false;
            solveProblemThread = new Thread(new ThreadStart(BeginSolveProblem));
            solveProblemThread.Start();

            int timeUsed = 0;
            System.Timers.Timer monitor = new System.Timers.Timer(100);
            monitor.Elapsed += (object _sender, System.Timers.ElapsedEventArgs _args) =>
            {
                if (solveProblemThread == null)
                {
                    monitor.Stop();
                    monitor.Close();
                }
                else if (timeUsed > 10000)
                {
                    //solveProblemThread.Abort();
                    FinishSolveProblem();
                    MessageBox.Show("答题过程超过10秒,自动终止.\r\n请确保您的网络环境良好!", "执行超时", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    timeUsed += 100;
                }
            };
            monitor.Start();
        }

        private void BeginSolveProblem()
        {
            try
            {
                SolveProblem();
            }
            catch(ADBException ex)
            {
                MessageBox.Show("请确保已连接手机并配置正确" + "\r\n\r\n详情:\r\n" + ex.ToString(), "ADB手机连接错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(OCRException ex)
            {
                MessageBox.Show("请确保手机在题目界面" + "\r\n\r\n详情:\r\n" + ex.ToString(), "文本识别错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(APIException ex)
            {
                MessageBox.Show("请确保网络连接正常以及API可用" + "\r\n\r\n详情:\r\n" + ex.ToString(), "API错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(IndexOutOfRangeException ex)
            {
                MessageBox.Show("请确保手机在题目界面" + "\r\n\r\n详情:\r\n" + ex.ToString(), "解析错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(WebException ex)
            {
                MessageBox.Show("请确保网络环境良好" + "\r\n\r\n详情:\r\n" + ex.ToString(), "网络错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "未知错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                FinishSolveProblem();
            }
        }

        private void SolveProblem()
        {

            string screenShotPath;
            byte[] smallScreenShot;
            try
            {
                screenShotPath = ADB.GetScreenshotPath();
                smallScreenShot = BitmapOperation.CutImage(screenShotPath, new Point(CutX, CutY), new Size(CutWidth, CutHeight));
            }
            catch(Exception ex)
            {
                throw new ADBException("获取的屏幕截图无效!" + ex);
            }

            string recognizeResult = BaiDuOCR.Recognize(smallScreenShot);

            string[] recRes = Regex.Split(recognizeResult, "\r\n|\r|\n");

            CheckOCRResult(recRes);
            
            textBox_AnswerC.Text = recRes[recRes.Length - 2];
            textBox_AnswerB.Text = recRes[recRes.Length - 3];
            textBox_AnswerA.Text = recRes[recRes.Length - 4];

            string problem = recRes[0];

            int dotP = problem.IndexOf('.');
            if (dotP != -1)
            {
                problem = problem.Substring(dotP + 1, problem.Length - dotP - 1);
            }

            for (int i = 1; i < recRes.Length - 4; i++)
            {
                problem += recRes[i];
            }

            textBox_Problem.Text = problem;

            browserForm.Jump("http://www.baidu.com/s?wd=" + problem);

            char[] ans = new char[3] { 'A', 'B', 'C' };
            AnalyzeResult aRes = AnalyzeProblem.Analyze(textBox_Problem.Text, new string[] { textBox_AnswerA.Text, textBox_AnswerB.Text, textBox_AnswerC.Text });
            MessageBox.Show("最有可能选择" + ans[aRes.Index] + "项!");
        }

        private void CheckOCRResult(string[] arr)
        {
            if (arr.Length > 7)
            {
                throw new OCRException("识别到的文本过多");
            }
            else if (arr.Length > 0 && arr.Length < 4)
            {
                throw new OCRException("识别到的文本过少");
            }
            else if (arr.Length == 0)
            {
                throw new OCRException("没有识别到文本");
            }
        }
        private void FinishSolveProblem()
        {
            button_Config.Enabled = true;
            button_Start.Enabled = true;
            solveProblemThread = null;
        }
    }
}
