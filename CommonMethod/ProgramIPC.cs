using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CommonMethod
{
    /// <summary>
    /// 程序间通讯
    /// </summary>
    public class ProgramIPC
    {
        /// <summary>
        /// 目标窗口句柄
        /// </summary>
        private int intTargetHandler = -1;
        /// <summary>
        /// 目标窗口句柄
        /// </summary>
        public int TargetHandler
        {
            get { return intTargetHandler; }
            set { intTargetHandler = value; }
        }

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(
         int hWnd, //目标窗口的handle
         int Msg, // 消息
         int wparam,// 第二个消息参数
         ref string  lParam // 第一个消息参数
         );


        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern int FindWindow(string lpClassName, string
         lpWindowName);

    }
}
