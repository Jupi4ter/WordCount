using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace wordCount
{
    class Program
    {
        public static string words1 = "";
        public static string words2 = "";
        public static string filename1 = @"E:\3\git\second\WordCount\201731062106\input.txt";
        static void Main(string[] args)
        {
            //Console.WriteLine(words1.Length);
            FileStream fs = new FileStream(filename1, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(filename1);
            StringBuilder sb = new StringBuilder();
            while (sr.Peek() >= 0)           //如果未到文件尾，继续读取文件行
            {
                sb.AppendLine(sr.ReadLine());//读取文件行加入sb，构造字符串
                //sb = sb.Replace("\r\n", "");
            }

            words1 = sb.ToString();
            sr.Close();
            fs.Close();
            string filename2 = @"E:\3\git\second\WordCount\201731062106\output.txt";
            StreamWriter sw = new StreamWriter(filename2);
            sw.Write("characters: " + GetCnum(words1) + "\r\n" + "words:" + GetWnum(words1) + "\r\n" + "lines:" +GetLine(filename1) + "\r\n"+GetStr(words2));
            sw.Flush();
            sw.Close();
        }
        //返回字符数
        public static int GetCnum(string str)
        {
            int j = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i]<127)
                {
                    j++;
                }
            }
            return j;
        }
        //返回单词数
        public static int GetWnum(string str)
        {
            int k = 0;
            string temp1 = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsLetter(str[i])||char.IsDigit(str[i]))       //判断是不是数字或者字母
                {
                    temp1 += str[i];
                }
                else
                {
                    temp1 += " ";
                }
            }
            string[] arr = temp1.Trim().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);   //去除字符数组中所有空格
            string arr1 = string.Join(" ", arr); 
            string[] temp2 = arr1.Split(' ');
            int j = 0, flag = 1;
            for (int i = 0; i < temp2.Length; i++)
            {
                if (temp2[i].Length<4)
                {
                    continue;
                }
                else
                {
                    for ( j = 0; j < 4; j++)                      //判断前四个是否为字母
                    {
                        flag = 1;
                        if (char.IsDigit(temp2[i][j]))
                        {
                            flag = 0;
                        }

                    }

                    if (flag == 1)
                    {
                        k++;
                        words2 += temp2[i]+" ";
                    }
                }
            }
            return k;
        }

        public static int GetLine(string filename)
        {
            Stopwatch sw=new Stopwatch();
            var path = filename;
            int lines = 0;
            sw.Restart();                                      //按行读取
            using (var sr=new StreamReader(path))
            {
                var Is = "";
                while ((Is=sr.ReadLine())!=null)
                {
                    lines++;
                }
            }
            sw.Stop();
            return lines;
        }

        public static string GetStr(string str1)
        {
            int j = 0;
            str1 = str1.Trim();
            string[] str = str1.Split(' ');
            ArrayList strList=new ArrayList(str);
            strList.Sort();
            str = (string[]) strList.ToArray(typeof(string));        //将ARRAYLIST转换成string[]
            var temp1 = str.GroupBy(i => i).ToList();
            string temp = "";
            //temp1.ForEach(i =>
            //{
            //    string wordi = i.Key;
            //    int timei = i.Count();
            //    temp += wordi + ":" + timei + "\r\n";
            //});
            foreach (var i in temp1)
            {
                string wordi = i.Key;
                int timei = i.Count();
                temp += wordi + ":" + timei + "\r\n";
                j++;
                if (j==10)
                {
                    break;
                }
            }
            return temp;
        }
    }
}
