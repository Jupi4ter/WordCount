using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;
using CountAscii;
using CountLine;
using LengthDeterminingPhrases;

namespace Word1
{
    class Print
    {

        public void PrintWord(int asciiNum, int wordNum, int lineNum, Dictionary<string, int> dictionary, Dictionary<string, int> dictionary1)
        {
            
            Console.WriteLine("characters: {0}", asciiNum);
            Console.WriteLine("words: {0}", wordNum);
            Console.WriteLine("lines: {0}", lineNum);
            dictionary.OrderByDescending(p => p.Key).ToDictionary(p => p.Key, o => o.Value);

            foreach (KeyValuePair<string, int> item in dictionary)
            {
                Console.WriteLine("{0} : {1} ", item.Key, item.Value);
            }
            foreach (KeyValuePair<string, int> item in dictionary1)
            {
                Console.WriteLine("{0} : {1} ", item.Key, item.Value);
            }

        }

    }
    public interface ICountWord
    {
        int CountWord(string filePath);
    }

    public class Word : ICountWord
    {
        public int CountWord(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("文件不存在！");
                return 0;
            }

            StreamReader sr = new StreamReader(filePath, System.Text.Encoding.UTF8);
            int wordNum = 0;

            string str = "";
            string[] word = null;
            List<string> res = new List<string>();
            List<int> num = new List<int>();


            try
            {

                string line = sr.ReadLine();

                while (line != null)
                {
                    str = str + line + " ";
                    line = sr.ReadLine();
                }

                word = Regex.Split(str, @"[^a-z|^A-Z|^0-9]", RegexOptions.IgnoreCase);

                for (int i = 0; i < word.Length; i++)
                {

                    if (word[i].Length >= 4 && Regex.IsMatch(word[i].Substring(0, 3), @"^[A-Za-z]"))
                    {
                        res.Add(word[i]);
                    }
                }
                for (int i = 0; i < res.Count; i++)
                {
                    for (int j = i + 1; j < res.Count; j++)
                    {
                        if ((res[j].ToLower() == res[i].ToLower()))
                        {
                            num.Add(j);
                        }
                    }
                }
                num = num.Distinct().ToList();
                num.Reverse();
                for (int i = 0; i < num.Count; i++)
                {
                    res.RemoveAt(num[i]);
                }
                wordNum = res.Count;

            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sr.Close();
            }
            return wordNum;

        }

        public string[] WordArr(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("文件不存在！");
                return null;
            }

            StreamReader sr = new StreamReader(filePath, System.Text.Encoding.UTF8);
            //int wordNum = 0;

            string str = "";
            string[] word = null;
            List<string> res = new List<string>();
            List<int> num = new List<int>();


            try
            {

                string line = sr.ReadLine();

                while (line != null)
                {
                    str = str + line + " ";
                    line = sr.ReadLine();
                }

                word = Regex.Split(str, @"[^a-z|^A-Z|^0-9]", RegexOptions.IgnoreCase);

                for (int i = 0; i < word.Length; i++)
                {

                    if (word[i].Length >= 4 && Regex.IsMatch(word[i].Substring(0, 3), @"^[A-Za-z]"))
                    {
                        res.Add(word[i]);
                    }
                }
                for (int i = 0; i < res.Count; i++)
                {
                    for (int j = i + 1; j < res.Count; j++)
                    {
                        if ((res[j].ToLower() == res[i].ToLower()))
                        {
                            num.Add(j);
                        }
                    }
                }
                num = num.Distinct().ToList();
                num.Reverse();
                for (int i = 0; i < num.Count; i++)
                {
                    res.RemoveAt(num[i]);
                }
                word = res.ToArray();

            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sr.Close();
            }
            return word;
        }

    }
    class C1
    {
        public Dictionary<string,int> OutputWord(string filePath, int outNumb)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("文件不存在！");
                return null;
            }

            StreamReader sr = new StreamReader(filePath, System.Text.Encoding.UTF8);
            int wordNum = 0;

            string str = "";
            string[] word = null;
            List<string> res = new List<string>();
            List<string> temp = new List<string>();
            List<int> num = new List<int>();
            List<int> freqNum = new List<int>();
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            try
            {

                string line = sr.ReadLine();

                while (line != null)
                {
                    str = str + line + " ";
                    line = sr.ReadLine();
                }

                word = Regex.Split(str, @"[^a-z|^A-Z|^0-9]", RegexOptions.IgnoreCase);

                for (int i = 0; i < word.Length; i++)
                {

                    if (word[i].Length >= 4 && Regex.IsMatch(word[i].Substring(0, 3), @"^[A-Za-z]"))
                    {
                        res.Add(word[i]);
                        temp.Add(word[i]);
                    }
                }
                
               
                for (int i = 0; i < res.Count-1; i++)
                {
                    for (int j = i + 1; j < res.Count; j++)
                    {
                        if ((res[j].ToLower() == res[i].ToLower()))
                        {
                            num.Add(j);
                        }
                    }
                }
                num = num.Distinct().ToList();
                num.Reverse();
                for (int i = 0; i < num.Count; i++)
                {
                    res.RemoveAt(num[i]);
                }
                for (int i = 0; i < res.Count; i++)
                {
                    wordNum = 0;
                    for (int j = i; j < temp.Count; j++)
                    {
                        if ((temp[j].ToLower() == res[i].ToLower()))
                        {
                            wordNum++;
                        }
                    }
                    freqNum.Add(wordNum);
                }

                for (int i = 0; i < res.Count; i++)
                {
                    dictionary.Add(res[i], freqNum[i]);
                }
               
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sr.Close();
            }
            return dictionary;
        }
    }
    class Test
    {


        static void Main(string[] args)
        {
            Word wd = new Word();
            C1 c = new C1();
            string txt = @"C:\Users\Administrator.WIN-4K5HDJFV5BS\Desktop\软件工程作业\WordCount\201731072323\123.txt";
            //Console.WriteLine("单词数:{0}", wd.CountWord(txt));
            CountASCII cs = new CountASCII();
            CountLINE cl = new CountLINE();
            CountLDP cldp = new CountLDP();

            Print pt = new Print();
            pt.PrintWord(cs.CountAscii(txt), wd.CountWord(txt), cl.CountLine(txt), c.OutputWord(txt, 3), cldp.LengthDeterminingPhrases(wd.WordArr(txt), 2));
            Console.ReadKey();
        }
    }
}


