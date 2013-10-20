using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;

namespace WINfix
{
    partial class frmInfo : Form
    {
        public frmInfo()
        {
            InitializeComponent();
            this.Text = "WINfix || Information";
            this.labelProductName.Text = "WINfix";
            this.labelVersion.Text = String.Format("Version {0}", "1.0.0.0");
            this.textBoxDescription.Text = "This tool is designed to fix the current error, which occurs while updating Microsoft Windows 8 to Microsoft Windows 8.1 via Windows Store.";
        }

      
       

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabelHomepage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://deeavenue.com");
        }
    }
}
