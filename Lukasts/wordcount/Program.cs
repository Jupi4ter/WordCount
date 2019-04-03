using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ConsoleApp28
{
    class Program
    {
        static Class1 Class1 = new Class1();
        static Class2 Class2 = new Class2();
        static Class3 Class3 = new Class3();
        static void Main(string[] args)
        {
           // string failname=Console.ReadLine();
            string failname = @"C:\xv\c.txt";
            Class1.Print_Word(failname);
            Class2.Print_lines(failname);
            Class3.Print_Char_Num(failname);
            Console.ReadLine();
            //@"C:\xv\c.txt"
        }
    }
}
