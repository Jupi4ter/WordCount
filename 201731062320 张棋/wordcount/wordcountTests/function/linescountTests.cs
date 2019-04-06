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
    public class linescountTests
    {
        [TestMethod()]
        public void linesTest()
        {
            path.s = @"D:\se.txt";
            int x = 0;
            Assert.AreEqual(x, linescount.lines());
           // Assert.Fail();
        }
    }
}