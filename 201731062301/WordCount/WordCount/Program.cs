using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using Words;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int countLine = 0;
            string str = "";
            string path = "";
            int phraseNum = 0;
            int wordFreNum = 0;
            // 判断输入参数
            for (int i = 0; i < args.Length; i += 2)    
            {
                switch (args[i])
                {
                    /* -i 参数设定读入文件的路径*/
                    case "-i":
                        path = args[i + 1];
                        break;
                    /* -m 参数设定的词组长度*/
                    case "-m":
                        phraseNum = int.Parse(args[i + 1]);
                        break;
                    /* -n 参数设定输出单词数量*/
                    case "-n":
                        wordFreNum = int.Parse(args[i + 1]);
                        break;
                    /* -o 参数设定生成文件的存储路径*/
                    case "-o":
                        break;
                }
            }
            //当文件路径存在时
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
                        sw.WriteLine("Characters:" + WordsList.CountChar(str));
                        sw.WriteLine("Lines: " + countLine);
                        sw.WriteLine("Words:" + WordsList.CountWords(str));
                        //如果有-n参数且有大于零的输入，调用PutNwords函数
                        if (wordFreNum>0)
                        {
                            sw.WriteLine("输出频率前"+wordFreNum+"的词组：");
                            Dictionary<string, int> item = PutNwords(str).OrderByDescending(r => r.Value).ThenBy(r => r.Key).ToDictionary(r => r.Key, r => r.Value);
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
                        if(phraseNum > 0)
                        {
                            sw.WriteLine("输出长度为" + phraseNum + "的词组：");
                            Dictionary<string, int> item = PhraseFre(str,phraseNum).OrderByDescending(r => r.Value).ThenBy(r => r.Key).ToDictionary(r => r.Key, r => r.Value);
                            foreach (KeyValuePair<string, int> entry in item)
                            {
                                string word = entry.Key;
                                int frequency = entry.Value;
                                sw.WriteLine(word + ":" + frequency);
                            }
                        }
                        sw.Flush();//关闭流
                        sw.Close();
                        Console.WriteLine("文件已创建在：" + args[i + 1]);
                    }
                }
            }
            else Console.WriteLine("没有文件路径或文件不存在！");
        }
        //输出前n多的单词数量与其词频
        public static Dictionary<string, int> PutNwords(string path)
        {
            List<string> list = new List<string>();
            list = WordsList.Judge(path);
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
        //词组个数
        private static Dictionary<string,int> PhraseFre(string path,int n)
        {

            List<string> list = new List<string>();
            //list是符合单词要求单词的集合
            list = WordsList.Judge(path);
            Dictionary<string, int> frequencies = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase); string s = "";
            //将长度为n的词组当成一个字符串
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
