
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounts
{
    class CharNum
    {
        public int getCharCount(string FilePath)
        {
            int charCount = 0;
            FileStream fsRead = new FileStream(FilePath, FileMode.Open);//流方式读取文件
            int fsLen = (int)fsRead.Length;//判断文件长度
            byte[] heByte = new byte[fsLen];//创建对应长度的byte数组
            int r = fsRead.Read(heByte, 0, heByte.Length);//文件内容放到数组里
            foreach (byte b in heByte)  //循环数组判断 是不是在ASCII表内
            {
                if (b >= 0 && b <= 126)
                {
                    charCount++; // 是就+1

                }
            }
            fsRead.Close();
            return charCount;
        }
    }
}
