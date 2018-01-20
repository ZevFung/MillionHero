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

namespace MillionHerosHelper
{
    public partial class MainForm : Form
    {
        public static int CutX { get; set; }
        public static int CutY { get; set; }
        public static int CutHeight { get; set; }
        public static int CutWidth { get; set; }

        private ConfigForm configForm;
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ServicePointManager.MaxServicePoints = 512;
            ServicePointManager.DefaultConnectionLimit = 512;
            Control.CheckForIllegalCrossThreadCalls = false;

            CutX = 80;
            CutY = 250;
            CutHeight = 1000;
            CutWidth = 900;

            BaiDuOCR.InitBaiDuOCR("0kEPZddCBO5cUD0Lf1yTN91O", "fEkXWR4CINttqCQVAQejX5cXgQKrVbnW");
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
            backgroundWorker_Main.RunWorkerAsync();
        }

        private void backgroundWorker_Main_DoWork(object sender, DoWorkEventArgs e)
        {
            string screenShotPath = ADB.GetScreenshotPath();

            byte[] smallScreenShot = BitmapOperation.CutImage(screenShotPath, new Point(CutX, CutY), new Size(CutWidth, CutHeight));
            string recognizeResult = BaiDuOCR.Recognize(smallScreenShot);

            string[] recRes = Regex.Split(recognizeResult, "\r\n|\r|\n");

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

            char[] ans = new char[3] { 'A', 'B', 'C' };
            AnalyzeResult aRes = AnalyzeProblem.Analyze(textBox_Problem.Text, new string[] { textBox_AnswerA.Text, textBox_AnswerB.Text, textBox_AnswerC.Text });
            MessageBox.Show("最有可能选择" + ans[aRes.Index] + "项!");
        }
    }
}
