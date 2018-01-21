namespace MillionHerosHelper
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_CheckConnect = new System.Windows.Forms.Button();
            this.label_Step1 = new System.Windows.Forms.Label();
            this.label_ConnectStatus = new System.Windows.Forms.Label();
            this.button_HowToConnect = new System.Windows.Forms.Button();
            this.label_Setp2 = new System.Windows.Forms.Label();
            this.pictureBox_ScreenShot = new System.Windows.Forms.PictureBox();
            this.button_GetScreenShort = new System.Windows.Forms.Button();
            this.label_X = new System.Windows.Forms.Label();
            this.label_Y = new System.Windows.Forms.Label();
            this.textBox_X = new System.Windows.Forms.TextBox();
            this.textBox_Y = new System.Windows.Forms.TextBox();
            this.label_Height = new System.Windows.Forms.Label();
            this.label_Width = new System.Windows.Forms.Label();
            this.textBox_Height = new System.Windows.Forms.TextBox();
            this.textBox_Width = new System.Windows.Forms.TextBox();
            this.button_SaveConfig = new System.Windows.Forms.Button();
            this.label_OCR = new System.Windows.Forms.Label();
            this.linkLabel_Apply = new System.Windows.Forms.LinkLabel();
            this.textBox_API_KEY = new System.Windows.Forms.TextBox();
            this.label_API_KEY = new System.Windows.Forms.Label();
            this.label_SECRET_KEY = new System.Windows.Forms.Label();
            this.textBox_SECRET_KEY = new System.Windows.Forms.TextBox();
            this.checkBox_Emulator = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ScreenShot)).BeginInit();
            this.SuspendLayout();
            // 
            // button_CheckConnect
            // 
            this.button_CheckConnect.Location = new System.Drawing.Point(265, 69);
            this.button_CheckConnect.Name = "button_CheckConnect";
            this.button_CheckConnect.Size = new System.Drawing.Size(135, 30);
            this.button_CheckConnect.TabIndex = 0;
            this.button_CheckConnect.Text = "检查连接";
            this.button_CheckConnect.UseVisualStyleBackColor = true;
            this.button_CheckConnect.Click += new System.EventHandler(this.button_CheckConnect_Click);
            // 
            // label_Step1
            // 
            this.label_Step1.AutoSize = true;
            this.label_Step1.ForeColor = System.Drawing.Color.Black;
            this.label_Step1.Location = new System.Drawing.Point(30, 20);
            this.label_Step1.Name = "label_Step1";
            this.label_Step1.Size = new System.Drawing.Size(250, 15);
            this.label_Step1.TabIndex = 1;
            this.label_Step1.Text = "1.检查手机连接状态,请打开USB调试";
            // 
            // label_ConnectStatus
            // 
            this.label_ConnectStatus.AutoSize = true;
            this.label_ConnectStatus.Font = new System.Drawing.Font("宋体", 11F);
            this.label_ConnectStatus.ForeColor = System.Drawing.Color.Orange;
            this.label_ConnectStatus.Location = new System.Drawing.Point(100, 75);
            this.label_ConnectStatus.Name = "label_ConnectStatus";
            this.label_ConnectStatus.Size = new System.Drawing.Size(114, 19);
            this.label_ConnectStatus.TabIndex = 2;
            this.label_ConnectStatus.Text = "状态:未检测";
            // 
            // button_HowToConnect
            // 
            this.button_HowToConnect.Location = new System.Drawing.Point(305, 10);
            this.button_HowToConnect.Name = "button_HowToConnect";
            this.button_HowToConnect.Size = new System.Drawing.Size(135, 35);
            this.button_HowToConnect.TabIndex = 3;
            this.button_HowToConnect.Text = "如何连接?";
            this.button_HowToConnect.UseVisualStyleBackColor = true;
            this.button_HowToConnect.Click += new System.EventHandler(this.button_HowToConnect_Click);
            // 
            // label_Setp2
            // 
            this.label_Setp2.AutoSize = true;
            this.label_Setp2.Location = new System.Drawing.Point(30, 122);
            this.label_Setp2.Name = "label_Setp2";
            this.label_Setp2.Size = new System.Drawing.Size(286, 15);
            this.label_Setp2.TabIndex = 4;
            this.label_Setp2.Text = "2.设置截图范围,使其刚好截取到题目部分";
            // 
            // pictureBox_ScreenShot
            // 
            this.pictureBox_ScreenShot.Location = new System.Drawing.Point(33, 156);
            this.pictureBox_ScreenShot.Name = "pictureBox_ScreenShot";
            this.pictureBox_ScreenShot.Size = new System.Drawing.Size(280, 260);
            this.pictureBox_ScreenShot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_ScreenShot.TabIndex = 5;
            this.pictureBox_ScreenShot.TabStop = false;
            // 
            // button_GetScreenShort
            // 
            this.button_GetScreenShort.Location = new System.Drawing.Point(341, 382);
            this.button_GetScreenShort.Name = "button_GetScreenShort";
            this.button_GetScreenShort.Size = new System.Drawing.Size(107, 34);
            this.button_GetScreenShort.TabIndex = 6;
            this.button_GetScreenShort.Text = "获取截图";
            this.button_GetScreenShort.UseVisualStyleBackColor = true;
            this.button_GetScreenShort.Click += new System.EventHandler(this.button_GetScreenShort_Click);
            // 
            // label_X
            // 
            this.label_X.AutoSize = true;
            this.label_X.Location = new System.Drawing.Point(355, 153);
            this.label_X.Name = "label_X";
            this.label_X.Size = new System.Drawing.Size(75, 15);
            this.label_X.TabIndex = 7;
            this.label_X.Text = "起点X坐标";
            // 
            // label_Y
            // 
            this.label_Y.AutoSize = true;
            this.label_Y.Location = new System.Drawing.Point(355, 211);
            this.label_Y.Name = "label_Y";
            this.label_Y.Size = new System.Drawing.Size(75, 15);
            this.label_Y.TabIndex = 8;
            this.label_Y.Text = "起点Y坐标";
            // 
            // textBox_X
            // 
            this.textBox_X.Location = new System.Drawing.Point(344, 177);
            this.textBox_X.Name = "textBox_X";
            this.textBox_X.Size = new System.Drawing.Size(100, 25);
            this.textBox_X.TabIndex = 9;
            this.textBox_X.Text = "80";
            // 
            // textBox_Y
            // 
            this.textBox_Y.Location = new System.Drawing.Point(344, 234);
            this.textBox_Y.Name = "textBox_Y";
            this.textBox_Y.Size = new System.Drawing.Size(100, 25);
            this.textBox_Y.TabIndex = 10;
            this.textBox_Y.Text = "250";
            // 
            // label_Height
            // 
            this.label_Height.AutoSize = true;
            this.label_Height.Location = new System.Drawing.Point(375, 267);
            this.label_Height.Name = "label_Height";
            this.label_Height.Size = new System.Drawing.Size(37, 15);
            this.label_Height.TabIndex = 11;
            this.label_Height.Text = "高度";
            // 
            // label_Width
            // 
            this.label_Width.AutoSize = true;
            this.label_Width.Location = new System.Drawing.Point(375, 326);
            this.label_Width.Name = "label_Width";
            this.label_Width.Size = new System.Drawing.Size(37, 15);
            this.label_Width.TabIndex = 12;
            this.label_Width.Text = "宽度";
            // 
            // textBox_Height
            // 
            this.textBox_Height.Location = new System.Drawing.Point(344, 290);
            this.textBox_Height.Name = "textBox_Height";
            this.textBox_Height.Size = new System.Drawing.Size(100, 25);
            this.textBox_Height.TabIndex = 13;
            this.textBox_Height.Text = "1000";
            // 
            // textBox_Width
            // 
            this.textBox_Width.Location = new System.Drawing.Point(344, 347);
            this.textBox_Width.Name = "textBox_Width";
            this.textBox_Width.Size = new System.Drawing.Size(100, 25);
            this.textBox_Width.TabIndex = 14;
            this.textBox_Width.Text = "900";
            // 
            // button_SaveConfig
            // 
            this.button_SaveConfig.Location = new System.Drawing.Point(169, 559);
            this.button_SaveConfig.Name = "button_SaveConfig";
            this.button_SaveConfig.Size = new System.Drawing.Size(120, 35);
            this.button_SaveConfig.TabIndex = 15;
            this.button_SaveConfig.Text = "保存设置";
            this.button_SaveConfig.UseVisualStyleBackColor = true;
            this.button_SaveConfig.Click += new System.EventHandler(this.button_SaveConfig_Click);
            // 
            // label_OCR
            // 
            this.label_OCR.AutoSize = true;
            this.label_OCR.Location = new System.Drawing.Point(33, 433);
            this.label_OCR.Name = "label_OCR";
            this.label_OCR.Size = new System.Drawing.Size(139, 15);
            this.label_OCR.TabIndex = 16;
            this.label_OCR.Text = "3.百度OCR API信息";
            // 
            // linkLabel_Apply
            // 
            this.linkLabel_Apply.AutoSize = true;
            this.linkLabel_Apply.Location = new System.Drawing.Point(361, 433);
            this.linkLabel_Apply.Name = "linkLabel_Apply";
            this.linkLabel_Apply.Size = new System.Drawing.Size(67, 15);
            this.linkLabel_Apply.TabIndex = 17;
            this.linkLabel_Apply.TabStop = true;
            this.linkLabel_Apply.Text = "点我申请";
            this.linkLabel_Apply.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_Apply_LinkClicked);
            // 
            // textBox_API_KEY
            // 
            this.textBox_API_KEY.Location = new System.Drawing.Point(139, 463);
            this.textBox_API_KEY.Name = "textBox_API_KEY";
            this.textBox_API_KEY.Size = new System.Drawing.Size(305, 25);
            this.textBox_API_KEY.TabIndex = 18;
            // 
            // label_API_KEY
            // 
            this.label_API_KEY.AutoSize = true;
            this.label_API_KEY.Location = new System.Drawing.Point(33, 468);
            this.label_API_KEY.Name = "label_API_KEY";
            this.label_API_KEY.Size = new System.Drawing.Size(71, 15);
            this.label_API_KEY.TabIndex = 19;
            this.label_API_KEY.Text = "API_KEY:";
            // 
            // label_SECRET_KEY
            // 
            this.label_SECRET_KEY.AutoSize = true;
            this.label_SECRET_KEY.Location = new System.Drawing.Point(30, 511);
            this.label_SECRET_KEY.Name = "label_SECRET_KEY";
            this.label_SECRET_KEY.Size = new System.Drawing.Size(95, 15);
            this.label_SECRET_KEY.TabIndex = 20;
            this.label_SECRET_KEY.Text = "SECRET_KEY:";
            // 
            // textBox_SECRET_KEY
            // 
            this.textBox_SECRET_KEY.Location = new System.Drawing.Point(139, 504);
            this.textBox_SECRET_KEY.Name = "textBox_SECRET_KEY";
            this.textBox_SECRET_KEY.Size = new System.Drawing.Size(305, 25);
            this.textBox_SECRET_KEY.TabIndex = 21;
            // 
            // checkBox_Emulator
            // 
            this.checkBox_Emulator.AutoSize = true;
            this.checkBox_Emulator.Location = new System.Drawing.Point(326, 121);
            this.checkBox_Emulator.Name = "checkBox_Emulator";
            this.checkBox_Emulator.Size = new System.Drawing.Size(134, 19);
            this.checkBox_Emulator.TabIndex = 22;
            this.checkBox_Emulator.Text = "使用安卓模拟器";
            this.checkBox_Emulator.UseVisualStyleBackColor = true;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 606);
            this.Controls.Add(this.checkBox_Emulator);
            this.Controls.Add(this.textBox_SECRET_KEY);
            this.Controls.Add(this.label_SECRET_KEY);
            this.Controls.Add(this.label_API_KEY);
            this.Controls.Add(this.textBox_API_KEY);
            this.Controls.Add(this.linkLabel_Apply);
            this.Controls.Add(this.label_OCR);
            this.Controls.Add(this.button_SaveConfig);
            this.Controls.Add(this.textBox_Width);
            this.Controls.Add(this.textBox_Height);
            this.Controls.Add(this.label_Width);
            this.Controls.Add(this.label_Height);
            this.Controls.Add(this.textBox_Y);
            this.Controls.Add(this.textBox_X);
            this.Controls.Add(this.label_Y);
            this.Controls.Add(this.label_X);
            this.Controls.Add(this.button_GetScreenShort);
            this.Controls.Add(this.pictureBox_ScreenShot);
            this.Controls.Add(this.label_Setp2);
            this.Controls.Add(this.button_HowToConnect);
            this.Controls.Add(this.label_ConnectStatus);
            this.Controls.Add(this.label_Step1);
            this.Controls.Add(this.button_CheckConnect);
            this.Name = "ConfigForm";
            this.Text = "配置引导";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ScreenShot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_CheckConnect;
        private System.Windows.Forms.Label label_Step1;
        private System.Windows.Forms.Label label_ConnectStatus;
        private System.Windows.Forms.Button button_HowToConnect;
        private System.Windows.Forms.Label label_Setp2;
        private System.Windows.Forms.PictureBox pictureBox_ScreenShot;
        private System.Windows.Forms.Button button_GetScreenShort;
        private System.Windows.Forms.Label label_X;
        private System.Windows.Forms.Label label_Y;
        private System.Windows.Forms.TextBox textBox_X;
        private System.Windows.Forms.TextBox textBox_Y;
        private System.Windows.Forms.Label label_Height;
        private System.Windows.Forms.Label label_Width;
        private System.Windows.Forms.TextBox textBox_Height;
        private System.Windows.Forms.TextBox textBox_Width;
        private System.Windows.Forms.Button button_SaveConfig;
        private System.Windows.Forms.Label label_OCR;
        private System.Windows.Forms.LinkLabel linkLabel_Apply;
        private System.Windows.Forms.TextBox textBox_API_KEY;
        private System.Windows.Forms.Label label_API_KEY;
        private System.Windows.Forms.Label label_SECRET_KEY;
        private System.Windows.Forms.TextBox textBox_SECRET_KEY;
        private System.Windows.Forms.CheckBox checkBox_Emulator;
    }
}