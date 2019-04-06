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
        public static string filename1 = "";
        public static string filename2 = "";
        static void Main(string[] args)
        {
            string massage = Console.ReadLine();
            massage = massage.Trim();
            string[] str = massage.Split(' ');
            if (str.Length<=1)
            {
                filename1 = @"E:\3\git\second\WordCount\201731062106\input.txt";
                filename2 = @"E:\3\git\second\WordCount\201731062106\output.txt";
                Init.File(filename1,filename2);
                Console.WriteLine("已输出到filename2");
            }
            else
            {
                New.Pro(str);
            }
        }
    }
}
