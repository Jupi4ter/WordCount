using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCount;

namespace TestDll.Tests
{
    [TestClass()]
    public class ClassLibraryTests
    {
        [TestMethod()]
        public void CharacterCountTest()
        {
          Assert.IsTrue(ClassLibrary.CharacterCount("1") == 1);
          Assert.IsTrue(ClassLibrary.CharacterCount("12") == 2);
          Assert.IsTrue(ClassLibrary.CharacterCount("12 ") == 3);
          Assert.IsTrue(ClassLibrary.CharacterCount("12 \n") == 4);
          Assert.IsTrue(ClassLibrary.CharacterCount("12 \n \r") == 6);
          Assert.IsTrue(ClassLibrary.CharacterCount("厉害") == 2);
          Assert.IsTrue(ClassLibrary.CharacterCount("!@#$%^&*") == 8);
          Assert.IsTrue(ClassLibrary.CharacterCount("~()_+{}:") == 8);
          Assert.IsTrue(ClassLibrary.CharacterCount("<>?:,./`") == 8);
          Assert.IsTrue(ClassLibrary.CharacterCount("") == 0);
          

        }

        [TestMethod()]
        public void WordGroupCountTest()
        {
            List<string> tempList;
            string fileContent1 = "a b c d e";
            string fileContent2 = "word ";
            string fileContent3 = "word word";
            string fileContent4 = "word character count";
            string fileContent5 = "word character count output";
            Assert.IsTrue(ClassLibrary.WordGroupCount(out tempList, fileContent1, 1) == 0);
            Assert.IsTrue(ClassLibrary.WordGroupCount(out tempList, fileContent2, 1) == 1);
            Assert.IsTrue(ClassLibrary.WordGroupCount(out tempList, fileContent3, 1) == 2);
            Assert.IsTrue(ClassLibrary.WordGroupCount(out tempList, fileContent4, 2) == 2);
            Assert.IsTrue(ClassLibrary.WordGroupCount(out tempList, fileContent5, 3) == 2);

        }
        [TestMethod()]
        public void EachWordCountTest()
        {
            List<string> words = new List<string>();
            words.Add("aaaa");
            words.Add("aaaa");
            words.Add("aaaa");
            words.Add("bbbb");
            words.Add("bbbb");
            words.Add("bbbb");
            words.Add("cccc");
            words.Add("cccc");
            words.Add("dddd");
            words.Add("eeee");
            words.Add("eeee");
            Dictionary<string, int> keyValuePairs = ClassLibrary.EachWordCount(words);
            Assert.IsTrue(keyValuePairs["aaaa"] == 3);
            Assert.IsTrue(keyValuePairs["bbbb"] == 3);
            Assert.IsTrue(keyValuePairs["cccc"] == 2);
            Assert.IsTrue(keyValuePairs["dddd"] == 1);
            Assert.IsTrue(keyValuePairs["eeee"] == 2);
  
        }
    }
}