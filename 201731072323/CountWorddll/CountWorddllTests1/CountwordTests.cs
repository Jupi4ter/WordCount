using Microsoft.VisualStudio.TestTools.UnitTesting;
using Countword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countword.Tests
{
    [TestClass()]
    public class CountwordTests
    {
        [TestMethod()]
        //CountWord function test
        public void CountWordTest()
        {
            Countword cw = new Countword();
            //abcd --- 1;
            Assert.AreEqual(cw.CountWord(@"C:\Users\Administrator.WIN-4K5HDJFV5BS\Desktop\软件工程作业\WordCount\201731072323\CountWorddll\Test1.txt"), 1);

            //ABCD --- 1
            Assert.AreEqual(cw.CountWord(@"C:\Users\Administrator.WIN-4K5HDJFV5BS\Desktop\软件工程作业\WordCount\201731072323\CountWorddll\Test2.txt"), 1);

            //ABCD abcd --- 1
            Assert.AreEqual(cw.CountWord(@"C:\Users\Administrator.WIN-4K5HDJFV5BS\Desktop\软件工程作业\WordCount\201731072323\CountWorddll\Test3.txt"), 1);

            //123abcd abcd123 --- 1
            Assert.AreEqual(cw.CountWord(@"C:\Users\Administrator.WIN-4K5HDJFV5BS\Desktop\软件工程作业\WordCount\201731072323\CountWorddll\Test4.txt"), 1);

            //abcd@efgh qwer --- 3
            Assert.AreEqual(cw.CountWord(@"C:\Users\Administrator.WIN-4K5HDJFV5BS\Desktop\软件工程作业\WordCount\201731072323\CountWorddll\Test5.txt"), 3);

            //abcd%ABCD&AbCd --- 1
            Assert.AreEqual(cw.CountWord(@"C:\Users\Administrator.WIN-4K5HDJFV5BS\Desktop\软件工程作业\WordCount\201731072323\CountWorddll\Test6.txt"), 1);

            //1234 --- 0
            Assert.AreEqual(cw.CountWord(@"C:\Users\Administrator.WIN-4K5HDJFV5BS\Desktop\软件工程作业\WordCount\201731072323\CountWorddll\Test7.txt"), 0);

            //@#$% --- 0
            Assert.AreEqual(cw.CountWord(@"C:\Users\Administrator.WIN-4K5HDJFV5BS\Desktop\软件工程作业\WordCount\201731072323\CountWorddll\Test8.txt"), 0);

            //abc123 abcd1 --- 1
            Assert.AreEqual(cw.CountWord(@"C:\Users\Administrator.WIN-4K5HDJFV5BS\Desktop\软件工程作业\WordCount\201731072323\CountWorddll\Test9.txt"), 1);

            //!@#abcde*() --- 1
            Assert.AreEqual(cw.CountWord(@"C:\Users\Administrator.WIN-4K5HDJFV5BS\Desktop\软件工程作业\WordCount\201731072323\CountWorddll\Test10.txt"), 1);

        }
    }
}