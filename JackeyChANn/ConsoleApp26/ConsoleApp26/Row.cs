using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26
{
    class Rows//行数
    {
        public int Line(string filename)//传入文件位置字符串
        {
            //打开文件
            Encoding encode = Encoding.GetEncoding("GB2312");//中文字符读取
            FileStream fs = new FileStream(@"D:\TESTDIARY\TEST.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs, encode);

            string line;
            int CountLine = 0;//记录行数

            //当当前行不为空，即当前行存在，即 +1 
            while ((line = sr.ReadLine()) != null)
            {
                CountLine++;
            }
            Console.WriteLine("line:" + CountLine);//显示行数

            //关闭文件
            sr.Close();
            fs.Close();

            return CountLine;//注意函数是有返回值的

            //应该先关闭文件再return
        }
    }
}
