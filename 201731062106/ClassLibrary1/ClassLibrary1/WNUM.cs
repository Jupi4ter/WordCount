using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class WNUM
    {
        //返回单词数
        public static int GetWnum(string str,ref string word)
        {
            int k = 0;
            string temp1 = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsLetter(str[i]) || char.IsDigit(str[i])) //判断是不是数字或者字母
                {
                    temp1 += str[i];
                }
                else
                {
                    temp1 += " ";
                }
            }

            string[] arr = temp1.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); //去除字符数组中所有空格
            string arr1 = string.Join(" ", arr);
            string[] temp2 = arr1.Split(' ');
            int j = 0, flag = 1;
            for (int i = 0; i < temp2.Length; i++)
            {
                if (temp2[i].Length < 4)
                {
                    continue;
                }
                else
                {
                    for (j = 0; j < 4; j++) //判断前四个是否为字母
                    {
                        flag = 1;
                        if (char.IsDigit(temp2[i][j]))
                        {
                            flag = 0;
                        }

                    }

                    if (flag == 1)
                    {
                        k++;
                        word += temp2[i] + " ";
                    }
                }
            }

            return k;
        }
    }
}
