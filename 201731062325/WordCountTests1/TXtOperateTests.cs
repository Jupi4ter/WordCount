using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount.Tests
{
    [TestClass()]
    public class TXtOperateTests
    {
        [TestMethod()]
        public void IswordsTest()
        {
            string path = "good123";
            Assert.IsNotNull(TXtOperate.Iswords(path));
            //Assert.Fail();
        }

        [TestMethod()]
        public void CountCharTest()
        {
            string str = "Hello world!I am a boy.";
            int count = str.Length;
            Assert.AreEqual(TXtOperate.CountChar(str), count);
            string str1 = "";
            Assert.AreEqual(TXtOperate.CountChar(str1), str1.Length);
            //Assert.Fail();
        }

        [TestMethod()]
        public void CountSumofWordsTest()
        {
            string path = "Hello world!I am a boy.";
            Assert.AreEqual(2,TXtOperate.CountSumofWords(path));
            //Assert.Fail();
        }
    }
}