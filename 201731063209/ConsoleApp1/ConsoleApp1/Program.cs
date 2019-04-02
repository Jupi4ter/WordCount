using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounts
{
    class Program
    {
        static void Main(string[] args)
        {
            CharNum charNum = new CharNum();
            WordNum wordNum = new WordNum();
            FileLines fileLine = new FileLines();
            string filePath = "input.txt";//默认文件为 input.txt
            int wordLength = 0;
            int wordCount = 0;
            string outFile = "";
            string outPut = "";
            if (args.Length > 0) // 判断输入参数   
            {
                switch (args[0])
                {
                    case "-i":
                        filePath = args[1];
                        //读入的文件路径
                        break;
                    case "-m":
                        wordLength = int.Parse(args[1]);
                        //m个单词组成一个词组
                        break;
                    case "-n":
                        wordCount = int.Parse(args[1]);
                        //输出出现次数最多的前worldCount个单词
                        break;
                    case "-o":
                        outFile = args[1];
                        //生成的文件路径
                        break;
                }
                if (args.Length > 2)
                    switch (args[2])
                    {
                        case "-i":
                            filePath = args[3];
                            break;
                        case "-m":
                            wordLength = int.Parse(args[3]);
                            break;
                        case "-n":
                            wordCount = int.Parse(args[3]);
                            break;
                        case "-o":
                            outFile = args[3];
                            break;
                    }
                if (args.Length > 4)
                    switch (args[4])
                    {
                        case "-i":
                            filePath = args[5];
                            break;
                        case "-m":
                            wordLength = int.Parse(args[5]);
                            break;
                        case "-n":
                            wordCount = int.Parse(args[5]);
                            break;
                        case "-o":
                            outFile = args[5];
                            break;
                    }
                if (args.Length > 6)
                    switch (args[6])
                    {
                        case "-i":
                            filePath = args[7];
                            break;
                        case "-m":
                            wordLength = int.Parse(args[7]);
                            break;
                        case "-n":
                            wordCount = int.Parse(args[7]);
                            break;
                        case "-o":
                            outFile = args[7];
                            break;
                    }


                outPut += "characters:" + charNum.getCharCount(filePath) + "\n";
                outPut += "words:" + wordNum.getWordCount(filePath) + "\n";
                outPut += "lines:" + fileLine.getFileLineCount(filePath) + "\n";

                wordNum.getWordCount(filePath, wordLength);//先调用方法把单词处理完成   
                Dictionary<string, int> dict = wordNum.getLinq();//再调用排序 

                int i = 10;
                if (wordCount != 0)
                    i = wordCount;
                foreach (KeyValuePair<string, int> kvp in dict)
                {
                    if (i == 0)
                        break;
                    else
                    {
                        outPut += "<" + kvp.Key + ">:" + kvp.Value + "\n";
                        i--;
                    }
                }
                if (outFile == "")
                {
                    Console.WriteLine(outPut);
                }
                else
                {
                    FileStream fs = new FileStream(outFile, FileMode.Create);
                    //获得字节数组
                    byte[] data = System.Text.Encoding.Default.GetBytes(outPut);
                    //开始写入
                    fs.Write(data, 0, data.Length);
                    //清空缓冲区、关闭流
                    fs.Flush();
                    fs.Close();
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("参数输入错误!");
            }


        }
    }
}
