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

namespace MillionHerosHelper
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ServicePointManager.MaxServicePoints = 512;
            ServicePointManager.DefaultConnectionLimit = 512;
        }

        private void button_AnalyzeProblem_Click(object sender, EventArgs e)
        {
            AnalyzeResult ar = AnalyzeProblem.Analyze(textBox_Problem.Text, new string[3] { textBox_AnswerA.Text, textBox_AnswerB.Text, textBox_AnswerC.Text });

            Debug.WriteLine(ar.PMIRank[0] + "  " + ar.PMIRank[1] + "  " + ar.PMIRank[2]);
            Debug.WriteLine(ar.CntRank[0] + "  " + ar.CntRank[1] + "  " + ar.CntRank[2]);

            label_RankA.Text = "Rank:" + ar.SumRank[0].ToString();
            label_RankB.Text = "Rank:" + ar.SumRank[1].ToString();
            label_RankC.Text = "Rank:" + ar.SumRank[2].ToString();
            char[] ans = new char[3] { 'A', 'B', 'C' };
            MessageBox.Show("最有可能选择" + ans[ar.Index] + "项!");
        }
    }
}
