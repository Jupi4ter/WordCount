using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2;

namespace wordCount
{
    class New
    {
        public static string filename2 = @"E:\3\git\second\WordCount\201731062106\output.txt";
        public static string words1 = "";
        public static int wnum = 0;
        public static string strr = "";
        public static void Pro(string[] str)
        {
            int len = str.Length;
            if (len==2)
            {
                string file = str[1];
                if (str[0]=="-i")
                {
                    Fileopen(file);
                }
                else
                {
                    Fileout(file);
                }
            }
            else if (len==4)
            {
                string file = str[3];
                words1 = Fileopen(file);
                int num = Convert.ToInt32(str[1]);
                wnum = ClassLibrary2.Wnum.GetWnum(ref words1);
                string arr = str[0];
                
                switch (arr)
                {
                    case "-m":
                        strr = ClassLibrary2.Wnum.GetStrm(num, words1);
                        break;
                    case "-n":
                        strr = ClassLibrary2.Wnum.Getstrn(num, words1);
                        break;
                    default:break;
                }
                Fileout(filename2);
            }
            else
            {
                int count = 0;
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j]=="-i")
                    {
                        count++;
                    }

                    if (str[j]=="-o")
                    {
                        count++;
                    }
                }

                if (count<=1)
                {
                    return ;
                }
                else
                {
                    strr = ClassLibrary2.Wnum.Fileoutput(str, words1);
                }
            }
        }
        public static int lines = 0;
        public static string Fileopen(string filename1)
        {
            FileStream fs = new FileStream(filename1, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(filename1);
            StringBuilder sb = new StringBuilder();
            while (sr.Peek() >= 0)           //如果未到文件尾，继续读取文件行
            {
                sb.AppendLine(sr.ReadLine());//读取文件行加入sb，构造字符串
            }
            words1 = sb.ToString();
            sr.Close();
            fs.Close();
            //判断行数
            Stopwatch sw = new Stopwatch();
            var path = filename1;
            
            sw.Restart();                                      //按行读取
            using (var s = new StreamReader(path))
            {
                var Is = "";
                while ((Is = s.ReadLine()) != null)
                {
                    lines++;
                }
            }
            sw.Stop();
            return words1;
        }
        public static int GetCnum(string str)
        {
            int j = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] < 127)                   //大于127的是汉字
                {
                    j++;
                }
            }
            return j;
        }
        public static int GetLine(string filename)
        {
            Stopwatch sw = new Stopwatch();
            var path = filename;
            int lines = 0;
            sw.Restart();                                      //按行读取
            using (var sr = new StreamReader(path))
            {
                var Is = "";
                while ((Is = sr.ReadLine()) != null)
                {
                    lines++;
                }
            }
            sw.Stop();
            return lines;
        }
        public static void Fileout(string filename2)
        {
            StreamWriter sw = new StreamWriter(filename2);
            sw.Write("characters: " + GetCnum(words1) + "\r\n" + "words:" + wnum + "\r\n" + "lines:" + lines + "\r\n"+strr);
            sw.Flush();
            sw.Close();
            Console.WriteLine("已输出");
        }
    }

}
