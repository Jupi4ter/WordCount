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
    public class IsWordTests
    {
        [TestMethod()]
        public void IswordTest()
        {
            IsWord isWord = new IsWord();
            bool expect = true;
            bool real = isWord.Isword("abcd2");
            Assert.AreEqual(real, expect);
        }
    }
}