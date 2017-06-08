using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CommonMethod
{
    /// <summary>
    /// 通用方法
    /// </summary>
    public class Common
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
    }
}
