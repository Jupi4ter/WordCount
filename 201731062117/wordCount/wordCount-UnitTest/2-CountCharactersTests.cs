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
    public class CountCharactersTests
    {
        [TestMethod()]
        public void CountcharactersTest()
        {
            string str = "abcd2 Adgdg gggg A4fgtf jhufd 含电话v lovejx97 " +
                "99999 gggg gggg hgyfv 09ibj jhnbh abcd2 abcd3 abc";
            CountCharacters countCharacters = new CountCharacters();
            int real = countCharacters.Countcharacters(str);
            int expect = 90;
            Assert.AreEqual(real, expect);
        }
    }
}