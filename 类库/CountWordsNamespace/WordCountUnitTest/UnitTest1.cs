using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CountWordsNamespace;

namespace WordCountUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string path = @"D:\软件工程\WordCount\201731062329\wordCount\wordCount\bin\Debug\input.txt";
            WordNumber words = new WordNumber(path);
            StringAssert.Contains("2", words.wordNumber().ToString());
        }
    }
}
