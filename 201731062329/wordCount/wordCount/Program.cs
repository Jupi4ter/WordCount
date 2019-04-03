using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordCount
{
    class Program
    {
        static void Main(String[] args)
        {            
            StreamWriter writeFile = new StreamWriter("out.txt", false);//false表示将文件覆盖，而不是追加
            FileOperate fileOperate = new FileOperate("input.txt", writeFile);
            //fileOperate.wordTimes(); 
            fileOperate.charNumber();
            fileOperate.wordNumber();
            fileOperate.lineNumber();
            fileOperate.wordTimes();
            Console.WriteLine("Please press any key to exit......");
            Console.ReadKey();
        }
    }
    /// <summary>
    /// 对文件的操作类
    /// </summary>
    ///     
    public class FileOperate
    {
        StreamReader reader = null;//读文件的对象
        StreamWriter writeFile = null;//写文件对象
        public FileOperate(string path, StreamWriter writeFile)
        {
            this.reader = new StreamReader(path);
            this.writeFile = writeFile;
        }
        /// <summary>
        /// 统计字符数，并写入文件
        /// </summary>
        public void charNumber()
        {
            reader.BaseStream.Seek(0, SeekOrigin.Begin);//将文件重新读取一遍
            int num = -1;//为了便于统计回车符
            string temp;
            while((temp=reader.ReadLine())!=null)
            {
                num++;
                num += temp.Length;               
            }            
            if(num == -1)
            {
                writeFile.WriteLine("characters: " + 0);
                //return 0;
            }
            writeFile.WriteLine("characters: " + num);
            writeFile.Flush();//将缓冲区的文件写到基础流
            //return num;
        }
        /// <summary>
        /// 统计单词数,并写入文件
        /// </summary>
        public void wordNumber()
        {
            reader.BaseStream.Seek(0, SeekOrigin.Begin);//将文件重新读取一遍
            string temp;//临时变量
            int num = 0;//单词的数目
            while((temp = reader.ReadLine())!=null)
            {
                string[] words = temp.Split(' ');//将每一行拆分成字符串数组
                for(int i = 0; i < words.Length; i++)
                {
                    if(isWords(words[i]))
                    {
                        num++;
                    }
                }
            }           
            writeFile.WriteLine("words: " + num);
            writeFile.Flush();//将缓冲区的文件写到基础流
            //return num;
        }
        /// <summary>
        /// 判断一个字符串是否是单词
        /// </summary>
        private bool isWords(string word)
        {
            char[] ch = word.ToCharArray();//将单词转换成字符数组
            if(ch.Length < 4)
            {
                return false;
            }
            else
            {
                for(int i = 0; i < word.Length; i++)
                {
                    if(i < 4)
                    {
                        //如果前四个字符不为字母，就不是单词
                        if(!((ch[i] >= 'a' && ch[i] <= 'z') || (ch[i] >= 'A' && ch[i] <= 'Z')))
                        {
                            return false;
                        }
                    }
                    else
                    {                        
                        //如果第五个字符开始出现非字母、数字，就不是单词
                        if(!((ch[i] >= 'a' && ch[i] <= 'z') || (ch[i] >= 'A' && ch[i] <= 'Z') || (ch[i] >= '0' && ch[i] <= '9')))
                        {
                            if(i == word.Length - 1)
                            {
                                if(ch[i] == ',' || ch[i] == '.' || ch[i]=='!')//若最后一个字符为","、"."、"!"前面也应该是单词
                                {
                                    return true;
                                }
                            }
                            return false;
                        }
                    }
                }
                return true;
            }
        }
        /// <summary>
        /// 统计有效行数，并写入文件
        /// </summary>
        public void lineNumber()
        {
            reader.BaseStream.Seek(0, SeekOrigin.Begin);//将文件重新读取一遍
            int num = 0;//记录有效行数
            string temp;//临时变量
            while((temp = reader.ReadLine()) != null)
            {
                char[] ch = temp.ToCharArray();//将每一行读取的字符串转换成字符数组
                for(int i = 0; i < ch.Length; i++)
                {
                    //每一行只要有非空格、回车符就为一有效行
                    if(ch[i] != ' ' || ch[i] !=  '\t')
                    {
                        num++;
                        break;
                    }
                }              
            }            
            writeFile.WriteLine("lines: " + num);
            writeFile.Flush();//将缓冲区的文件写到基础流
            //return num;
        }
        /// <summary>
        /// 统计每个单词出现的次数，并写入文件
        /// </summary>
        public void wordTimes()
        {
            reader.BaseStream.Seek(0, SeekOrigin.Begin);//将文件重新读取一遍
            string temp;//临时的字符串变量
            string[] tempArray;//临时的字符串数组，用于存储每一行的字符串数组
            List<string> wordList = new List<string>();//存储单词的动态链表
            //将单词存储到字典中
            while((temp=reader.ReadLine())!=null)
            {
                tempArray = temp.Split(' ');
                for(int i = 0; i < tempArray.Length; i++)
                {
                    if(isWords(tempArray[i]))
                    {
                        if (tempArray[i].EndsWith(".") || tempArray[i].EndsWith(",") || tempArray[i].EndsWith("!"))//这里将英语标点符号的特性处理掉
                        {
                            char[] tempCharArray1 = tempArray[i].ToCharArray();
                            tempArray[i] = new string(tempCharArray1, 0, tempCharArray1.Length - 1);//用字符数组的起始位置和长度创建字符串
                        }
                        wordList.Add(tempArray[i]);
                    }
                }
            }
            int count;//临时变量count记录单词出现的次数
            Dictionary<string, int> wordsAndTimes = new Dictionary<string, int>();//用于存储单词以及他们的次数
            for(int i = 0; i < wordList.Count; i++)
            {
                count = 1;//单词本身就已经出现了一次
                temp = wordList[i];
                for(int j = i+1; j < wordList.Count; j++)
                {
                    if(temp.ToLower().Equals(wordList[j].ToLower()))//不区分大小写的比较
                    {
                        count++;
                    }
                }
                try
                {
                    wordsAndTimes.Add(temp, count);//添加元素
                }
                catch(Exception e)//主要处理重复的情况
                {
                    continue;
                }
            }
            count = 0;
            //使用linq语句排序，以前了解过，很管用，参考https://www.cnblogs.com/wt-vip/p/5997094.html
            var desSort = from tempElement in wordsAndTimes orderby tempElement.Value descending,tempElement.Key ascending select tempElement;
            foreach(KeyValuePair<string,int> keyValuePairs in desSort)//原理转换不是很清除,命名是推荐的
            {
                count++;
                writeFile.WriteLine(keyValuePairs.Key + ": " + keyValuePairs.Value);
                writeFile.Flush();//将缓冲区的文件写到基础流
                if (count == 10)
                {
                    break;
                }
            }           
        }
        /// <summary>
        /// 关闭读写文件流
        /// </summary>
        public void closeFiles()
        {           
            reader.Close();
            writeFile.Close();
        }
    }
    
}
