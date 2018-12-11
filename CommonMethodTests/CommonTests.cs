using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommonMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonMethod.Tests
{
    [TestClass()]
    public class CommonTests
    {
        [TestMethod()]
        public void CreateFolderTest()
        {
            string Temp_strFolderPath = @"C:\Users\thankyou_1996\Desktop\新建文件夹\123\456\456.txt";
            bool bolResult = Common.CreateFolder(Temp_strFolderPath);
            Assert.IsTrue(bolResult);
        }

        [TestMethod()]
        public void CopyDirTest()
        {
            string s1 = @"C:\Users\thankyou_1996\Desktop\新建文件夹";
            string s2 = @"C:\Users\thankyou_1996\Desktop\新建文件夹 (2)";
            int intResult = CommonMethod.Common.CopyDir(s1, s2);
            Assert.AreEqual(intResult, 1);
        }

        [TestMethod()]
        public void DeleteDirTest()
        {
            string s2 = @"C:\Users\thankyou_1996\Desktop\新建文件夹 (2)";
            int intResult = CommonMethod.Common.DeleteDir(s2);
            Assert.AreEqual(intResult, 1);
        }

        [TestMethod()]
        public void GetIPTest()
        {
            string strIP = Common.GetInternetIP();
            Assert.AreEqual(strIP, "1");
        }
    }
}