using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace wordcount.function
{
   
    public class wordcount
    {

    
        public  static int sum1(Dictionary<string, int> dic1Asc)
        {
            StreamWriter sw1 = new StreamWriter(@path.outputpath);
            int sum = 0;
            foreach (KeyValuePair<string, int> entry in dic1Asc)
            {

                string word = entry.Key;
                int frequency = entry.Value;
                sw1.Write(word + "\r\n");
                 sum = sum + frequency;

            }
            sw1.Close();
            return sum;
        }
        public static Dictionary<string, int> Countword(ref Dictionary<string, int> frequencies1,int len)
        {
            int b = 0;
            string str = File.ReadAllText(@path.s);
            Dictionary<string, int> frequencies = new Dictionary<string, int>();
            string[] words = Regex.Split(str, @"\W+");
            int k = 0;
            string[] newwords = ynword.ynword1(words,ref k);
            string[] newwords1 = new string[k];
            string[] newwords2 = new string[k];
            for (int i = 0; i < k; i++)
            {
                newwords1[i] = newwords[i];
            }
            foreach (string word in newwords1)
            {

                if (frequencies.ContainsKey(word))
                {
                    frequencies[word]++;
                }
                else
                {
                    frequencies[word] = 1;
                }
            }
            if (len >0)
            {
                for (int j = 0; j < k - len+1  ; j++)
                {
                    
                    for (int z = 0; z < len; z++)
                    {
                        newwords2[b] =newwords2[b]+" "+ newwords1[j + z];
                    }
                    b++;
                }
                for (int i = 0; i < b; i++)
                {
                    if (frequencies1.ContainsKey(newwords2[i]))
                    {
                        frequencies1[newwords2[i]]++;
                    }
                    else
                    {
                        frequencies1[newwords2[i]] = 1;
                    }
                }
            }
            return frequencies;
        }
    }
}
