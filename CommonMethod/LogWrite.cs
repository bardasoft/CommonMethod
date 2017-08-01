using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CommonMethod
{
    /// <summary>
    /// 日志记录
    /// </summary>
    public class LogWrite
    {
        /// <summary>
        /// 异常日志路径
        /// </summary>
        public static string strExlogFilePath = System.Environment.CurrentDirectory + "\\UserData\\ExceptionLog";

        /// <summary>
        /// 日志记录文件
        /// </summary>
        public static string strLogFilePath = System.Environment.CurrentDirectory + "\\UserData\\OperAtLog";

        /// <summary>
        /// 异常记录(输出至文本)
        /// </summary>
        /// <param name="Tag"></param>
        /// <param name="ex"></param>
        public static void WritExceptionLog(string Tag, Exception ex)
        {
            //工作目录下的CULog文件
            if (!Directory.Exists(strExlogFilePath))
            {
                Directory.CreateDirectory(strExlogFilePath);
            }
            StreamWriter sw = new StreamWriter(strExlogFilePath + "\\" + DateTime.Now.ToString("yyyyMMdd") + "(ErrorLog)" + ".log", true, Encoding.Default);
            StringBuilder sbExceptionLog = new StringBuilder();
            sbExceptionLog.Append("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]\t 异常标识:" + Tag + Environment.NewLine);
            sbExceptionLog.Append("异常信息：" + ex.Message + Environment.NewLine);
            sbExceptionLog.Append("异常对象：" + ex.Source + Environment.NewLine);
            sbExceptionLog.Append("调用堆栈：" + ex.StackTrace.Trim() + Environment.NewLine);
            sbExceptionLog.Append("触发方法：" + ex.TargetSite + Environment.NewLine);
            sbExceptionLog.Append(Environment.NewLine);

            sw.Write(sbExceptionLog.ToString());
            sw.Close();
        }


        /*获取当前代码执行的 命名空间 类名 方法名
         * 静态
         * 命名空间+类：System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName 
         * 命名空间：System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace
         * 类：System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
         * 方法：new System.Diagnostics.StackTrace().GetFrame(0).GetMethod().Name
         * 
         * 非静态
         * 命名空间：this.GetType().ToString()
         * 类：this.GetType().Name
         * 方法：new System.Diagnostics.StackTrace().GetFrame(0).GetMethod().Name
         * 
         ***************************************************/

        private static object objWriteEventLock = new object();
        /// <summary>
        /// 信息记录(输出至文本)
        /// </summary>
        /// <param name="logInfo"></param>
        /// <param name="logFileName"></param>
        public static void WriteEventLog(string Tag, string LogInfo, string LogFileName = "\\UserData\\OperAtLog")
        {

            try
            {
                lock (objWriteEventLock)
                {
                    if (!Directory.Exists(strLogFilePath)) //判断文件是否存在
                    {
                        Directory.CreateDirectory(strLogFilePath);
                    }
                    StreamWriter sw = new StreamWriter(strLogFilePath + "\\" + DateTime.Now.ToString("yyyyMMdd") + "(EventLog)" + ".log", true, Encoding.Default);
                    StringBuilder sbEventLog = new StringBuilder();
                    sbEventLog.Append("[" + Tag + "]" + Environment.NewLine);
                    sbEventLog.Append("[DateTime : " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]" + Environment.NewLine);
                    sbEventLog.Append(LogInfo + Environment.NewLine);
                    sbEventLog.Append(Environment.NewLine);
                    sw.WriteLine(sbEventLog);
                    sw.Close();
                }

            }
            catch (Exception ex)
            {
                WritExceptionLog("写入事件记录异常", ex);
            }
        }

        /// <summary>
        /// 程序异常排查
        /// </summary>
        /// <param name="Tag"></param>
        /// <param name="ex"></param>
        /// <param name="bolDeBug"></param>
        public static void ProgramDebug(string Tag, Exception ex, bool bolDeBug = false)
        {
            if (bolDeBug)
            {
                MessageBox.Show(ex.ToString(), "异常提示" + Tag);
                return;
            }
            else
            {
                WritExceptionLog(Tag, ex);
            }
        }
    }
}
