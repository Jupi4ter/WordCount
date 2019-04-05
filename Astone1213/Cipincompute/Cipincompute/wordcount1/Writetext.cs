using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Cipincompute
{
    public class Writetext   //从文本写入字典序
    {
        public Dictionary<string, int> Writeword(string text)
        {
            Dictionary<string, int> frequencies;
            frequencies = new Dictionary<string, int>();
            string[] words = Regex.Split(text, @"\W+");
            foreach (string word in words)
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
            return frequencies;
        }

    }
}
