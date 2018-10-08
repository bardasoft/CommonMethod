using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommonMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonMethod.Tests
{
    [TestClass()]
    public class testTests
    {
        [TestMethod()]
        public void EncryptTest()
        {
            string Temp_strSource = "SELECT * FROM 报警基本信息 ORDER BY 主机编号 DESC";
            //string Temp_strResult = StringEncrypt.Encrypt(Temp_strSource);
            //Assert.AreEqual(Temp_strResult, 1);
        }

        [TestMethod()]
        public void DecryptTest()
        {
            string Temp_strSource = "SELECT * FROM 报警基本信息 ORDER BY 主机编号 DESC";
            //string Temp_strResult1 = StringEncrypt.Encrypt(Temp_strSource);
            //string Temp_strResult2 = StringEncrypt.Decrypt(Temp_strResult1);
            //Assert.AreEqual(Temp_strSource, Temp_strResult2);
        }
    }
}