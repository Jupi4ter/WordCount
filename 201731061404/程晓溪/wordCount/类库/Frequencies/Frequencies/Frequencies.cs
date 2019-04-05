using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace _Frequencies
{
    public class Frequencies
    {
        public static Dictionary<string, int> frequencies(string Path)
        {
            try
            {
                FileStream file = new FileStream(Path, FileMode.Open);
                StreamReader sr = new StreamReader(file);
                Regex regex = new Regex("^[a-zA-Z]{4,}[a-zA-Z0-9]*");
                Dictionary<string, int> frequencies = new Dictionary<string, int>();        //建立字典
                string readLine = null;
                while ((readLine = sr.ReadLine()) != null)
                {
                    string[] wordsArr1 = Regex.Split(readLine, "\\s*[^0-9a-zA-Z]+");//以空格和非字母数字符号分割，至少4个英文字母开头，跟上字母数字符号
                    foreach (string word in wordsArr1)
                    {
                        if (regex.IsMatch(word.ToLower()))
                        {
                            //统计词频
                            if (frequencies.ContainsKey(word.ToLower()))
                            {
                                frequencies[word.ToLower()]++;
                            }
                            else
                            {
                                frequencies[word.ToLower()] = 1;
                            }
                        }

                    }
                }
                sr.Close();
                return frequencies;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            return null;
        }
    }
}
