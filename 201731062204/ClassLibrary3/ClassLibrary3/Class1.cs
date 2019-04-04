using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary3
{
    public class Class3
    {
        public void Countlines()//统计行数
        {
            string[] line = File.ReadAllLines(@"C:\Users\hdkj\Desktop\test.txt");
            int lines = line.Length;
            string result1 = @"F:\WordCount\201731062204\wordcount\wordcount\result.txt";
            FileStream fs = new FileStream(result1, FileMode.Append);
            StreamWriter wr = null;
            wr = new StreamWriter(fs);
            wr.WriteLine("lines:" + lines);
            wr.Close();
            fs.Close();
        }
    }
}
