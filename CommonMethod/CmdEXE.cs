using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CommonMethod
{
    public class CmdEXE
    {
        public static string Execute(string dosCommand, int outtime)
        {
            string output = "";
            if (dosCommand != null && dosCommand != "")
            {
                Process process = new Process();//创建进程对象  
                ProcessStartInfo startinfo = new ProcessStartInfo();//创建进程时使用的一组值，如下面的属性  
                startinfo.FileName = "cmd.exe";//设定需要执行的命令程序  
                                               //以下是隐藏cmd窗口的方法  
                startinfo.Arguments = "/c" + dosCommand;//设定参数，要输入到命令程序的字符，其中"/c"表示执行完命令后马上退出  
                startinfo.UseShellExecute = false;//不使用系统外壳程序启动  
                startinfo.RedirectStandardInput = false;//不重定向输入  
                startinfo.RedirectStandardOutput = true;//重定向输出，而不是默认的显示在dos控制台上  
                startinfo.CreateNoWindow = true;//不创建窗口  
                process.StartInfo = startinfo;

                try
                {
                    if (process.Start())//开始进程  
                    {
                        if (outtime == 0)
                        { process.WaitForExit(); }
                        else
                        { process.WaitForExit(outtime); }
                        output = process.StandardOutput.ReadToEnd();//读取进程的输出  
                    }
                }
                catch
                {

                }
                finally
                {
                    if (process != null)
                    { process.Close(); }

                }
            }
            return output;
        }
    }
}
