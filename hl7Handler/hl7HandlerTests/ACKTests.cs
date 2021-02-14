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
    public class ACKTests
    {
        [TestMethod()]
        public void ACKTest()
        {
            ACK ack = new ACK();
            ack.Value = "第一层消息容器ACK类";
            Assert.AreEqual(ack.msh.Name, "MSH");


            DateTime dt = DateTime.Now;
            ack.msh.FieldSeparator.Parse(dt.ToString("yyyy年MM月dd日hh时mm分"));
            Assert.AreEqual(dt.ToString("yyyyMMddhhmm"), ack.msh.FieldSeparator.Value);
            //FieldSeparator是ST类型,实现和第一次测试的一样
            //成功了说明容器构件、类关联没问题,只是叶子节点类的方法都是一样的,没有各自实现
        }
    }
}