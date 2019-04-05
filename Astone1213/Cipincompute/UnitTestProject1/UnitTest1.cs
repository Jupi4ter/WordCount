using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cipincompute;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string text2 = @"F:\vs\github\WordCount\Astone1213\input.txt";
            totallines tl = new totallines();
            Assert.AreEqual(tl.Print_lines(text2), 2);
        }
    }
}
