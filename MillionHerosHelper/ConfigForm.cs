using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace MillionHerosHelper
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {

        }

        private void button_HowToConnect_Click(object sender, EventArgs e)
        {
            const string msg =
                "1.安装手机对应的驱动程序(百度 手机型号+驱动)" + "\r\n\r\n" +
                "2.在安卓手机中进行如下操作:" + "\r\n" +
                "  点击 设置-关于手机-版本号(点击5次)" + "\r\n" +
                "  回退到设置界面-点击开发者选项-勾选USB调试" + "\r\n\r\n" +
                "3.使用数据线连接上电脑,点击检查连接,OK";
            MessageBox.Show(msg, "步骤", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_CheckConnect_Click(object sender, EventArgs e)
        {
            if (ADB.CheckConnect())
            {
                label_ConnectStatus.Text = "连接成功";
                label_ConnectStatus.ForeColor = Color.Green;
            }
            else
            {
                label_ConnectStatus.Text = "未连接";
                label_ConnectStatus.ForeColor = Color.Red;
            }
        }

        private void button_GetScreenShort_Click(object sender, EventArgs e)
        {
            int x = 0, y = 0, width = 2, height = 2;
            try
            {
                x = int.Parse(textBox_X.Text);
                y = int.Parse(textBox_Y.Text);
                width = int.Parse(textBox_Width.Text);
                height = int.Parse(textBox_Height.Text);
            }
            catch
            {
                MessageBox.Show("截图信息格式不正确,必须为数字");
                return;
            }


            if (!ADB.CheckConnect()) 
            {
                label_ConnectStatus.Text = "未连接";
                label_ConnectStatus.ForeColor = Color.Red;
                MessageBox.Show("连接手机失败,请按照步骤1配置!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string screenShotPath = ADB.GetScreenshotPath();
            byte[] screenShot = BitmapOperation.CutImage(screenShotPath, new Point(x, y), new Size(width, height));
            MemoryStream memoryStream = new MemoryStream(screenShot);
            pictureBox_ScreenShot.Image = Image.FromStream(memoryStream);
            memoryStream.Close();
        }

        private void button_SaveConfig_Click(object sender, EventArgs e)
        {
            int x = 0, y = 0, width = 2, height = 2;
            try
            {
                x = int.Parse(textBox_X.Text);
                y = int.Parse(textBox_Y.Text);
                width = int.Parse(textBox_Width.Text);
                height = int.Parse(textBox_Height.Text);
            }
            catch
            {
                MessageBox.Show("截图信息格式不正确,必须为数字");
                return;
            }

            MainForm.CutX = x;
            MainForm.CutY = y;
            MainForm.CutHeight = height;
            MainForm.CutWidth = width;

            BaiDuOCR.InitBaiDuOCR(textBox_API_KEY.Text, textBox_SECRET_KEY.Text);
        }

        private void linkLabel_Apply_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://cloud.baidu.com/product/ocr/general");
        }
    }
}
