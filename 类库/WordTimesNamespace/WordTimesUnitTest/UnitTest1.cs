using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordTimesNamespace;
using System.Collections.Generic;

namespace WordTimesUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            WordTimes wordTimes = new WordTimes(@"D:\软件工程\WordCount\201731062329\wordCount\wordCount\bin\Debug\input.txt");
            Dictionary<string, int> result = null;//用于存储返回的结果
            result = wordTimes.wordTimes();
            int i = 0;
            foreach(KeyValuePair<string,int> temp in result)
            {
                i++;
                switch(i)
                {
                    case 1:
                        StringAssert.Contains("abcd5: 1", temp.Key + ": " + temp.Value);
                        break;
                    case 2:
                        StringAssert.Contains("kkkk: 1", temp.Key + ": " + temp.Value);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
