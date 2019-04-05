using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace _Sort
{
    public class sort
    {
        public static void Sort(Dictionary<string, int> dic, string out_Path)
        {
            try
            {
                //同频率按字典序排序
                //先按照key值字典序升序排序，再按照value值降序排序
                var _dicSort = from objDic in dic orderby objDic.Key select objDic;
                var dicSort = from objDic in _dicSort orderby objDic.Value descending select objDic;

                string[] str = new string[dicSort.Count()];

                FileStream wFile = new FileStream(out_Path, FileMode.Append);
                StreamWriter sw = new StreamWriter(wFile);

                if (dicSort.Count() < 10)
                {

                    foreach (KeyValuePair<string, int> kvp in dicSort)
                    {
                        sw.WriteLine("<" + kvp.Key + ">:" + kvp.Value);
                    }
                }
                else
                {
                    for (int i = 0; i < dicSort.Count(); i++)
                    {
                        foreach (KeyValuePair<string, int> kvp in dicSort)
                        {
                            sw.WriteLine("<" + kvp.Key + ">:" + kvp.Value);
                        }
                    }
                }

                sw.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }
    }
}
