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

            Config.LoadConfig();

            BaiDuOCR.InitBaiDuOCR(Config.OCR_API_KEY, Config.OCR_SECRET_KEY);
            browserForm = new BrowserForm();
            
            browserForm.Show();
            MainForm_Move(null, null);
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
                else if (timeUsed > 15000)
                {
                    //solveProblemThread.Abort();
                    FinishSolveProblem();
                    label_Message.Text = "题目分析超时";
                    label_Message.ForeColor = Color.Red;
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
                label_Message.Text = "手机连接出错";
                label_Message.ForeColor = Color.Red;
                MessageBox.Show("请确保已连接手机并配置正确" + "\r\n\r\n详情:\r\n" + ex.ToString(), "ADB手机连接错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(OCRException ex)
            {
                label_Message.Text = "题目识别出错";
                label_Message.ForeColor = Color.Red;
                MessageBox.Show("请确保手机在题目界面" + "\r\n\r\n详情:\r\n" + ex.ToString(), "文本识别错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(APIException ex)
            {
                label_Message.Text = "网络连接出错";
                label_Message.ForeColor = Color.Red;
                MessageBox.Show("请确保网络连接正常以及API可用" + "\r\n\r\n详情:\r\n" + ex.ToString(), "API错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(IndexOutOfRangeException ex)
            {
                label_Message.Text = "题目识别出错";
                label_Message.ForeColor = Color.Red;
                MessageBox.Show("请确保手机在题目界面" + "\r\n\r\n详情:\r\n" + ex.ToString(), "解析错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(WebException ex)
            {
                label_Message.Text = "网络连接出错";
                label_Message.ForeColor = Color.Red;
                MessageBox.Show("请确保网络环境良好" + "\r\n\r\n详情:\r\n" + ex.ToString(), "网络错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                label_Message.Text = "未知错误";
                label_Message.ForeColor = Color.Red;
                MessageBox.Show(ex.ToString(), "未知错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                FinishSolveProblem();
            }
        }

        private void SolveProblem()
        {
            label_Message.Text = "正在获取手机界面";
            label_Message.ForeColor = Color.Orange;
            //获取屏幕截图
            string screenShotPath;
            byte[] smallScreenShot;
            try
            {
                if(Config.UseEmulator)//是否为模拟器
                {
                    smallScreenShot = BitmapOperation.CutScreen(new Point(Config.CutX, Config.CutY), new Size(Config.CutWidth, Config.CutHeight));
                }
                else
                {
                    screenShotPath = ADB.GetScreenshotPath();
                    smallScreenShot = BitmapOperation.CutImage(screenShotPath, new Point(Config.CutX, Config.CutY), new Size(Config.CutWidth, Config.CutHeight));
                    System.IO.File.Delete(screenShotPath);
                }
            }
            catch(Exception ex)
            {
                throw new ADBException("获取的屏幕截图无效!" + ex);
            }

            label_Message.Text = "正在识别题目信息";
            //调用API识别文字
            string recognizeResult = BaiDuOCR.Recognize(smallScreenShot);


            string[] recRes = Regex.Split(recognizeResult, "\r\n|\r|\n");
            //检查识别结果正确性
            CheckOCRResult(recRes);
            //显示识别结果
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
            
            //浏览器跳转到搜索页面
            browserForm.Jump("http://www.baidu.com/s?wd=" + problem);
            browserForm.Show();
            browserForm.WindowState = FormWindowState.Normal;

            label_Message.Text = "正在分析题目";
            //分析问题
            AnalyzeResult aRes = AnalyzeProblem.Analyze(textBox_Problem.Text, new string[] { textBox_AnswerA.Text, textBox_AnswerB.Text, textBox_AnswerC.Text });
            char[] ans = new char[3] { 'A', 'B', 'C' };
            label_Message.Text = "最有可能选择:" + ans[aRes.Index] + "项!";
            if(aRes.Oppose)
            {
                label_Message.Text += "(包含否定词)";
            }

            label_Message.ForeColor = Color.Green;

            //显示概率
            label_AnalyzeA.Text = "概率:" + aRes.Probability[0].ToString() + "%";
            label_AnalyzeB.Text = "概率:" + aRes.Probability[1].ToString() + "%";
            label_AnalyzeC.Text = "概率:" + aRes.Probability[2].ToString() + "%";
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

        private void MainForm_Move(object sender, EventArgs e)
        {
            if (browserForm != null && !browserForm.IsDisposed) 
            {
                browserForm.Location = new Point(this.Location.X + this.Width + 10, browserForm.Location.Y);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.SaveConfig();
        }

        private void linkLabel_Author_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Azure99");
        }

        private void linkLabel_SourceCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Azure99/MillionHerosHelper");
        }
    }
}
