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
    public class TopWordsTests
    {
        [TestMethod()]
        public void ToptenwordsTest()
        {
            TopWords topWords = new TopWords();
            string[] str = { "abcd2", "Adgdg", "gggg", "jhufd", "lovejx97", "abcd2"};
            string real = topWords.Toptenwords(str);
            string expect = "abcd2 (2)\r\nAdgdg (1)\r\ngggg (1)\r\njhufd (1)\r\nlovejx97 (1)\r\n";
            Assert.AreEqual(real, expect);
        }
    }
}