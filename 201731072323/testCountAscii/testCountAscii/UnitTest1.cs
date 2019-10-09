using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CountAscii;
namespace testCountAscii
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CountASCII countASCII = new CountASCII();
            //test  blank txt
            Assert.AreEqual(countASCII.CountAscii(@"C:\Users\15476\Desktop\tset files\test-CountAscii\test1.txt"),0);
            //test one black and one Enter and one tab
            Assert.AreEqual(countASCII.CountAscii(@"C:\Users\15476\Desktop\tset files\test-CountAscii\test2.txt"),4);
            //test Chinese characters
           Assert.AreEqual(countASCII.CountAscii(@"C:\Users\15476\Desktop\tset files\test-CountAscii\test3.txt"), 13);
            //test Random files
            Assert.AreEqual(countASCII.CountAscii(@"C:\Users\15476\Desktop\tset files\test-CountAscii\test4.txt"), 24);

            //test one black
            Assert.AreEqual(countASCII.CountAscii(@"C:\Users\15476\Desktop\tset files\test-CountAscii\test5.txt"), 1);
            //test one tab
            Assert.AreEqual(countASCII.CountAscii(@"C:\Users\15476\Desktop\tset files\test-CountAscii\test6.txt"), 1);
            //test one enter
           Assert.AreEqual(countASCII.CountAscii(@"C:\Users\15476\Desktop\tset files\test-CountAscii\test7.txt"), 2);
            //test one word +enter+black
            Assert.AreEqual(countASCII.CountAscii(@"C:\Users\15476\Desktop\tset files\test-CountAscii\test8.txt"), 4);
            //test one word +enter+black+enter+tab+enter
           Assert.AreEqual(countASCII.CountAscii(@"C:\Users\15476\Desktop\tset files\test-CountAscii\test9.txt"), 9);
            //test Special characters
           Assert.AreEqual(countASCII.CountAscii(@"C:\Users\15476\Desktop\tset files\test-CountAscii\test10.txt"), 4);
        }
    }
}
