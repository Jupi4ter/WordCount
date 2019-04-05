using Microsoft.VisualStudio.TestTools.UnitTesting;
using wordCount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordCount.Tests
{
    [TestClass()]
    public class ReadTests
    {
        [TestMethod()]
        public void Read1Test()
        {
            Read read = new Read();
            string expect= "abcd2 Adgdg gggg A4fgtf jhufd 含电话v lovejx97 " +
                "99999 gggg gggg hgyfv 09ibj jhnbh abcd2 abcd3 abc";
            string real = read.Read1(@"E:\subject.txt");
            Assert.AreEqual(real, expect);
        }
    }
}