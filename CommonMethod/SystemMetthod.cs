using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CommonMethod
{
    public class SystemMetthod
    {
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32")]  //080728
        public static extern int SetWindowPos(IntPtr hwnd, IntPtr hWndInsertAfter, int X, int y, int cx, int cy, int wFlagslong);


    }
}
