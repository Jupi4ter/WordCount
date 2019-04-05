using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hxhandtcy
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo file = new FileInfo(@"D:\hxh.txt");
            StreamReader sw = file.OpenText();
            //建立空字符串用于接收文件读取的内容
            string content = "";
            //记录文件行数
            int account = 0;
            //循环读取文件内容
            while (true)
            {
                //对文件读取内容进行判断，如果不为空用变量接收，行数加一
                string temp = sw.ReadLine();
                if (temp != null)
                {
                    account++;
                    content += temp;
                }
                //为空则停止
                else
                {
                    break;
                }

            }
            //关闭文件
            sw.Close();
            //列表接收正则匹配到的单词
            List<string> test = new List<string>();
            //利用正则进行匹配，以字母开头，可以数字结尾
            MatchCollection rel = Regex.Matches(content, "([a-zA-ZI'm]*\\w+)");
            for (int i = 0; i < rel.Count; i++)
            {
                //匹配到的单词进入列表
                test.Add(Convert.ToString(rel[i]));
            }
            //利用字典进行单词使用数统计
            Dictionary<string, int> hot = new Dictionary<string, int>();
            for (int i = 0; i < test.Count; i++)
            {
                if (hot.ContainsKey(test[i]))
                {
                    hot[test[i]]++;
                }
                else
                {
                    hot[test[i]] = 1;
                }
            }
            //对字典内容排序
            Dictionary<string, int> hot_sort = hot.OrderByDescending(p => p.Value).ToDictionary(p => p.Key, o => o.Value); ;
            //对字典遍历输出
            foreach (KeyValuePair<string, int> kvp in hot_sort)
            {
                Console.WriteLine("单词为:{0}\t次数为：{1}", kvp.Key, kvp.Value);
            }
            Console.WriteLine("文件行数为：{0}", account);
            Console.WriteLine("单词总数为:{0}", test.Count);
        }
    }
}

