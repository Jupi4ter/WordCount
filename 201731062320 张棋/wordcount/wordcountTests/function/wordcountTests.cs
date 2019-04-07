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
    public class wordcountTests
    {
        [TestMethod()]
        public void sum1Test()
        {
            Dictionary<string, int> frequencies = new Dictionary<string, int>();
            frequencies.Add("word1", 1);
           
            Assert.AreEqual(1, wordcount.sum1(frequencies));
         //   Assert.Fail();
        }

        [TestMethod()]
        public void CountwordTest()
        {
            path.s = @"D:\se.txt";
            Dictionary<string, int> frequencies = new Dictionary<string, int>();
            frequencies.Add("word1",1);
            Assert.AreEqual(wordcount.Countword(),frequencies);
          //  Assert.Fail();
        }
    }
}