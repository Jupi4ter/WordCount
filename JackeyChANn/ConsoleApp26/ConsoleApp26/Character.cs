using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26
{
    class Character//字符
    {
        public string ope;

        public int TotalWord(string filename)
        {
            Encoding encode = Encoding.GetEncoding("GB2312");
            FileStream fs = new FileStream(@"D:\TESTDIARY\TEST.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs, encode);

            int charcount = 0;
            int nChar;

            while ((nChar = sr.Read()) != -1)
            {
                charcount++;     // 统计字符数
            }
            Console.WriteLine("Total Char:" + charcount);//显示文件内容

            sr.Close();
            fs.Close();

            return charcount;
        }
    }
