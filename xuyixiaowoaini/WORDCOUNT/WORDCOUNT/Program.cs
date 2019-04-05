using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WORDCOUNT
{
    public class Program
    {
        static void Main(string[] args)
        {
            Maintest();
        }
        public class Result
        {
            public long charactersnumber = 0;//字符数
            public long wordsnumber = 0;//单词数
            public long linesnumber = 0;//行数
        }
        public static Result Maintest()
        {
            WordIO io = new WordIO();
            WordCalculate datanumber = new WordCalculate();
            WordTrie wtrie = new WordTrie();
            Result res = new Result();

            io.pathIn = "F:\\Demo.txt";
            io.pathOut = "F:\\Result.txt";
            datanumber = io.Input(datanumber, wtrie);  //按行读取文件并统计
            io.Output(datanumber, wtrie);
            res.charactersnumber = datanumber.charactersnumber;
            res.wordsnumber = datanumber.wordsnumber;
            res.linesnumber = datanumber.linesnumber;
            return res;
        }
    }
    public class WordIO
    {
        public string pathIn;
        public string pathOut;

        //按行读取输入文件并统计
        public WordCalculate Input(WordCalculate datanumber, WordTrie wtrie)
        {
            FileStream fs = null;
            StreamReader sr = null;
            String dataline = String.Empty;
            try
            {
                fs = new FileStream(this.pathIn, FileMode.Open);
                sr = new StreamReader(fs);
                while ((dataline = sr.ReadLine()) != null)
                {
                    datanumber.Calculate(dataline, wtrie);  //按行统计数据
                }
            }
            catch { Console.WriteLine("wrong！"); }
            finally
            {
                if (sr != null) { sr.Close(); }
                if (fs != null) { fs.Close(); }
            }
            return datanumber;
        }

        //将统计数据输出并写到输出文件
        public void Output(WordCalculate datanumber, WordTrie wtrie)
        {
            FileStream fs = null;
            StreamWriter sw = null;
            List<WordTrie.ListUnit> WordList = new List<WordTrie.ListUnit>();
            try
            {
                fs = new FileStream(this.pathOut, FileMode.Create);
                sw = new StreamWriter(fs);
                WordList = wtrie.Sort();
                sw.WriteLine("字符总数为：{0}", datanumber.charactersnumber);
                sw.WriteLine("单词总数为：{0}", datanumber.wordsnumber);
                sw.WriteLine("有效行数为：{0}", datanumber.linesnumber);
                sw.WriteLine("\n词频\t单词\n");
                Console.WriteLine("字符总数为：{0}", datanumber.charactersnumber);
                Console.WriteLine("单词总数为：{0}", datanumber.wordsnumber);
                Console.WriteLine("有效行数为：{0}", datanumber.linesnumber);
                Console.WriteLine("\n词频\t单词\n");
                for (int i = 0; (i < 10 && i < WordList.Count); i++)
                {
                    sw.WriteLine("{0}\t{1}",WordList[i].WordNum, WordList[i].Word);
                    Console.WriteLine("{0}\t{1}",WordList[i].WordNum,  WordList[i].Word);
                }
            }
            catch { Console.WriteLine("文档写入失败！"); }
            finally
            {
                if (sw != null) 
                { 
                    sw.Close(); 
                }
                if (fs != null) 
                {
                    fs.Close();
                }
            }
        }
    }

    public class WordTrie
    {
        //Trie树节点
        private class TrieNode
        {
            public int PrefixNum = 0;  
            public int WordNum = 0;  //单词出现次数
            public Dictionary<char, TrieNode> Sons = new Dictionary<char, TrieNode>();  
            public bool IsEnd = false;  
            public char Val; 
            public string Word = null; 
            
            public TrieNode()
            {
            }
            public TrieNode(char val)
            {
                Val = val;
            }
        }

        private TrieNode _Root = new TrieNode();

        public int CountSum
        {
            get { return _Root.PrefixNum; }
        }

        
        public void Insert(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return;
            }
            TrieNode node = _Root;
            node.PrefixNum++;
            for (int i = 0, len = word.Length; i < len; i++)
            {
                char pos = word[i];
                if (!node.Sons.ContainsKey(pos))
                {
                    node.Sons[pos] = new TrieNode(pos);
                }
                node.Sons[pos].PrefixNum++;
                node = node.Sons[pos];
            }
            node.Word = word;
            node.IsEnd = true;
            node.WordNum++;
        }
        
        public int PrefixCount(string prefix)
        {
            return GetCount(prefix, false);
        }

        //获取单词词频
        public int WordCount(string word)
        {
            return GetCount(word, true);
        }

        private int GetCount(string str, bool isword)
        {
            if (string.IsNullOrEmpty(str))
            {
                return -1;
            }
            TrieNode node = _Root;
            for (int i = 0, len = str.Length; i < len; i++)
            {
                char pos = str[i];
                if (!node.Sons.ContainsKey(pos)) return 0;
                else node = node.Sons[pos];
            }
            return isword ? node.WordNum : node.PrefixNum;
        }

        //是否包含指定的单词
        public bool ContainsWord(string word)
        {
            return WordCount(word) > 0;
        }

        //单词表单元
        public class ListUnit
        {
            public string Word;  //单词
            public int WordNum;  //词频
        }

        //词频排序
        public List<ListUnit> Sort()
        {
            TrieNode node = _Root;
            List<ListUnit> WordList = new List<ListUnit>();
            WordList = WordPreOrder(node, WordList);
            //按词频降序排列，若词频相等按字典序排列
            WordList.Sort((a, b) =>
            {
                if (a.WordNum.CompareTo(b.WordNum) != 0)
                    return -a.WordNum.CompareTo(b.WordNum);
                else
                    return a.Word.CompareTo(b.Word);
            });
            return WordList;
        }

        //单词表生成
        private List<ListUnit> WordPreOrder(TrieNode node, List<ListUnit> WordList)
        {
            if (node.PrefixNum == 0) { return WordList; }
            if (node.WordNum != 0)
            {
                ListUnit unit = new ListUnit();
                unit.Word = node.Word;
                unit.WordNum = node.WordNum;
                WordList.Add(unit);
            }
            foreach (char key in node.Sons.Keys)
            {
                WordList = WordPreOrder(node.Sons[key], WordList);
            }
            return WordList;
        }
    }

    public class WordCalculate
    {
        public long charactersnumber = 0;  //统计数据：字符数
        public long wordsnumber = 0;  //统计数据：单词数
        public long linesnumber = 0;  //统计数据：行数
        //数据统计
        public void Calculate(string dataline, WordTrie wtrie)
        {
            if (string.IsNullOrEmpty(dataline)) return;
            string word = null;
            for (int i = 0, len = dataline.Length; i < len; i++)
            {
                char unit = dataline[i];
                if (unit >= 65 && unit <= 90) 
                { 
                    unit = (char)(unit + 32); 
                }  //大写字母转换成小写
                if ((unit >= 48 && unit <= 57) || (unit >= 97 && unit <= 122))
                {
                    word = String.Concat(word, unit);
                }
                else
                {
                    if (!string.IsNullOrEmpty(word))  //判断是否为词尾后的字符
                    {
                        if ((word[0] >= 97 && word[0] <= 122) ) 
                        { 
                            wtrie.Insert(word); 
                        }
                        word = null;
                    }
                }
            }
            if (!string.IsNullOrEmpty(word))  
            {
                if ((word[0] >= 97 && word[0] <= 122) ) 
                { 
                    wtrie.Insert(word); 
                }
                word = null;
            }
            this.linesnumber++;  //统计行数
            this.wordsnumber = wtrie.CountSum;  //统计单词数
            this.charactersnumber += dataline.Length;  //统计字符数
        }
    }


}
