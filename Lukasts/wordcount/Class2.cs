using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace ConsoleApp28
{
    public class Class2
    {
        public static int Countlines(string failname)
         {
             using (StreamReader sw = new StreamReader (failname, true))
             {
                 int lines = 0;
                 var text = "";
                 while ((text = sw.ReadLine() )!= null)
                 {
                     lines++;                   
                 }//计数不为空的行数
                 return lines;
             }    
         }
       /* public static int Countlines(string text)
        {
            int lines = 0;
            string text1;
          
                while ((text1 =!= null)
                {
                    lines++;
                }
            return lines;

        }*/
       /*public void Print()
        {
            string filename = @"C:\xv\c.txt";
            using (StreamReader sw = new StreamReader(filename, true))
            {
                string text = sw.ReadToEnd();
                Console.WriteLine("total lines of text:{0}", Countlines(text));
            }
        }*/
       public void Print_lines(string s)
        {
           
            Console.WriteLine("total lines:{0}", Countlines(s));
        }
    }
}
