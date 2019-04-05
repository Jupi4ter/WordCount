using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using WordCount;

namespace UnitTestWordCount
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestcharactersNum() //统计字符总数
        {
            string text = "abcdefg";
            int chNum = Program.charactersNum(text);
            Assert.IsTrue(chNum == 7);
        }
        [TestMethod]
        public void TestwordsNum()      //统计单词总数
        {
            string text = "With the development of Chinese economy";
            int wordsNum = Program.wordsNum(text).Count;
            Assert.IsTrue(wordsNum == 4);
        }
        [TestMethod]
        public void TestlinesNum()      //统计总行数
        {
            string text = "With the \r\n development \r\n of Chinese economy";
            int lines = Program.linesNum(text);
            Assert.IsTrue(lines == 3);
        }
        [TestMethod]
        public void TestlmaxFrequency()      //统计单词频率
        {
            string text = File.ReadAllText(@"C:\Users\95388\Desktop\C#\WordCount\WordCount\obj\Debug\input.txt").ToLower();
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic.Add("chinese", 6);
            dic.Add("more", 4);
            dic.Add("different", 3);
            dic.Add("language", 3);
            dic.Add("them", 3);
            dic.Add("there", 3);
            dic.Add("they", 3);
            dic.Add("foreigners", 2);
            dic.Add("history", 2);
            dic.Add("learn", 2);
            List<string> wordList = Program.wordsNum(text);
            Dictionary<string, int> di = Program.wordFrequency(wordList);
            Dictionary<string, int> d = Program.maxFrequency(di, 10);   //最高频率的10个单词及其出现频率
            Assert.IsTrue(d.Count>0);
        }
    }
}
