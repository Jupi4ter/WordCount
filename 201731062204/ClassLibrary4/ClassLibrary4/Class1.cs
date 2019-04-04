using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary4
{
    public class Class4
    {
        public void frequency(string q)//统计出现频率最高的前十个单词
        {
            List<string> list = new List<string>();
            int n = 0;
            int num = 0;
            char[] ch = null;
            string[] words = q.Split(new char[] { ',', ' ', '.', '?', '!', ':', ';', '—', ',', '"', '\n' });//提取单词
            foreach (string i in words)//判断是否为单词
            {
                if (i.Length >= 4)
                {
                    int cout = 0;
                    int m = 0;
                    n++;
                    ch = i.ToCharArray();
                    foreach (char chs in ch)
                    {
                        cout++;
                        if (chs <= 'z' && chs >= 'a')
                        {
                            m++;
                        }
                        while (m == 4 && cout == 4)
                        {
                            num++;
                            string v = new string(ch);
                            list.Add(v);
                            break;
                        }
                    }
                }
            }
            var result = from item in list
                         group item by item into team
                         orderby team.Count() descending//按照数量进行排序
                         select new
                         {
                             a = team.Key,
                             b = team.Count()//输出值以及次数
                         };
            foreach (var item in result.Take(10))
            {
                string result1 = @"F:\WordCount\201731062204\wordcount\wordcount\result.txt";
                FileStream fs = new FileStream(result1, FileMode.Append);
                StreamWriter wr = null;
                wr = new StreamWriter(fs);
                wr.WriteLine(string.Format("{0}：{1}", item.a, item.b + "\n"));//输出前几个单词
                wr.Close();
                fs.Close();
            }
        }
    }
}
