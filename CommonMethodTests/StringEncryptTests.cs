using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommonMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonMethod.Tests
{
    [TestClass()]
    public class StringEncryptTests
    {
        [TestMethod()]
        public void DecryptTest()
        {
            string Temp_str = "LsQbmgV4VLkvDqqBypQyBOIkd6A8R1E9bmZKytCORQQE0vFD80gCQGHQjTc7cannBHDHYx5 vO78lBfvMYpO/3JiSsCAx4Xb";
            string strResult1 = System.Web.HttpUtility.UrlDecode(Temp_str);
            //string strResult = StringEncrypt.Decrypt(Temp_str);
            //Assert.AreEqual(strResult, "123");
        }

        [TestMethod()]
        public void EncryptTest()
        {
            string Temp_strSource = "SELECT * FROM 报警基本信息 ORDER BY 主机编号 ";
            //string Temp_result = StringEncrypt.Encrypt(Temp_strSource);
            byte[] bytes = Encoding.Unicode.GetBytes(Temp_strSource);
            string Temp_result = Convert.ToBase64String(bytes);
            Assert.AreEqual(Temp_result, "");
        }

        [TestMethod()]
        public void Base64EncodeTest()
        {
            string sss = StringEncrypt.Base64Encode("testt");
            Assert.AreEqual(sss, "123");
        }
    }
}
