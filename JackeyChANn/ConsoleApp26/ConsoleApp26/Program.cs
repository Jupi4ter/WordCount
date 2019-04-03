using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.RegularExpressions;

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
    class Rows//行数
    {
        public int Line(string filename)//传入文件位置字符串
        {
            //打开文件
            Encoding encode = Encoding.GetEncoding("GB2312");//中文字符读取
            FileStream fs = new FileStream(@"D:\TESTDIARY\TEST.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs, encode);

            string line;
            int CountLine = 0;//记录行数

            //当当前行不为空，即当前行存在，即 +1 
            while ((line = sr.ReadLine()) != null)
            {
                CountLine++;
            }
            Console.WriteLine("line:" + CountLine);//显示行数

            //关闭文件
            sr.Close();
            fs.Close();

            return CountLine;//注意函数是有返回值的

            //应该先关闭文件再return
        }
    }
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
    class WriteFile
    {
        public void Write(string theword)
        {
            FileStream fs = new FileStream(@"D:\TESTDIARY\TEST1.txt", FileMode.Create);//相对位置

            // FileStream fs = new FileStream("F:\\c#\\WordCount\\WordCount\\bin\\Debug\\outputFile.txt", FileMode.Create);//绝对位置

            //获得字节数组
            byte[] data = System.Text.Encoding.Default.GetBytes(theword);
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
        }
    }
    class WordRead
    {
        public string ope;
        public int LoadWord()
        {
            if (ope == "-l")
            {
                return 1;
            }
            else if (ope == "-w")
            {
                return 2;
            }
            else if (ope == "-c")
            {
                return 3;
            }
            else
                return 0;
        }

    }
    class Wordfrequency
    {
        public void frequency()
        {
            try
            {
                StreamReader sr = new StreamReader(@"D:\TESTDIARY\TEST.txt"); //创建输入流  
                SortedList sortedlist = new SortedList();//创建sortelist对象，该对象可以自动排序  
                char[] delimiter = new char[] { '~', '`', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', ',', ' ', '>', '<', '?', '/', '\\' };
                string line;
                int count = 0;
                line = sr.ReadLine();
                while (line != null)
                {
                    count++;
                    string[] temp = line.Split(delimiter);
                    for (int i = 0; i < temp.Length; i++)
                    {
                        if (!sortedlist.ContainsKey(temp[i]))   //检测该list中是否有该字符  
                        {
                            sortedlist.Add(temp[i], 1); //如果数组中没有该单词加进去  
                        }
                        else
                        {
                            int index = sortedlist.IndexOfKey(temp[i]); //取得指定键的索引  //如果有则更改单词的次数  

                            int value = (int)sortedlist.GetByIndex(index);//取得指定索引的值  
                            value++;
                            sortedlist.SetByIndex(index, value);
                        }
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
                Console.Write(count);
                StreamWriter sw = new StreamWriter(@"D:\TESTDIARY\TEST1.txt");  //打开输出流  
                for (int i = 0; i < 10; i++)
                {
                    string temp = (string)sortedlist.GetKey(i);
                    if (temp == null || temp.Equals(""))
                        continue;
                    else
                    {
                        sw.WriteLine("{0} {1} ", sortedlist.GetKey(i), sortedlist.GetByIndex(i));
                    }
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Can not read!");
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //新建对象
            WordRead wordRead = new WordRead();
            string Operand;
            string theword = "";
            int ope1, ope2, ope3;

            ope1 = ope2 = ope3 = 0;
           

            Operand =Console.ReadLine() ;//读取返回值

            if (Operand == "1")  //当用户选择读取总行数
            {
                Rows rows = new Rows();
                ope1 = rows.Line(args[0]);
                theword += string.Format("Total Line:{0}", ope1);
            }
            else if (Operand == "2")  //当用户选择读取总单词数
            {
                Word word = new Word();
                ope2 = word.TotalWord(args[0]);
                theword += string.Format("Total Word:{0}", ope2);
            }
            else if (Operand == "3")  //当用户选择读取总字符数
            {
                Character character = new Character();
                ope3 = character.TotalWord(args[0]);
                theword += string.Format("Total Character:{0}", ope3);
            }
            else if (Operand == "4")
            {
                Wordfrequency wordfrequency = new Wordfrequency();
                wordfrequency.frequency();
            }
            else
                Console.WriteLine("error!");

            //将结果写入txt
            WriteFile writeFile = new WriteFile();
            writeFile.Write(theword);
        }
    }
}
