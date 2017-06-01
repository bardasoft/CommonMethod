using System;
using System.Collections.Generic;
using System.Text;

namespace CommonMethod
{
    /// <summary>
    /// 转换
    /// </summary>
    public class ConvertClass
    {
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
        public static string Special_BytesToStrHex(byte[] bytsValue)
        {
            StringBuilder sbResult = new StringBuilder();
            foreach (byte byt in bytsValue)       //拼接电话号码
            {
                sbResult.Append(byt.ToString("X2"));
            }
            return sbResult.ToString();
        }
        #endregion


    }
}
