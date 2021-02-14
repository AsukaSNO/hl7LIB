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
    public class primitiveTypeTests
    {
        
        [TestMethod()]
        public void primitiveTypeTest()
        {
            primitiveType obj = new primitiveType("ID");
            Assert.AreEqual("ID", obj.Name);
            obj.Value = "ABC123456";
            Assert.AreEqual("ABC123456", obj.Value);
        }

        [TestMethod()]
        public void ParseTest()
        {
            primitiveType obj = new primitiveType("TS");
            string ts = DateTime.Now.ToString("yyyyMMddhhmmss.fff");
            obj.Parse(ts);
            Assert.AreEqual(ts, obj.Value);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            primitiveType obj = new primitiveType("TS");
            string ts = DateTime.Now.ToString("yyyyMMddhhmmss.fff");
            obj.Parse(ts);
            Assert.AreEqual(ts, obj.Value);
        }
    }
}