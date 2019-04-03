using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
namespace ConsoleApp1
{
	class Wordcount
	{
		public string filename;
		public int charcount = 0;//字符数
		public int wordcount = 0;//单词数
		public int linecount = 0;//有效行数
								 //读取文件
		public void Readfile()
		{
			Console.WriteLine("请输入你想读取的文件名：");
			string path = Console.ReadLine();
			if (Directory.Exists(path))
			{
				string[] filename = Directory.GetDirectories(path);
			}
			else
			{
				Console.WriteLine("非法路径!");

			}
		}
		//统计各个数据
		public void Count(string name)
		{
			int i = 0;
			string line = null;
			//StringBuilder sb = new StringBuilder();
			Dictionary<string, int> list = new Dictionary<string, int>();
			FileStream fs = new FileStream(name, FileMode.Open);
			StreamReader sr = new StreamReader(fs);
			//Regex re=new Regex(@"[A-Za-z]{4,}[A-Za-z0-9]*");
			//char[] symbol = { ' ', '\t', ',', '.', '?', '!', ':', ';', '\'', '\"', '\n', '{', '}', '(', ')', '+' ,'-',
			// '*', '='};
			//统计字符数
			while (sr.Read() != -1)
				i++;
			charcount += i;
			//统计单词数
			fs.Position = 0;
			while ((line = sr.ReadLine()) != null)
			{
				wordcount += Regex.Matches(line, @"[A-Za-z]{4,}[A-Za-z0-9]*").Count;
				Console.WriteLine(line);
			}
			//统计有效行数
			fs.Position = 0;
			string lines = "";
			int nullcount = 0;
			while ((lines = sr.ReadLine()) != null)
			{
				lines = lines.Trim(' ');//每一行去掉两头空白字符
				lines = lines.Trim('\t');//每一行去掉两头TAB字符
				if (lines == "" || lines.Length <= 1)
				{
					nullcount++;//空行计数加一
				}
				else
				{
					linecount++;//代码行计数加一
				}
			}
		}
		public void pritnf()
		{
			Console.WriteLine("字符数：" + charcount);
			Console.WriteLine("单词数：" + wordcount);
			Console.WriteLine("有效行数：" + linecount);
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			
			Wordcount wc = new Wordcount();
			//	wc.Readfile();
			wc.Count(@"C:\Users\李文毅\Desktop\123.txt");
			wc.pritnf();
		}
	}
}
