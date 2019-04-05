using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using ClassLibrary9;

namespace ConsoleApp6
{
    public class Program
    {
        /*static void StatisticsCount(string a)//统计字符数函数
        {
            try
            {
                StreamReader sR = File.OpenText(@"C:\wordCount\" + a);
                string str = sR.ReadToEnd();
                Console.WriteLine("characters: " + str.Length);
            }
            catch
            {
                Console.WriteLine("文件路径不存在");
            }
        }
        static void Statisticswords(string a)//统计单词个数函数
        {
            try
            {
                StreamReader sR = File.OpenText(@"C:\wordCount\" + a);
                string str = sR.ReadToEnd();
                string[] str2 = Regex.Split(str, @"\W");
                int num = 0;
                int num1 = 0;
                int length;
                length = str2.Length;
                for (int j = 0; j < length; j++)
                {
                    num1 = Regex.Matches(str2[j], @"^[A-Za-z]{4,}").Count;
                    num += num1;
                }
                Console.WriteLine("words: " + num);
                sR.Close();
            }
            catch
            {
                Console.WriteLine("文件路径不存在");
            }
        }
        static void Statisticsline(string a)//统计行数函数
        {
            try
            {
                string fileName = @"C:\wordCount\" + a;
                StreamReader sR = new StreamReader(fileName, Encoding.Default);
                String str;
                int num = 0;
                while ((str = sR.ReadLine()) != null)
                {
                    ;
                    if (str.Equals(""))
                    { }
                    else
                        num = num + 1;
                }
                Console.WriteLine("lines: " + num);
                sR.Close();
            }
            catch
            {
                Console.WriteLine("文件路径不存在");
            }
        }
        static void Statisticsword(string a, string b, int c)//统计单词数量并排序
        {
            try
            {
                StreamReader sR = File.OpenText(@"C:\wordCount\" + a);
                try
                {
                    StreamWriter sW = new StreamWriter(@"C:\wordCount\" + b, true, Encoding.UTF8);
                    string str = sR.ReadToEnd();
                    string[] str2 = Regex.Split(str, @"\W");
                    string[] str3 = new string[1000];
                    string[] word = new string[100];
                    string str4;
                    int[] wordnum = new int[100];
                    int num = 0;
                    int num1 = 0;
                    int length;
                    length = str2.Length;
                    for (int i = 0; i < length; i++)
                    {
                        if (Regex.IsMatch(str2[i], @"^[A-Za-z]{4,}"))
                        {
                            str3[num] = str2[i];
                            num++;
                        }
                    }
                    foreach (var kv in str3
                        .GroupBy(x => x)
                        .OrderBy(x => x.Key))
                    {
                        if (kv.Key != null)
                        {
                            word[num1] = kv.Key.ToLower();
                            wordnum[num1] = kv.Count();
                            num1++;
                        }
                    }
                    for (int j = 0; j < num1; j++)
                    {
                        for (int k = j; k < num1; k++)
                        {
                            if (wordnum[j] < wordnum[k + 1])
                            {
                                num = wordnum[j];
                                wordnum[j] = wordnum[k + 1];
                                wordnum[k + 1] = num;
                                str4 = word[j];
                                word[j] = word[k + 1];
                                word[k + 1] = str4;
                            }
                            else if (wordnum[j] == wordnum[k + 1] && string.Compare(word[j], word[k + 1]) == 1)
                            {
                                str4 = word[j];
                                word[j] = word[k + 1];
                                word[k + 1] = str4;
                            }
                        }
                    }
                    try
                    {
                        for (int i = 0; i < c; i++)
                        {
                            Console.WriteLine("<" + word[i].ToLower() + ">" + ": " + wordnum[i]);
                            sW.WriteLine(word[i], wordnum[i]);
                        }
                        sR.Close();
                    }
                    catch
                    {
                        Console.WriteLine("c值过大，可能超出了界限");
                    }
                }
                catch
                {
                    Console.WriteLine("文件名格式有错");
                }
            }
            catch
            {
                Console.WriteLine("文件路径不存在");
            }
        }
        static void StatisticswordGroup(string a, int b)//统计词组数函数
        {
            try
            {
                StreamReader sR = File.OpenText(@"C:\wordCount\" + a);
                SortedList<string, int> list = new SortedList<string, int>();
                string str = sR.ReadToEnd();
                string[] str2 = Regex.Split(str, @"\W");
                string[] str3 = new string[1000];
                string str4;
                int num = 0;
                int length = str2.Length;
                for (int i = 0; i < length; i++)
                {
                    if (Regex.IsMatch(str2[i], @"^[A-Za-z]{4,}"))
                    {
                        str3[num] = str2[i];
                        num++;
                    }
                }
                for (int i = 0; i < num - 2; i++)
                {
                    str4 = str3[i] + " " + str3[i + 1] + " " + str3[i + 2];
                    if (!list.ContainsKey(str4))
                    {
                        list.Add(str4, 1);
                    }
                    else
                        list[str4] += 1;
                }
                num = 0;
                foreach (KeyValuePair<string, int> sv in list)
                {
                    Console.WriteLine(sv.Key + ": " + sv.Value);
                    num++;
                    if (num == b)
                        break;
                }
            }
            catch
            {
                Console.WriteLine("文件路径不存在");
            }
        }*/
        static void OpFetch(string[] inputs)//操作信息收集函数
        {
            int a = 0;
            int b = 0;
            int c = 0;
            int d = 0;
            for (int i = 0; i < inputs.Length - 1; i++)
            {
                switch (inputs[i])
                {
                    case "-i":
                        b = i + 1;
                        i++;
                        break;
                    case "-o":
                        a = i + 1;
                        i++;
                        break;
                    case "-m":
                        c = i + 1;
                        i++;
                        break;
                    case "-n":
                        d = i + 1;
                        i++;
                        break;
                    default:
                        Console.WriteLine("无此指令");
                        break;
                }
            }
            ClassLibrary9.Class1.StatisticsCount(inputs[b]);
            ClassLibrary9.Class1.Statisticswords(inputs[b]);
            ClassLibrary9.Class1.Statisticsline(inputs[b]);
            if (c != 0)
            {
                ClassLibrary9.Class1.StatisticswordGroup(inputs[b], Convert.ToInt32(inputs[c]));
            }
            if (d != 0)
            {
                ClassLibrary9.Class1.Statisticsword(inputs[b], inputs[a], Convert.ToInt32(inputs[d]));
            }

        }
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(" ".ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);
            OpFetch(inputs);
        }
    }
}
