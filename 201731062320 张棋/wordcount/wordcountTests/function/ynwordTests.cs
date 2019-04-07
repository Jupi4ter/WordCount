using Microsoft.VisualStudio.TestTools.UnitTesting;
using wordcount.function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordcount.function.Tests
{
    [TestClass()]
    public class ynwordTests
    {
        [TestMethod()]
        public void ynword1Test()
        {


            string[] n = { "word1" };
            string[] newword = { "word1" };
            int w = 1;
            string[] test = ynword.ynword1(n, ref w);
            
            Assert.AreEqual(newword,test );
           // Assert.Fail();
        }
    }
}