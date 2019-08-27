using CommonMethod;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CommonMethodTests
{
    [TestClass()]
    public class RemoteUpdateTest
    {
        [TestMethod()]
        public void Test()
        {
            string strSrc = @"G:\Working\Currency\CommonMethod\CommonMethodTests\bin\Debug\Src";
            string strAim = @"G:\Working\Currency\CommonMethod\CommonMethodTests\bin\Debug\Aim";
            //获取所有文件
            List<SKFileInfo>  lstFileInfo = FileOperat.GetSKFileInfoList(strSrc);
            foreach (SKFileInfo item in lstFileInfo)
            {
                string strFilePath = strSrc + "\\" + item.path;
                Console.WriteLine(strFilePath);
                string strAimPath = strAim + "\\" + item.path;
                string strrr = Path.GetDirectoryName(strAimPath);
                if (!Directory.Exists(strrr))
                {
                    Directory.CreateDirectory(strrr);
                }
                System.IO.File.Copy(strFilePath, strAimPath, true);
            }
            CommonMethod.Common.Delay_Millisecond(15000);
            Assert.AreEqual(lstFileInfo.Count, 1);
        }
    }
}
