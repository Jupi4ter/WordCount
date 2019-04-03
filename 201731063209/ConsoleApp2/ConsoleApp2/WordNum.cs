
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounts
{
    class WordNum
    {
        Dictionary<string, int> wordOccNum = new Dictionary<string, int>();
        public int getWordCount(string FilePath)
        {
            int wordCount = 0;
            String line;
            StreamReader sr = new StreamReader(FilePath, Encoding.Default);
            while ((line = sr.ReadLine()) != null)
            {
                string[] words = line.ToLower().Split(' ');
                foreach (string str in words)
                {
                    char[] cc = str.ToCharArray();
                    if (cc.Length > 4)
                    {
                        if (cc[0] >= 97 && cc[0] <= 122
                            && cc[1] >= 97 && cc[1] <= 122
                            && cc[2] >= 97 && cc[2] <= 122
                            && cc[3] >= 97 && cc[3] <= 122)
                        {

                            if (wordOccNum.ContainsKey(str))
                            {
                                wordOccNum[str]++;
                            }
                            else
                            {
                                wordOccNum.Add(str, 1);
                            }
                            wordCount++;

                        }
                    }
                }
            }
            sr.Close();
            return wordCount;
        }

        //判断和度为 wordLength的词组
        public void getWordCount(string FilePath, int wordLength)
        {
            wordOccNum.Clear();
            String line;
            StreamReader sr = new StreamReader(FilePath, Encoding.Default);
            while ((line = sr.ReadLine()) != null)
            {
                string[] words = line.ToLower().Split(' ');
                foreach (string str in words)
                {
                    string key = "";
                    char[] cc = str.ToCharArray();
                    if (cc.Length > 4
                        && cc[0] >= 97 && cc[0] <= 122
                            && cc[1] >= 97 && cc[1] <= 122
                            && cc[2] >= 97 && cc[2] <= 122
                            && cc[3] >= 97 && cc[3] <= 122)
                    {
                        key += str + " ";
                        foreach (string str1 in words)
                        {
                            char[] cc1 = str1.ToCharArray();
                            if (cc1.Length > 4
                                && cc1[0] >= 97 && cc1[0] <= 122
                                    && cc1[1] >= 97 && cc1[1] <= 122
                                    && cc1[2] >= 97 && cc1[2] <= 122
                                    && cc1[3] >= 97 && cc1[3] <= 122)
                            {
                                key += str1 + " ";
                            }
                            else
                            {
                                break;
                            }
                            if (key.Split(' ').Length >= 3) break;
                        }
                    }
                    if (key.Split(' ').Length >= 3)
                    {
                        if (wordOccNum.ContainsKey(key))
                        {
                            wordOccNum[key]++;
                        }
                        else
                        {
                            wordOccNum.Add(key, 1);
                        }
                    }
                }
            }
            sr.Close();
        }

        public Dictionary<string, int> getLinq()
        {

            //返回用
            Dictionary<string, int> returnDict = new Dictionary<string, int>();
            //按个数降序排列
            Dictionary<string, int> tempOrder = wordOccNum.OrderByDescending(o => o.Value).ToDictionary(p => p.Key, o => o.Value);
            //l临时转换用
            Dictionary<string, int> temp = new Dictionary<string, int>();
            int lastValue = 0;
            //循环降序排列的单词列表
            foreach (KeyValuePair<string, int> kvp in tempOrder)
            {
                //只有在个数相同的时候才进行单词名称排序
                //判断临时用字典表是不是空 ， 空的就把当前人单词和个数放进去
                if (temp.Count == 0)
                {
                    temp.Add(kvp.Key, kvp.Value);
                    lastValue = kvp.Value;
                }
                else if (kvp.Value == lastValue)//不是空 判断是不是和上一个单词的个数相同 相同就放里
                {
                    temp.Add(kvp.Key, kvp.Value);
                }
                else if (kvp.Value != lastValue)//不是空  也不相同 把列表按照单词名称将序排列，结果放到返回用的字典里
                {
                    //把已经有的 放到返回里
                    temp.OrderByDescending(p => p.Key).ToList().ForEach(x => returnDict.Add(x.Key, x.Value));
                    temp.Clear();//清空
                    temp.Add(kvp.Key, kvp.Value);//把当前的放进去
                    lastValue = kvp.Value;//记录一下这次人单词个数  用于后面判断
                }
            }
            //循环跳出时临时字典里还有  就再处理一下  清空  防止数据忘记处理
            if (temp.Count > 0)
            {
                temp.OrderByDescending(p => p.Key).ToList().ForEach(x => returnDict.Add(x.Key, x.Value));
            }
            return returnDict;//排序就结束了
        }
    }
}
