using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;



namespace Cipincompute
{

    public class Cipin //传入地址并统计词频
    {
        string txt;

        public Cipin(string bTemp)
        {         
            txt = bTemp;
        }
        
        public void Printnumber()
        {
            
            Writetext wrtt = new Writetext();
            using (StreamWriter sw = new StreamWriter(@"F:\vs\github\WordCount\Astone1213\output.txt", true))
            using (StreamReader sr = new StreamReader(txt, true))
            {
                string text1 = sr.ReadToEnd();
                text1 = text1.ToLower();
                Dictionary<string, int> frequencies = wrtt.Writeword(text1);
                foreach (KeyValuePair<string, int> entry2 in frequencies)
                {
                    
                    Console.WriteLine(entry2.Key+" : "+entry2.Value);
                                    
                }

            }
        }
    }
}
