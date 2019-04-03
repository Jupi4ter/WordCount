using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26
{
    class WriteFile
    {
        public void Write(string theword)
        {
            FileStream fs = new FileStream(@"D:\TESTDIARY\TEST1.txt", FileMode.Create);//相对位置

            // FileStream fs = new FileStream("F:\\c#\\WordCount\\WordCount\\bin\\Debug\\outputFile.txt", FileMode.Create);//绝对位置

            //获得字节数组
            byte[] data = System.Text.Encoding.Default.GetBytes(theword);
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
        }
    }
}
