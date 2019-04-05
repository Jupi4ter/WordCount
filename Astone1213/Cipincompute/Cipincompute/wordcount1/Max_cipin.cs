using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;


namespace Cipincompute
{
    public class Max_cipin//求出现次数最多的前十个单词
    {       
        public Max_cipin()
        {

        }
        public string str;
      
        public void PrintCipin()
        {
            Writetext wrtt = new Writetext();
            using (StreamWriter sw = new StreamWriter(@"F:\vs\github\WordCount\Astone1213\output.txt", true))
            using (StreamReader sr = new StreamReader(str, true))
            {
                string text = sr.ReadToEnd();
                text=text.ToLower();
                Dictionary<string, int> frequencies = wrtt.Writeword(text);
                var dic = from objDic in frequencies orderby objDic.Value descending select objDic;
                foreach (KeyValuePair<string, int> entry in dic.Take(10))
                {                                       
                    Console.WriteLine(entry.Key + " : " + entry.Value);
                    sw.WriteLine(entry.Key + " : " + entry.Value);
                }              
            }
            
        }
    }
    
}
