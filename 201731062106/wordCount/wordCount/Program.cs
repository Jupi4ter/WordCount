using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;


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
            sw.Write("characters: " + ClassLibrary1.CNUM.GetCnum(words1) + "\r\n" + "words:" + ClassLibrary1.WNUM.GetWnum(words1,ref words2) + "\r\n" + "lines:" +GetLine(filename1) + "\r\n"+ClassLibrary1.STRNUM.GetStr(words2));
            sw.Flush();
            sw.Close();
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
        
    }
}
