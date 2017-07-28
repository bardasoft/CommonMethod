using CommonMethod;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace CommonMethod_Winform_Use
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnLogWrite_Click(object sender, EventArgs e)
        {
            string strTest = "Test";
            CommonMethod.LogWrite.WriteEventLog("tETS", strTest);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + "\\CommonMethod_Winform_Use1.exe","test");
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            textBox1.SetWatermark("Test");
            

        }

        private void btnPing_Click(object sender, EventArgs e)
        {
            if (Common.CmdPing(IPAddress.Parse(txtIP.Text)))
            {
                MessageBox.Show("Ping Success");
            }
            else
            {
                MessageBox.Show("Ping Fault");
            }

        }

        private void btnTelnet_Click(object sender, EventArgs e)
        {
            if (Common.CmdTelnet(IPAddress.Parse(txtIP.Text),int.Parse(txtPort.Text)))
            {
                MessageBox.Show("Telnet Success");
            }
            else
            {
                MessageBox.Show("Telnet Fault");
            }
        }
    }
}
