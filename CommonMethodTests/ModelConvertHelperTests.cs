using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommonMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonMethod.Tests
{
    [TestClass()]
    public class ModelConvertHelperTests
    {
        [TestMethod()]
        public void testcTest()
        {
            //ModelConvertHelper<Test>.testc();
            Assert.Fail();
        }


        public class Test
        {
            public int? Test3
            {
                get;
                set;
            }
            public string Test1
            {
                get;
                set;
            }
            public string Test2
            {
                get;
                set;
            }

        }
    }
}