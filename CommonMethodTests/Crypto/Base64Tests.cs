using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommonMethod.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonMethod.Crypto.Tests
{
    [TestClass()]
    public class Base64Tests
    {
        [TestMethod()]
        public void EncodeBase64Test()
        {
            //string strSource = "temp123";
            //string strResult1 = Base64.EncodeBase64(Encoding.UTF8, strSource);
            //string strResult2 = Base64.DecodeBase64(Encoding.UTF8, strResult1);
            //Assert.AreEqual(strSource, strResult2);
        }

        [TestMethod()]
        public void DecodeBase64Test()
        {
            //string strSource = "A+wOBX/m";
            //string strresult = Base64.DecodeBase64(Encoding.UTF8, strSource);
            //Assert.AreEqual("123", strresult); ;
        }
    }
}