using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp14;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp14.Tests
{
    [TestClass()]
    public class CountLineTests
    {
        [TestMethod()]
        public void CountLineTest()
        {
            string text = File.ReadAllText(@"d:\input.txt");
            CountLine countLine = new CountLine(text);
            //Assert.Fail();
        }
    }
}