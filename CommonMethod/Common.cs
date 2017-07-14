using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace CommonMethod
{
    /// <summary>
    /// 通用方法
    /// </summary>
    public static class Common
    {
        #region 延时操作
        /// <summary>
        /// 延时操作秒_秒 161014
        /// </summary>
        /// <param name="delayTime"></param>
        /// <returns></returns>
        public static bool Delay_Second(int delayTime)
        {
            DateTime now = DateTime.Now;
            int s;
            do
            {
                TimeSpan spand = DateTime.Now - now;
                s = spand.Seconds;
                Application.DoEvents();
            }
            while (s < delayTime);
            return true;
        }

        /// <summary>
        /// 延时操作_毫秒
        /// </summary>
        /// <param name="Millisecond"></param>
        public static void Delay_Millisecond(int Millisecond)
        {
            DateTime current = DateTime.Now;
            while (current.AddMilliseconds(Millisecond) > DateTime.Now)
            {
                Application.DoEvents();
            }
            return;
        }

        #endregion

        #region 添加水印文字
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        /// <summary>
        /// 为TextBox设置水印文字 
        /// </summary>
        /// <param name="textBox">TextBox</param>
        /// <param name="watermark">水印文字</param>
        public static void SetWatermark(this TextBox textBox, string watermark)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, watermark);
        }

        #endregion
    }
}

//缺少编译器要求的成员“System.Runtime.CompilerServices.ExtensionAttribute..ctor”
namespace System.Runtime.CompilerServices
{
    public class ExtensionAttribute : Attribute { }
}