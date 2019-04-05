using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipincompute
{
    class Program
    {
       
   
        static void Main(string[] args)
        {
            Console.Write("输入地址：");
            string text = Console.ReadLine();
            Console.Write("输入需要统计的字符长度：");
            int tenumber = Convert.ToInt32(Console.ReadLine());

            Max_cipin mx = new Max_cipin();//词频
            Cipin ct = new Cipin(text);

            totalchar tc = new totalchar();//字符总数
            totalwords tw = new totalwords();//单词总数
            totallines tl = new totallines();//行数
            tc.Print_Char_Num(text);
            tw.Print_Word(text);
            tl.Print_lines(text);

            mx.str = text;
            mx.PrintCipin();
            Console.WriteLine();

            ct.Printnumber();
            Console.WriteLine();

            cizu cz = new cizu(text, tenumber);
            cz.cizuPrint();


            Console.ReadLine();
            
        }
    }
}
