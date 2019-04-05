using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Char_Number
{
    public class CharNumber
    {
        public static void charNumber(string in_Path,string out_Path)
        {
            int countChar = 0;
            int countLine = 0;
            int[] count = new int[2];//统计字符数&行数
            try
            {
                FileStream file = new FileStream(in_Path, FileMode.Open);
                StreamReader sr = new StreamReader(file);
                string readLine = null;
                while ((readLine = sr.ReadLine()) != null)
                {
                    countChar += readLine.Length;
                    countLine++;
                }
                count[0] = countChar;
                count[1] = countLine;
                sr.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            try
            {
                FileStream wFile = new FileStream(out_Path, FileMode.Create);
                StreamWriter sw = new StreamWriter(wFile);
                sw.WriteLine("characters: {0}", count[0]);
                sw.WriteLine("lines: {0}", count[1]);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }

        }

    }
}
