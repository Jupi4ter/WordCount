using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Cipincompute
{
    class totalchar
    {
        public static int CharactersNum(string failname)
        {
            int Char_Num = 0;
            using (StreamReader sw = new StreamReader(failname, true))
            {
                string text = sw.ReadToEnd();
                char[] everychar = text.ToCharArray();
                for (int i = 0; i < everychar.Length; i++)
                {
                    if ((int)everychar[i] < 128)
                    {
                        Char_Num++;
                    }//判断非汉字字符总数                    
                }
            }
            return Char_Num;
        }
        public void Print_Char_Num(string s)
        {
            Console.WriteLine("characters num:{0}", CharactersNum(s));
        }
    }
}

