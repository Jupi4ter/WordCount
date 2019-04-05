using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Word_Number
{
    public class WordNumber
    {
        public static void wordNumber(string in_Path, string out_Path)
        {
            try
            {
                FileStream file = new FileStream(in_Path, FileMode.Open);
                StreamReader sr = new StreamReader(file);
                List<string> WordsList = new List<string>();//储存处理后的单词

                int countWords = 0;


                //输入统计字符串
                //string wholeText = Console.ReadLine();
                //定义分割符
                Regex regex = new Regex("^[a-zA-Z]{4,}[a-zA-Z0-9]*");
                string readLine = null;
                while ((readLine = sr.ReadLine()) != null)
                {
                    string[] wordsArr1 = Regex.Split(readLine, "\\s*[^0-9a-zA-Z]+");//以空格和非字母数字符号分割，至少4个英文字母开头，跟上字母数字符号
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

                FileStream wFile = new FileStream(out_Path, FileMode.Append);
                StreamWriter sw = new StreamWriter(wFile);
                sw.WriteLine("words: {0}", countWords);
                sw.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
           
        }

        }
}
