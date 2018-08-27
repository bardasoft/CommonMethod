using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommonMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonMethod.Tests
{
    [TestClass()]
    public class FTPHelperTests
    {
        [TestMethod()]
        public void FtpUploadBrokenTest()
        {
            FTPHelper.FtpServerIP = "192.168.2.19:8008";
            string local = @"C:\Users\thankyou_1996\Desktop\TIM图片20180826223916.png";
            string remote = "SK_VideoRecord";

            bool  bolResult= FTPHelper.FtpUploadBroken(local, remote);
            Assert.IsTrue(bolResult);
        }
    }
}