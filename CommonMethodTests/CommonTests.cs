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
            string Temp_strFolderPath = @"G:\上班汇总\Working\维护项目\公用项目\VideoPlayControl\VideoPlayControl\VideoPlayControl\VideoPlayControl_UseDemo\bin\Debug\AxisRecord\AxisRecord1\AxisRecord2\AxisRecord3\AxisRecord4";
            bool bolResult = Common.CreateFolder(Temp_strFolderPath);
            Assert.IsTrue(bolResult);
        }
    }
}