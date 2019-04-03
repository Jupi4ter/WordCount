using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;

namespace Out
{
    class Output
    {
        public void OutputWord(string filePath, int outNumb)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("文件不存在！");
                return;
            }

            StreamReader sr = new StreamReader(filePath, System.Text.Encoding.UTF8);
            int wordNum = 0;

            string str = "";
            string[] word = null;
            List<string> res = new List<string>();
            List<string> temp = new List<string>();
            List<int> num = new List<int>();
            List<int> freqNum = new List<int>();
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            try
            {

                string line = sr.ReadLine();

                while (line != null)
                {
                    str = str + line + " ";
                    line = sr.ReadLine();
                }

                word = Regex.Split(str, @"[^a-z|^A-Z|^0-9]", RegexOptions.IgnoreCase);

                for (int i = 0; i < word.Length; i++)
                {

                    if (word[i].Length >= 4 && Regex.IsMatch(word[i].Substring(0, 3), @"^[A-Za-z]"))
                    {
                        res.Add(word[i]);
                        temp.Add(word[i]);
                    }
                }


                for (int i = 0; i < res.Count - 1; i++)
                {
                    for (int j = i + 1; j < res.Count; j++)
                    {
                        if ((res[j].ToLower() == res[i].ToLower()))
                        {
                            num.Add(j);
                        }
                    }
                }
                num = num.Distinct().ToList();
                num.Reverse();
                for (int i = 0; i < num.Count; i++)
                {
                    res.RemoveAt(num[i]);
                }
                for (int i = 0; i < res.Count; i++)
                {
                    wordNum = 0;
                    for (int j = i; j < temp.Count; j++)
                    {
                        if ((temp[j].ToLower() == res[i].ToLower()))
                        {
                            wordNum++;
                        }
                    }
                    freqNum.Add(wordNum);
                }

                for (int i = 0; i < res.Count; i++)
                {
                    dictionary.Add(res[i], freqNum[i]);
                }
                dictionary.OrderByDescending(p => p.Key).ToDictionary(p => p.Key, o => o.Value);

                foreach (KeyValuePair<string, int> item in dictionary)
                {
                    Console.WriteLine("{0} : {1} ", item.Key, item.Value);
                }

            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sr.Close();
            }

        }
    }
    
}


