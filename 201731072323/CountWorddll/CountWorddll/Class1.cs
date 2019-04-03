using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;

namespace Word
{
    public interface ICountWord
    {
        int CountWord(string filePath);
    }

    public class Countword : ICountWord
    {
        public int CountWord(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("文件不存在！");
                return 0;
            }

            StreamReader sr = new StreamReader(filePath, System.Text.Encoding.UTF8);
            int wordNum = 0;
            //StringBuilder res = new StringBuilder();
            //string res = "";
            string str = "";
            string[] word = null;
            List<string> res = new List<string>();


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

                    if (Regex.IsMatch(word[i], @"[a-zA-Z]{4}\w+"))
                    {
                        res.Add(word[i]);
                    }
                }

                return res.Count;

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