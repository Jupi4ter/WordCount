using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
     public class STRNUM
    { 
        public static string GetStr(string str1)
        {
            if (str1=="")
            {
                return "";
            }
            int j = 0;
            str1 = str1.Trim();
            string[] str = str1.Split(' ');
            List<System.String> strList=new List<System.String>(str);
            strList.Sort();
            str = strList.ToArray();      //将LIST转换成string[]
            var temp1 = str.GroupBy(i => i).ToList();
            string temp = "";
            //temp1.ForEach(i =>
            //{
            //    string wordi = i.Key;
            //    int timei = i.Count();
            //    temp += wordi + ":" + timei + "\r\n";
            //});
            foreach (var i in temp1)
            {
                string wordi = i.Key;
                int timei = i.Count();
                temp += wordi + ":" + timei + "\r\n";
                j++;
                if (j == 10)
                {
                    break;
                }
            }
            return temp.ToLower();
        }
    }
}
