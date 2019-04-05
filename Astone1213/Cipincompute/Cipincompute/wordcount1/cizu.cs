using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using Cipincompute;
namespace Cipincompute
{
    class cizu //词组统计 新增
    {
        string[] temp1 = null;
        string txt;
        int num;
        int num2;
        bool fin = true;
        char[] kh=new char[3];
        public cizu(string t1,int n)
        {
            txt = t1;
            num = n;
            num2 = n;
        }

        public static bool IsLetter(string str)
        {
            string pattern = @"^[A-Za-z]+$";
            Match match = Regex.Match(str, pattern);
            return match.Success;
        }//判断字符串是否为英文

        public void cizuPrint()
        {
            kh[0] = ' ';
            kh[1]='\n';
            kh[2] = '\r';
            
            using (StreamReader sr = new StreamReader(txt, true))
            {
                string text1 = sr.ReadToEnd();
                text1 = text1.ToLower();
                temp1 = text1.Split(kh);
                
                for (int i = 0; i < temp1.Length; i++)
                {
                    
                    for (int j = i; j < num; j++)
                    {
                        //if (num - j >= 2)
                        //{
                        //    num--;
                        //}
                        if (IsLetter(temp1[j]))
                        {
                            Console.Write(temp1[j]);
                            Console.Write(' ');
                            fin = true;
                        }
                      
                        else
                        {
                            fin = false;
                            break;
                        }
                    }
                    
                    if (num <temp1.Length)
                    {
                        num++;
                    }
                    if (temp1.Length - num <= num2 )
                    {
                        break;
                    }
                    if (fin)
                    {
                        Console.WriteLine(":" + num2);
                    }
                }
            }
        }

       
    }
}
