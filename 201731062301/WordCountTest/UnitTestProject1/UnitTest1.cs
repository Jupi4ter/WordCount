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
        }
        [TestMethod]
        public void TestCountWords()
        {
            string str = "Abcd aa abcd";
            List<string> list = new List<string>();
            string[] wordsArr1 = Regex.Split(str.ToLower(), "\\s*[^0-9a-zA-Z]+");
            foreach (string word in wordsArr1)
            {
                if (Regex.IsMatch(word, "^[a-zA-Z]{4,}[a-zA-Z0-9]*"))
                {
                    list.Add(word);
                }
            }
            Assert.AreEqual(WordsList.CountWords(str), list.Count);
        }
    }
}
