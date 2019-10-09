using System;
using System.IO;

namespace CountAscii
{
    // Function: Computing ASCII characters
    // Parameter: File path
    // Parameter type: string
    // Return: Number of characters
    // Return type: int
    // class name:CountASCII
    // Interface definitions:
    public interface ICountAscii
    {
        int CountAscii(string txtPathString);
    }

    //Specific Function Definition
    public class CountASCII:ICountAscii
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
    }
}

