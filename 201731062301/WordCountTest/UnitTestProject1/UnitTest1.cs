using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Words;
using System.Text.RegularExpressions;
using System.Collections.Generic;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCountChar()
        {
            string str = "Abcd aa!";
            int count = str.Length;
            Assert.AreEqual(WordsList.CountChar(str), count);
            string str1 = "";
            Assert.AreEqual(WordsList.CountChar(str1), str1.Length);
        }
        [TestMethod]
        public void TestJudgeWords()
        {
            string str = null;
            Assert.IsNull(WordsList.Judge(str));
        }
        [TestMethod]
        public void TestCountWord()
        {
            string str = null;
            List<string> list = new List<string>();
            list = WordsList.Judge(str);
            Assert.IsNull(list);
        }
    }
}
