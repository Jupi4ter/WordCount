using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestDll
{
    public class ClassLibrary
    {
        //统计字符数
        public static int CharacterCount(string fileContent)
        {
            return fileContent.Length;
        }

        //为有效单词列表赋值并统计单词数
        public static int WordCount(out List<string> validWords, string fileContent)
        {
            validWords = new List<string>();
            string[] tempWords = fileContent.Split(new char[] { '\n', ' ', ',', ';',':','\r' });
            foreach (string i in tempWords)
            {
                if (i.Length >= 4 && Regex.IsMatch(i.Substring(0, 4), @"^[A-Za-z]+$") && Regex.IsMatch(i.Trim(), "^[0-9a-zA-Z]+$"))
                {
                    validWords.Add(i.ToLower().Trim());
                }
            }
            return validWords.Count;
        }

        //统计文件中各单词的出现次数
        public static Dictionary<string, int> EachWordCount(List<string> vaildWords)
        {
            Dictionary<string, int> wordsDictionary = new Dictionary<string, int>();
            for (int i = 0; i < vaildWords.Count; i++)
            {
                if (!wordsDictionary.ContainsKey(vaildWords[i]))
                {
                    wordsDictionary.Add(vaildWords[i], 1);
                }
                else
                {
                    wordsDictionary[vaildWords[i]] += 1;
                }
            }

            return wordsDictionary;
        }
    }
}
