using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordcount.function
{
   public class ynword
    {
        public static string[] ynword1(string[] words,ref int w)
        {
            char[] newword = new char[1000];
            int k = 0;
            string[] newwords = new string[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                char[] wordss = words[i].ToCharArray();
                for (int j = 0; j < wordss.Length; j++)
                {
                    if (wordss[j] >= 'A' && wordss[j] <= 'Z')
                    {
                        wordss[j] = Convert.ToChar((Convert.ToInt32(wordss[j]) + 32));
                    }

                }
                if (wordss.Length >= 4)
                {
                    if ((wordss[0] >= 'a' && wordss[0] <= 'z') && (wordss[1] >= 'a' && wordss[1] <= 'z') && (wordss[2] >= 'a' && wordss[2] <= 'z') && (wordss[3] >= 'a' && wordss[3] <= 'z'))
                    {
                        newword = wordss;
                        string s = String.Join("", newword);
                        newwords[k] = s;
                        k++;
                    }
                }

            }
            w = k;
            return newwords;
        }
    }
}
