using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class Class2
    {
        public void Countword(string q)//统计单词数
        {
            int n = 0;
            int num = 0;
            string[] words = q.Split(new char[] { ',', ' ', '.', '?', '!', ':', ';', '—', ',', '"', '\n' });//提取单词
            foreach (string i in words)//判断是否为单词
            {
                if (i.Length >= 4)
                {
                    int cout = 0;
                    int m = 0;
                    n++;
                    char[] ch = i.ToCharArray();
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
                            break;
                        }
                    }
                }
            }
            string result1 = @"F:\WordCount\201731062204\wordcount\wordcount\result.txt";
            FileStream fs = new FileStream(result1, FileMode.Append);
            StreamWriter wr = null;
            wr = new StreamWriter(fs);
            wr.WriteLine("words:" + num);
            wr.Close();
            fs.Close();
        }
    }
}
