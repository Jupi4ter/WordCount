using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutputWorddll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputWorddll.Tests
{
    [TestClass()]
    public class OutputwordTests
    {
        [TestMethod()]
        //OutputWord function test
        public void OutputWordTest()
        {
            Outputword ow = new Outputword();
            Dictionary<string, int> dic = new Dictionary<string, int>();

            //abcd -- abcd:1
            dic.Add("abcd", 1);
            Assert.AreEqual(ow.OutputWord(@"C:\Users\Administrator.WIN-4K5HDJFV5BS\Desktop\软件工程作业\WordCount\201731072323\OutputWorddll\Test1.txt", 1).ToString(), dic.ToString());
            dic.Clear();

            //ABCD qwer abcd
            //ABCD:2
            //qwer:1
            dic.Add("ABCD", 2);
            dic.Add("qwer", 1);
            Assert.AreEqual(ow.OutputWord(@"C:\Users\Administrator.WIN-4K5HDJFV5BS\Desktop\软件工程作业\WordCount\201731072323\OutputWorddll\Test2.txt", 2).ToString(), dic.ToString());
            dic.Clear();

            //1234 abcd -- abcd:1
            dic.Add("abcd", 1);
            Assert.AreEqual(ow.OutputWord(@"C:\Users\Administrator.WIN-4K5HDJFV5BS\Desktop\软件工程作业\WordCount\201731072323\OutputWorddll\Test3.txt", 2).ToString(), dic.ToString());
            dic.Clear();

            //1234@abcd -- abcd:1
            dic.Add("abcd", 1);
            Assert.AreEqual(ow.OutputWord(@"C:\Users\Administrator.WIN-4K5HDJFV5BS\Desktop\软件工程作业\WordCount\201731072323\OutputWorddll\Test4.txt", 2).ToString(), dic.ToString());
            dic.Clear();

            //abcd123 abcd
            //abcd123:1
            //abcd:1
            dic.Add("abcd123", 1);
            dic.Add("abcd", 1);
            Assert.AreEqual(ow.OutputWord(@"C:\Users\Administrator.WIN-4K5HDJFV5BS\Desktop\软件工程作业\WordCount\201731072323\OutputWorddll\Test5.txt", 2).ToString(), dic.ToString());
            dic.Clear();

            //ABCD abcd ABCD --ABCD:3
            dic.Add("abcd", 3);
            Assert.AreEqual(ow.OutputWord(@"C:\Users\Administrator.WIN-4K5HDJFV5BS\Desktop\软件工程作业\WordCount\201731072323\OutputWorddll\Test6.txt", 3).ToString(), dic.ToString());
            dic.Clear();

            /*abcd
             * abcd*/
            //abcd:2
            dic.Add("abcd", 2);
            Assert.AreEqual(ow.OutputWord(@"C:\Users\Administrator.WIN-4K5HDJFV5BS\Desktop\软件工程作业\WordCount\201731072323\OutputWorddll\Test7.txt", 2).ToString(), dic.ToString());
            dic.Clear();

            //@#$%  null
            Assert.AreEqual(ow.OutputWord(@"C:\Users\Administrator.WIN-4K5HDJFV5BS\Desktop\软件工程作业\WordCount\201731072323\OutputWorddll\Test8.txt", 1).ToString(), dic.ToString());
            dic.Clear();

            //abcd qwer ABCD --abcd:2
            dic.Add("abcd", 2);
            Assert.AreEqual(ow.OutputWord(@"C:\Users\Administrator.WIN-4K5HDJFV5BS\Desktop\软件工程作业\WordCount\201731072323\OutputWorddll\Test9.txt", 1).ToString(), dic.ToString());
            dic.Clear();

            /*abcd qwer
             * ABCD*/
            //abcd:2
            dic.Add("abcd", 2);
            Assert.AreEqual(ow.OutputWord(@"C:\Users\Administrator.WIN-4K5HDJFV5BS\Desktop\软件工程作业\WordCount\201731072323\OutputWorddll\Test10.txt", 1).ToString(), dic.ToString());
            dic.Clear();
        }
    }
}