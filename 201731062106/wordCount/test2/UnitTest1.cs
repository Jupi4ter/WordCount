using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using wordCount;

namespace test2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string str = "";
            string str1 = @"E:\3\git\second\WordCount\201731062106\input.txt";
            string str2 = @"E:\3\git\second\WordCount\201731062106\output.txt";
            Init.File(str1,str2);
            FileStream fs = new FileStream(str1, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(str1);
            StringBuilder sb = new StringBuilder();
            while (sr.Peek() >= 0)           
            {
                sb.AppendLine(sr.ReadLine());
            }

            str = sb.ToString();
            sr.Close();
            fs.Close();
            Assert.AreEqual(str,"abcd123"+"\r\n");
        }
    }
}
