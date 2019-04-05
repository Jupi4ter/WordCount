using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace WordCount
{
    public class Program
    {
        static void Main(string[] args)
        {
            string inputPath = @"C:\Users\95388\Desktop\C#\WordCount\WordCount\obj\Debug\input.txt";         //作为输入文件的路径
            string outputPath = @"C:\Users\95388\Desktop\C#\WordCount\WordCount\obj\Debug\output.txt";       //作为输出文件的路径
            int m = 0;                              //词组单词个数
            int n = 10;                             //需要统计最高频率输出的单词个数

            if(args.Length == 4)                    //命令行参数只有-i与-o参数时
            {
                inputPath = args[1];
                outputPath = args[3];
            }
            else                                    //命令行参数不止有-i与-o参数时
            {
                for(int i=0;i<args.Length;i++)
                {
                    if (string.Equals(args[i], "-i"))//获取-i参数
                        inputPath = args[i + 1];
                    if (string.Equals(args[i], "-o"))//获取-o参数
                        outputPath = args[i + 1];
                    if (string.Equals(args[i], "-m"))//获取-m参数
                        m = int.Parse(args[i + 1]);
                    if (string.Equals(args[i], "-n"))//获取-n参数
                        n = int.Parse(args[i + 1]);
                }
            }
            string text = File.ReadAllText(inputPath).ToLower();                    //读取文本内容并全部转成小写字母
            int ch = charactersNum(text);                                           //所有字符总数
            List<string> wordList = wordsNum(text);                                 //字符串中所有单词集合（包括重复的单词）
            Dictionary<string, int> d = maxFrequency(wordFrequency(wordList), n);   //最高频率的10个单词及其出现频率
            int word = wordList.Count;                                              //所有单词总数
            int nr = linesNum(text);                                                //行数
            //构造要输出的信息字符串
            string str = String.Format("characters:{0}\r\nwords:{1}\r\nlines:{2}\r\n",ch,word,nr);
            StringBuilder sb = new StringBuilder();
            foreach(string s in d.Keys)
            {
                sb.Append(string.Format("{0},频率:{1}\r\n", s, d[s]));
            }
            str += sb.ToString();
            //将字符串信息写入指定路径的文件
            fileWrite(outputPath, str);
        }
        /// <summary>
        /// 统计字符串中所有字符总数
        /// </summary>
        /// <param name="text">要统计字符数的字符串</param>
        /// <returns>字符总个数</returns>
        public static int charactersNum(string text)
        {
            int ch = 0;
            ch = Regex.Matches(text, @"[\S| ]").Count;
            return ch;
        }

        /// <summary>
        /// 统计字符串中所有单词总数
        /// </summary>
        /// <param name="text">要统计的字符串</param>
        /// <returns>返回一个储存了所有单词的集合包括重复的单词</returns>
        public static List<string> wordsNum(string text)
        {
            List<string> words = new List<string>();
            MatchCollection matches = Regex.Matches(text, @"[A-Za-z]{4}[A-Za-z0-9]*(\W|$)");
            foreach(Match match in matches)
            {
                words.Add(match.Value);
            }
            return words;
        }

        /// <summary>
        /// 统计字符串中文本行数
        /// </summary>
        /// <param name="text">要统计的字符串</param>
        /// <returns>字符串行数</returns>
        public static int linesNum(string text)
        {
            int lines = 0;
            lines = Regex.Matches(text, @"\r").Count + 1;
            return lines;
        }

        /// <summary>
        /// 统计一个集合中单词出现的频率
        /// </summary>
        /// <param name="wordList">单词的集合</param>
        /// <returns>返回一个字典储存了集合中单词与其出现频率</returns>
        public static Dictionary<string, int> wordFrequency(List<string> wordList)
        {
            Dictionary<string,int> dic = new Dictionary<string,int>();
            foreach(string s in wordList)               //遍历集合中每个单词
            {
                int val;
                if (dic.TryGetValue(s, out val))
                {
                    //如果指定的字典的键存在则将值+1
                    dic[s] += 1;
                }
                else
                {
                    //不存在，则添加
                    dic.Add(s, 1);
                }
            }
            return dic;
        }

        /// <summary>
        /// 找出单词字典中出现频率最高的n个单词
        /// </summary>
        /// <param name="dic">储存单词及出现频率的字典</param>
        /// <param name="n">需要输出单词个数</param>
        /// <returns>一个储存了频率最高的n个单词及其频率的字典</returns>
        public static Dictionary<string, int> maxFrequency(Dictionary<string, int> dic, int n)
        {
            Dictionary<string, int> d = new Dictionary<string, int>();
            //判断需要的单词个数是否超出总单词个数
            int x = 0;
            if (n <= dic.Count)
                x = n;
            else
                x = dic.Count;
            while(d.Count < x)
            {  
                List<string> l = new List<string>();    //多个单词有相同频率时储存至这个临时集合中按字典顺序排序
                int maxValue = dic.Values.Max(); ;      //字典中单词的最高频率
                foreach(string s in dic.Keys)
                {
                    if (dic[s] == maxValue)             //获取拥有最高频率的单词
                    {
                        l.Add(s);                       //添加至临时集合中
                    }
                }
                //将这一轮获取到的单词从原来的字典中删除
                foreach(string s in l)
                {
                    dic.Remove(s);
                }
                //给这一轮获取到的单词按字典顺序排序然后按顺序添加到一个新的字典中
                l.Sort(string.CompareOrdinal);
                foreach(string s in l)
                {
                    d.Add(s, maxValue);
                    if (d.Count >= x)                   //获取到足够数量的单词后退出
                        break;
                }
            }
            return d;
        }

        /// <summary>
        /// 将一个字符串写入指定路径的文件中
        /// </summary>
        /// <param name="path">指定路径的文件</param>
        /// <param name="str">要写入文件的字符串</param>
        public static void fileWrite(string path,string str)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(str);
            //写入信息完毕
            sw.Close();
            fs.Close();
        }
    }
}
