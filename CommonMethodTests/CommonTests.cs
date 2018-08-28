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
    }
}