using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace _LimitOut
{
    public class limitOut
    {
        public static void LimitOut(Dictionary<string, int> dic, int i, string Path)
        {
            try
            {
                FileStream wFile = new FileStream(Path, FileMode.Append);
                StreamWriter sw = new StreamWriter(wFile);
                foreach (KeyValuePair<string, int> kvp in dic)
                {
                    if (i > 0)
                    {
                        sw.WriteLine("<" + kvp.Key + ">:" + kvp.Value);
                        i--;
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
