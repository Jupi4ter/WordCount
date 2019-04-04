using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Test3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WordCount word = new WordCount();
            string message = "";
            while (message != "exit")
            {
                message = Console.ReadLine();
                string[] MessageSplit = message.Split(' ');
                int MLength = MessageSplit.Length;
                string[] sParameter = new string[MLength - 1];
                for (int i = 0; i < MLength - 1; i++)
                {
                    sParameter[i] = MessageSplit[i];
                }
                string sFilename = MessageSplit[MLength - 1];
                word.Operator(sParameter, sFilename);
                word.Count(sFilename);
                word.Display();
            }
        }

        public class WordCount
        {
            private string sFilename;                   //文件名
            private string[] sParameter;                //参数
            private int iChar;                          //字符数
            private int iWord;                          //单词数
            private int iLine;                          //总行数
            //判断输入命令是否合法
            public void Operator(string[] sParameter, string sFilename)
            {
                this.sParameter = sParameter;
                this.sFilename = sFilename;
                foreach (string xchar in sParameter)
                {
                    if (xchar == "-c" || xchar == "-w" || xchar == "-l")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("参数{0}不存在", xchar);
                        break;
                    }
                }
            }
            //统计字符数、单词数、总行数
            public void Count(string name) 
            {
                try
                {
                    FileStream fs = new FileStream(name, FileMode.Open, FileAccess.Read, FileShare.Read);
                    StreamReader sr = new StreamReader(fs);
                    fs.Position = 0;
                    iChar = (int)fs.Length;
                    string streamToString = sr.ReadToEnd();
                    iLine = streamToString.Split('\n').Length;
                    streamToString = Regex.Replace(streamToString, "[^\u4e00-\u9fa5a-zA-z0-9.].*?", " ");
                    streamToString = Regex.Replace(streamToString, "\\s{2,}", " ");
                    iWord = streamToString.Split(' ', ',').Length;
                    sr.Close();
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
            //最终结果显示
            public void Display()
            {
                StreamWriter f = new StreamWriter(@"output.txt", false);
                foreach (string a in sParameter)
                {
                    if (a == "-c")
                        f.WriteLine("characters:{0}", iChar);
                    if (a == "-w")
                        f.WriteLine("words:{0}", iWord);
                    if (a == "-l")
                        f.WriteLine("lines:{0}", iLine);
                }
                f.Close();
                Console.ReadKey();
            }
        }
    }
}
