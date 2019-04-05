
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
namespace work1
{
    public class Deal
    {
        public static int getCharCount(string text) // 统计文件字符数(ascll码（32~126），制表符，换行符，)
        {
            char c;
            int charNum = 0;
            for (int i = 0; i < text.Length; i++)
            {
                c = text[i]; //把字符串转化为字符数组
                if (c >= (char)32 && c <= (char)126 || c == '\r' || c == '\n' || c == '\t')
                {
                    charNum++;
                }
            }
            return charNum;
        }
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        //ORIGINAL LINE: public static int getLineCount(String text)throws Exception
        public static int getLineCount(string text)
        { // 统计有效行数
            int lineNum = 0;
            string[] line = text.Split("\r\n", true); // 将每一行分开放入一个字符串数组
            for (int i = 0; i < line.Length; i++)
            { // 找出无效行，统计有效行
                if (line[i].Trim().Length == 0)
                {
                    continue;
                }
                lineNum++;
            }
            return lineNum;
        }
        public static string[] getWords(string text)
        {

            text = text.Replace('\r', ' ');
            text = text.Replace('\r', ' ');
            text = text.Replace('\r', ' ');
            string[] words = text.Split(" ", true);
            return words;
        }

        public static int getWordsNum(string text)
        {

            string content = text.Replace('\r', ' ');
            content = text.Replace('\b', ' ');
            content = text.Replace('\n', ' ');
            string[] words = content.Split(" ", true);
            int wordCount = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length < 4)
                {
                    continue;
                }

                int j = 0;
                for (j = 0; j < 4; j++)
                {
                    char c = words[i][j];
                    if (!((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z')))
                    {
                        break;
                    }

                }

                if (j == 4)
                {
                    wordCount++;
                }
            }

            return wordCount;

        }
        public static IDictionary<string, int> getWordFreq(string text) // 统计单词词频(单词：以4个英文字母开头，跟上字母数字符号，单词以分隔符分割，不区分大小写。)
        {
            Dictionary<string, int> wordFreq = new Dictionary<string, int>();

            string content = text.Replace('\r', ' ');
            content = text.Replace('\b', ' ');
            content = text.Replace('\n', ' ');

            string[] words = content.Split(" ", true);


            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length < 4)
                {
                    continue;
                }

                int j = 0;
                for (j = 0; j < 4; j++)
                {
                    char c = words[i][j];
                    if (!((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z')))
                    {
                        break;
                    }
                }
                if (j == 4)
                {
                    words[i] = words[i].Trim().ToLower(); // 将字符串转化为小写
                    if (wordFreq[words[i]] == null)
                    { // 判断之前Map中是否出现过该字符串
                        wordFreq[words[i]] = 1;
                    }
                    else
                    {
                        wordFreq[words[i]] = wordFreq[words[i]] + 1;
                    }
                }
            }
            return wordFreq;
        }
    }
    public class Mainmain
    {


        public static void Main(string[] args)
        {
            FileInfo file = new FileInfo(@"D:\hxh.txt");
            string content = ReadFile.readFileContent(file);
            Console.WriteLine(content);
            int charNUM = Deal.getCharCount(content);
            Console.WriteLine("字符数：" + charNUM);
            int lineNum = Deal.getLineCount(content);
            Console.WriteLine("行数：" + lineNum);
            int wordsNum = Deal.getWordsNum(content);
            Console.WriteLine("单词数：" + wordsNum);

            IDictionary<string, int> wordFreq = Deal.getWordFreq(content);
            /*遍历map*/
            foreach (KeyValuePair<string, int> entry in wordFreq.SetOfKeyValuePairs())
            {
                string key = entry.Key;
                int? value = entry.Value;
                Console.WriteLine("单词:" + key + ", 数量:" + value);
            }
        }

    }
    internal static class StringHelper
    {

        public static string SubstringSpecial(this string self, int start, int end)
        {
            return self.Substring(start, end - start);
        }
        public static bool StartsWith(this string self, string prefix, int toffset)
        {
            return self.IndexOf(prefix, toffset, System.StringComparison.Ordinal) == toffset;
        }
        public static string[] Split(this string self, string regexDelimiter, bool trimTrailingEmptyStrings)
        {
            string[] splitArray = System.Text.RegularExpressions.Regex.Split(self, regexDelimiter);

            if (trimTrailingEmptyStrings)
            {
                if (splitArray.Length > 1)
                {
                    for (int i = splitArray.Length; i > 0; i--)
                    {
                        if (splitArray[i - 1].Length > 0)
                        {
                            if (i < splitArray.Length)
                                System.Array.Resize(ref splitArray, i);

                            break;
                        }
                    }
                }
            }

            return splitArray;
        }

        public static string NewString(sbyte[] bytes)
        {
            return NewString(bytes, 0, bytes.Length);
        }
        public static string NewString(sbyte[] bytes, int index, int count)
        {
            return System.Text.Encoding.UTF8.GetString((byte[])(object)bytes, index, count);
        }
        public static string NewString(sbyte[] bytes, string encoding)
        {
            return NewString(bytes, 0, bytes.Length, encoding);
        }
        public static string NewString(sbyte[] bytes, int index, int count, string encoding)
        {
            return System.Text.Encoding.GetEncoding(encoding).GetString((byte[])(object)bytes, index, count);
        }

        public static sbyte[] GetBytes(this string self)
        {
            return GetSBytesForEncoding(System.Text.Encoding.UTF8, self);
        }
        public static sbyte[] GetBytes(this string self, System.Text.Encoding encoding)
        {
            return GetSBytesForEncoding(encoding, self);
        }
        public static sbyte[] GetBytes(this string self, string encoding)
        {
            return GetSBytesForEncoding(System.Text.Encoding.GetEncoding(encoding), self);
        }
        private static sbyte[] GetSBytesForEncoding(System.Text.Encoding encoding, string s)
        {
            sbyte[] sbytes = new sbyte[encoding.GetByteCount(s)];
            encoding.GetBytes(s, 0, s.Length, (byte[])(object)sbytes, 0);
            return sbytes;
        }
    }
    public class ReadFile
    {

        public string RF(File file)
        {

            FileStream fis = new FileStream(file, FileMode.Open, FileAccess.Read);
            sbyte[] buf = new sbyte[1024];
            StringBuilder sb = new StringBuilder();
            while (fis.Read(buf) != -1)
            {
                sb.Append(StringHelper.NewString(buf));
                buf = new sbyte[1024]; // 重新生成，避免和上次读取的数据重复
            }
            return sb.ToString();



        }

        internal static string readFileContent(FileInfo file)
        {
            throw new NotImplementedException();
        }
    }


}

