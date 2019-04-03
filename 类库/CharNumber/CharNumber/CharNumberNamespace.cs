using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharNumberNamespace
{
    public class CharNumber
    {        
        //读文件的对象,由需求得，方法应该为静态放法--也不一定
        StreamReader reader = null;
        public CharNumber(string path)
        {
            this.reader = new StreamReader(path);
        }
        
        /// <summary>
        /// 返回文件中的字符数
        /// </summary>
        public int countChar()
        {
            reader.BaseStream.Seek(0, SeekOrigin.Begin);//将文件重新读取一遍
            int num = -1;//为了便于统计回车符
            string temp;
            while ((temp = reader.ReadLine()) != null)
            {
                num++;//将回车符计入在内
                num += temp.Length;
            }
            if (num == -1)
            {               
                return 0;
            }
            reader.Close();//关闭文件流
            return num;
        }
    }
}
