using System;
using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Librarytest
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            string str1 = "abcdefg@123456 248";
            string str2 = "123!!!2456阿姨";
            string str3 = "123456789";
            string str4 = "aaaa!!c23!!ddddd@ee";
            string word = "";
            //对返回字符数函数进行测试

            Assert.AreEqual(CNUM.GetCnum(str1), 18);
            Assert.AreEqual(CNUM.GetCnum(str2), 10);
            Assert.AreEqual(CNUM.GetCnum(str3), 9);
            //对返回单词函数进行测试和对返回词频函数进行测试
            Assert.AreEqual(WNUM.GetWnum(str1,ref word),1);
            Assert.AreEqual(STRNUM.GetStr(word), "abcdefg:1"+"\r\n");
            //
            word = "";
            Assert.AreEqual(WNUM.GetWnum(str2,ref word),0);
            Assert.AreEqual(STRNUM.GetStr(word), "");
            //
            word = "";
            Assert.AreEqual(WNUM.GetWnum(str3,ref word),0);
            Assert.AreEqual(STRNUM.GetStr(word), "");
            //
            word = "";
            Assert.AreEqual(WNUM.GetWnum(str4,ref word),2);
            Assert.AreEqual(STRNUM.GetStr(word), "aaaa:1"+"\r\n"+"ddddd:1"+"\r\n");
        }
    }
}
