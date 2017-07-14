using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CommonMethod
{
    /// <summary>
    /// 公用方法_窗体
    /// </summary>
    public class Common_Form
    {
        /// <summary>
        /// 文本框只允许输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void txtInputValidity_Number(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
