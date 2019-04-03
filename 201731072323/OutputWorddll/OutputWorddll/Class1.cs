using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace OutputWorddll
{
    public interface IOutputWord
    {
        /// <summary>
        /// Output word frequency interface
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="outNumb"></param>
        /// <returns></returns>
        Dictionary<string, int> OutputWord(string filePath, int outNumb);
    }
    public class Outputword : IOutputWord
    {
        /// <summary>
        /// this function is to count the frequency of all words and sort the output descendly
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="outNum"></param>
        /// <returns> word dictionary </returns>
        public Dictionary<string, int> OutputWord(string filePath, int outNum)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist！");
                return null;
            }
            //StreamReader to read file
            StreamReader sr = new StreamReader(filePath, System.Text.Encoding.UTF8);

            int wordNum = 0;
            string str = "";
            string[] word = null;
            List<string> res = new List<string>();  //Save all words
            List<string> temp = new List<string>(); //Temporary word
            List<int> num = new List<int>();        //Save words index
            List<int> freqNum = new List<int>();    //Save the frequency
            Dictionary<string, int> dictionary = new Dictionary<string, int>(); //Save the word and its frequency

            try
            {

                string line = sr.ReadLine();
                //Read all characters in the file
                while (line != null)
                {
                    str = str + line + " ";
                    line = sr.ReadLine();
                }

                //Delimiters are Spaces and special characters
                word = Regex.Split(str, @"[^a-z|^A-Z|^0-9]", RegexOptions.IgnoreCase);

                for (int i = 0; i < word.Length; i++)
                {
                    //Determine if it is a word
                    if (word[i].Length >= 4 && Regex.IsMatch(word[i].Substring(0, 4), @"^[A-Za-z]{4}$"))
                    {
                        res.Add(word[i]);
                        temp.Add(word[i]);
                    }
                }

                //Words eliminate heavy
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

                //Count words frequency
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

                //Write the types and frequencies of words into the dictionary
                for (int i = 0; i < res.Count; i++)
                {
                    dictionary.Add(res[i], freqNum[i]);
                }
                dictionary.OrderByDescending(p => p.Key).ToDictionary(p => p.Key, o => o.Value);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sr.Close();
            }

            return dictionary;
        }
    }
}
