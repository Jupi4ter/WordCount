using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace wordCount
{
    class Program
    {
        static void Main(string[] args)
        {

            //读入
            string mess = @"G:\input.txt";
            FileStream file = new FileStream(mess, FileMode.Open);
            StreamReader sr = new StreamReader(file);
            List<string> WordsList = new List<string>();//储存处理后的单词
            //List<int> uniqueWordsCountList = new List<int>();
            int countChar = 0;
            int countWords = 0;
            int countLine = 0;

            //输入统计字符串
            //string wholeText = Console.ReadLine();
            //定义分割符

            Regex regex = new Regex("[a-zA-Z]{4,}[a-zA-Z0-9]*");
            //
            string readLine = null;
            while ((readLine = sr.ReadLine()) != null)
            {
                countChar += readLine.Length;
                countLine++;
                string[] wordsArr1 = Regex.Split(readLine, "\\s*[^0-9a-zA-Z]+");
                foreach (string word in wordsArr1)
                {
                    //word = word.ToLower();
                    if (regex.IsMatch(word.ToLower()))
                    {
                        if (WordsList.IndexOf(word.ToLower()) == -1) //判断大小写不同的重复单词
                        {
                            WordsList.Add(word);
                            countWords++;
                        }

                    }
                }

            }
            sr.Close();

            //写入
            FileStream wFile = new FileStream(@"G:\ontput.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(wFile);

            sw.WriteLine("characters: {0}", countChar);
            sw.WriteLine("words: {0}", countWords);
            sw.WriteLine("lines: {0}", countLine);

            sw.Close();
        }
    }
}
