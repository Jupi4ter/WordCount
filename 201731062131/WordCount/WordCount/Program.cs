using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            /*if (args.Length==0)
            {
                Console.Write("请重新输入参数后，再打开文件，按任意键结束程序");
                Console.ReadKey();
                return ;
            }*/
            //读取文件的所有字符到字符串中
            countword CountWord = new countword();
            //CountWord.OutPut(args[0]);
            CountWord.OutPut("d://1.txt");
            Console.ReadKey();
        }
    }
    class countword
    {
        private string FileTxt;
        Dictionary<string, int> dictionary = new Dictionary<string, int>();
        int[] Index=new int[] {0,0,0,0,0,0,0,0,0,0 };
        public void OutPut(string filepath)
        {
            FileTxt = File.ReadAllText(filepath);
            Console.WriteLine(FileTxt);
            //输出文件所有字符的个数
            Console.WriteLine("characters:" + FileTxt.Length);
            //输出单词个数
            Console.WriteLine("words:" + ComputeWords(FileTxt));
            //输出行数
            Console.WriteLine("lines:" + CountLines(filepath));
            //将单词分割出来
            SplitString(FileTxt);
            //计算单词出现次数
            ComputeWords(FileTxt);
            //统计单词出现次数
            string[] result = CountTimes();
            for(int i = 0; i < 10; i++)
            {
                if (Index[i] != 0)
                {
                    Console.WriteLine("<"+result[i]+">:"+Index[i]);
                }

            }
        }
        //读取txt文件中总行数的方法
        public int CountLines(String filepath)
        {
            Stopwatch sw = new Stopwatch();
            int lines = 0;
            //按行读取
            sw.Restart();
            using (var sr = new StreamReader(filepath))
            {
                string ls = "";
                //循环读取直到最后一行
                while ((ls = sr.ReadLine()) != null)
                {
                    //若是换行符行数不变
                    if (ls.Length != 0)
                        lines++;
                }
            }
            sw.Stop();
            return lines;
        }
        public int ComputeWords(string FileTxt)
        {
            int count = 0;
            int result = 0;
            int i = 0;
            //遍历整个文件字符串
            while (i<FileTxt.Length)
            {
                if(FileTxt[i] == '\n')
                {
                    FileTxt.Remove(i,1);
                }
                //若不是文件分隔符，则单词长度加1，否则判断前字符串是否是单词
                if(FileTxt[i]==' '||(FileTxt[i]>'0'&&FileTxt[i]<'9'))
                {
                    while ((FileTxt[i] > '0' && FileTxt[i] < '9'))
                    {
                        i++;
                        count++;
                    }
                    if (count >= 4)
                    {
                        result++;
                    }
                    if (FileTxt[i] == ' ')
                        count = 0;
                    else
                        count = 1;
                }
                else
                {
                    count++;
                }
                i++;
            }
            return result;
        }
        public string[] CountTimes()
        {
            //字典排序
            dictionary = dictionary.OrderBy(p => p.Value).ToDictionary(o => o.Key, p => p.Value);
            int temp = 0;
            //计数器计算string的下标
            int j = 0;
            //初始化索引数组
            string[] strings = new string[10];
            for (int i = 0; i < 10&&dictionary.Count>0; i++)
            {               
                //找到当前集合中出现频率最高的一个单词的索引
                foreach(int x in dictionary.Values)
                {
                    if (x > Index[i])
                    {
                        temp = j;
                        Index[i] = x;
                    }                        
                    j++;
                }
                j = 0;
                //遍历keys找到该索引处的字符串
                foreach(string s in dictionary.Keys)
                {
                    if (j == temp)
                    {
                        strings[i] = s;
                        break;
                    }                       
                    j++;
                }
                //在集合中删除对象
                dictionary.Remove(strings[i]);
                j = 0;
                temp = 0;
            }
            return strings;
        }



        public void SplitString(string FileTxt)
        {
            int i = 0;
            int Chars = 0;
            int count = 0;
            string temp=null;
            while (i < FileTxt.Length)
            {
                if(FileTxt[i] == ' ' || (FileTxt[i] > '0' && FileTxt[i] < '9'))
                {
                    while ((FileTxt[i] > '0' && FileTxt[i] < '9'))
                    {
                        i++;
                        Chars++;
                    }
                    //排除数字后面是一个空格和空格后面跟一个数字的情况
                    if (Chars != 0)
                    {
                        temp = FileTxt.Substring(i - Chars, Chars).ToLower();
                        if (dictionary.ContainsKey(temp))
                        {
                            dictionary.TryGetValue(temp, out count);
                            dictionary.Remove(temp);
                            dictionary.Add(temp, ++count);
                        }
                        else
                        {
                            if(temp.Length>=4)
                                dictionary.Add(temp, 1);
                        }
                        if (FileTxt[i] == ' ')
                            Chars = 0;
                        else
                            Chars = 1;
                    }                     
                }
                else
                {
                    Chars++;
                }
                i++;
            }
            //读取最后一个字符串
            if(FileTxt[i-1]!= ' '&&(FileTxt[i-1] < '0' || FileTxt[i-1] > '9'))
            {
                temp = FileTxt.Substring(i - Chars, Chars);
                if (dictionary.ContainsKey(temp))
                {
                    dictionary.TryGetValue(temp, out count);
                    dictionary.Remove(temp);
                    dictionary.Add(temp, ++count);
                }
                else
                {
                    if (temp.Length >= 4)
                        dictionary.Add(temp, 1);
                }
            }            
        }
    }
}
