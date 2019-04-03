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
            //StreamWriter writeFile = new StreamWriter("out.txt", false);//false表示将文件覆盖，而不是追加
            //FileOperate fileOperate = new FileOperate("input.txt", writeFile);
            //初始化
            //string[] arg = new string[] { "-i", "input.txt","-o","out.txt","-n","5" };//测试代码
            StreamWriter writeFile = null;
            FileOperate fileOperate = null;
            //创建读文件对象
            for (int i = 0; i < args.Length; i++)
            {
                if(args[i] == "-help" || args[i] == "help")//可以直接使用help命令
                {
                    Console.WriteLine("https://www.cnblogs.com/haveadate/ [version 3.0]");
                    Console.WriteLine("(c) 2019 haveadate 保留所有权利。\n");
                    Console.WriteLine("-i  参数设定读入的文件路径       （必要）     格式：-i [file]");
                    Console.WriteLine("-o  参数设定生成文件的存储路径   （必要）     格式：-o [file]");
                    Console.WriteLine("-m  参数设定统计的词组长度       （非必要）   格式：-m [number]");
                    Console.WriteLine("-n  参数设定输出的单词数量       （非必要）   格式：-n [number]");
                    Console.WriteLine("注: 参数顺序不对结果产生影响");
                    return;
                }
                if(args[i] == "-i")
                {
                    fileOperate = new FileOperate(args[i + 1]);
                    break;//减少不必要的运行
                }
            }
            //创建写文件对象
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-o")
                {
                    writeFile = new StreamWriter(args[i + 1], false);
                    //三个必须输出
                    writeFile.WriteLine("characters: " + fileOperate.charNumber());
                    writeFile.WriteLine("words: " + fileOperate.wordNumber());
                    writeFile.WriteLine("lines: " + fileOperate.lineNumber());
                    break;
                }
            }
            //附加命令处理
            for (int i = 0; i < args.Length; i++)
            {
                if(args[i].StartsWith("-"))//表明该项是输入参数
                {
                    switch(args[i])
                    {                  
                        case "-m":
                            int len = int.Parse(args[i + 1]);//将字符串转换成数字                            
                            Dictionary<string, int> temp1 = fileOperate.wordGroup(len);
                            foreach (KeyValuePair<string, int> keyValuePairs in temp1)//Dictionary的foreach遍历对象自动转换成KeyValuePairs
                            {
                                writeFile.WriteLine(keyValuePairs.Key + ": " + keyValuePairs.Value);
                                writeFile.Flush();//将缓冲区的文件写到基础流                                
                            }
                            break;
                        case "-n":
                            int n = int.Parse(args[i + 1]);//将字符串转换成数字
                            //Console.WriteLine(n);
                            Dictionary<string, int> temp2 = fileOperate.wordTimes(n);
                            foreach (KeyValuePair<string, int> keyValuePairs in temp2)//原理转换不是很清除,命名是推荐的
                            {                               
                                writeFile.WriteLine(keyValuePairs.Key + ": " + keyValuePairs.Value);
                                writeFile.Flush();//将缓冲区的文件写到基础流                                
                            }
                            break;
                        case "-help":
                            Console.WriteLine("https://www.cnblogs.com/haveadate/ [version 3.0]");
                            Console.WriteLine("(c) 2019 haveadate 保留所有权利。\n");
                            Console.WriteLine("-i  参数设定读入的文件路径       （必要）     格式：-i [file]");
                            Console.WriteLine("-o  参数设定生成文件的存储路径   （必要）     格式：-o [file]");
                            Console.WriteLine("-m  参数设定统计的词组长度       （非必要）   格式：-m [number]");
                            Console.WriteLine("-n  参数设定输出的单词数量       （非必要）   格式：-n [number]");
                            Console.WriteLine("注: 参数顺序不对结果产生影响");
                            break;
                        case "-i":
                        case "-o":                            
                            break;
                        default:
                            Console.WriteLine("无效命令行参数，请重新输入！");
                            Console.WriteLine("命令输入格式为：exeName.exe -[命令代号] [命令对应内容]，命令可以无序使用" +
                                "，但必须有-i -o命令。\n想要了解更多，请在输入exeName.exe后输入-help命令");                                   
                            break;
                    }
                }
            }

            //fileOperate.wordTimes(); 
            /*
            fileOperate.charNumber();
            fileOperate.wordNumber();
            fileOperate.lineNumber();
            fileOperate.wordTimes();
            */
            fileOperate.closeFiles();//关闭文件流
            writeFile.Close();
            Console.WriteLine("The result has been saved to the file, please check");
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
        //多态
        public FileOperate(string path)
        {
            this.reader = new StreamReader(path);            
        }
        /// <summary>
        /// 统计字符数，并写入文件
        /// </summary>
        public int charNumber()
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
                //writeFile.WriteLine("characters: " + 0);
                return 0;
            }
            //writeFile.WriteLine("characters: " + num);
            //writeFile.Flush();//将缓冲区的文件写到基础流
            return num;
        }
        /// <summary>
        /// 统计单词数,并写入文件
        /// </summary>
        public int wordNumber()
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
            //writeFile.WriteLine("words: " + num);
            //writeFile.Flush();//将缓冲区的文件写到基础流
            return num;
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
        public int lineNumber()
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
            //writeFile.WriteLine("lines: " + num);
            //writeFile.Flush();//将缓冲区的文件写到基础流
            return num;
        }
        /// <summary>
        /// 统计每个单词出现的次数，并写入文件
        /// </summary>
        public Dictionary<string, int> wordTimes(int number)
        {
            reader.BaseStream.Seek(0, SeekOrigin.Begin);//将文件重新读取一遍
            string temp;//临时的字符串变量
            string[] tempArray;//临时的字符串数组，用于存储每一行的字符串数组
            List<string> wordList = new List<string>();//存储单词的动态链表
            //将单词存储到List集合中
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
                catch(Exception  e)//主要处理重复的情况
                {
                    continue;
                }
            }            
            //使用linq语句排序，以前了解过，很管用，参考https://www.cnblogs.com/wt-vip/p/5997094.html
            var desSort = from tempElement in wordsAndTimes orderby tempElement.Value descending,tempElement.Key ascending select tempElement;
            /*
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
            */
            Dictionary<string, int> keyValues = new Dictionary<string, int>();
            count = 0;
            foreach (KeyValuePair<string, int> keyValuePairs in desSort)//原理转换不是很清除,命名是推荐的
            {
                count++;
                keyValues.Add(keyValuePairs.Key, keyValuePairs.Value);
                if (count == number)
                {
                    //Console.WriteLine("kkk");
                    break;                    
                }
            }
            return keyValues;
        }
        /// <summary>
        /// 词组统计：能统计文件夹中指定长度的词组的词频，约定，词组不能跨行
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        public Dictionary<string, int> wordGroup(int len)//代码复用比较多
        {
            reader.BaseStream.Seek(0, SeekOrigin.Begin);//将文件重新读取一遍
            string temp;//临时的字符串变量
            string[] tempArray;//临时的字符串数组，用于存储每一行的字符串数组
            List<string> wordList = new List<string>();//存储单词的List集合
            while ((temp = reader.ReadLine())!=null)//读取文件
            {
                tempArray = temp.Split(' ');
                for(int i = 0; i < tempArray.Length + 1 - len; i++)//+1-len的原因是后面根本没有足够的词组成词组
                {                     
                    for (int j = 0; j < len; j++)//词组的判断
                    {
                        if((i+j)<tempArray.Length && (!isWords(tempArray[i+j])))
                        {                          
                            goto end;//只要后面几个单词不是词组，那么就不满足词组定义
                            //两个循环无法调出，迫不得已用goto语句
                        }
                    }
                    temp = tempArray[i];
                    for (int j = 1; j < len; j++)//从第二个词开始添加
                    {
                        temp += " ";
                        if((i + j) < tempArray.Length)
                        {
                            //应该有点小bug
                            if (tempArray[i+j].EndsWith(".") || tempArray[i+j].EndsWith(",") || tempArray[i+j].EndsWith("!"))//这里将英语标点符号的特性处理掉
                            {
                                char[] tempCharArray1 = tempArray[i+j].ToCharArray();
                                tempArray[i+j] = new string(tempCharArray1, 0, tempCharArray1.Length - 1);//用字符数组的起始位置和长度创建字符串
                            }
                            temp += tempArray[i + j];
                        }                        
                    }
                    wordList.Add(temp);
                end: continue;
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
                    if (temp.Equals(wordList[j]))//约定词组区分大小写
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
            //使用linq语句排序，以前了解过，很管用，参考https://www.cnblogs.com/wt-vip/p/5997094.html
            var desSort = from tempElement in wordsAndTimes orderby tempElement.Value descending, tempElement.Key ascending select tempElement;
            Dictionary<string, int> keyValues = new Dictionary<string, int>();
            //count = 0;
            foreach (KeyValuePair<string, int> keyValuePairs in desSort)//原理转换不是很清除,命名是推荐的
            {
                //count++;
                keyValues.Add(keyValuePairs.Key, keyValuePairs.Value);
                /*
                if (count == number)
                {
                    //Console.WriteLine("kkk");
                    break;
                }
                */
            }
            return keyValues;
        }
        /// <summary>
        /// 关闭读写文件流
        /// </summary>
        public void closeFiles()
        {           
            reader.Close();
            //writeFile.Close();
        }
    }
    
}
