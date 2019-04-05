using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WORDCOUNT;

namespace TestWORDCOUNT
{
    [TestClass]
    public class UnitTest1
    {
        

        [TestMethod()]
        public void MainTest01()
        {
            string test;
            Program.Result trueres = new Program.Result();
            string reason;
            test = "123abcd";
            trueres.charactersnumber = 7;
            trueres.wordsnumber = 0;
            trueres.linesnumber = 1;
            reason = "测试用例1";
            UnitTest(test, trueres, reason);

        }
        
        [TestMethod()]
        public void MainTest02()
        {
            string test;
            Program.Result trueres = new Program.Result();
            string reason;
            test = "abcd abcd@abcd";
            trueres.charactersnumber = 14;
            trueres.wordsnumber = 3;
            trueres.linesnumber = 1;
            reason = "测试用例2";
            UnitTest(test, trueres, reason);
        }
        
        [TestMethod()]
        public void MainTest03()
        {
            string test;
            Program.Result trueres = new Program.Result();
            string reason;
            test = "abcd\n\nabcd";
            trueres.charactersnumber = 8;
            trueres.wordsnumber = 2;
            trueres.linesnumber = 2;
            reason = "测试用例3";
            UnitTest(test, trueres, reason);
        }
        
        [TestMethod()]
        public void MainTest04()
        {
            string test;
            Program.Result trueres = new Program.Result();
            string reason;
            test = "abcd123";
            trueres.charactersnumber = 7;
            trueres.wordsnumber = 1;
            trueres.linesnumber = 1;
            reason = "测试用例4";
            UnitTest(test, trueres, reason);
        }
        
        public void UnitTest(string test, Program.Result trueres, string reason)
        {
            FileStream fs = null;
            StreamWriter sw = null;
            bool result = false;
            string pathinput = "F:\\Demo.txt";
            Program.Result testres = new Program.Result();
            result = false;
            fs = new FileStream(pathinput, FileMode.Create);
            sw = new StreamWriter(fs);
            sw.WriteLine(test);
            sw.Close();
            fs.Close();
            testres = Program.Maintest();
            result =
                (testres.charactersnumber == trueres.charactersnumber) &&
                (testres.wordsnumber == trueres.wordsnumber) &&
                (testres.linesnumber == trueres.linesnumber);
            Assert.AreEqual(true, result, reason);
        }
    }
}
