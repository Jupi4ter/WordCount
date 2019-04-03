﻿using System;
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
            Console.WriteLine("请输入读取文件名:");
            string fileName = Console.ReadLine();
            string fileContent = File.ReadAllText(fileName);
            string[] lines = fileContent.Split('\n');
            foreach (string i in lines)
            {
                if (i.Trim() != "")
                {
                    validLineList.Add(i);
                }
            }
            int characterNumber = ClassLibrary.CharacterCount(fileContent);;
            int wordNumber = ClassLibrary.WordCount(out vaildWordList,fileContent);
            int linesNumber = validLineList.Count;
            Dictionary<string, int> wordsDictionary =ClassLibrary.EachWordCount(vaildWordList);
            Dictionary<string, int> finalDictionary = Sort(wordsDictionary);
            Output(characterNumber,wordNumber,linesNumber,finalDictionary);
            foreach (string arg in args)
            {
                Console.WriteLine(arg);

                    }
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
