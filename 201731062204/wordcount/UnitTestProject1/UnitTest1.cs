using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;
using ClassLibrary2;
using ClassLibrary3;
using ClassLibrary4;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Class1 class1 = new Class1();
            string word = File.ReadAllText(@"C:\Users\hdkj\Desktop\test.txt").ToLower();//将输入的英文字符全部转换为小写字符
            class1.countChar(word);
        }
        public void TestMethod2()
        {
            Class2 class2 = new Class2();
            string word = File.ReadAllText(@"C:\Users\hdkj\Desktop\test.txt").ToLower();//将输入的英文字符全部转换为小写字符
            class2.Countword(word);
        }
        public void TestMethod3()
        {
            Class3 class3 = new Class3();
            string word = File.ReadAllText(@"C:\Users\hdkj\Desktop\test.txt").ToLower();//将输入的英文字符全部转换为小写字符
            class3.Countlines();
        }
        public void TestMethod4()
        {
            Class4 class4 = new Class4();
            string word = File.ReadAllText(@"C:\Users\hdkj\Desktop\test.txt").ToLower();//将输入的英文字符全部转换为小写字符
            class4.frequency(word);
        }
    }
}
