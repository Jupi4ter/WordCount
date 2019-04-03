using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CharNumberNamespace;

namespace CharNumberUnitTest
{
    [TestClass]
    public class CharNumberUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            string path = @"D:\软件工程\WordCount\201731062329\wordCount\wordCount\bin\Debug\input.txt";
            CharNumber num = new CharNumber(path);
            StringAssert.Contains("10", num.countChar().ToString());
        }
    }
}
