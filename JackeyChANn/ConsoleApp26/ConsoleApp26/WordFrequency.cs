using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26
{
    class Wordfrequency
    {
        public void frequency()
        {
            try
            {
                StreamReader sr = new StreamReader(@"D:\TESTDIARY\TEST.txt"); //创建输入流  
                SortedList sortedlist = new SortedList();//创建sortelist对象，该对象可以自动排序  
                char[] delimiter = new char[] { '~', '`', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', ',', ' ', '>', '<', '?', '/', '\\' };
                string line;
                int count = 0;
                line = sr.ReadLine();
                while (line != null)
                {
                    count++;
                    string[] temp = line.Split(delimiter);
                    for (int i = 0; i < temp.Length; i++)
                    {
                        if (!sortedlist.ContainsKey(temp[i]))   //检测该list中是否有该字符  
                        {
                            sortedlist.Add(temp[i], 1); //如果数组中没有该单词加进去  
                        }
                        else
                        {
                            int index = sortedlist.IndexOfKey(temp[i]); //取得指定键的索引  //如果有则更改单词的次数  

                            int value = (int)sortedlist.GetByIndex(index);//取得指定索引的值  
                            value++;
                            sortedlist.SetByIndex(index, value);
                        }
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
                Console.Write(count);
                StreamWriter sw = new StreamWriter(@"D:\TESTDIARY\TEST1.txt");  //打开输出流  
                for (int i = 0; i < sortedlist.Count; i++)
                {
                    string temp = (string)sortedlist.GetKey(i);
                    if (temp == null || temp.Equals(""))
                        continue;
                    else
                    {
                        sw.WriteLine("{0} {1} ", sortedlist.GetKey(i), sortedlist.GetByIndex(i));
                    }
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Can not read!");
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
