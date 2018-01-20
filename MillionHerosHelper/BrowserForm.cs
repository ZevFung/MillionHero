using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MillionHerosHelper
{
    public partial class BrowserForm : Form
    {
        public BrowserForm()
        {
            InitializeComponent();
        }

        private void BrowserForm_Load(object sender, EventArgs e)
        {

        }

        public void Jump(string url)
        {
            webBrowser_Main.Url = new Uri(url);
        }

        private void BrowserForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
