using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using wordCount;

namespace CharNumerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            FileOperate fileOperate = new FileOperate(@"D:\软件工程\WordCount\201731062329"+
                @"\wordCount\wordCount\bin\Debug\input.txt");
            string num = fileOperate.charNumber().ToString();
            StringAssert.Contains("28", num);//StringAssert是个类
        }
    }
}
