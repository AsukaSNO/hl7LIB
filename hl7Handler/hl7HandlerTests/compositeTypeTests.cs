using Microsoft.VisualStudio.TestTools.UnitTesting;
using hl7Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hl7Handler.Tests
{
    [TestClass()]
    public class compositeTypeTests
    {
        private abstractType[] data;//子组件
        private string delimiter = common.segmentDelimiter;
        compositeType cT = new compositeType(null, "cT");
        [TestMethod()]
        public void compositeTypeTest()
        {
            Assert.AreEqual(delimiter,common.segmentDelimiter);
        }

        [TestMethod()]
        public void ParseTest()
        {
            //待测试
            cT.Parse("ABC\r123");
            Assert.AreEqual(cT.Value, "ABC\r123");
        }

        [TestMethod()]
        public void ToStringTest()
        {
            //待测试
            Assert.Fail();
        }
    }
}