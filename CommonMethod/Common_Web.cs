using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;

namespace CommonMethod
{
    /// <summary>
    /// 公用方法_Web
    /// </summary>
    public class Common_Web
    {
        /// <summary>
        /// HttpPost请求 已测试验证
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="postDataStr"></param>
        /// <returns></returns>
        public static string HttpPost(string Url, string postDataStr)
        {
            //cookie
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            byte[] bytData = Encoding.UTF8.GetBytes(postDataStr);
            request.ContentLength = bytData.Length;
            Stream myRequestStream = request.GetRequestStream();
            myRequestStream.Write(bytData, 0, bytData.Length);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //response.Cookies = cookie.GetCookies(response.ResponseUri);
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myRequestStream.Close();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

        /// <summary>
        /// HttpPost请求 尚未测试验证
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
            byte[] bytData = Encoding.UTF8.GetBytes(strPostData);
            request.ContentLength = Encoding.UTF8.GetByteCount(strPostData);
            Stream myRequestStream = request.GetRequestStream();
            myRequestStream.Write(bytData, 0, bytData.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
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
            request.Headers.Add("Accept-Encoding", "gzip");
            request.Method = "GET";
            request.ContentType = "application/json;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string retString = GetResponseBody(response);
            return retString;
        }
        /// <summary>
        /// 数据压缩解码
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private static string GetResponseBody(HttpWebResponse response)
        {
            string responseBody = string.Empty;
            if (response.ContentEncoding.ToLower().Contains("gzip"))
            {
                using (GZipStream stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        responseBody = reader.ReadToEnd();
                    }
                }
            }
            else if (response.ContentEncoding.ToLower().Contains("deflate"))
            {
                using (DeflateStream stream = new DeflateStream(response.GetResponseStream(), CompressionMode.Decompress))
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        responseBody = reader.ReadToEnd();
                    }
                }
            }
            else
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        responseBody = reader.ReadToEnd();
                    }
                }
            }
            return responseBody;
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
            request.ContentType = "application/json;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding(strStreamReadEncoding));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }



        /// <summary>
        /// 转换为Url参数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string ConvertToUrlPara<T>(T t)
        {
            StringBuilder sbResult = new StringBuilder();
            PropertyInfo[] propertys = t.GetType().GetProperties();// 获得此模型的公共属性
            foreach (var pi in propertys)
            {
                string Temp_value = Convert.ToString(pi.GetValue(t, null));
                if (!string.IsNullOrEmpty(Temp_value))
                {
                    sbResult.AppendFormat("{0}={1}", pi.Name, Temp_value);
                    sbResult.Append("&");
                }
            }
            if (sbResult.Length > 0)
            {
                sbResult.Length = sbResult.Length - 1;
            }
            return sbResult.ToString();
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
            string strData = "cb=jQuery1102033239549674370017_1513645089824&resource_name=guishudi&query=" + strPhome + "&_=1513645089826";
            int Temp_intIndex1 = 0;
            int Temp_intIndex2 = 0;
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
            return sbJsonData.ToString();
        }


        #region HFS
        /// <summary>
        /// HFSHttpUploadFile
        /// </summary>
        /// <param name="url"></param>
        /// <param name="files"></param>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string HFSHttpUploadFile(string url, string[] files, NameValueCollection data, Encoding encoding)
        {
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
            byte[] endbytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");

            //1.HttpWebRequest
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Method = "POST";
            request.KeepAlive = true;
            request.Credentials = CredentialCache.DefaultCredentials;

            using (Stream stream = request.GetRequestStream())
            {
                //1.1 key/value
                string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
                if (data != null)
                {
                    foreach (string key in data.Keys)
                    {
                        stream.Write(boundarybytes, 0, boundarybytes.Length);
                        string formitem = string.Format(formdataTemplate, key, data[key]);
                        byte[] formitembytes = encoding.GetBytes(formitem);
                        stream.Write(formitembytes, 0, formitembytes.Length);
                    }
                }

                //1.2 file
                string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: application/octet-stream\r\n\r\n";
                byte[] buffer = new byte[4096];
                int bytesRead = 0;
                for (int i = 0; i < files.Length; i++)
                {
                    stream.Write(boundarybytes, 0, boundarybytes.Length);
                    string header = string.Format(headerTemplate, "file" + i, Path.GetFileName(files[i]));
                    byte[] headerbytes = encoding.GetBytes(header);
                    stream.Write(headerbytes, 0, headerbytes.Length);
                    using (FileStream fileStream = new FileStream(files[i], FileMode.Open, FileAccess.Read))
                    {
                        while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            stream.Write(buffer, 0, bytesRead);
                        }
                    }
                }

                //1.3 form end
                stream.Write(endbytes, 0, endbytes.Length);
            }
            //2.WebResponse
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                return stream.ReadToEnd();
            }
        }

        /// <summary>
        /// HFSHttpUploadFile
        /// </summary>
        /// <param name="url"></param>
        /// <param name="files"></param>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string HFSHttpTest(string url, string[] files, NameValueCollection data, Encoding encoding)
        {
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
            byte[] endbytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");

            //1.HttpWebRequest
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Method = "POST";
            request.KeepAlive = true;
            request.Credentials = CredentialCache.DefaultCredentials;

            using (Stream stream = request.GetRequestStream())
            {
                //1.1 key/value
                string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
                if (data != null)
                {
                    foreach (string key in data.Keys)
                    {
                        stream.Write(boundarybytes, 0, boundarybytes.Length);
                        string formitem = string.Format(formdataTemplate, key, data[key]);
                        byte[] formitembytes = encoding.GetBytes(formitem);
                        stream.Write(formitembytes, 0, formitembytes.Length);
                    }
                }

                //1.2 file
                string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: application/octet-stream\r\n\r\n";
                byte[] buffer = new byte[4096];
                int bytesRead = 0;
                for (int i = 0; i < files.Length; i++)
                {
                    stream.Write(boundarybytes, 0, boundarybytes.Length);
                    string header = string.Format(headerTemplate, "file" + i, Path.GetFileName(files[i]));
                    byte[] headerbytes = encoding.GetBytes(header);
                    stream.Write(headerbytes, 0, headerbytes.Length);
                    using (FileStream fileStream = new FileStream(files[i], FileMode.Open, FileAccess.Read))
                    {
                        while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            stream.Write(buffer, 0, bytesRead);
                        }
                    }
                }

                //1.3 form end
                stream.Write(endbytes, 0, endbytes.Length);
            }
            //2.WebResponse
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                return stream.ReadToEnd();
            }
        }

        /// <summary>
        /// HFS获取文件/下载文件
        /// </summary>
        /// <param name="strUrl"></param>
        /// <param name="strLocalSavePath"></param>
        /// <returns></returns>
        public static bool HFSHttpGetFile(string strUrl, string strLocalSavePath)
        {
            bool bolResult = false;
            List<HFSDownLoadFileInfo> lstDownLoaFile = HFSHttpGetFileNameList(strUrl);
            foreach (HFSDownLoadFileInfo s in lstDownLoaFile)
            {
                s.SaveName = strLocalSavePath + "/" + s.SaveName;
                s.DownName = strUrl + "/" + s.DownName;
            }
            bolResult = HFSHttpGetFile(lstDownLoaFile);
            return bolResult;
        }

        /// <summary>
        /// HFS获取文件/下载文件
        /// </summary>
        /// <param name="lstDownLoaFile"></param>
        /// <returns></returns>
        public static bool HFSHttpGetFile(List<HFSDownLoadFileInfo> lstDownLoaFile)
        {
            bool bolResult = false;
            foreach (HFSDownLoadFileInfo s in lstDownLoaFile)
            {
                HFSHttpGetFile(s);
            }
            return bolResult;
        }

        /// <summary>
        /// HFS获取文件/下载文件
        /// </summary>
        /// <param name="DownLoadFile"></param>
        /// <returns></returns>
        public static bool HFSHttpGetFile(HFSDownLoadFileInfo DownLoadFile)
        {
            bool bolResult = true;
            string Temp_strSaveFolder = Path.GetDirectoryName(DownLoadFile.SaveName);
            Common.CreateFolder(Temp_strSaveFolder);
            string Temp_strDownLoadUrl = DownLoadFile.DownName;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Temp_strDownLoadUrl);
            request.Timeout = 5000;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                long Temp_lngTotal = response.ContentLength;
                using (Stream st = response.GetResponseStream())
                {
                    using (Stream so = new FileStream(DownLoadFile.SaveName, FileMode.Create))
                    {
                        long Temp_lngDownTotal = 0;
                        byte[] buffer = new byte[4096];
                        int intOSize = st.Read(buffer, 0, (int)buffer.Length);
                        while (intOSize > 0)
                        {
                            Temp_lngDownTotal += intOSize;
                            so.Write(buffer, 0, intOSize);
                            intOSize = st.Read(buffer, 0, (int)buffer.Length);
                        }
                    }
                }
            }
            catch 
            {
                //如果404 会产生异常
                bolResult = false;
            }

            
            return bolResult;
        }

        /// <summary>
        /// 获取URL的文件列表
        /// </summary>
        /// <param name="url"></param>
        /// <param name="savePath"></param>
        public static List<HFSDownLoadFileInfo> HFSHttpGetFileNameList(string strUrl)
        {
            List<HFSDownLoadFileInfo> result = new List<HFSDownLoadFileInfo>();
            WebClient MyWebClient = new WebClient();
            MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
            Byte[] pageData = MyWebClient.DownloadData(strUrl); //从指定网站下载数据
            //string pageHtml = System.Text.Encoding.GetEncoding("GB2312").GetString(pageData);
            //string pageHtml = Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句          
            string pageHtml = Encoding.UTF8.GetString(pageData); //如果获取网站页面采用的是UTF-8，则使用这句

            //获取表格信息
            int tbStartIndex = pageHtml.IndexOf("<table id='files'>");
            int tbEndIndex = pageHtml.IndexOf("</table>") + 8;
            int tbLength = tbEndIndex - tbStartIndex;
            if (tbStartIndex > -1)
            {
                //无文件信息;
                string strTb = pageHtml.Substring(tbStartIndex, tbLength);
                string[] fileInfos = strTb.Split(Environment.NewLine.ToCharArray());//换行分割
                List<string> fileNames = new List<string>();
                foreach (string s in fileInfos)
                {
                    if (string.IsNullOrEmpty(s))
                    {
                        continue;
                    }
                    if (!s.Trim().StartsWith("<a href="))       //<a>标签
                    {
                        continue;
                    }
                    if (!(s.Trim().IndexOf("<img src") != -1))//有前置小图标 下载文件
                    {
                        continue;
                    }
                    string saveFileName = "";
                    string downLoadUrlName = "";
                    string strTransition = "";    //过渡变量，便于字符串截取
                    strTransition = s.Substring(0, s.IndexOf("</a>"));
                    saveFileName = strTransition.Substring(strTransition.LastIndexOf(">") + 2); //网页中文件名称前面会有一个空格字符

                    int downLoadUrlStartIndex = s.IndexOf("href=") + 6;
                    int downLoadUrlEndIndex = s.IndexOf('"' + ">");
                    int downLoadUrlNameLength = downLoadUrlEndIndex - downLoadUrlStartIndex;
                    //下载地址url
                    downLoadUrlName = s.Substring(downLoadUrlStartIndex, downLoadUrlNameLength);

                    string[] temp = s.Split('>');
                    string Temp_strSaveName = temp[2].Replace("</a", "").Trim();

                    //if (downLoadUrlName.LastIndexOf(".") == -1)
                    if (downLoadUrlName.EndsWith("/"))
                    {
                        //文件夹 递归
                        List<HFSDownLoadFileInfo> Temp_Result = HFSHttpGetFileNameList(strUrl + "\\" + Temp_strSaveName);
                        foreach (HFSDownLoadFileInfo ss in Temp_Result)
                        {
                            //result.Add(downLoadUrlName + "/" + ss);
                            result.Add(new HFSDownLoadFileInfo
                            {
                                SaveName = Temp_strSaveName + "/" + ss.SaveName,
                                DownName = Temp_strSaveName + "/" + ss.DownName,
                            });
                        }
                    }
                    else
                    {
                        HFSDownLoadFileInfo Temp_HFSFileInfo = new HFSDownLoadFileInfo
                        {
                            SaveName = saveFileName,
                            DownName = downLoadUrlName
                        };

                        result.Add(Temp_HFSFileInfo);
                    }
                }
            }

            return result;
        }


        #endregion 
    }
    public class HFSDownLoadFileInfo
    {
        /// <summary>
        /// 保存名称
        /// </summary>
        public string SaveName
        {
            get;
            set;
        }


        /// <summary>
        /// 下载名称
        /// </summary>
        public string DownName
        {
            get;
            set;
        }

    }
}
