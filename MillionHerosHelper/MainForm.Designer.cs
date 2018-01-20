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
            this.label_RankA = new System.Windows.Forms.Label();
            this.label_RankB = new System.Windows.Forms.Label();
            this.label_RankC = new System.Windows.Forms.Label();
            this.button_Config = new System.Windows.Forms.Button();
            this.button_Start = new System.Windows.Forms.Button();
            this.label_Problem = new System.Windows.Forms.Label();
            this.label_AnswerA = new System.Windows.Forms.Label();
            this.label_AnswerB = new System.Windows.Forms.Label();
            this.label_AnswerC = new System.Windows.Forms.Label();
            this.textBox_Problem = new System.Windows.Forms.TextBox();
            this.textBox_AnswerA = new System.Windows.Forms.TextBox();
            this.textBox_AnswerB = new System.Windows.Forms.TextBox();
            this.textBox_AnswerC = new System.Windows.Forms.TextBox();
            this.label_Message = new System.Windows.Forms.Label();
            this.label_AnalyzeA = new System.Windows.Forms.Label();
            this.label_AnalyzeB = new System.Windows.Forms.Label();
            this.label_AnalyzeC = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            // button_Config
            // 
            this.button_Config.Location = new System.Drawing.Point(26, 23);
            this.button_Config.Name = "button_Config";
            this.button_Config.Size = new System.Drawing.Size(89, 35);
            this.button_Config.TabIndex = 13;
            this.button_Config.Text = "配置向导";
            this.button_Config.UseVisualStyleBackColor = true;
            this.button_Config.Click += new System.EventHandler(this.button_Config_Click);
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(183, 12);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(124, 56);
            this.button_Start.TabIndex = 14;
            this.button_Start.Text = "开始答题";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // label_Problem
            // 
            this.label_Problem.AutoSize = true;
            this.label_Problem.Location = new System.Drawing.Point(23, 90);
            this.label_Problem.Name = "label_Problem";
            this.label_Problem.Size = new System.Drawing.Size(45, 15);
            this.label_Problem.TabIndex = 15;
            this.label_Problem.Text = "问题:";
            // 
            // label_AnswerA
            // 
            this.label_AnswerA.AutoSize = true;
            this.label_AnswerA.Location = new System.Drawing.Point(23, 187);
            this.label_AnswerA.Name = "label_AnswerA";
            this.label_AnswerA.Size = new System.Drawing.Size(53, 15);
            this.label_AnswerA.TabIndex = 16;
            this.label_AnswerA.Text = "选项A:";
            // 
            // label_AnswerB
            // 
            this.label_AnswerB.AutoSize = true;
            this.label_AnswerB.Location = new System.Drawing.Point(23, 278);
            this.label_AnswerB.Name = "label_AnswerB";
            this.label_AnswerB.Size = new System.Drawing.Size(53, 15);
            this.label_AnswerB.TabIndex = 17;
            this.label_AnswerB.Text = "选项B:";
            // 
            // label_AnswerC
            // 
            this.label_AnswerC.AutoSize = true;
            this.label_AnswerC.Location = new System.Drawing.Point(23, 379);
            this.label_AnswerC.Name = "label_AnswerC";
            this.label_AnswerC.Size = new System.Drawing.Size(45, 15);
            this.label_AnswerC.TabIndex = 18;
            this.label_AnswerC.Text = "选项C";
            // 
            // textBox_Problem
            // 
            this.textBox_Problem.Font = new System.Drawing.Font("宋体", 11F);
            this.textBox_Problem.Location = new System.Drawing.Point(93, 87);
            this.textBox_Problem.Multiline = true;
            this.textBox_Problem.Name = "textBox_Problem";
            this.textBox_Problem.ReadOnly = true;
            this.textBox_Problem.Size = new System.Drawing.Size(368, 81);
            this.textBox_Problem.TabIndex = 19;
            // 
            // textBox_AnswerA
            // 
            this.textBox_AnswerA.Font = new System.Drawing.Font("宋体", 13F);
            this.textBox_AnswerA.Location = new System.Drawing.Point(27, 221);
            this.textBox_AnswerA.Name = "textBox_AnswerA";
            this.textBox_AnswerA.ReadOnly = true;
            this.textBox_AnswerA.Size = new System.Drawing.Size(439, 32);
            this.textBox_AnswerA.TabIndex = 20;
            // 
            // textBox_AnswerB
            // 
            this.textBox_AnswerB.Font = new System.Drawing.Font("宋体", 13F);
            this.textBox_AnswerB.Location = new System.Drawing.Point(26, 320);
            this.textBox_AnswerB.Name = "textBox_AnswerB";
            this.textBox_AnswerB.ReadOnly = true;
            this.textBox_AnswerB.Size = new System.Drawing.Size(440, 32);
            this.textBox_AnswerB.TabIndex = 21;
            // 
            // textBox_AnswerC
            // 
            this.textBox_AnswerC.Font = new System.Drawing.Font("宋体", 13F);
            this.textBox_AnswerC.Location = new System.Drawing.Point(26, 416);
            this.textBox_AnswerC.Name = "textBox_AnswerC";
            this.textBox_AnswerC.ReadOnly = true;
            this.textBox_AnswerC.Size = new System.Drawing.Size(440, 32);
            this.textBox_AnswerC.TabIndex = 22;
            // 
            // label_Message
            // 
            this.label_Message.AutoSize = true;
            this.label_Message.Font = new System.Drawing.Font("宋体", 15F);
            this.label_Message.Location = new System.Drawing.Point(21, 478);
            this.label_Message.Name = "label_Message";
            this.label_Message.Size = new System.Drawing.Size(450, 25);
            this.label_Message.TabIndex = 23;
            this.label_Message.Text = "答题之前记得点击配置向导进行配置哦!";
            // 
            // label_AnalyzeA
            // 
            this.label_AnalyzeA.AutoSize = true;
            this.label_AnalyzeA.Font = new System.Drawing.Font("宋体", 10F);
            this.label_AnalyzeA.ForeColor = System.Drawing.Color.DarkGreen;
            this.label_AnalyzeA.Location = new System.Drawing.Point(315, 185);
            this.label_AnalyzeA.Name = "label_AnalyzeA";
            this.label_AnalyzeA.Size = new System.Drawing.Size(0, 17);
            this.label_AnalyzeA.TabIndex = 24;
            // 
            // label_AnalyzeB
            // 
            this.label_AnalyzeB.AutoSize = true;
            this.label_AnalyzeB.Font = new System.Drawing.Font("宋体", 10F);
            this.label_AnalyzeB.ForeColor = System.Drawing.Color.DarkGreen;
            this.label_AnalyzeB.Location = new System.Drawing.Point(315, 276);
            this.label_AnalyzeB.Name = "label_AnalyzeB";
            this.label_AnalyzeB.Size = new System.Drawing.Size(0, 17);
            this.label_AnalyzeB.TabIndex = 25;
            // 
            // label_AnalyzeC
            // 
            this.label_AnalyzeC.AutoSize = true;
            this.label_AnalyzeC.Font = new System.Drawing.Font("宋体", 10F);
            this.label_AnalyzeC.ForeColor = System.Drawing.Color.DarkGreen;
            this.label_AnalyzeC.Location = new System.Drawing.Point(315, 377);
            this.label_AnalyzeC.Name = "label_AnalyzeC";
            this.label_AnalyzeC.Size = new System.Drawing.Size(0, 17);
            this.label_AnalyzeC.TabIndex = 26;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 519);
            this.Controls.Add(this.label_AnalyzeC);
            this.Controls.Add(this.label_AnalyzeB);
            this.Controls.Add(this.label_AnalyzeA);
            this.Controls.Add(this.label_Message);
            this.Controls.Add(this.textBox_AnswerC);
            this.Controls.Add(this.textBox_AnswerB);
            this.Controls.Add(this.textBox_AnswerA);
            this.Controls.Add(this.textBox_Problem);
            this.Controls.Add(this.label_AnswerC);
            this.Controls.Add(this.label_AnswerB);
            this.Controls.Add(this.label_AnswerA);
            this.Controls.Add(this.label_Problem);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.button_Config);
            this.Controls.Add(this.label_RankC);
            this.Controls.Add(this.label_RankB);
            this.Controls.Add(this.label_RankA);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "百万英雄超级答题助手";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Move += new System.EventHandler(this.MainForm_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_RankA;
        private System.Windows.Forms.Label label_RankB;
        private System.Windows.Forms.Label label_RankC;
        private System.Windows.Forms.Button button_Config;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Label label_Problem;
        private System.Windows.Forms.Label label_AnswerA;
        private System.Windows.Forms.Label label_AnswerB;
        private System.Windows.Forms.Label label_AnswerC;
        private System.Windows.Forms.TextBox textBox_Problem;
        private System.Windows.Forms.TextBox textBox_AnswerA;
        private System.Windows.Forms.TextBox textBox_AnswerB;
        private System.Windows.Forms.TextBox textBox_AnswerC;
        private System.Windows.Forms.Label label_Message;
        private System.Windows.Forms.Label label_AnalyzeA;
        private System.Windows.Forms.Label label_AnalyzeB;
        private System.Windows.Forms.Label label_AnalyzeC;
    }
}

