using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordCount
{
    public class TXtOperate
    {
        //判断单词是否符合要求，若符合用列表存储。
        public static List<string> Iswords(string path)
        {
            List<string> list = new List<string>();
            if (path == null)
            {
                list = null;
            }
            else
            {
                string[] wordsArr1 = Regex.Split(path, "\\s*[^0-9a-zA-Z]+");
                foreach (string word in wordsArr1)
                {
                    if (Regex.IsMatch(word, "^[a-zA-Z]{4,}[a-zA-Z0-9]*"))
                    {
                        list.Add(word);
                    }
                }
            }
            return list;
        }
        //统计字符个数
        public static int CountChar(string path)
        {
            int countChar = 0;
            countChar = path.Length;
            return countChar;
        }
        //对单词个数进行统计
        public static int CountSumofWords(string path)
        {
            List<string> list = new List<string>();
            list = Iswords(path);
            return list.Count;
        }
        //统计单词词频并输出前10
        public static void CountWordFre(string path)
        {
            List<string> list = new List<string>();
            list = Iswords(path);
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
        //写入文件
        public static void OutPut(string path)
        {
            List<string> list = new List<string>();
            list = Iswords(path);
            list.Sort();
            string path1 = "PaiXu.txt";
            FileStream fs = new FileStream(path1, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            foreach (string word in list)
            {
                sw.Write(word + " ");
            }
            sw.Flush();//关闭流
            sw.Close();
            fs.Close();
        }
    }
}
