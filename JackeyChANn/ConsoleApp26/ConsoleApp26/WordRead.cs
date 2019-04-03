using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26
{
    class WordRead
    {
        public string ope;
        public int LoadWord()
        {
            if (ope == "-l")
            {
                return 1;
            }
            else if (ope == "-w")
            {
                return 2;
            }
            else if (ope == "-c")
            {
                return 3;
            }
            else
                return 0;
        }

    }
}
