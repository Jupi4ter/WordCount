using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Cipincompute
{
    public class totallines
    {
        public static int Countlines(string failname)
        {
            using (StreamReader sw = new StreamReader(failname, true))
            {
                int lines = 0;
                var text = "";
                while ((text = sw.ReadLine()) != null)
                {
                    lines++;
                }//计数不为空的行数
                return lines;
            }
        }
        public void Print_lines(string s)
        {

            Console.WriteLine("total lines:{0}", Countlines(s));
            
        }
    }
}

