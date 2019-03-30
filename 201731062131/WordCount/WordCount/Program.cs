using System;
using System.Diagnostics;
using System.IO;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length==0)
            {
                Console.Write("请重新输入参数后，再打开文件，按任意键结束程序");
                Console.ReadKey();
                return ;
            }
            //读取文件的所有字符到字符串中
            countword CountWord = new countword();
            CountWord.OutPut(args[0]);           
            Console.ReadKey();
        }
    }
    class countword
    {
        private string FileTxt;

        public void OutPut(string filepath)
        {
            FileTxt = File.ReadAllText(filepath);
            Console.WriteLine(FileTxt);
            //输出文件所有字符的个数
            Console.WriteLine("characters:" + FileTxt.Length);
            Console.WriteLine("words:" + ComputeWords(FileTxt));
            Console.WriteLine("lines:" + CountLines(filepath));
            
        }
        //读取txt文件中总行数的方法
        public int CountLines(String filepath)
        {
            Stopwatch sw = new Stopwatch();
            int lines = 0;
            //按行读取
            sw.Restart();
            using (var sr = new StreamReader(filepath))
            {
                string ls = "";
                //循环读取直到最后一行
                while ((ls = sr.ReadLine()) != null)
                {
                    //若是换行符行数不变
                    if (ls.Length != 0)
                        lines++;
                }
            }
            sw.Stop();
            return lines;
        }
        public int ComputeWords(string filetxt)
        {
            int count = 0;
            int result = 0;
            int i = 0;
            while (i<filetxt.Length)
            {
                if(filetxt[i]==' '||(filetxt[i]>'0'&&filetxt[i]<'9'))
                {
                    if (count >= 4)
                    {
                        result++;
                    }
                    count = 0;
                }
                else
                {
                    count++;
                }
                i++;
            }
            return result;
        }
    }
}
