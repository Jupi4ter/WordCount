using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountAscii;
using CountLine;
using Count;
using LengthDeterminingPhrases;
using OutputWorddll;
using PrintWord;
using System.IO;
using System.Text.RegularExpressions;

namespace Beta1
{
    //Inherit the interface of each component
    public interface IWordCount : ICountAscii, ICountWord, ICountLineAndCharacters, IOutputWord, IPrintResult
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            CountASCII ca = new CountASCII();
            CountLDP cldp = new CountLDP();
            CountLINE cl = new CountLINE();
            Countword cw = new Countword();
            Outputword ow = new Outputword();
            PrintResult pr = new PrintResult();

            string inputTxtPath = @"C:\Users\Administrator.WIN-4K5HDJFV5BS\Desktop\软件工程作业\WordCount\201731072323\test.txt";
            string OutputTxtPath = @"C:\Users\Administrator.WIN-4K5HDJFV5BS\Desktop\软件工程作业\WordCount\201731072323\save.txt";
            //Print result
            pr.PrintWord(ca.CountAscii(inputTxtPath), cw.CountWord(inputTxtPath), cl.CountLine(inputTxtPath), ow.OutputWord(inputTxtPath, 5), cldp.LengthDeterminingPhrases(inputTxtPath, 2), OutputTxtPath);
            Console.ReadKey();
        }
    }
}
