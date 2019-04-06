using Microsoft.VisualStudio.TestTools.UnitTesting;
using wordcount.function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordcount.function.Tests
{
    [TestClass()]
    public class asccountTests
    {
        [TestMethod()]
        public void asccountsTest()
        {
            path.s = @"D:\se.txt";
            int num = 0;
            Assert.AreEqual(num, asccount.asccounts());
            //Assert.Fail();
        }
    }
}