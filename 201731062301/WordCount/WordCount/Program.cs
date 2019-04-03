using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using Words;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            int countLine = 0;
            string str = "";
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path, Encoding.Default);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    countLine++;
                    str += line + "\n";
                }
                sr.Close();
                str = str.Trim();
            }
            Console.WriteLine("Characters: "+WordsList.CountChar(str));
            Console.WriteLine("Lines: " + countLine);
            Console.WriteLine("Words: "+WordsList.CountWords(str));
            WordsList.CountWordFre(str);
            OutPut(str);
            Console.ReadLine();
        }
        //输出到文件
        public static void OutPut(string path)
        {
            List<string> list = new List<string>();
            string[] wordsArr1 = Regex.Split(path.ToLower(), "\\s*[^0-9a-zA-Z]+");
            foreach (string word in wordsArr1)
            {
                if (Regex.IsMatch(word, "^[a-zA-Z]{4,}[a-zA-Z0-9]*") && !(list.Contains(word)))
                {
                    list.Add(word);
                }
            }
            list.Sort();
            string path1 = "output.txt";
            FileStream fs = new FileStream(path1, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            foreach (string word in list)
            {
                sw.Write(word + " ");
            }
            sw.Flush();//关闭流
            sw.Close();
            fs.Close();
        }
    }
}
