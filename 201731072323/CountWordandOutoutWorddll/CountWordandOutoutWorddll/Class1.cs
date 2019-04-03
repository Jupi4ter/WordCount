using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;


namespace CountWord
{
    
    public interface ICountWord
    {
        /// <summary>
        /// Count Word interface
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>Word number</returns>
        int CountWord(string filePath);

    }

    public class CountWordandOutputWord : ICountWord
    {
        /// <summary>
        /// this function is to Count all words
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns> output numbers of words</returns>
        public int CountWord(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist！");
                return 0;
            }
            //StreamReader to read file
            StreamReader sr = new StreamReader(filePath, System.Text.Encoding.UTF8);


            int wordNum = 0;    //Numbers of word
            string str = "";    //Save all characters
            string[] word = null;   //Save temporary word
            List<string> res = new List<string>();  //Save all words
            List<int> num = new List<int>();        //Save the words index


            try
            {
                string line = sr.ReadLine();

                while (line != null)
                {
                    str = str + line + " ";
                    line = sr.ReadLine();
                }
                //Delimiters are Spaces and special characters
                word = Regex.Split(str, @"[^a-z|^A-Z|^0-9]", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                //Determine if it is a word
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i].Length >= 4 && Regex.IsMatch(word[i].Substring(0, 3), @"^[A-Za-z]"))
                    {
                        res.Add(word[i]);
                    }
                }

                //Words eliminate heavy
                for (int i = 0; i < res.Count; i++)
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
                wordNum = res.Count;

            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sr.Close();
            }
            return wordNum;
        }

    }
}

