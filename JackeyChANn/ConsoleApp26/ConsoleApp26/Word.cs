using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26
{
    class Word//单词
    {
        public int TotalWord(string filename)
        {
            Encoding encode = Encoding.GetEncoding("GB2312");
            FileStream fs = new FileStream(@"D:\TESTDIARY\TEST.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs, encode);

            int nChar;
            int wordcount = 0;
            char[] symbol = { ' ', '\t', ',', '.', '?', '!', ':', ';', '\'', '\"', '\n', '{', '}', '(', ')', '+', '-', '*', '=' };
            //间隔符
            while ((nChar = sr.Read()) != -1)
            {
                foreach (char c in symbol)
                {
                    if (nChar == (int)c)
                    {
                        wordcount++; // 统计单词数
                    }
                }
            }
            Console.WriteLine("Total Word:" + wordcount);//显示单词总数

            sr.Close();
            fs.Close();

            return wordcount;
        }
    }
}
