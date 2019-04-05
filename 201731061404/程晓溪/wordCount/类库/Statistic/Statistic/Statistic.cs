using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace _Statistic
{
    public class Statistic
    {
        public static void statistic(Dictionary<string, int> dic, string Path, int num)
        {
            try
            {
                FileStream wFile = new FileStream(Path, FileMode.Append);
                StreamWriter sw = new StreamWriter(wFile);
                Dictionary<KeyValuePair<string, int>, int> st = new Dictionary<KeyValuePair<string, int>, int>();
                int flag = 0;

                foreach (KeyValuePair<string, int> kvp in dic)
                {
                    int len = kvp.Key.Length;

                    st.Add(kvp, len);
                }

                foreach (KeyValuePair<KeyValuePair<string, int>, int> kvp in st)
                {
                    if (kvp.Value == num)
                    {
                        flag = 1;
                        sw.WriteLine("The length of word is " + num + " : <" + kvp.Key.Key + ">:" + kvp.Key.Value);
                    }

                }
                if (flag == 0)
                {
                    sw.WriteLine("Nothing");
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }

        }
    }
}
