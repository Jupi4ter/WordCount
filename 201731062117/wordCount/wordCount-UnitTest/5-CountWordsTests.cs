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
    public class CountWordsTests2
    {
        [TestMethod()]
        public void GetwordsTest()
        {
            string str = "abcd2 Adgdg gggg A4fgtf jhufd 含电话v lovejx97 ";
            CountWords countWords = new CountWords();
            string[] real = countWords.Getwords(str);
            string[] expect = { "abcd2", "Adgdg", "gggg" , "jhufd", "lovejx97" };
            for(int i=0;i<real.Length;i++)
            {
                Assert.AreEqual(real[i], expect[i]);
            }
        }
    }
}