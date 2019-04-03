using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using wordCount;

namespace LineNumberUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            FileOperate fileOperate = new FileOperate(@"D:\软件工程\WordCount\201731062329" +
              @"\wordCount\wordCount\bin\Debug\input.txt");
            string num = fileOperate.lineNumber().ToString();
            StringAssert.Contains("4", num);
        }
    }
}
