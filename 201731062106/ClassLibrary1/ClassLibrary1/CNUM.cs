using System;

namespace ClassLibrary1
{
    public class CNUM
    {
        //返回字符数
        public static int GetCnum(string str)
        {
            int j = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] < 127)                   //大于127的是汉字
                {
                    j++;
                }
            }
            return j;
        }
    }
}
