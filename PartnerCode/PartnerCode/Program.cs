using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WordCount;
using CharCount;
using WordGet;
using System.Net;
using System.Text.RegularExpressions;

namespace wordCount
{
    class TFile
    {
        public TFile()
        {

        }
        public TFile(string p)
        {
            fPath =p;
            this.lineCount = this.LineCount();
            CharCount.CharCount a = new CharCount.CharCount();//得到字符数
            WordCount.WordCount b = new WordCount.WordCount();//得到单词数
            WordGet.WordGet c = new WordGet.WordGet();//得到单词以及频率
            GetWord d = new GetWord();//得到单词，无排序
            this.charCount = a.func_CharCount(p);
            this.wordCount = b.func_WordCount(p);
            this.Word = c.func_WordGet(p);
            this.wordlist = d.Get_Word(p);
        }
        public string fPath;//文件路径
        public int lineCount;//文件行数
        public int charCount;//文件字符数
        public int wordCount;//文件单词数
        public SortedList Word;//文件中单词及其频率,按照值排序
        public List<string> wordlist;
        public int LineCount()
        {
            StreamReader sr = File.OpenText(fPath);
            int count = 0;
            string temp = sr.ReadLine();
            while (temp != null)
            {
                count++;
                temp = sr.ReadLine();
            }
            sr.Close();
            return count;
        }//获得文件行数
        public void OutPutToTxt(string file_name)
        {
            StreamWriter sw = new StreamWriter(file_name);  //打开输出流  
            for (int i = 1; i < this.Word.Count; i++)
            {
                string temp = (string)this.Word.GetKey(i);
                if (temp == null || temp.Equals(""))
                    continue;
                else
                {
                    sw.WriteLine("{0} {1} ", this.Word.GetKey(i), this.Word.GetByIndex(i));
                }
            }
            sw.Close();
        }//写入另一个文件
        public void Print()
        {
            Console.WriteLine("characters:" + charCount);
            Console.WriteLine("wordCount:" + wordCount);
            Console.WriteLine("lines", this.lineCount);
            string[][] a = new string[20][];
            foreach (string str in Word.GetKeyList())
            {
                Console.WriteLine(str + " " + Word[str]);
            }
        }
    }
   public class GetWord//得到单词无排序
    {
        public List<string> Get_Word(string file_name)
        {
            StreamReader sr_getword = new StreamReader(file_name);
            char[] delimiter = new char[] { '~', '`', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', ',', ' ', '>', '<', '?', '/', '\\' };
            string temp = sr_getword.ReadLine();
            List<string> line1 = new List<string>();
            while(temp!=null)
            {
                string[] line = temp.Split(delimiter);
                for(int i=0;i<line.Length;i++)
                line1.Add(line[i]);
                temp = sr_getword.ReadLine();
            }
            sr_getword.Close();
            return line1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入参数：");
            string[] str = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            TFile F = new TFile(str[1]);
            if (str.Length == 6)
            {
                if (str[2] == "-m")
                {
                    Console.WriteLine("characters:" + F.charCount);
                    Console.WriteLine("words:" + F.wordCount);
                    Console.WriteLine("lines:" + F.lineCount);
                    int m = Convert.ToInt32(str[3]);
                    while(m>F.wordlist.Count)
                    {

                    }
                    for (int i = 0; i < m; i++)
                    {
                        if (i + m >F.wordlist.Count)
                            break;
                        for (int j = i; j < i + m; j++)
                        {
                            Console.Write(F.wordlist[j]+ " ");
                        }
                        Console.WriteLine();
                    }
                    Console.ReadLine();
                }
                if (str[2] == "-n")
                {
                    SortedList sortedlist = new SortedList();
                    sortedlist = F.Word;
                    int num = int.Parse(str[3])+1;
                    int t = F.Word.Count-1;
                    Console.WriteLine("文件内含有不重复单词数为："+t);
                    while(num>sortedlist.Count)
                    {
                        Console.WriteLine("要求输出的单词数超过文件夹内单词总数！请重新输入：");
                        num= int.Parse(Console.ReadLine())+1;
                    }
                    List<string> list2 = new List<string>();
                    int[] str3=new int[sortedlist.Count];
                    string[] str4 = new string[sortedlist.Count];
                    int i2 = 0;
                    foreach(string str5 in sortedlist.GetKeyList()) 
                    {
                        if (str5 !=" "&&str5!=""&&i2 < sortedlist.Count  )
                        {
                            str4[i2] = str5;
                            str3[i2] = (int)F.Word.GetByIndex(i2);
                        }
                        i2++;
                    }
                    int temp = 0;
                    string temp2;
                    for(int j=1;j< str3.Length; j++)//按照频率排序
                    {
                        for (int k = j+1; k <str3.Length; k++)
                        {
                            if (str3[k] > str3[j])
                            {
                                temp = str3[k];
                                str3[k] = str3[j];
                                str3[j] = temp;
                                temp2 = str4[k];
                                str4[k] = str4[j];
                                str4[j] = temp2;
                            }
                            else
                                continue;
                        }
                    }
                    for (int i = 0; i < num; i++)
                    {
                        //Console.WriteLine(sortedlist.GetByIndex(1));
                        if(str3[i]!=0)
                        Console.WriteLine(str4[i]+ " "+ str3[i]);
                    }
                }
                F.OutPutToTxt(str[5]);
            }
            else if (str.Length == 8)
            {
                if (str[2] == "-m")
                {
                    int m = Convert.ToInt32(str[3]);
                    Console.WriteLine("characters:"+F.charCount);
                    Console.WriteLine("words:" + F.wordCount);
                    Console.WriteLine("lines:" + F.lineCount);
                    while (m > F.wordlist.Count)
                    {

                    }
                    for (int i = 0; i < m; i++)
                    {
                        if (i + m > F.wordlist.Count)
                            break;
                        for (int j = i; j < i + m; j++)
                        {
                            Console.Write(F.wordlist[j] + " ");
                        }
                        Console.WriteLine();
                    }
                }
                if (str[2] == "-n")
                {
                    SortedList sortedlist = new SortedList();
                    sortedlist = F.Word;
                    int num = int.Parse(str[3]) + 1;
                    int t = F.Word.Count - 1;
                    Console.WriteLine("文件内含有不重复单词数为：" + t);
                    while (num > sortedlist.Count)
                    {
                        Console.WriteLine("要求输出的单词数超过文件夹内单词总数！请重新输入：");
                        num = int.Parse(Console.ReadLine()) + 1;
                    }
                    List<string> list2 = new List<string>();
                    int[] str3 = new int[sortedlist.Count];
                    string[] str4 = new string[sortedlist.Count];
                    int i2 = 0;
                    foreach (string str5 in sortedlist.GetKeyList())
                    {
                        if (str5 != " " && str5 != "" && i2 < sortedlist.Count)
                        {
                            str4[i2] = str5;
                            str3[i2] = (int)F.Word.GetByIndex(i2);
                        }
                        i2++;
                    }
                    int temp = 0;
                    string temp2;
                    for (int j = 1; j < str3.Length; j++)//按照频率排序
                    {
                        for (int k = j + 1; k < str3.Length; k++)
                        {
                            if (str3[k] > str3[j])
                            {
                                temp = str3[k];
                                str3[k] = str3[j];
                                str3[j] = temp;
                                temp2 = str4[k];
                                str4[k] = str4[j];
                                str4[j] = temp2;
                            }
                            else
                                continue;
                        }
                    }
                    for (int i = 0; i < num; i++)
                    {
                        //Console.WriteLine(sortedlist.GetByIndex(1));
                        if (str3[i] != 0)
                            Console.WriteLine(str4[i] + " " + str3[i]);
                    }
                }

                if (str[4] == "-m")
                {
                    Console.WriteLine("characters:" + F.charCount);
                    Console.WriteLine("words:" + F.wordCount);
                    Console.WriteLine("lines:" + F.lineCount);
                    string s2 = str[5];
                    int m = Convert.ToInt32(s2);
                    string[] temp = (string[])F.Word.GetKeyList();
                    for (int i = 0; i < m; i++)
                    {
                        if (i + m > temp.Length)
                            break;
                        for (int j = i; j < i + m; j++)
                        {
                            Console.Write(temp[j] + " ");
                        }
                        Console.WriteLine();
                    }
                    Console.ReadLine();
                }
                if (str[4] == "-n")
                {
                    SortedList sortedlist = new SortedList();
                    sortedlist = F.Word;
                    int num = int.Parse(str[5]) + 1;
                    int t = F.Word.Count - 1;
                    Console.WriteLine("文件内含有不重复单词数为：" + t);
                    while (num > sortedlist.Count)
                    {
                        Console.WriteLine("要求输出的单词数超过文件夹内单词总数！请重新输入：");
                        num = int.Parse(Console.ReadLine()) + 1;
                    }
                    List<string> list2 = new List<string>();
                    int[] str3 = new int[sortedlist.Count];
                    string[] str4 = new string[sortedlist.Count];
                    int i2 = 0;
                    foreach (string str5 in sortedlist.GetKeyList())
                    {
                        if (str5 != " " && str5 != "" && i2 < sortedlist.Count)
                        {
                            str4[i2] = str5;
                            str3[i2] = (int)F.Word.GetByIndex(i2);
                        }
                        i2++;
                    }
                    int temp = 0;
                    string temp2;
                    for (int j = 1; j < str3.Length; j++)//按照频率排序
                    {
                        for (int k = j + 1; k < str3.Length; k++)
                        {
                            if (str3[k] > str3[j])
                            {
                                temp = str3[k];
                                str3[k] = str3[j];
                                str3[j] = temp;
                                temp2 = str4[k];
                                str4[k] = str4[j];
                                str4[j] = temp2;
                            }
                            else
                                continue;
                        }
                    }
                    for (int i = 0; i < num; i++)
                    {
                        //Console.WriteLine(sortedlist.GetByIndex(1));
                        if (str3[i] != 0)
                            Console.WriteLine(str4[i] + " " + str3[i]);
                    }

                   
                }

                F.OutPutToTxt(str[7]);
            }
           
        }
    }
}
