using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CommonMethod
{
    public class ProcessControl
    {

        public static bool KillProcess(string processName)
        {
            bool bolResult = false;
            System.Diagnostics.Process myproc = new System.Diagnostics.Process();
            //得到所有打开的进程   

            foreach (Process thisproc in Process.GetProcessesByName(processName))
            {
                //找到程序进程,kill之。
                if (!thisproc.CloseMainWindow())
                {
                    thisproc.Kill();
                    bolResult = true;
                }
            }

            return bolResult;
        }


        public static bool StopProcess(string processName)
        {
            bool bolResult = false;
            System.Diagnostics.Process[] ps = System.Diagnostics.Process.GetProcessesByName(processName);
            foreach (System.Diagnostics.Process p in ps)
            {
                p.Kill();
            }
            return bolResult;
        }
    }
}
