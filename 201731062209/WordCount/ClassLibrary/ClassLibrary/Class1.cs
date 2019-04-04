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
        public static int WordGroupCount(out List<string> validWords, string fileContent,int groupLength)
        {
            validWords = new List<string>();
            string[] tempWords = fileContent.Split(new char[] { '\n','\r', ' ', ',', ';',':','.','?','!' });
            for (int i = 0; i < tempWords.Length - groupLength+1; i++)
            {
                string[] group = new string[groupLength];
                for (int j = i,k=0; j <= i + group.Length-1; j++,k++)
                {
                    group[k] = tempWords[j];                  
                }
                if (IsVaildWordGroup(group))
                {
                    string tempWordGroup = "";
                    for (int k = 0;k<group.Length;k++)
                    {
                        tempWordGroup += group[k] + " ";
                    }
                        validWords.Add(tempWordGroup.ToLower().Trim());
                }
            }
            return validWords.Count;
        }
        //判断是否为有效词组
        public static bool IsVaildWordGroup(string[] wordGroup)
        {
            for (int i = 0; i < wordGroup.Length; i++)
            {
                if (!IsVaildWord(wordGroup[i]))
                {
                    return false;
                }
            }
            return true;
        }

        //判断是否为有效单词
        public static bool IsVaildWord(string word)
        {
            if (word.Length >= 4 && Regex.IsMatch(word.Substring(0, 4), @"^[A-Za-z]+$") && Regex.IsMatch(word.Trim(), "^[0-9a-zA-Z]+$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //统计文件中各单词的出现次数
        public static Dictionary<string, int> EachWordCount(List<string> vaildWords)
        {
            Dictionary<string, int> wordsDictionary = new Dictionary<string, int>();
            for (int i = 0; i < vaildWords.Count; i++)
            {
                if (!wordsDictionary.ContainsKey(vaildWords[i]))                //如果wordsDictionary中没有保存该单词（词组）
                {
                    wordsDictionary.Add(vaildWords[i], 1);                      //就录入该单词（词组）并将对应的出现的次数value设为1
                }
                else
                {
                    wordsDictionary[vaildWords[i]] += 1;                        //如果已经录入就将出现的次数加一
                }
            }

            return wordsDictionary;
        }
    }
}
