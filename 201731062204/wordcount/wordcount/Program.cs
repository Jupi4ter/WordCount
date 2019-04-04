using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClassLibrary1;
using ClassLibrary2;
using ClassLibrary3;
using ClassLibrary4;
using System.Text;
using System.Threading.Tasks;
namespace wordcount
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 class1 = new Class1();
            Class2 class2 = new Class2();
            Class3 class3 = new Class3();
            Class4 class4 = new Class4();
           string word = File.ReadAllText(@"C:\Users\hdkj\Desktop\test.txt").ToLower();//将输入的英文字符全部转换为小写字符
            class1.countChar(word);
            class2.Countword(word);
            class3.Countlines();
            class4.frequency(word);
        }
    }
}
