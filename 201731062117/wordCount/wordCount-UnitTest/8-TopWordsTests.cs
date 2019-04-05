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
    public class TopWordsTests2
    {
        [TestMethod()]
        public void TopnwordsTest()
        {
            TopWords topWords = new TopWords();
            string[] str = { "abcd2", "Adgdg", "gggg", "jhufd", "lovejx97", "abcd2" };
            string real = topWords.Topnwords(str,3);
            string expect = "abcd2 (2)\r\nAdgdg (1)\r\ngggg (1)\r\n";
            Assert.AreEqual(real, expect);
        }
    }
}