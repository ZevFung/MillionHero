namespace MillionHerosHelper
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_AnalyzeProblem = new System.Windows.Forms.Button();
            this.textBox_Problem = new System.Windows.Forms.TextBox();
            this.label_Probelm = new System.Windows.Forms.Label();
            this.label_AnswerA = new System.Windows.Forms.Label();
            this.textBox_AnswerA = new System.Windows.Forms.TextBox();
            this.label_AnswerB = new System.Windows.Forms.Label();
            this.textBox_AnswerB = new System.Windows.Forms.TextBox();
            this.label_AnswerC = new System.Windows.Forms.Label();
            this.textBox_AnswerC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_RankA = new System.Windows.Forms.Label();
            this.label_RankB = new System.Windows.Forms.Label();
            this.label_RankC = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_AnalyzeProblem
            // 
            this.button_AnalyzeProblem.Location = new System.Drawing.Point(118, 360);
            this.button_AnalyzeProblem.Name = "button_AnalyzeProblem";
            this.button_AnalyzeProblem.Size = new System.Drawing.Size(124, 43);
            this.button_AnalyzeProblem.TabIndex = 0;
            this.button_AnalyzeProblem.Text = "分析题目";
            this.button_AnalyzeProblem.UseVisualStyleBackColor = true;
            this.button_AnalyzeProblem.Click += new System.EventHandler(this.button_AnalyzeProblem_Click);
            // 
            // textBox_Problem
            // 
            this.textBox_Problem.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBox_Problem.Location = new System.Drawing.Point(23, 42);
            this.textBox_Problem.Multiline = true;
            this.textBox_Problem.Name = "textBox_Problem";
            this.textBox_Problem.Size = new System.Drawing.Size(336, 99);
            this.textBox_Problem.TabIndex = 1;
            // 
            // label_Probelm
            // 
            this.label_Probelm.AutoSize = true;
            this.label_Probelm.Location = new System.Drawing.Point(147, 9);
            this.label_Probelm.Name = "label_Probelm";
            this.label_Probelm.Size = new System.Drawing.Size(71, 15);
            this.label_Probelm.TabIndex = 2;
            this.label_Probelm.Text = "Problem:";
            // 
            // label_AnswerA
            // 
            this.label_AnswerA.AutoSize = true;
            this.label_AnswerA.Location = new System.Drawing.Point(27, 154);
            this.label_AnswerA.Name = "label_AnswerA";
            this.label_AnswerA.Size = new System.Drawing.Size(63, 15);
            this.label_AnswerA.TabIndex = 3;
            this.label_AnswerA.Text = "AnswerA";
            // 
            // textBox_AnswerA
            // 
            this.textBox_AnswerA.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBox_AnswerA.Location = new System.Drawing.Point(23, 178);
            this.textBox_AnswerA.Name = "textBox_AnswerA";
            this.textBox_AnswerA.Size = new System.Drawing.Size(336, 25);
            this.textBox_AnswerA.TabIndex = 4;
            // 
            // label_AnswerB
            // 
            this.label_AnswerB.AutoSize = true;
            this.label_AnswerB.Location = new System.Drawing.Point(27, 220);
            this.label_AnswerB.Name = "label_AnswerB";
            this.label_AnswerB.Size = new System.Drawing.Size(63, 15);
            this.label_AnswerB.TabIndex = 5;
            this.label_AnswerB.Text = "AnswerB";
            // 
            // textBox_AnswerB
            // 
            this.textBox_AnswerB.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBox_AnswerB.Location = new System.Drawing.Point(22, 247);
            this.textBox_AnswerB.Name = "textBox_AnswerB";
            this.textBox_AnswerB.Size = new System.Drawing.Size(337, 25);
            this.textBox_AnswerB.TabIndex = 6;
            // 
            // label_AnswerC
            // 
            this.label_AnswerC.AutoSize = true;
            this.label_AnswerC.Location = new System.Drawing.Point(27, 292);
            this.label_AnswerC.Name = "label_AnswerC";
            this.label_AnswerC.Size = new System.Drawing.Size(63, 15);
            this.label_AnswerC.TabIndex = 7;
            this.label_AnswerC.Text = "AnswerC";
            // 
            // textBox_AnswerC
            // 
            this.textBox_AnswerC.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBox_AnswerC.Location = new System.Drawing.Point(23, 320);
            this.textBox_AnswerC.Name = "textBox_AnswerC";
            this.textBox_AnswerC.Size = new System.Drawing.Size(336, 25);
            this.textBox_AnswerC.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 428);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "原理:基于PMI与出现次数(百度)共同求权值";
            // 
            // label_RankA
            // 
            this.label_RankA.AutoSize = true;
            this.label_RankA.Location = new System.Drawing.Point(115, 154);
            this.label_RankA.Name = "label_RankA";
            this.label_RankA.Size = new System.Drawing.Size(0, 15);
            this.label_RankA.TabIndex = 10;
            // 
            // label_RankB
            // 
            this.label_RankB.AutoSize = true;
            this.label_RankB.Location = new System.Drawing.Point(115, 220);
            this.label_RankB.Name = "label_RankB";
            this.label_RankB.Size = new System.Drawing.Size(0, 15);
            this.label_RankB.TabIndex = 11;
            // 
            // label_RankC
            // 
            this.label_RankC.AutoSize = true;
            this.label_RankC.Location = new System.Drawing.Point(115, 292);
            this.label_RankC.Name = "label_RankC";
            this.label_RankC.Size = new System.Drawing.Size(0, 15);
            this.label_RankC.TabIndex = 12;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 461);
            this.Controls.Add(this.label_RankC);
            this.Controls.Add(this.label_RankB);
            this.Controls.Add(this.label_RankA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_AnswerC);
            this.Controls.Add(this.label_AnswerC);
            this.Controls.Add(this.textBox_AnswerB);
            this.Controls.Add(this.label_AnswerB);
            this.Controls.Add(this.textBox_AnswerA);
            this.Controls.Add(this.label_AnswerA);
            this.Controls.Add(this.label_Probelm);
            this.Controls.Add(this.textBox_Problem);
            this.Controls.Add(this.button_AnalyzeProblem);
            this.Name = "MainForm";
            this.Text = "百万英雄搜题部分演示";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_AnalyzeProblem;
        private System.Windows.Forms.TextBox textBox_Problem;
        private System.Windows.Forms.Label label_Probelm;
        private System.Windows.Forms.Label label_AnswerA;
        private System.Windows.Forms.TextBox textBox_AnswerA;
        private System.Windows.Forms.Label label_AnswerB;
        private System.Windows.Forms.TextBox textBox_AnswerB;
        private System.Windows.Forms.Label label_AnswerC;
        private System.Windows.Forms.TextBox textBox_AnswerC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_RankA;
        private System.Windows.Forms.Label label_RankB;
        private System.Windows.Forms.Label label_RankC;
    }
}

