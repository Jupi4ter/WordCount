using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace wordcount
{
    class Program
    {
        static totalchar Class1 = new totalchar();
        static totallines Class2 = new totallines();
        static totalwords Class3 = new totalwords();
        static void Main(string[] args)
        {
            string failname = Console.ReadLine();
           // string failname = @"C:\xv\c.txt";
            Class1.Print_Char_Num(failname);
            Class2.Print_lines(failname);
            Class3.Print_Word(failname);
        }
    }
}

