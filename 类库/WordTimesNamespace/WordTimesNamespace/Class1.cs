using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordTimesNamespace
{
    public class WordTimes
    {
        //读文件的对象
        StreamReader reader = null;
        public WordTimes(string path)
        {
            this.reader = new StreamReader(path);
        }
        /// <summary>
        /// 统计每个单词出现的次数，返回KeyValuePair集合结果
        /// </summary>
        public Dictionary<string, int> wordTimes()
        {
            reader.BaseStream.Seek(0, SeekOrigin.Begin);//将文件重新读取一遍
            string temp;//临时的字符串变量
            string[] tempArray;//临时的字符串数组，用于存储每一行的字符串数组
            List<string> wordList = new List<string>();//存储单词的动态链表
                                                       //将单词存储到字典中
            while ((temp = reader.ReadLine()) != null)
            {
                tempArray = temp.Split(' ');
                for (int i = 0; i < tempArray.Length; i++)
                {
                    if (isWords(tempArray[i]))
                    {
                        wordList.Add(tempArray[i]);
                    }
                }
            }
            int count;//临时变量count记录单词出现的次数
            Dictionary<string, int> wordsAndTimes = new Dictionary<string, int>();//用于存储单词以及他们的次数
            for (int i = 0; i < wordList.Count; i++)
            {
                count = 1;//单词本身就已经出现了一次
                temp = wordList[i];
                for (int j = i + 1; j < wordList.Count; j++)
                {
                    if (temp.ToLower().Equals(wordList[j].ToLower()))//不区分大小写的比较
                    {
                        count++;
                    }
                }
                try
                {
                    wordsAndTimes.Add(temp, count);//添加元素
                }
                catch (Exception e)//主要处理重复的情况
                {
                    continue;
                }
            }
            count = 0;
            //使用linq语句排序，以前了解过，很管用，参考https://www.cnblogs.com/wt-vip/p/5997094.html
            var desSort = from tempElement in wordsAndTimes orderby tempElement.Value descending, tempElement.Key ascending select tempElement;
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach(KeyValuePair<string, int> keyValuePair in desSort)
            {
                result.Add(keyValuePair.Key, keyValuePair.Value);//因为不能将Linq中的KeyValuePair转换成System.Collections.Generic.KeyValuePair,
                //故将其转化为字典类型
            }
            return result;
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
