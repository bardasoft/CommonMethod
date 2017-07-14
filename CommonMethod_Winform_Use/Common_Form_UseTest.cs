using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CommonMethod_Winform_Use
{
    public partial class Common_Form_UseTest : Form
    {
        public Common_Form_UseTest()
        {
            InitializeComponent();
        }

        private void Common_Form_UseTest_Load(object sender, EventArgs e)
        {
            textBox1.KeyPress += CommonMethod.Common_Form.txtInputValidity_Number;
            textBox2.KeyPress += CommonMethod.Common_Form.txtInputValidity_Number;
        }

        /// <summary>
        /// 文本框只允许输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void txtInputValidity_Number(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
