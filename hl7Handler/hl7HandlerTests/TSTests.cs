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
    public class TSTests
    {
        [TestMethod()]
        public void TSTest()
        { 
            primitiveType obj = new TS("TS");
            DateTime dt = DateTime.Now;
            obj.Parse(dt.ToString("yyyy年MM月dd日hh时mm分"));
            Assert.AreEqual(dt.ToString("yyyyMMddhhmm"),obj.Value);
        }
    }
}