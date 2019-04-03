using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
namespace Words
{
    public class WordsList
    {
        //统计字符个数
        public static int CountChar(string path)
        {
            int countChar = 0;
            countChar = path.Length;
            return countChar;
        }
        //对单词个数进行统计
        public static int CountWords(string path)
        {
            List<string> list = new List<string>();

            string[] wordsArr1 = Regex.Split(path.ToLower(), "\\s*[^0-9a-zA-Z]+");
            foreach (string word in wordsArr1)
            {
                if (Regex.IsMatch(word, "^[a-zA-Z]{4,}[a-zA-Z0-9]*"))
                {
                    list.Add(word);
                }
            }
            return list.Count;
        }
        //统计单词词频并输出前10
        public static void CountWordFre(string path)
        {
            List<string> list = new List<string>();
            string[] wordsArr1 = Regex.Split(path, "\\s*[^0-9a-zA-Z]+");
            foreach (string word in wordsArr1)
            {
                if (Regex.IsMatch(word, "^[a-zA-Z]{4,}[a-zA-Z0-9]*"))
                {
                    list.Add(word);
                }
            }
            Dictionary<string, int> frequencies = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            foreach (string word in list)
            {
                if (frequencies.ContainsKey(word))
                {
                    frequencies[word]++;
                }
                else
                    frequencies[word] = 1;
            }
            Dictionary<string, int> item = frequencies.OrderByDescending(r => r.Value).ThenBy(r => r.Key).ToDictionary(r => r.Key, r => r.Value);
            int size = 0;
            foreach (KeyValuePair<string, int> entry in item)
            {
                string word = entry.Key;
                int frequency = entry.Value;
                size++;
                if (size > 10)
                    break;
                Console.WriteLine(word + ":" + frequency);
            }
        }
    }
}

