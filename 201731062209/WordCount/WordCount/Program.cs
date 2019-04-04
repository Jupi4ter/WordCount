using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TestDll;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> validLineList = new List<string>();
            List<string> vaildWordList;
            int groupLength=1;
            string filePath = "";
            string outputPath = "";
            int outputNumber = 10;
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-i")
                {
                    filePath = args[i + 1];
                }
                else if (args[i] == "-o")
                {
                    outputPath = args[i + 1];
                }
                else if (args[i] == "-n")
                {
                    outputNumber = int.Parse(args[i + 1]);
                }
                else if (args[i] == "-m")
                {
                    groupLength = int.Parse(args[i + 1]);
                }
            }
            if(filePath=="")
            {
                Console.WriteLine("请输入文件读取路径:");
                filePath = Console.ReadLine();
            }
            if (outputPath=="")
            {
                Console.WriteLine("请输入文件输出路径:");
                outputPath = Console.ReadLine();
            }
            string fileContent = File.ReadAllText(filePath);
            string[] lines = fileContent.Split('\n');
            foreach (string i in lines)
            {
                if (i.Trim() != "")
                {
                    validLineList.Add(i);
                }
            }
            int characterNumber = ClassLibrary.CharacterCount(fileContent);;                                //统计字符数
            int wordNumber = ClassLibrary.WordGroupCount(out vaildWordList,fileContent,groupLength);        //统计有效/单词(词组)数
            int linesNumber = validLineList.Count;
            Dictionary<string, int> wordsDictionary =ClassLibrary.EachWordCount(vaildWordList);             //统计每个单词(词组)出现的次数
            Dictionary<string, int> finalDictionary = Sort(wordsDictionary);                                //按照出现的次数为单词(词组)降序排序，出现次数相同按字典顺序升序排
            Output(outputPath,characterNumber,wordNumber,linesNumber,finalDictionary,outputNumber);
            Console.ReadKey();
        }
               
        //输出
        public static void Output(string outputPath, int characterNumber,int wordNumber,int linesNumber, Dictionary<string, int> wordsDictionary,int outputNunber)
        {
            Console.WriteLine("characters:" + characterNumber);
            Console.WriteLine("words:" + wordNumber);
            Console.WriteLine("lines:" + linesNumber);
            File.WriteAllText(outputPath, "characters:" + characterNumber+"\n");
            File.AppendAllText(outputPath, "word:" + wordNumber + "\n");
            File.AppendAllText(outputPath, "lines:" + linesNumber + "\n");
            foreach (string key in wordsDictionary.Keys)
            {
                if (outputNunber >0)
                {
                    Console.WriteLine("<"+key+">:" + wordsDictionary[key]);
                    File.AppendAllText(outputPath, "<" + key + ">:" + wordsDictionary[key] + "\n");
                    outputNunber--;
                }
                else
                {
                    break;
                }
            }
        }
        //进行排序
        public static Dictionary<string, int> Sort(Dictionary<string,int> dictionary)
        {
            try
            {
                Dictionary<string, int> dictionaryDes = dictionary.OrderByDescending(o => o.Value).ToDictionary(o => o.Key, x => x.Value); //按单词出现次数进行第一次排序
                List<string> keyList = new List<string>();                                  //用一个List保存一下key，用该List进行排序
                Dictionary<string, int> tempDictionary = new Dictionary<string, int>();     //用一个Dictionary临时保存一下key和value
                foreach (string key in dictionaryDes.Keys)
                {
                    keyList.Add(key);
                    tempDictionary.Add(key, dictionaryDes[key]);
                }
                //按字典顺序进行排序
                bool flag = true;
                for (int i = 1; i < keyList.Count && flag == true; i++)
                {
                    flag = false;
                    for (int j = 0; j < keyList.Count - i; j++)
                    {
                        string nowKey = keyList[j];
                        string nextKey = keyList[j + 1];
                        if (nowKey.CompareTo(nextKey) > 0 && tempDictionary[nowKey] == tempDictionary[nextKey])
                        {
                            flag = true;
                            var tempKey = keyList[j];
                            keyList[j] = keyList[j + 1];
                            keyList[j + 1] = tempKey;
                        }
                    }                   
                }
                //将排好序的keys和values重新写入Dictionary
                dictionary.Clear();      
                for (int n = 0; n < keyList.Count; n++)
                {
                    foreach (string tempKey in tempDictionary.Keys)
                    {
                        if (tempKey.Equals(keyList[n]))
                        {
                            if (!dictionary.ContainsKey(tempKey))
                            {
                                  dictionary.Add(tempKey, tempDictionary[tempKey]);
                            }
                                   
                            
                        }      
                    }     
                }
            }          
            catch{ }
            return dictionary;
        }
    }
}
