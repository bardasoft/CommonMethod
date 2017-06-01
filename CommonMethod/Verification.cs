using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CommonMethod
{
    /// <summary>
    /// 验证判断
    /// </summary>
    public class Verification
    {
        /// <summary>
        /// 判断是否为合法的IP地址
        /// </summary>
        /// <param name="strIP"></param>
        /// <returns></returns>
        public static bool isIP(string strIP)
        {
            try
            {
                string[] str = strIP.Split(new char[] { '.' });
                if (str.Length != 4)
                {
                    return false;
                }
                else
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        int.Parse(str[i]);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断验证是否为合法端口
        /// </summary>
        /// <param name="strPort"></param>
        /// <returns></returns>
        public static bool isPort(string strPort)
        {
            try
            {
                int intPort = Convert.ToUInt16(strPort);
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 是否为数字
        /// </summary>
        /// <param name="strNumber"></param>
        /// <returns></returns>
        public static bool isNumber(string strNumber)
        {
            Regex reg = new Regex(@"[^0-9]"); // 排除型字符组(取反思想)
            if (reg.IsMatch(strNumber))
            {
                return false;
            }
            return true;
        }
    }
}
