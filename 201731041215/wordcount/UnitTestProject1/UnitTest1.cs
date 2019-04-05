using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//导入dll文件
using WY;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Function f = new Function(@"C:\Users\Administrator\Desktop\WY\WordCount\201731041215\wordcount\wordcount\test.txt");
            //运行先行函数
            f.GetChar();
            f.ExtractChar();
            f.ToLow();
            f.Statistical();
            //断言测试
            Assert.AreEqual(f.WordsNum(), 11);
            Assert.AreEqual(f.CharNum(), 91);
        }
    }
}
