using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;


namespace ConsoleApp28
{
    public class Class1
        
    {
        public static bool IsLetter(string str)
        {
            string pattern = @"^[A-Za-z]+$";
            Match match = Regex.Match(str, pattern);
            return match.Success;
        }//判断字符串是否为英文
        public static Dictionary<string, int> CountWords(string text)
        {
            Dictionary<string, int> fre;         
            fre = new Dictionary<string, int>();            
                string[] words = Regex.Split(text, @"\W+");
            foreach (string word in words)
            {
                //char[] c = word.ToCharArray();
                if (word.Length > 3)
                {
                    string word_4 = word.Substring(0, 4);//得到前四个字符
                    if (IsLetter(word_4))
                    {
                        string prt_word = word.ToLower();
                        if (fre.ContainsKey(prt_word))
                        {
                            fre[prt_word]++;
                        }
                        else
                        {
                            fre[prt_word] = 1;
                        }

                    }
                }
            }
            return fre;
        }
        public void Print_Word(string failname)
        {
            using (StreamReader sw = new StreamReader(failname, true))
            {
                string text = sw.ReadToEnd();               
                Dictionary<string, int> fre = CountWords(text);
                int Total_Words = 0;
               /* for (total = 0; total < entry.Key.Length; total++)
                {
                    total++;
                }
                Console.WriteLine("{0}", total);*/
                foreach (KeyValuePair<string, int> entry in fre)
                {
                    Total_Words = Total_Words + entry.Value;
                    //Console.WriteLine("{0}", entry.Key.Length);
                  //Console.WriteLine("{0}:{1}", entry.Key, entry.Value);
                }
                Console.WriteLine("total wods:{0}", Total_Words);
            }
        }
            
    }
}
