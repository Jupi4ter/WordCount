using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace WY
{
    class Function
    {
        //定义整型变量记录行数
        int account = 0;
        //定义空字符串用于接收文件内容
        string content = "";
        //列表接收正则匹配到的单词
        List<string> result = new List<string>();
        //利用接收单词以及其出现次数
        Dictionary<string, int> words_sort = new Dictionary<string, int>();
        //接收文件路径
        string path = "";
        public Function(string path)
        {
            //构造函数
            this.path = path;
        }
        //读取文件中的字符数目并保存文件内容
        public void GetChar()
        {
            //打开文件
            FileInfo file = new FileInfo(this.path);
            //定义读取文件对象
            StreamReader sw = file.OpenText();
            //按行进行读取，不为空行记录行数并保存内容，返回null打断循环
            while (true)
            {
                //对文件读取内容进行判断，如果不为空用变量接收，行数加一
                string temp = sw.ReadLine();
                if (temp != null)
                {
                    account++;
                    this.content += temp;
                }
                //为空则停止
                else
                {
                    break;
                }

            }
        }
        //利用正则表达式提取出文件中的英文单词
        public void ExtractChar()
        {
            //利用正则进行匹配，以字母开头，可以数字结尾
            MatchCollection rel = Regex.Matches(this.content, @"([a-zA-Z]{4}\w*)");
            for (int i = 0; i < rel.Count; i++)
            {
                //匹配到的单词进入列表
                this.result.Add(Convert.ToString(rel[i]));
            }
        }
        //将正则结果列表中所有单词转为小写
        public void ToLow()
        {
            foreach (string _ in this.result)
            {
                _.ToLower();
            }
        }
        //返回文件中字符总数
        public int CharNum()
        {
            MatchCollection m = Regex.Matches(this.content, @"[^\u4E00-\u9FA5]*");
            string temp = "";
            for (int i = 0; i < m.Count; i++)
            {

                temp += Convert.ToString(m[i]);
            }
            return temp.Length;
        }
        //返回文件中单词总数
        public int WordsNum()
        {
            return this.result.Count;
        }
        //利用字典统计单词出现次数
        public void Statistical()
        {
            //建立临时字典保存单词以及出现次数
            Dictionary<string, int> words = new Dictionary<string, int>();
            for (int i = 0; i < this.result.Count; i++)
            {
                if (words.ContainsKey(this.result[i]))
                {
                    words[this.result[i]]++;
                }
                else
                {
                    words[this.result[i]] = 1;
                }
            }
            //对字典内容排序，并赋值给类变量
            this.words_sort = words.OrderByDescending(p => p.Value).ToDictionary(p => p.Key, o => o.Value);
            //清空临时字典内容
            words.Clear();

        }
        //将内容写入文件中
        public void ToFile(string path)
        {
            //运行先行函数，将需要的文件内容保存至变量中
            this.GetChar();
            this.ExtractChar();
            this.ToLow();
            this.Statistical();
            //获取当前文件路径
            string filepath = Directory.GetCurrentDirectory();
            //定义文件输出路径
            filepath += path;
            FileInfo file = new FileInfo(@filepath);
            StreamWriter sw = file.AppendText();
            sw.WriteLine("characters: {0}", this.CharNum());
            sw.WriteLine("words: {0}", this.WordsNum());
            sw.WriteLine("lines: {0}", this.account);
            ////遍历字典将内容写入文件
            //foreach(KeyValuePair<string,int> kvp in this.words_sort)
            //{
            //    sw.WriteLine("{0,-10}:{1,-3}", kvp.Key, kvp.Value);
            //}
            foreach (KeyValuePair<string, int> kvp in this.words_sort)
            {
                sw.WriteLine("{0,-10}:{1,-3}", kvp.Key, kvp.Value);
            }
            //关闭文件
            sw.Close();
            Console.WriteLine("结果文件保存于:{0}", filepath);
        }        
    }
}
