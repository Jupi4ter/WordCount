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
    public class CountWordsTests
    {
        [TestMethod()]
        public void CountwordsTest()
        {
            string str = "abcd2 Adgdg gggg A4fgtf jhufd 含电话v lovejx97 " +
                "99999 gggg gggg hgyfv 09ibj jhnbh abcd2 abcd3 abc";
            CountWords countWords = new CountWords();
            int real = countWords.Countwords(str);
            int expect = 11;
            Assert.AreEqual(real, expect);
        }
    }
}