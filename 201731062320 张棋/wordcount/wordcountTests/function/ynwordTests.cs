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
    public class ynwordTests
    {
        [TestMethod()]
        public void ynword1Test()
        {
            string[] words = { "123", "word1","word2" };
            int o = 0;
           string [] test= ynword.ynword1(words, ref o);
            string[] newword = { "word1","word2" };
            Assert.AreEqual(newword, ynword.ynword1(words, ref o));
           // Assert.Fail();
        }
    }
}