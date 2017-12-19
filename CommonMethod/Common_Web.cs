using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace CommonMethod
{
    /// <summary>
    /// 公用方法_Web
    /// </summary>
    public class Common_Web
    {
        /// <summary>
        /// HttpPost请求
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="postDataStr"></param>
        /// <returns></returns>
        public static string HttpPost(string Url, string postDataStr)
        {
            //cookie
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
            //request.CookieContainer = cookie;
            Stream myRequestStream = request.GetRequestStream();
            StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
            myStreamWriter.Write(postDataStr);
            myStreamWriter.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //response.Cookies = cookie.GetCookies(response.ResponseUri);
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

        /// <summary>
        /// HttpPost请求
        /// </summary>
        /// <param name="strUrl"></param>
        /// <param name="strPostData"></param>
        /// <param name="strSteamWriteEncoding"></param>
        /// <param name="strStreamReadEncoding"></param>
        /// <returns></returns>
        public static string HttpPost(string strUrl, string strPostData, string strSteamWriteEncoding, string strStreamReadEncoding)
        {


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strUrl);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = Encoding.UTF8.GetByteCount(strPostData);
            //request.CookieContainer = cookie;
            Stream myRequestStream = request.GetRequestStream();
            StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding(strSteamWriteEncoding));
            myStreamWriter.Write(strPostData);
            myStreamWriter.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //response.Cookies = cookie.GetCookies(response.ResponseUri);
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding(strStreamReadEncoding));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }


        /// <summary>
        /// HttpGet请求
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="postDataStr"></param>
        /// <returns></returns>
        public static string HttpGet(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }


        /// <summary>
        /// HttpGet请求
        /// </summary>
        /// <param name="strUrl"></param>
        /// <param name="strGetDataStr"></param>
        /// <param name="strSteamWriteEncoding"></param>
        /// <param name="strStreamReadEncoding"></param>
        /// <returns></returns>
        public static string HttpGet(string strUrl, string strGetDataStr, string strSteamWriteEncoding, string strStreamReadEncoding)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strUrl + (strGetDataStr == "" ? "" : "?") + strGetDataStr);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding(strStreamReadEncoding));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }

        /// <summary>
        /// 获取网络时间
        /// </summary>
        /// <returns></returns>
        public static string GetNetDataTime()
        {
            WebRequest request = null;
            WebResponse response = null;
            WebHeaderCollection headerCollection = null;
            string datetime = string.Empty;
            try
            {
                request = WebRequest.Create("https://www.baidu.com");
                request.Timeout = 3000;
                request.Credentials = CredentialCache.DefaultCredentials;
                response = (WebResponse)request.GetResponse();
                headerCollection = response.Headers;
                foreach (var h in headerCollection.AllKeys)
                { if (h == "Date") { datetime = headerCollection[h]; } }
                return datetime;
            }
            catch (Exception) { return datetime; }
            finally
            {
                if (request != null)
                { request.Abort(); }
                if (response != null)
                { response.Close(); }
                if (headerCollection != null)
                { headerCollection.Clear(); }
            }
        }

        public static string QueryPhoneAttribution(string strPhome)
        {
            StringBuilder sbJsonData = new StringBuilder();
            string strProv = "";
            string strCity = "";
            string strType = "";
            bool bolResult = false;
            string strUrl = "https://sp0.baidu.com/8aQDcjqpAAV3otqbppnN2DJv/api.php?";
            string strData ="cb=jQuery1102033239549674370017_1513645089824&resource_name=guishudi&query="+ strPhome + "&_=1513645089826";
            int Temp_intIndex1=0;
            int Temp_intIndex2= 0;
            int Temp_intLength = 0;
            try
            {
                string Temp_strRequestResult = HttpPost(strUrl, strData, "gb2312", "gb2312");
                //不在单独引用 JSON DLL 独自进行字符串解析
                if (!string.IsNullOrEmpty(Temp_strRequestResult))
                {
                    //省
                    Temp_intIndex1 = Temp_strRequestResult.IndexOf("\"prov\":") + 8;
                    Temp_intIndex2 = Temp_strRequestResult.IndexOf("\"city\":") - 3;
                    Temp_intLength = Temp_intIndex2 - Temp_intIndex1;
                    strProv = Temp_strRequestResult.Substring(Temp_intIndex1, Temp_intLength);

                    //市
                    Temp_intIndex1 = Temp_strRequestResult.IndexOf("\"city\":") + 8;
                    Temp_intIndex2 = Temp_strRequestResult.IndexOf("\"type\":") - 3;
                    Temp_intLength = Temp_intIndex2 - Temp_intIndex1;
                    strCity = Temp_strRequestResult.Substring(Temp_intIndex1, Temp_intLength);

                    //运营商
                    Temp_intIndex1 = Temp_strRequestResult.IndexOf("\"type\":") + 8;
                    Temp_intIndex2 = Temp_strRequestResult.IndexOf("\"SiteId\":") - 3;
                    Temp_intLength = Temp_intIndex2 - Temp_intIndex1;
                    strType = Temp_strRequestResult.Substring(Temp_intIndex1, Temp_intLength);
                    bolResult = true;
                }
            }
            catch
            {
                bolResult = false;
            }
            sbJsonData.Append("[{");
            sbJsonData.Append("\"result\":\"" + bolResult.ToString().ToLower() + "\",");
            sbJsonData.Append("\"prov\":\"" + strProv + "\",");
            sbJsonData.Append("\"city\":\"" + strCity + "\",");
            sbJsonData.Append("\"type\":\"" + strType + "\"");
            sbJsonData.Append("}]");
            return sbJsonData.ToString() ;
        }

    }
}
