using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace wordcount
{
    class Count
    {
        public void countChar(string word)//统计字符个数
        {
            int num = 0;
            char[] word1 = word.ToCharArray();//将接收的英文存入字符数组方便统计个数
            for (int i = 0; i < word1.Length; i++)
            {
                if (word[i] >= 0 && word[i] <= 127)
                {
                    num++;
                }
            }
            string result1 = @"F:\WordCount\201731062204\wordcount\wordcount\result.txt";
            FileStream fs = new FileStream(result1, FileMode.Append);
            StreamWriter wr = null;
            wr = new StreamWriter(fs);
            wr.WriteLine("characters:" + num);
            wr.Close();
            fs.Close();
        }
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
                        if (chs <= 'Z' && chs >= 'A')
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
        public void Countlines()
        {
            string[] line = File.ReadAllLines(@"C:\Users\hdkj\Desktop\test.txt");
            int lines= line.Length;
            string result1 = @"F:\WordCount\201731062204\wordcount\wordcount\result.txt";
            FileStream fs = new FileStream(result1, FileMode.Append);
            StreamWriter wr = null;
            wr = new StreamWriter(fs);
            wr.WriteLine("lines:" + lines);
            wr.Close();
            fs.Close();
        }                   
    }
    class Program
    {
        static void Main(string[] args)
        {
            Count count = new Count();//实例化  
            string word = File.ReadAllText(@"C:\Users\hdkj\Desktop\test.txt").ToUpper();//将输入的英文字符全部转换为大写字符
            count.countChar(word);
            count.Countlines();
            count.Countword(word);
        }
    }
}
