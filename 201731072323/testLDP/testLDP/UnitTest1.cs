using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LengthDeterminingPhrases;
namespace testLDP
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            CountLDP countLDP = new CountLDP();
            Dictionary<string, int> temp1 = new Dictionary<string, int>
            {
                { "monday tuesday wednesday", 2 },
                { "tuesday wednesday monday", 1 },
                { "wednesday monday tuesday", 1 }
            };
            Dictionary<string, int> temp2 = new Dictionary<string, int>();
            temp2 = countLDP.LengthDeterminingPhrases(@"C:\Users\15476\Desktop\tset files\test-LengthDeterminingPhrases\test1.txt", 3);
            Assert.AreEqual(temp1.ToString(),temp2.ToString());

            Dictionary<string, int> temp3 = new Dictionary<string, int>
            {
                { "monday tuesday",1},
                { "tuesday wednesday",1}
            };
            Dictionary<string, int> temp4 = new Dictionary<string, int>();
            temp4 = countLDP.LengthDeterminingPhrases(@"C:\Users\15476\Desktop\tset files\test-LengthDeterminingPhrases\test2.txt", 2);
            Assert.AreEqual(temp3.ToString(), temp4.ToString());

            Dictionary<string, int> temp5 = new Dictionary<string, int>
            {
                 { "monday tuesday wednesday Friday", 1}
            };
            Dictionary<string, int> temp6 = new Dictionary<string, int>();
            temp6 = countLDP.LengthDeterminingPhrases(@"C:\Users\15476\Desktop\tset files\test-LengthDeterminingPhrases\test3.txt", 4);
            Assert.AreEqual(temp5.ToString(), temp6.ToString());

            Dictionary<string, int> temp7 = new Dictionary<string, int>
            {

                { "monday tuesday wednesday Friday", 1 },
                { "tuesday wednesday Friday Thursday", 1 }
            };
            Dictionary<string, int> temp8 = new Dictionary<string, int>();
            temp8 = countLDP.LengthDeterminingPhrases(@"C:\Users\15476\Desktop\tset files\test-LengthDeterminingPhrases\test4.txt", 4);
            Assert.AreEqual(temp7.ToString(), temp8.ToString());

            Dictionary<string, int> temp9 = new Dictionary<string, int>
            {

                { "monday", 1 },
                { "tuesday", 1 }
            };
            Dictionary<string, int> temp10 = new Dictionary<string, int>();
            temp10 = countLDP.LengthDeterminingPhrases(@"C:\Users\15476\Desktop\tset files\test-LengthDeterminingPhrases\test5.txt", 1);
            Assert.AreEqual(temp9.ToString(), temp10.ToString());

            Dictionary<string, int> temp11 = new Dictionary<string, int>
            {
                { "monday tuesday wednesday monday tuesday", 1 }
            };
            Dictionary<string, int> temp12 = new Dictionary<string, int>();
            temp12 = countLDP.LengthDeterminingPhrases(@"C:\Users\15476\Desktop\tset files\test-LengthDeterminingPhrases\test6.txt", 5);
            Assert.AreEqual(temp11.ToString(), temp12.ToString());

            Dictionary<string, int> temp13 = new Dictionary<string, int>
            {
                { "monday tuesday wednesday monday tuesday wednesday", 1 }
            };
            Dictionary<string, int> temp14 = new Dictionary<string, int>();
            temp14 = countLDP.LengthDeterminingPhrases(@"C:\Users\15476\Desktop\tset files\test-LengthDeterminingPhrases\test7.txt", 6);
            Assert.AreEqual(temp13.ToString(), temp14.ToString());

            Dictionary<string, int> temp15 = new Dictionary<string, int>
            {
                { "monday tuesday", 3},
                { "tuesday wednesday", 3 },
                { "wednesday monday", 2 },
                { "wednesday wednesday", 1 },
            };
            Dictionary<string, int> temp16 = new Dictionary<string, int>();
            temp16 = countLDP.LengthDeterminingPhrases(@"C:\Users\15476\Desktop\tset files\test-LengthDeterminingPhrases\test8.txt", 2);
            Assert.AreEqual(temp15.ToString(), temp16.ToString());

            Dictionary<string, int> temp17 = new Dictionary<string, int>
            {
                { "wednesday", 2 }
            };
            Dictionary<string, int> temp18 = new Dictionary<string, int>();
            temp18 = countLDP.LengthDeterminingPhrases(@"C:\Users\15476\Desktop\tset files\test-LengthDeterminingPhrases\test9.txt", 1);
            Assert.AreEqual(temp17.ToString(), temp18.ToString());

            Dictionary<string, int> temp19 = new Dictionary<string, int>
            {
                { "wednesday wednesday", 1 }
            };
            Dictionary<string, int> temp20= new Dictionary<string, int>();
            temp20 = countLDP.LengthDeterminingPhrases(@"C:\Users\15476\Desktop\tset files\test-LengthDeterminingPhrases\test10.txt", 2);
            Assert.AreEqual(temp19.ToString(), temp20.ToString());



            //handing of exceptions

            //the file is not exisit
            Dictionary<string, int> temp21 = new Dictionary<string, int>();
            temp21 = countLDP.LengthDeterminingPhrases(@"C:\Users\15476\Desktop\tset files\test-LengthDeterminingPhrases\test.txt", 1);
            Assert.AreEqual(temp21,null);

            //Given length greater than array length
            Dictionary<string, int> temp22 = new Dictionary<string, int>();
            temp22 = countLDP.LengthDeterminingPhrases(@"C:\Users\15476\Desktop\tset files\test-LengthDeterminingPhrases\test10.txt",20);
            Assert.AreEqual(temp22,null);
        }
    }
}
