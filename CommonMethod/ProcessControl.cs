using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
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






        public static readonly IntPtr HWND_TOP = new IntPtr(0);
        public static bool StartProcess(string dir, string exename, string strOpenFile) //080725
        {
            int r = ShellExecute(IntPtr.Zero, "Open", exename, strOpenFile, dir, 1);

            if (r < 32)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //public static bool KillProcess(string processname)
        //{
        //    try
        //    {
        //        int ProceedingCount = 0;
        //        System.Diagnostics.Process[] targetProcesses;
        //        targetProcesses = System.Diagnostics.Process.GetProcessesByName(processname);

        //        foreach (System.Diagnostics.Process IsProcedding in targetProcesses)
        //        {
        //            if (IsProcedding.ProcessName == processname) { ProceedingCount += 1; }
        //        }
        //        if (ProceedingCount > 0)
        //        {
        //            foreach (System.Diagnostics.Process myProcess in targetProcesses)
        //            {
        //                myProcess.Kill();
        //            }
        //            return true;
        //        }
        //    }
        //    catch
        //    {

        //    }
        //    return false;
        //}

        public static bool KillProcessByFilename(string filename)
        {
            try
            {
                int ProceedingCount = 0;
                string processname = GetProcessNameByFileName(filename);
                System.Diagnostics.Process[] targetProcesses;
                targetProcesses = System.Diagnostics.Process.GetProcessesByName(processname);

                foreach (System.Diagnostics.Process IsProcedding in targetProcesses)
                {
                    if (IsProcedding.ProcessName == processname) { ProceedingCount += 1; }
                }
                if (ProceedingCount > 0)
                {
                    foreach (System.Diagnostics.Process myProcess in targetProcesses)
                    {
                        myProcess.Kill();
                    }
                    return true;
                }
            }
            catch
            {

            }
            return false;
        }

        public static string GetProcessNameByFileName(string filename)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                System.Diagnostics.Process[] targetProcesses;
                targetProcesses = System.Diagnostics.Process.GetProcesses();

                foreach (System.Diagnostics.Process IsProcedding in targetProcesses)
                {
                    string str = "";
                    try
                    {
                        str = IsProcedding.MainModule.ModuleName;
                        Console.WriteLine(str);
                        sb.Append(str + Environment.NewLine);
                    }
                    catch
                    {
                    }
                    if (str == filename) { return IsProcedding.ProcessName; }
                }
            }
            catch (Exception ex)
            {
                CommonMethod.LogWrite.WritExceptionLog("GetProcessNameByFileName", ex);
            }
            return "";
        }


        #region 启动外部程序

        #region 外部函数
        //#define SW_HIDE             0 //隐藏窗口，活动状态给令一个窗口
        //#define SW_SHOWNORMAL       1 //用原来的大小和位置显示一个窗口，同时令其进入活动状态
        //#define SW_NORMAL           1
        //#define SW_SHOWMINIMIZED    2
        //#define SW_SHOWMAXIMIZED    3
        //#define SW_MAXIMIZE         3
        //#define SW_SHOWNOACTIVATE   4 //用最近的大小和位置显示一个窗口，同时不改变活动窗口
        //#define SW_SHOW             5 //用当前的大小和位置显示一个窗口，同时令其进入活动状态
        //#define SW_MINIMIZE         6 //最小化窗口，活动状态给令一个窗口
        //#define SW_SHOWMINNOACTIVE  7 //最小化一个窗口，同时不改变活动窗口
        //#define SW_SHOWNA           8 //用当前的大小和位置显示一个窗口，不改变活动窗口
        //#define SW_RESTORE          9 //与 SW_SHOWNORMAL  1 相同
        //#define SW_SHOWDEFAULT      10
        //#define SW_FORCEMINIMIZE    11
        //#define SW_MAX              11
        [DllImport("kernel32.dll")]
        private static extern int WinExec(string exeName, int operType);

        [DllImport("shell32.dll")]
        private static extern int ShellExecute(IntPtr hwnd, String lpszOp, String lpszFile, String lpszParams, String lpszDir, int FsShowCmd);

        [DllImport("user32")]  //080728
        public static extern int SetWindowPos(IntPtr hwnd, IntPtr hWndInsertAfter, int X, int y, int cx, int cy, int wFlagslong);

        //080830
        //[DllImport("shell32.dll", EntryPoint = "Shell_NotifyIcon")]
        //public static extern int Shell_NotifyIcon(
        //int dwMessage,
        //ref   NOTIFYICONDATA lpData
        //);
        //****************
        #endregion

        #region 参考代码

        //以下面的方式运行exe，运行的程序认为它和本程序在同一目录下．
        //System.Diagnostics.Process.Start(@"VTDU\VideoTransmitServer.exe") == null
        #region 如何强制中止某个应用程序的所有进程
        //中止所有Excel进程
        //public static void KillExcelProceed()
        //{
        //    int ProceedingCount = 0;
        //    System.Diagnostics.Process[] targetProcesses; 
        //    targetProcesses = System.Diagnostics.Process.GetProcessesByName("EXCEL");
        //    foreach (System.Diagnostics.Process IsProcedding in targetProcesses)
        //    {
        //        if (IsProcedding.ProcessName == "EXCEL") { ProceedingCount += 1; }
        //    }
        //    if (ProceedingCount > 0)
        //    {
        //        DialogResult result; 
        //        result = MessageBox.Show("发现系统中有Excel进程，要关闭所有Excel进程吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        //        if (result == DialogResult.Yes)
        //        {
        //            foreach (System.Diagnostics.Process myProcess in targetProcesses)
        //            {
        //                myProcess.Kill();
        //            }
        //        }
        //    }
        //} 
        #endregion
        #endregion
        #endregion
    }
}
