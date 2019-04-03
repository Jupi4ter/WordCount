using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountWordsNamespace
{
    public class WordNumber
    {
        //读文件的对象
        StreamReader reader = null;
        public WordNumber(string path)
        {
            this.reader = new StreamReader(path);
        }

        /// <summary>
        /// 返回文件中的单词数
        /// </summary>
        public int wordNumber()
        {
            reader.BaseStream.Seek(0, SeekOrigin.Begin);//将文件重新读取一遍
            string temp;//临时变量
            int num = 0;//单词的数目
            while ((temp = reader.ReadLine()) != null)
            {
                string[] words = temp.Split(' ');//将每一行拆分成字符串数组
                for (int i = 0; i < words.Length; i++)
                {
                    if (isWords(words[i]))
                    {
                        num++;
                    }
                }
            }
            return num;
        }
        /// <summary>
        /// 判断一个字符串是否是单词
        /// </summary>
        private bool isWords(string word)
        {
            char[] ch = word.ToCharArray();//将单词转换成字符数组
            if (ch.Length < 4)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (i < 4)
                    {
                        //如果前四个字符不为字母，就不是单词
                        if (!((ch[i] >= 'a' && ch[i] <= 'z') || (ch[i] >= 'A' && ch[i] <= 'Z')))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        //如果第五个字符开始出现非字母、数字，就不是单词
                        if (!((ch[i] >= 'a' && ch[i] <= 'z') || (ch[i] >= 'A' && ch[i] <= 'Z') || (ch[i] >= '0' && ch[i] <= '9')))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }
    }
}
