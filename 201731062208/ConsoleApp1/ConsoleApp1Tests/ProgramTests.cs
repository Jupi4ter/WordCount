using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1.Tests
{
	[TestClass()]
	public class ProgramTests
	{
		[TestMethod()]
		public void MainTest()
		{
			string name = @"C: \Users\李文毅\Desktop\123.txt";
			string name2 = @"C: \Users\李文毅\Desktop\result.txt";
			//我们对一个固定路径的文档统计数据，我们已经知道了结果，
			//所以只需判断运行之后能否得到这个结果就好了
			Wordcount wc = new Wordcount();
			wc.Countchar(name,name2);
			Assert.AreEqual(wc.wordcount,77);
		}
	}
}