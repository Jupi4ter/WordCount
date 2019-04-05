using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using Char_Number;
using _Frequencies;
using Word_Number;
using _Sort;
using _Statistic;
using _LimitOut;

namespace ConsoleApplication9
{
    class Program
    {
        static void Main(string[] args)
        {
            //默认参数
            string in_mess = @"input.txt";
            string out_mess = @"output.txt";
            int wordLength = 2;
            int wordCount = 3;

           if (args.Length > 0) // 判断输入参数   
            {
                switch (args[0])
                {
                    case "-i":
                        in_mess = args[1];
                        break;
                    case "-m":
                        wordLength = int.Parse(args[1]);
                        break;
                    case "-n":
                        wordCount = int.Parse(args[1]);
                        break;
                    case "-o":
                        out_mess = args[1];
                        break;
                }
                if (args.Length > 2)
                    switch (args[2])
                    {
                        case "-i":
                            in_mess = args[3];
                            break;
                        case "-m":
                            wordLength = int.Parse(args[3]);
                            break;
                        case "-n":
                            wordCount = int.Parse(args[3]);
                            break;
                        case "-o":
                            out_mess = args[3];
                            break;
                    }
                if (args.Length > 4)
                    switch (args[4])
                    {
                        case "-i":
                            in_mess = args[5];
                            break;
                        case "-m":
                            wordLength = int.Parse(args[5]);
                            break;
                        case "-n":
                            wordCount = int.Parse(args[5]);
                            break;
                        case "-o":
                            out_mess = args[5];
                            break;
                    }
                if (args.Length > 6)
                    switch (args[6])
                    {
                        case "-i":
                            in_mess = args[7];
                            break;
                        case "-m":
                            wordLength = int.Parse(args[7]);
                            break;
                        case "-n":
                            wordCount = int.Parse(args[7]);
                            break;
                        case "-o":
                            out_mess = args[7];
                            break;
                    }
            }
            CharNumber.charNumber(in_mess, out_mess);//统计字符数&行数
            WordNumber.wordNumber(in_mess, out_mess);//统计单词数
            Dictionary<string, int> frequencies = Frequencies.frequencies(in_mess);//统计词频
            sort.Sort(frequencies, out_mess);//排序

            //如果输入词组长度，则输出统计结果
            if (wordLength != 0)
            {
                Statistic.statistic(frequencies, out_mess, wordLength);
            }
            //如果设定输出的单词数量，则输出统计结果
            if (wordCount != 0)
            {
                limitOut.LimitOut(frequencies, wordCount, out_mess);
            }
        }
    }
}
