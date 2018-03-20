using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CommonMethod_Winform_Use
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CommonMethod.LogWrite.WriteEventLog("Test", "t");
            Application.Run(new FrmItemsTest());
        }
    }
}
