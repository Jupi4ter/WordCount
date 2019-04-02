﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> validLineList = new List<string>();
            List<string> vaildWordList;
            Console.WriteLine("请输入读取文件路径:");
            string filePath = Console.ReadLine();
            string fileContent = File.ReadAllText(filePath);
            string[] lines = fileContent.Split('\n');
            foreach (string i in lines)
            {
                if (i.Trim() != "")
                {
                    validLineList.Add(i);
                }
            }
            int characterNumber = CharacterCount(fileContent);
            int wordNumber = WordCount(out vaildWordList,fileContent);
            int linesNumber = validLineList.Count;
            Dictionary<string, int> wordsDictionary = EachWordCount(vaildWordList);
            Console.WriteLine("characters:" + characterNumber);
            Console.WriteLine("word:" + wordNumber);
            Console.WriteLine("lines:" + linesNumber);
            Dictionary<string, int> finalDictionary = Sort(wordsDictionary);
            Output(characterNumber,wordNumber,linesNumber,finalDictionary);

        }


        //统计字符数
        static int CharacterCount(string fileContent)
        {
            return fileContent.Length;
        }

        //为有效单词列表赋值并统计单词数
        static int WordCount(out List<string> validWords, string fileContent)
        {
            validWords = new List<string>();
            string[] tempWords = fileContent.Split(new char[] { '\n', ' ', ',', ';' });
            foreach(string i in tempWords)
            {
                if (i.Length >= 4 && Regex.IsMatch(i.Substring(0, 4),@"^[A-Za-z]+$")&&Regex.IsMatch(i.Trim(),"^[0-9a-zA-Z]+$"))
                {
                    validWords.Add(i.ToLower().Trim());
                }
            }
            return validWords.Count;
        }

        //统计文件中各单词的出现次数
        static Dictionary<string,int> EachWordCount(List<string> vaildWords)
        {
            Dictionary<string,int> wordsDictionary = new Dictionary<string,int>();
            for(int i=0;i<vaildWords.Count; i++)
            {
                if (!wordsDictionary.ContainsKey(vaildWords[i]))
                {
                    wordsDictionary.Add(vaildWords[i], 1);
                }
                else
                {
                    wordsDictionary[vaildWords[i]] += 1;
                }
            }
           
            return wordsDictionary;
        }
        //输出
        static void Output( int characterNumber,int wordNumber,int linesNumber, Dictionary<string, int> wordsDictionary)
        {
            Console.WriteLine("请输入打印文件的路径");
            string outputPath = Console.ReadLine();
            Console.WriteLine("characters:" + characterNumber);
            Console.WriteLine("word:" + wordNumber);
            Console.WriteLine("lines:" + linesNumber);
            File.WriteAllText(outputPath, "characters:" + characterNumber+"\n");
            File.AppendAllText(outputPath, "word:" + wordNumber + "\n");
            File.AppendAllText(outputPath, "lines:" + linesNumber + "\n");

            int k = 0;
            foreach (string key in wordsDictionary.Keys)
            {
                if (k < 10)
                {
                    Console.WriteLine("<"+key+">:" + wordsDictionary[key]);
                    File.AppendAllText(outputPath, "<" + key + ">:" + wordsDictionary[key] + "\n");
                    k++;
                }
                else
                {
                    break;
                }
            }
        }
        //进行排序
        static Dictionary<string, int> Sort(Dictionary<string,int> dictionary)
        {
            try
            {
                Dictionary<string, int> dictionaryDes = dictionary.OrderByDescending(o => o.Value).ToDictionary(o => o.Key, x => x.Value); //按单词出现次数进行第一次排序
                List<string> keyList = new List<string>();
                Dictionary<string, int> tempDictionary = new Dictionary<string, int>();
                foreach (string key in dictionaryDes.Keys)
                {
                    keyList.Add(key);
                    tempDictionary.Add(key, dictionaryDes[key]);
                }
                int flag = 1;
                for (int i = 1; i < keyList.Count && flag == 1; i++)
                {
                    flag = 0;
                    for (int j = 0; j < keyList.Count - i; j++)
                    {
                        string nowKey = keyList[j];
                        string nextKey = keyList[j + 1];
                        if (nowKey.CompareTo(nextKey) > 0 && tempDictionary[nowKey] == tempDictionary[nextKey])
                        {
                            flag = 1;
                            var tempKey = keyList[j];
                            keyList[j] = keyList[j + 1];
                            keyList[j + 1] = tempKey;
                        }
                    }                   
                }
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
