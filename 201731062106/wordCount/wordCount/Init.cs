using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordCount
{
    public class Init
    {
        public static string words1 = "";
        public static string words2 = "";
        public static void File(string filename1, string filename2)
        {
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
            StreamWriter sw = new StreamWriter(filename2);
            sw.Write("characters: " + ClassLibrary1.CNUM.GetCnum(words1) + "\r\n" + "words:" + ClassLibrary1.WNUM.GetWnum(words1, ref words2) + "\r\n" + "lines:" + GetLine(filename1) + "\r\n" + ClassLibrary1.STRNUM.GetStr(words2));
            sw.Flush();
            sw.Close();
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
    }
}
