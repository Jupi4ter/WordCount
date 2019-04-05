
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounts
{
    class FileLines
    {
        public int getFileLineCount(string FilePath)
        {
            int lineCount = 0;
            StreamReader sr = new StreamReader(FilePath, Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                lineCount++;
            }
            sr.Close();
            return lineCount;
        }
    }
}
