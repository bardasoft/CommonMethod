using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CommonMethod
{
    /// <summary>
    /// 转换
    /// </summary>
    public class ConvertClass
    {
        #region 进制转换
        /// <summary>
        /// 16进制转为Byte
        /// </summary>
        /// <param name="chrInput"></param>
        /// <returns></returns>
        public static byte Decimal_ChartoByte(string chrInput)
        {
            byte chrValue;
            switch (chrInput)
            {
                case "A":
                    chrValue = 0x0A;
                    break;
                case "B":
                    chrValue = 0x0B;
                    break;
                case "C":
                    chrValue = 0x0C;
                    break;
                case "D":
                    chrValue = 0x0D;
                    break;
                case "E":
                    chrValue = 0x0E;
                    break;
                case "F":
                    chrValue = 0x0F;
                    break;
                default:
                    chrValue = (byte)int.Parse(chrInput);
                    break;
            }
            return chrValue;
        }

        public static int Decimal_BytesToInt(byte[] bytsValues)
        {
            int intResult = 0;
            for (int i = bytsValues.Length - 1; i >= 0; i--)
            {
                intResult += (int)(bytsValues[i] << ((bytsValues.Length - 1 - i) * 8));
            }
            return intResult;
        }
        #endregion

        #region BCD码转换
        private static Byte[] BCDToHex(string strTemp)
        {
            try
            {
                if (Convert.ToBoolean(strTemp.Length & 1))//数字的二进制码最后1位是1则为奇数
                {
                    strTemp = "0" + strTemp;//数位为奇数时前面补0
                }
                Byte[] aryTemp = new Byte[strTemp.Length / 2];
                for (int i = 0; i < (strTemp.Length / 2); i++)
                {
                    aryTemp[i] = (Byte)(((strTemp[i * 2] - '0') << 4) | (strTemp[i * 2 + 1] - '0'));
                }
                return aryTemp;//高位在前
            }
            catch
            { return null; }
        }

        /// <summary>
        /// BCD码转换16进制(压缩BCD)
        /// </summary>
        /// <param name="strTemp"></param>
        /// <returns></returns>
        public static Byte[] BCDToHex(string strTemp, int IntLen)
        {
            try
            {
                Byte[] Temp = BCDToHex(strTemp.Trim());
                Byte[] return_Byte = new Byte[IntLen];
                if (IntLen != 0)
                {
                    if (Temp.Length < IntLen)
                    {
                        for (int i = 0; i < IntLen - Temp.Length; i++)
                        {
                            return_Byte[i] = 0x00;
                        }
                    }
                    Array.Copy(Temp, 0, return_Byte, IntLen - Temp.Length, Temp.Length);
                    return return_Byte;
                }
                else
                {
                    return Temp;
                }
            }
            catch
            { return null; }
        }

        /// <summary>
        /// 16进制转换BCD（解压BCD）
        /// </summary>
        /// <param name="AData"></param>
        /// <returns></returns>
        public static string HexToBCD(Byte[] AData)
        {
            try
            {
                StringBuilder sb = new StringBuilder(AData.Length * 2);
                foreach (Byte b in AData)
                {
                    sb.Append(b >> 4);
                    sb.Append(b & 0x0f);
                }
                return sb.ToString();
            }
            catch { return null; }
        }
        #endregion

        #region Ascii码转换
        /// <summary>
        /// Asscii码转Char (单个字符)
        /// </summary>
        /// <param name="asciiCode"></param>
        /// <returns></returns>
        public static string AsciiToChar(int asciiCode)
        {
            if (asciiCode >= 0 && asciiCode <= 255)
            {
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                byte[] byteArray = new byte[] { (byte)asciiCode };
                string strCharacter = asciiEncoding.GetString(byteArray);
                return (strCharacter);
            }
            else
            {
                throw new Exception("ASCII Code is not valid.");
            }
        }

        /// <summary>
        /// String 转 Asscii码
        /// </summary>
        /// <param name="strOperatString"></param>
        /// <returns></returns>
        public static string StringToAscii(string strOperatString)
        {
            StringBuilder sbResult = new StringBuilder();
            for (int i = 0; i < strOperatString.Length; i++)
            {
                sbResult.Append(CharToAscii(strOperatString.Substring(i, 1)).ToString("X2"));
            }
            return sbResult.ToString();
        }

        /// <summary>
        /// Char转Asscii码
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public static int CharToAscii(string character)
        {
            if (character.Length == 1)
            {
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                int intAsciiCode = (int)asciiEncoding.GetBytes(character)[0];
                return (intAsciiCode);
            }
            else
            {
                throw new Exception("Character is not valid.");
            }
        }

        public static string BytesToCharStr(byte[] bytsValue)
        {
            StringBuilder sbResult = new StringBuilder();
            foreach (byte b in bytsValue)
            {
                sbResult.Append((char)b);
            }
            return sbResult.ToString();
        }

        #endregion

        #region UniCode码转换
        /// <summary>
        ///  Unicode码转String
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static String UnicodeToString(String content)
        {
            //每4位16进制Unicode编码转为一个字符
            String enUnicode = null;
            String deUnicode = null;
            for (int i = 0; i < content.Length; i++)
            {

                enUnicode += content[i];

                if (i % 4 == 3)
                {

                    deUnicode += (char)(Convert.ToInt32(enUnicode, 16));


                    enUnicode = null;
                }

            }
            return deUnicode;
        }

        /// <summary>
        /// String转Unicode码
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static String StringToUnicode(String content)
        {//将字符串的每个字符转换为4位16进制编码
            String enUnicode = null;
            for (int i = 0; i < content.Length; i++)
            {
                if (i == 0)
                {
                    int value = Convert.ToInt32(content[i]);
                    enUnicode = getHexString(String.Format("{0:X}", value));
                }
                else
                {
                    int value = Convert.ToInt32(content[i]);
                    enUnicode = enUnicode + getHexString(String.Format("{0:X}", value));
                }
            }
            return enUnicode;
        }


        private static String getHexString(String hexString)
        {
            String hexStr = "";
            for (int i = hexString.Length; i < 4; i++)
            {
                if (i == hexString.Length)
                    hexStr = "0";
                else
                    hexStr = hexStr + "0";
            }
            return hexStr + hexString;
        }
        #endregion
        
        #region 特殊转换
        /// <summary>
        /// 特殊转换_数字转换为中文描述
        /// </summary>
        /// <param name="intConvertNumber"></param>
        /// <returns></returns>
        public static string Special_NumberToChinaStrNum(int intConvertNumber)
        {
            switch (intConvertNumber)
            { 
                case 1:
                    return "一";

                case 2:
                    return "二";

                case 3:
                    return "三";

                case 4:
                    return "四";

                case 5:
                    return "五";

                case 6:
                    return "六";

                case 7:
                    return "七";

                case 8:
                    return "八";

                case 9:
                    return "九";

                case 0:
                    return "零";
                default:
                    return "";
            }
        }

        /// <summary>
        /// 特殊转换_字节数组转换为16进制字符串
        /// </summary>
        /// <returns></returns>
        public static string Special_BytesToStrHex(byte[] bytsValue,string strDelimiter="")
        {
            StringBuilder sbResult = new StringBuilder();
            foreach (byte byt in bytsValue)       //拼接电话号码
            {
                sbResult.Append(byt.ToString("X2"));
                sbResult.Append(strDelimiter);
            }
            return sbResult.ToString();
        }

        /// <summary>
        /// 特殊转换_字符串转换为Byte数组
        /// </summary>
        /// <returns></returns>
        public static byte[] Special_StringToBytes(string strValue)
        {
            int arrayLen = strValue.Length / 2;
            byte[] bytsValue = new byte[arrayLen];
            for (int i = 0; i < arrayLen; i++)
            {
                bytsValue[i] = (byte)(Decimal_ChartoByte(strValue.Substring(2 * i, 1)) * 16 + Decimal_ChartoByte(strValue.Substring(2 * i + 1, 1)));
            }
            return bytsValue;
        }

        /// <summary>
        /// 特殊转换_数字转换为中文描述
        /// </summary>
        /// <param name="intConvertNumber"></param>
        /// <returns></returns>
        public static string Special_NumberToWeekday(int intConvertNumber)
        {
            switch (intConvertNumber)
            {
                case 0:
                    return "周日";
                case 1:
                    return "周一";

                case 2:
                    return "周二";

                case 3:
                    return "周三";

                case 4:
                    return "周四";

                case 5:
                    return "周五";

                case 6:
                    return "周六";

                //case 7:
                //    return "周日";
                default:
                    return "";
            }
        }


        //public static byte[] Special_StrHexToBytes(string strHex)
        //{
        //    return null;
        //}
        //public static string Special_BytesToStrHex(byte[] bytsValue, string strWidth)
        //{
        //    StringBuilder sbResult = new StringBuilder();
        //    sbResult.Append("");
        //}
        #endregion

        #region 位运算
        /// <summary>
        /// 位运算_按位取反
        /// </summary>
        public static UInt32 BitOperation_BitwiseNOT(UInt32 intValue )
        {
            intValue = ((intValue >> 1) & 0X55555555) | ((intValue & 0X55555555) << 1);     //1位交换
            intValue = ((intValue >> 2) & 0X33333333) | ((intValue & 0X33333333) << 2);     //2位交换
            intValue = ((intValue >> 4) & 0X0F0F0F0F) | ((intValue & 0X0F0F0F0F) << 4);     //4位交换
            intValue = ((intValue >> 8) & 0X00FF00FF) | ((intValue & 0X00FF00FF) << 8);     //4位交换
            intValue = (intValue >> 16) | (intValue  << 16);     //16位交换
            return intValue;
        }

        #endregion

        #region 时间相关
        public static DateTime UnixTimestampToDateTime(long lTime)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            lTime = long.Parse(lTime + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }
        public static long DateTimeToUnixTimestamp(DateTime dateTime)
        {
            var start = new DateTime(1970, 1, 1, 8, 0, 0, dateTime.Kind);
            return Convert.ToInt64((dateTime - start).TotalSeconds);
        }

        public static int GetWeekOfDataTime(DateTime tim)
        {
            //一.找到第一周的最后一天（先获取1月1日是星期几，从而得知第一周周末是几）

            int firstWeekend = 7 - Convert.ToInt32(DateTime.Parse(tim.Year + "-1-1").DayOfWeek);
            //二.获取今天是一年当中的第几天
            int currentDay = tim.DayOfYear;
            //三.（今天 减去 第一周周末）/7 等于 距第一周有多少周 再加上第一周的1 就是今天是今年的第几周了
            return Convert.ToInt32(Math.Ceiling((currentDay - firstWeekend) / 7.0)) + 1;
        }

        /// <summary>
        ///获取周Value  
        ///（周一 1）（周二 2）（周三3）（周四 4） （周五 5）（周六6）（周日 7） 
        /// </summary>
        /// <param name="dayWeek"></param>
        /// <returns></returns>
        public static int GetWeekofDateTimeValue(DayOfWeek dayWeek)
        {
            int result = (int)dayWeek;
            result = result == 0 ? 7 : result;
            return result;
        }
        /// <summary>
        /// 获取当前时间月份  时间
        /// </summary>
        /// <param name="tim"></param>
        /// <returns></returns>
        public static DateTime GetMonthDateTime(DateTime tim)
        {
            DateTime result = tim.AddDays(1 - tim.Day);
            return result;
        }

        /// <summary>
        /// 获取当前时间当天的起始时间
        /// </summary>
        /// <param name="tim"></param>
        /// <returns></returns>
        public static DateTime GetDataTimeToDay(DateTime tim)
        {
            StringBuilder sbDateTimeValue = new StringBuilder();
            sbDateTimeValue.Append(tim.Year);
            sbDateTimeValue.Append("-"+tim.Month);
            sbDateTimeValue.Append("-" + tim.Day);
            sbDateTimeValue.Append(" 00:00:00" );
            DateTime timResult = Convert.ToDateTime(sbDateTimeValue.ToString());
            return timResult;
        }

        /// <summary>
        /// 获取当前周数（当前月）
        /// </summary>
        /// <param name="daytime"></param>
        /// <returns></returns>
        public static int GetWeekNumInMonth(DateTime daytime)
        {
            int dayInMonth = daytime.Day;
            //本月第一天
            DateTime firstDay = daytime.AddDays(1 - daytime.Day);
            //本月第一天是周几
            int weekday = (int)firstDay.DayOfWeek == 0 ? 7 : (int)firstDay.DayOfWeek;
            //本月第一周有几天
            int firstWeekEndDay = 7 - (weekday - 1);
            //当前日期和第一周之差
            int diffday = dayInMonth - firstWeekEndDay;
            diffday = diffday > 0 ? diffday : 1;
            //当前是第几周,如果整除7就减一天
            int WeekNumInMonth = ((diffday % 7) == 0
             ? (diffday / 7 - 1)
             : (diffday / 7)) + 1 + (dayInMonth > firstWeekEndDay ? 1 : 0);
            return WeekNumInMonth;
        }

        /// <summary>
        /// 获取当前周数（当前年）
        /// </summary>
        /// <param name="daytime"></param>
        /// <returns></returns>
        public static int GetWeekOfYear(DateTime daytime)
        {
            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(daytime, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            return weekOfYear;
        }

        #endregion
    }
}
