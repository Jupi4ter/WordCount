using System;
using System.Collections.Generic;
using System.Linq;
using CountAscii;
using CountLine;
using Count;
using LengthDeterminingPhrases;
using OutputWorddll;
using PrintWord;
using System.IO;
using System.Text.RegularExpressions;
namespace example1
{
    public class Test
    {
        CountASCII ca = new CountASCII();
        CountLDP cldp = new CountLDP();
        CountLINE cl = new CountLINE();
        Countword cw = new Countword();
        Outputword ow = new Outputword();
        PrintResult pr = new PrintResult();

        public void Set(string[] orders)
        {
            string txtInputPath = "";
            int pharaseLength = 0;
            int wordNumnerMax = 0;
            string txtOutputPath = "";


            for (int i = 0; i < orders.Length; i = i + 2)
            {
                switch (orders[i])
                {
                    case "-i":
                        {
                            txtInputPath = orders[i + 1];
                            //Console.WriteLine(txtInputPath);
                            break;
                        }
                    case "-m":
                        {
                            pharaseLength = Convert.ToInt32(orders[i + 1]);
                            break;
                        }
                    case "-n":
                        {
                            wordNumnerMax = Convert.ToInt32(orders[i + 1]);
                            break;
                        }
                    case "-o":
                        {
                            txtOutputPath = orders[i + 1];
                            //Console.WriteLine(txtInputPath);
                            break;
                        }
                    
                    default: break;
                }
            }
            //调用函数，传入参数，将结果存入指定文本即可。
            pr.PrintWord(ca.CountAscii(txtInputPath), cl.CountLine(txtInputPath), cw.CountWord(txtInputPath), ow.OutputWord(txtInputPath, wordNumnerMax), cldp.LengthDeterminingPhrases(txtInputPath, pharaseLength), txtOutputPath);
            
        }
        //调用函数，传入参数，将结果存入指定文本即可。
        public void Set(string msg)
        {
            if (msg == "help")
            {
                Console.WriteLine("功能说明书:");
                Console.WriteLine("-i 后跟参数代表程序读取文件的路径");
                Console.WriteLine("-m 后跟参数代表程序返回词组的长度");
                Console.WriteLine("-n 后跟参数代表程序返回单词的个数");
                Console.WriteLine("-o 后跟参数代表程序保存文件的路径");
                Console.WriteLine("例: WordCount.exe -i test.txt -m 2 -n 5 -o save.txt");
                Console.WriteLine("代表程序读取路径为test.txt, 返回词组长度为2, 返回单词个数为5, 结果保存路径为save.txt");
            }
           
        }
    }
    public class program
    {

        static void Main(string[] args)
        {
            Test t = new Test();

            if (args.Length > 1)
            {
                t.Set(args);
            }
            else if (args.Length == 1)
            {
                t.Set(args[0]);
            }
            else
            {
                Console.WriteLine("没有获取命令行参数");
            }
            
            Console.ReadKey();

        }
    }
}

