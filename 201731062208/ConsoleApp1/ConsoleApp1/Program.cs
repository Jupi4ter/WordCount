using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
namespace ConsoleApp1
{
	public class Wordcount
	{
		public int charcount = 0;//字符数
		public int wordcount = 0;//单词数
		public int linecount = 0;//有效行数							 
		//统计单词
		public void Countword(string name, string name2)
		{
			string str1 = null;
			int value;
			Dictionary<string, int> dic = new Dictionary<string, int>();
			char[] delimiter = new char[] { '-', '~', '`', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', ',', ' ', '>', '<', '?', '/', '\\', '.' };
			FileStream fs = new FileStream(name, FileMode.Open);
			FileStream fs2 = new FileStream(name2, FileMode.Open);
			StreamReader sr = new StreamReader(fs);
			StreamWriter sw = new StreamWriter(fs2);
			str1 = sr.ReadToEnd().Replace((char)10, ' ').Replace((char)13, ' ').ToLower();
			string[] temp = str1.Split(delimiter);
			//判断一个字符串是否是单词，如果是就将它们存入字典
			foreach (string a in temp)
			{
				if (Regex.IsMatch(a, @"^[A-Za-z]{4,}[A-Za-z0-9]*"))
				{
					if (!dic.ContainsKey(a))
						dic.Add(a, 1);
					else
					{
						value = dic[a];
						value++;
						dic.Remove(a);
						dic.Add(a, value);
					}
				}
			}
			//通过下面这个循环统计单词数
			foreach (string key in dic.Keys.Distinct())
			{
				wordcount++;
			}
			//对字典里的元素排序
			dic = (from entry in dic
				   orderby entry.Value descending, entry.Key
				   select entry).ToDictionary(pair => pair.Key, pair => pair.Value);
			Console.WriteLine("words:"+wordcount);
			sw.WriteLine("words:" + wordcount);
			//输出前十个元素
			foreach (KeyValuePair<string, int> kvp in dic.Take(10))
			{
				Console.WriteLine("<" + kvp.Key + ">: " + kvp.Value);
				sw.WriteLine("<" + kvp.Key + ">: " + kvp.Value);
			}
			sw.Close();
		}
		//统计字符数
		public void Countchar(string name, string name2)
		{
			FileStream fs = new FileStream(name, FileMode.Open);
			FileStream fs2 = new FileStream(name2, FileMode.Open);
			StreamReader sr = new StreamReader(fs);
			StreamWriter sw = new StreamWriter(fs2);
			int i = 0;
			while (sr.Read() != -1)
			{
				i++;
			}
			charcount += i;
			Console.WriteLine("characters:" + charcount);
			sw.WriteLine("characters:" + charcount.ToString());
			sw.Close();
		}
		//统计有效行数
		public void Countline(string name, string name2)
		{
			FileStream fs = new FileStream(name, FileMode.Open);
			FileStream fs2 = new FileStream(name2, FileMode.Open);
			StreamReader sr = new StreamReader(fs);
			StreamWriter sw = new StreamWriter(fs2);
			string lines = "";
			int nullcount = 0;
			while ((lines = sr.ReadLine()) != null)
			{
				lines = lines.Trim(' ');//每一行去掉两头空白字符
				lines = lines.Trim('\t');//每一行去掉两头TAB字符
				if (lines == "" || lines.Length <= 0)
				{
					nullcount++;//空行计数加一
				}
				else
				{
					linecount++;//非空行计数加一
				}
			}
			Console.WriteLine("lines:" + linecount);
			sw.WriteLine("lines:"+linecount);
			sw.Close();
		}
		
	}
	public class Program
	{
		public static void Main(string[] args)
		{
			Wordcount wc = new Wordcount();
			/*	Console.WriteLine("请输入想读取的文件路径：");
				string name = Console.ReadLine();
				Console.WriteLine("请输入想写入的文件路径：");
				string name2 = Console.ReadLine();*/
				Console.WriteLine("请输入操作编号：");
				string name = @"C: \Users\李文毅\Desktop\123.txt";
				string name2 = @"C: \Users\李文毅\Desktop\result.txt";
				Console.WriteLine("a:统计字符数"+"\n"+"b:统计单词数并输出频率最高的前十个单词"+"\n"+"c:统计有效行数");
				string str = Console.ReadLine();
				switch (str)
				{
					case "a" :
						wc.Countchar(name,name2);
						break;
					case "b":
						wc.Countword(name, name2);
						break;
					case "c":
						wc.Countline(name, name2);
						break;
				}
	}
	}
}
