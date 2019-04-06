using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Linq;
using wordcount.function;

namespace wordcount
{
    class Program
    {
        /// <param name="s">文件读入路径</param>
        /// <param name="sum">单词总量</param>
        /// <param name="temp">记录频数</param>
        static void Main(string[] args)
        {
            int temp = 0;
            int max = 0;
            int len = 0;
            if (args.Count() != 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] == "-i") path.s = args[++i];
                    else if (args[i] == "-n") max = Convert.ToInt32(args[++i]);
                    else if (args[i] == "-o") path.outputpath = args[++i];
                    else if (args[i] == "-m")
                    {
                       len = Convert.ToInt32(args[++i]);
                    }
                }
                if (path.s == null || path.outputpath == null)
                {
                    Console.WriteLine("路径不正确，文件不存在");
                }
            }
            // string s = Console.ReadLine();
            else
            {

                string s = @"D:\se.txt";
                path.s = s;
                max = 10;
                string s1 = @"D:\xe.txt";
                path.outputpath = s1;
            }
            
            Dictionary<string, int> frequencies = function.wordcount.Countword();//调用wordcount中方法统计单词
            Dictionary<string, int> dic1Asc = frequencies.OrderBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);//按照字典序进行排序
            int sum = function.wordcount.sum1(dic1Asc);//计算出单词总数量
            Console.WriteLine("字符数:"+asccount. asccounts());//计算出字符数量
            Console.WriteLine("单词总数:" + sum);
            Console.WriteLine("行数:"+linescount. lines());//计算出行数
            
            //先按照出现次数排序，如果次数相同按照字典序排序
            Dictionary<string, int> dic1Asc1 = frequencies.OrderByDescending(o => o.Value).ThenBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);
            foreach (KeyValuePair<string, int> entry in dic1Asc1)
            {
                if (temp == max)
                    break;
                string word = entry.Key;
                int frequency = entry.Value;
                temp++;
                
                Console.WriteLine("{0}:{1}", word, frequency);
            }
            Console.ReadKey();
        }
    }

}
