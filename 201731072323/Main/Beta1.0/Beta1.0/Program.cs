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

    //Inherit all interfaces
    class WordCount : IWordCount
    {
        public int CountAscii(string txtPathString)
        {

            int charactersNumber = 0;
            try
            {
                //Determine whether a document exists
                if (!File.Exists(txtPathString))
                {
                    Console.WriteLine("the file is not exist");
                }

                string temp = File.ReadAllText(txtPathString);

                //Determine whether characters are legal
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i] >= 0 && temp[i] <= 127)
                    {
                        charactersNumber++;
                    }
                }
                return charactersNumber;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return charactersNumber;
        }

        public int CountLine(string txtPathString)
        {
            FileStream txtFileStream = null;
            StreamReader txtStreamReader = null;
            int effectiveRowNumber = 0;
            try
            {
                //Determine whether a document exists
                if (!File.Exists(txtPathString))
                {
                    Console.WriteLine("the file is not exist");
                }
                //open the file,read by line
                txtFileStream = new FileStream(txtPathString, FileMode.Open, FileAccess.Read);
                txtStreamReader = new StreamReader(txtFileStream);
                string temp = txtStreamReader.ReadLine();
                while (temp != null)
                {
                    int i = 0;
                    for (i = 0; i < temp.Length; i++)
                    {
                        if (Convert.ToString(temp[i]) == "\\s")
                        {
                            continue;
                        }
                        else break;
                    }
                    if (i == temp.Length)
                    {
                        temp = txtStreamReader.ReadLine();
                    }
                    else
                    {
                        effectiveRowNumber++;
                        temp = txtStreamReader.ReadLine();
                    }
                }
                return effectiveRowNumber;
            }
            catch
            {
            }
            //Recycling resources
            finally
            {
                if (txtFileStream != null)
                {
                    txtFileStream.Close();
                }
                if (txtStreamReader != null)
                {
                    txtStreamReader.Close();
                }
            }
            return effectiveRowNumber;
        }

        public Dictionary<string, int> LengthDeterminingPhrases(string txtPathString, int number)
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
            string[] txtS = txtString.Where(s => !string.IsNullOrEmpty(s)).ToArray();

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

        public int CountWord(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist！");
                return 0;
            }
            //StreamReader to read file
            StreamReader sr = new StreamReader(filePath, System.Text.Encoding.UTF8);


            int wordNum = 0;    //Numbers of word
            string str = "";    //Save all characters
            string[] word = null;   //Save temporary word
            List<string> res = new List<string>();  //Save all words
            List<int> num = new List<int>();        //Save the words index


            try
            {
                string line = sr.ReadLine();

                while (line != null)
                {
                    str = str + line + " ";
                    line = sr.ReadLine();
                }
                //Delimiters are Spaces and special characters
                word = Regex.Split(str, @"[^a-z|^A-Z|^0-9]", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                //Determine if it is a word
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i].Length >= 4 && Regex.IsMatch(word[i].Substring(0, 4), @"^[a-zA-Z]{4}$"))
                    {
                        res.Add(word[i]);
                    }
                }
                word = res.ToArray();

                //Words eliminate heavy
                for (int i = 0; i < res.Count - 1; i++)
                {
                    for (int j = i + 1; j < res.Count; j++)
                    {
                        if ((res[j].ToLower() == res[i].ToLower()))
                        {
                            num.Add(j);
                        }
                    }
                }
                num.Sort();
                num = num.Distinct().ToList();
                num.Reverse();
                for (int i = 0; i < num.Count; i++)
                {
                    res.RemoveAt(num[i]);
                }
                wordNum = res.Count;

            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sr.Close();
            }
            return wordNum;

        }

        public Dictionary<string, int> OutputWord(string filePath, int outNum)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist！");
                return null;
            }
            //StreamReader to read file
            StreamReader sr = new StreamReader(filePath, System.Text.Encoding.UTF8);

            int wordNum = 0;
            string str = "";
            string[] word = null;
            List<string> res = new List<string>();  //Save all words
            List<string> temp = new List<string>(); //Temporary word
            List<int> num = new List<int>();        //Save words index
            List<int> freqNum = new List<int>();    //Save the frequency
            Dictionary<string, int> dictionary = new Dictionary<string, int>(); //Save the word and its frequency
            Dictionary<string, int> outWord = new Dictionary<string, int>();
            try
            {

                string line = sr.ReadLine();
                //Read all characters in the file
                while (line != null)
                {
                    str = str + line + " ";
                    line = sr.ReadLine();
                }

                //Delimiters are Spaces and special characters
                word = Regex.Split(str, @"[^a-z|^A-Z|^0-9]", RegexOptions.IgnoreCase);

                for (int i = 0; i < word.Length; i++)
                {
                    //Determine if it is a word
                    if (word[i].Length >= 4 && Regex.IsMatch(word[i].Substring(0, 4), @"^[A-Za-z]{4}$"))
                    {
                        res.Add(word[i]);
                        temp.Add(word[i]);
                    }
                }

                //Words eliminate heavy
                for (int i = 0; i < res.Count - 1; i++)
                {
                    for (int j = i + 1; j < res.Count; j++)
                    {
                        if ((res[j].ToLower() == res[i].ToLower()))
                        {
                            num.Add(j);
                        }
                    }
                }
                num.Sort();
                num = num.Distinct().ToList();
                num.Reverse();
                for (int i = 0; i < num.Count; i++)
                {
                    res.RemoveAt(num[i]);
                }

                //Count words frequency
                for (int i = 0; i < res.Count; i++)
                {
                    wordNum = 0;
                    for (int j = i; j < temp.Count; j++)
                    {
                        if ((temp[j].ToLower() == res[i].ToLower()))
                        {
                            wordNum++;
                        }
                    }
                    freqNum.Add(wordNum);
                }

                //Write the types and frequencies of words into the dictionary
                for (int i = 0; i < res.Count; i++)
                {
                    dictionary.Add(res[i], freqNum[i]);
                }

                //Sort the value of the dictionary
                dictionary = DictonarySort(dictionary);

                //Print outNumber words
                for (int i = 0; i < outNum; i++)
                {
                    outWord.Add(dictionary.ElementAt(i).Key, dictionary.ElementAt(i).Value);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sr.Close();
            }

            return outWord;
        }

        //Sort the value of the dictionary  <linq dictionary .net 3.5>
        private Dictionary<string, int> DictonarySort(Dictionary<string, int> dic)
        {
            var dicSort = from objDic in dic orderby objDic.Value descending select objDic;
            return dicSort.ToDictionary(p => p.Key, o => o.Value);
        }


        public void PrintWord(int asciiNum, int wordNum, int lineNum, Dictionary<string, int> wordFrequency, Dictionary<string, int> phraseFrequency, string filePath)
        {
            StreamWriter sw = new StreamWriter(filePath);
            try
            {
                //write characters, words, lines is file
                sw.WriteLine("characters: {0}", asciiNum);
                sw.WriteLine("words: {0}", wordNum);
                sw.WriteLine("lines: {0}", lineNum);

                //print characters, words, lines is file
                Console.WriteLine("characters: {0}", asciiNum);
                Console.WriteLine("words: {0}", wordNum);
                Console.WriteLine("lines: {0}", lineNum);

                //word frequency
                Console.WriteLine("\nWord Frequency:\n");
                foreach (KeyValuePair<string, int> item in wordFrequency)
                {
                    Console.WriteLine("{0} : {1} ", item.Key, item.Value);
                    //write wordFrequency
                    sw.WriteLine("{0} : {1} ", item.Key, item.Value);
                }

                //phrase frequency
                Console.WriteLine("\nPhrase Frequency:\n");
                foreach (KeyValuePair<string, int> item in phraseFrequency)
                {
                    Console.WriteLine("{0} : {1} ", item.Key, item.Value);
                    //write phraseFrequency
                    sw.WriteLine("{0} : {1} ", item.Key, item.Value);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sw.Close();
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            WordCount wc = new WordCount();


            string inputTxtPath = @"C:\Users\Administrator.WIN-4K5HDJFV5BS\Desktop\软件工程作业\WordCount\201731072323\test.txt";
            string OutputTxtPath = @"C:\Users\Administrator.WIN-4K5HDJFV5BS\Desktop\软件工程作业\WordCount\201731072323\save.txt";
            
            //Print result
            wc.PrintWord(wc.CountAscii(inputTxtPath), wc.CountWord(inputTxtPath), wc.CountLine(inputTxtPath), wc.OutputWord(inputTxtPath, 5), wc.LengthDeterminingPhrases(inputTxtPath, 2), OutputTxtPath);

            Console.ReadKey();
        }
    }
}
