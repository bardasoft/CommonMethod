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
            if (string.IsNullOrEmpty(strNumber))
            {
                //为空
                return false;
            }
            if (reg.IsMatch(strNumber))
            {
                return false;
            }
            return true;
        }

        #region 时间判断
        /// <summary>
        /// 是否为时间数字_时
        /// </summary>
        /// <param name="strNumber"></param>
        /// <returns></returns>
        public static bool isTimeNum_Hour(string strNumber)
        {
            if (isNumber(strNumber))
            {
                int Temp_intHour = Convert.ToInt32(strNumber);
                if (Temp_intHour >= 0 && Temp_intHour < 24)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 是否为时间数字_分
        /// </summary>
        /// <param name="strNumber"></param>
        /// <returns></returns>
        public static bool isTimeNum_Minute(string strNumber)
        {
            if (isNumber(strNumber))
            {
                int Temp_intMinute = Convert.ToInt32(strNumber);
                if (Temp_intMinute >= 0 && Temp_intMinute < 60)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 是否为时间数字_秒
        /// </summary>
        /// <param name="strNumber"></param>
        /// <returns></returns>
        public static bool isTimeNum_Second(string strNumber)
        {
            if (isNumber(strNumber))
            {
                int Temp_intSecond = Convert.ToInt32(strNumber);
                if (Temp_intSecond >= 0 && Temp_intSecond < 60)
                {
                    return true;
                }
            }
            return false;
        }


        #endregion
        #region 180124 判断IP地址为内网或外网
//        public bool isInnerIP(string ipAddress)
//        {
//            bool isInnerIp = false;
//            long ipNum = getIpNum(ipAddress);
//            /**  
//5.         私有IP：A类  10.0.0.0-10.255.255.255  
//6.                B类  172.16.0.0-172.31.255.255  
//7.                C类  192.168.0.0-192.168.255.255  
//8.         当然，还有127这个网段是环回地址  
//9.         **/
//            long aBegin = getIpNum("10.0.0.0");
//            long aEnd = getIpNum("10.255.255.255");
//            long bBegin = getIpNum("172.16.0.0");
//            long bEnd = getIpNum("172.31.255.255");
//            long cBegin = getIpNum("192.168.0.0");
//            long cEnd = getIpNum("192.168.255.255");
//            isInnerIp = isInner(ipNum, aBegin, aEnd) || isInner(ipNum, bBegin, bEnd) || isInner(ipNum, cBegin, cEnd) || ipAddress.Equals("127.0.0.1");
//            return isInnerIp;
//        }
//        private long getIpNum(string ipAddress)
//        {
//            string[] ip = ipAddress.Split(new string[] { "." }, StringSplitOptions.None);
//            long a = long.Parse(ip[0]);
//            long b = long.Parse(ip[1]);
//            long c = long.Parse(ip[2]);
//            long d = long.Parse(ip[3]);

//            long ipNum = a * 256 * 256 * 256 + b * 256 * 256 + c * 256 + d;
//            return ipNum;
//        }
//        private bool isInner(long userIp, long begin, long end)
//        {
//            return (userIp >= begin) && (userIp <= end);
//        }
        #endregion

    }
}
