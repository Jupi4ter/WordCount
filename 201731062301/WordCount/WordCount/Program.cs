using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            Console.WriteLine("Characters: " + CountChar(path));
            Console.WriteLine("Lines: " + CountLine(path));
            Console.WriteLine("Words: " + CountWords(path));
            CountWordFre(path);
            OutPut(path);
            Console.ReadLine();
        }
        //统计字符个数
        public static int CountChar(string path)
        {
            int countChar = 0;
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path, Encoding.Default);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    countChar += line.Length;
                }
                sr.Close();
            }
            return countChar;
        }
        //对单词个数进行统计
        public static int CountWords(string path)
        {
            List<string> list = new List<string>();
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path, Encoding.Default);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] wordsArr1 = Regex.Split(line.ToLower(), "\\s*[^0-9a-zA-Z]+");
                    foreach (string word in wordsArr1)
                    {
                        if (Regex.IsMatch(word, "^[a-zA-Z]{4,}[a-zA-Z0-9]*"))
                        {
                            list.Add(word);
                        }
                    }
                }
                sr.Close();
            }
            return list.Count;
        }
        //对行数进行统计
        public static int CountLine(string path)
        {
            int countLine = 0;
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path, Encoding.Default);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    countLine++;
                }
                sr.Close();
            }
            return countLine;
        }
        //统计单词词频并输出前10
        public static void CountWordFre(string path)
        {
            List<string> list = new List<string>();
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path, Encoding.Default);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] wordsArr1 = Regex.Split(line, "\\s*[^0-9a-zA-Z]+");
                    foreach (string word in wordsArr1)
                    {
                        if (Regex.IsMatch(word, "^[a-zA-Z]{4,}[a-zA-Z0-9]*"))
                        {
                            list.Add(word);
                        }
                    }
                }
                sr.Close();
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
        //输出到文件
        public static void OutPut(string path)
        {
            List<string> list = new List<string>();
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path, Encoding.Default);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] wordsArr1 = Regex.Split(line.ToLower(), "\\s*[^0-9a-zA-Z]+");
                    foreach (string word in wordsArr1)
                    {
                        if (Regex.IsMatch(word, "^[a-zA-Z]{4,}[a-zA-Z0-9]*") && !(list.Contains(word)))
                        {
                            list.Add(word);
                        }
                    }
                }
                sr.Close();
            }
            list.Sort();
            string path1 = "output.txt";
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
