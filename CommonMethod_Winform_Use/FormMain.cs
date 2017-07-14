using CommonMethod;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}
