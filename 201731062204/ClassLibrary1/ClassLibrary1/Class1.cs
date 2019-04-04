using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
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
    }
}
