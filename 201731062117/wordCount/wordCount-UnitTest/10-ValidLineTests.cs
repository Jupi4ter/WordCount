using Microsoft.VisualStudio.TestTools.UnitTesting;
using wordCount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordCount.Tests
{
    [TestClass()]
    public class ValidLineTests
    {
        [TestMethod()]
        public void ValidLine1Test()
        {
            ValidLine validLine = new ValidLine();
            int real = validLine.ValidLine1(@"E:\subject1.txt");
            int expect = 3;
            Assert.AreEqual(real, expect);
            
        }
    }
}