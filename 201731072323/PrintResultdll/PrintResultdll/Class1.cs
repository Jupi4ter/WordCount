using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;

namespace PrintWord
{
    public interface IPrintResult
    {
        void PrintWord(int asciiNum, int wordNum, int lineNum, Dictionary<string, int> wordFrequency, Dictionary<string, int> phraseFrequency);
    }
    class PrintResult : IPrintResult
    {

        /// <summary>
        ///  Print all the results
        /// </summary>
        /// <param name="ascii Number"></param>
        /// <param name="word Number"></param>
        /// <param name="line Number"></param>
        /// <param name="word Frequency"></param>
        /// <param name="phrase Frequency"></param>
        public void PrintWord(int asciiNum, int wordNum, int lineNum, Dictionary<string, int> wordFrequency, Dictionary<string, int> phraseFrequency)
        {

            Console.WriteLine("characters: {0}", asciiNum);
            Console.WriteLine("words: {0}", wordNum);
            Console.WriteLine("lines: {0}", lineNum);

            //word frequency
            Console.WriteLine("\nWord Frequency:\n");
            foreach (KeyValuePair<string, int> item in wordFrequency)
            {
                Console.WriteLine("{0} : {1} ", item.Key, item.Value);
            }

            //phrase frequency
            Console.WriteLine("\nPhrase Frequency:\n");
            foreach (KeyValuePair<string, int> item in phraseFrequency)
            {
                Console.WriteLine("{0} : {1} ", item.Key, item.Value);
            }
        }
    }
}

