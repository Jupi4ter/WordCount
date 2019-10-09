using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CountLine;

namespace testCountLine
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CountLINE countLINE = new CountLINE();
            Assert.AreEqual(countLINE.CountLine(@"C:\Users\15476\Desktop\tset files\test-CountLine\test1.txt"), 2);
            Assert.AreEqual(countLINE.CountLine(@"C:\Users\15476\Desktop\tset files\test-CountLine\test2.txt"), 0);
            Assert.AreEqual(countLINE.CountLine(@"C:\Users\15476\Desktop\tset files\test-CountLine\test3.txt"), 4);
            Assert.AreEqual(countLINE.CountLine(@"C:\Users\15476\Desktop\tset files\test-CountLine\test4.txt"), 2);
            Assert.AreEqual(countLINE.CountLine(@"C:\Users\15476\Desktop\tset files\test-CountLine\test5.txt"), 1);
            Assert.AreEqual(countLINE.CountLine(@"C:\Users\15476\Desktop\tset files\test-CountLine\test6.txt"), 5);
            Assert.AreEqual(countLINE.CountLine(@"C:\Users\15476\Desktop\tset files\test-CountLine\test7.txt"), 4);
            Assert.AreEqual(countLINE.CountLine(@"C:\Users\15476\Desktop\tset files\test-CountLine\test8.txt"), 10);
            Assert.AreEqual(countLINE.CountLine(@"C:\Users\15476\Desktop\tset files\test-CountLine\test9.txt"), 1);
            Assert.AreEqual(countLINE.CountLine(@"C:\Users\15476\Desktop\tset files\test-CountLine\test10.txt"), 2);
        }
    }
}
