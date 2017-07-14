using CommonMethod;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CommonMethod_Winform_Use1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //string[] strInfo = args[0].Split(new string[] { "|*|" }, StringSplitOptions.None);
            LogWrite.WriteEventLog("多路视频播放", "Test");
            Application.Run(new Form1());
        }
    }
}
