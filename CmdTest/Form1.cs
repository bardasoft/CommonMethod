using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CmdTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strSavePath = @"G:\Test";
            GetPictureForVideoRecord(@"C:\SHIKE_Video\9999\20180531021956\61-57354AA60831-3136_20180531022002_01_bfr10.H264", strSavePath, 10);
        }
        public static bool GetPictureForVideoRecord(string strVideoRecord, string strSaveFolder, int intFrequcency)
        {
            bool bolResult = false;
            StringBuilder sbffmpegCmd = new StringBuilder();
            //sbffmpegCmd.Append("cd " + Application.StartupPath);
            sbffmpegCmd.Append("ffmpeg.exe ");
            sbffmpegCmd.Append("-i " + strVideoRecord);
            sbffmpegCmd.Append(" -f image2 -r 5   ");
            sbffmpegCmd.Append(strSaveFolder + "\\b-%03d.jpg");
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";    //设置要启动的应用程序
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;    // 接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;  //输出信息
            p.StartInfo.RedirectStandardError = true;   // 输出错误
            p.StartInfo.CreateNoWindow = true;          //不显示程序窗口
            p.Start();          //启动程序
            p.StandardInput.WriteLine(sbffmpegCmd.ToString() + "&exit");//向cmd窗口发送输入信息
            p.StandardInput.AutoFlush = true;
            return bolResult;
        }
    }
}
