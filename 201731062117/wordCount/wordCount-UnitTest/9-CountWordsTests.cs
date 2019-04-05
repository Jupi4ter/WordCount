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
    public class CountWordsTests1
    {
        [TestMethod()]
        public void CountwordsTest()
        {
            string str = "acdvf huyg bhhgcgv 78hhv 9ijhg 哈哈哈 hhhh 7777 jjjj jjjj";
            CountWords countWords = new CountWords();
            int real = countWords.Countwords(str);
            int expect = 6;
            Assert.AreEqual(real, expect);
        }
    }
}