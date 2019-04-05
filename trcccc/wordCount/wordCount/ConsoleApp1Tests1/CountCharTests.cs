using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp14;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14.Tests
{
    [TestClass()]
    public class CountCharTests
    {
        [TestMethod()]
        public void CountCharTest()
        {
            string text = File.ReadAllText(@"d:\input.txt");
            //Assert.Fail();
        }
    }
}