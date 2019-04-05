using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using System.Diagnostics;

namespace WordCount
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //args = new string[] { "-i", "input.txt","-o","out.txt","-n","3","-m","2" };//测试代码
            int countLine = 0;
            string str = "";
            string path = "";
            int phraseNum = 0;
            int wordFreNum = 0;
            for (int i = 0; i < args.Length; i += 2)
            {
                if (args[i].StartsWith("-"))
                {
                    switch (args[i])
                    {
                        case "-m":
                            phraseNum = int.Parse(args[i + 1]);
                            break;
                        case "-n":
                            wordFreNum = int.Parse(args[i + 1]);
                            break;
                        case "-help":
                            Console.WriteLine("-------------------**********-------------------");//分隔线
                            Console.WriteLine("词频管理命令行程序(v2.0)帮助界面：\t");
                            Console.WriteLine("作者：Admin,其保留对该程序的所有权利");
                            Console.WriteLine("-------------------**********-------------------");//分隔线
                            Console.WriteLine("参数说明：");
                            Console.WriteLine("使用-i参数设定读入的文件路径       （必要）     格式：-i [file]");
                            Console.WriteLine("使用-o参数设定生成文件的存储路径   （必要）     格式：-o [file]");
                            Console.WriteLine("使用-m参数设定统计的词组长度       （非必要）   格式：-m [number]");
                            Console.WriteLine("使用-n参数设定输出的单词数量       （非必要）   格式：-n [number]");
                            Console.WriteLine("参数顺序对结果没有影响。");
                            break;
                        case "-i":
                            path = args[i + 1];
                            break;
                        case "-o":
                            break;
                        default:
                            Console.WriteLine("命令行参数输入错误，请重新输入！");
                            Console.WriteLine("命令输入格式为：exename.exe -[命令代号] [命令对应内容]，命令使用可无序。但-i和-o命令是必须的");
                            Console.WriteLine("要查看有关命令行参数的更多内容，请在exe可执行文件后输入-help命令！");
                            break;
                    }
                }
            }
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path, Encoding.Default);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    countLine++;
                    str += line + "\n";
                }
                sr.Close();
                str = str.Trim();
                //如果含有-o参数 将显示内容输出到文件中
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] == "-o")
                    {
                        FileStream fs = new FileStream(args[i + 1], FileMode.Create);
                        StreamWriter sw = new StreamWriter(fs);
                        sw.WriteLine("Characters:" + TXtOperate.CountChar(str));
                        sw.WriteLine("Lines: " + countLine);
                        sw.WriteLine("Words:" + TXtOperate.CountSumofWords(str));
                        //如果有-n参数且有大于零的输入，调用PutNwords函数
                        if (wordFreNum > 0)
                        {
                            Dictionary<string, int> item = CountWord(str).OrderByDescending(r => r.Value).ThenBy(r => r.Key).ToDictionary(r => r.Key, r => r.Value);
                            int size = 0;
                            foreach (KeyValuePair<string, int> entry in item)
                            {
                                string word = entry.Key;
                                int frequency = entry.Value;
                                size++;
                                if (size > wordFreNum)
                                    break;
                                sw.WriteLine(word + ":" + frequency);
                            }
                        }
                        //如果有-n参数且大于零的输入，则调用phraseNum函数
                        if (phraseNum > 0)
                        {
                            Dictionary<string, int> item = CountPhrase(str, phraseNum).OrderByDescending(r => r.Value).ThenBy(r => r.Key).ToDictionary(r => r.Key, r => r.Value);
                            foreach (KeyValuePair<string, int> entry in item)
                            {
                                string word = entry.Key;
                                int frequency = entry.Value;
                                sw.WriteLine(word + ":" + frequency);
                            }
                        }
                        sw.Flush();//关闭流
                        sw.Close();
                        Console.WriteLine("文件已创建成功！");
                    }
                }
            }
            Console.ReadKey();
        }
        /// <summary>
        /// 单词词频输出
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Dictionary<string, int> CountWord(string path)
        {
            List<string> list = new List<string>();
            list = TXtOperate.Iswords(path);
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
            return frequencies;
        }
        /// <summary>
        /// 词组词频输出
        /// </summary>
        /// <param name="path"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private static Dictionary<string, int> CountPhrase(string path, int n)
        {
            List<string> list = new List<string>();//存储符合要求的单词集合
            list = TXtOperate.Iswords(path);
            Dictionary<string, int> frequencies = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase); string s = "";//将长度为n的词组存入字符串
            for (int i = 0; i <= list.Count - n; i++)
            {
                int j;
                for (s = list[i], j = 0; j < n - 1; j++)
                {
                    s += " " + list[i + j + 1];
                }
                if (frequencies.ContainsKey(s))
                {
                    frequencies[s]++;
                }
                else
                    frequencies[s] = 1;
            }
            return frequencies;
        }
    }
}
  