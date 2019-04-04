using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;

namespace LengthDeterminingPhrases
{
    // Function: Computing the number of LengthDeterminingPhrases
    // Parameter: File Path
    // Parameter type: string 
    // Return: pharases and its numbers 
    // Return type:  Dictionary<string, int>,'stirng'is the pharases,'int'is the number of this pharases
    // class name: CountLDP
    // Interface definitions:
    public interface ILengthDeterminingPhrases
    {
        Dictionary<string, int> LengthDeterminingPhrases(string txtPathString, int number);
    }
    //Specific Function Definition
    public class CountLDP:ILengthDeterminingPhrases
    {
        public Dictionary<string, int> LengthDeterminingPhrases(string txtPathString,int number)
        {
            //Determine whether characters are legal
            if (!File.Exists(txtPathString))
            {
                Console.WriteLine("文件不存在！");
                return null;
            }
            string txt = File.ReadAllText(txtPathString);

            //Remove non-numeric and non-alphabetic symbols
            string[] txtString = Regex.Split(txt, @"[^a-z|^A-Z|^0-9]", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            //Remove empty strings from string arrays
            string[] txtS=txtString.Where(s => !string.IsNullOrEmpty(s)).ToArray();

            Dictionary<string, int> pharases = new Dictionary<string, int>();

            List<string> wordPhrases = new List<string>();

            try
            {
                if (number <= txtS.Length)
                {
                    //By four strings per cycle , To determine whether it is a  phrase or not
                    for (int i = 0; i < txtS.Length - number + 1; i++)
                    {

                        List<string> words = new List<string>();
                        for (int j = 0; j < number; j++)
                        {
                            words.Add(txtS[i + j]);
                        }
                        string temp = null;
                        int count = 0;
                        foreach (string word in words)
                        {
                            //Judge whether it's a word or not
                            if (word.Length >= 4 && Regex.IsMatch(word.Substring(0, 4), @"^[A-Za-z]{4}$"))
                            {
                                temp += word + " ";
                                count++;
                                continue;
                            }
                            else break;
                        }
                        if (count == number) wordPhrases.Add(temp);
                    }

                    //Create an array of de - duplicated strings
                    List<string> wordPhrasesDelete = wordPhrases.Distinct().ToList();

                    //Indexing the Number of Corresponding Phrases in the Primary Array by Deduplicated String Array
                    foreach (string wordDelete in wordPhrasesDelete)
                    {
                        int count = 0;
                        foreach (string wordPhrase in wordPhrases)
                        {
                            if (wordDelete == wordPhrase) count++;
                        }
                        pharases.Add(wordDelete, count);
                    }

                    return pharases;
                }
                else return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}

