using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ClassLibrary2
{
    public class Wnum
    {
        public static int GetWnum(ref string str)
        {
            int k = 0;
            string temp1 = "";
            string word = "";
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

            str = word;
            return k;
        }
        public static string GetStrm(int num,string str1)
        {
            string[] strS = Regex.Split(str1, @"[^a-z|^A-Z|^0-9]", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            string[] strList = strS.Where(s => !string.IsNullOrEmpty(s)).ToArray();
            
            if (str1 == "")
            {
                return "";
            }
            
            
            List<string> phara=new List<string>();
            if (strList.Length<num)
            {
                return "";
            }
            else
            {
                for (int i = 0; i < strList.Length - num+1; i++)
                {
                    string str = "";
                    for (int k = 0; k < num; k++)
                    {
                        str += strList[i+k] + " ";
                    }
                    phara.Add(str);
                }
            }
            List<string> strrD = phara.Distinct().ToList();
            string output = "";

            foreach (string x in strrD)
            {
                int count = 0;
                foreach (string y in phara)
                {
                    if (x == y) count++;
                }
                output += x + ":" + count.ToString() + "\r\n";
            }

            return output;
        }

        public static string Getstrn(int num,string str1)
        {
            if (str1 == "")
            {
                return "";
            }
            int j = 0;
            str1 = str1.Trim();
            string[] str = str1.Split(' ');
            List<System.String> strList = new List<System.String>(str);
            strList.Sort();
            str = strList.ToArray();      //将LIST转换成string[]
            var temp1 = str.GroupBy(i => i).ToList();
            string temp = "";
            foreach (var i in temp1)
            {
                string wordi = i.Key;
                int timei = i.Count();
                temp += wordi + ":" + timei + "\r\n";
                j++;
                if (j == num)
                {
                    break;
                }
            }
            return temp.ToLower();
        }
        //z这个函数并未能实现多参数
        public static string Fileoutput(string[] str,string strr)
        {
            int num1 = 0, num2 = 0;
            string arr = "";
            for (int i=0;i<str.Length;i++)
            {
                if (str[i]=="-m")
                {
                    num1 = Convert.ToInt32(str[i + 1]);
                }

                if (str[i]=="-n")
                {
                    num2 = Convert.ToInt32(str[i + 1]);
                }
            }

            if (num1 == 0)
            {
                arr=Getstrn(num2, strr);
            }
            if (num2==0)
            {
                arr = GetStrm(num1, strr);
            }

            if (num1!=0&&num2!=0)
            {
                arr = GetStrm(num1, strr);
                arr = Getstrn(num2, arr);
            }

            return arr.ToLower();
        }
    }
}
