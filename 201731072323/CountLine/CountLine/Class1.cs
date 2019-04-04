using System;
using System.IO;

namespace CountLine
{
    // Function: Computing the number of  effectiveRowNumber 
    // Parameter: File path
    // Parameter type: string
    // Return: Number of  effectiveRowNumber 
    // Return type: int
    // Class name: CountLINE
    // Interface definitions:
    public interface ICountLineAndCharacters
    {
        int CountLine(string txtPathString);
    }

    //Specific Function Definition
    public class CountLINE: ICountLineAndCharacters
    {
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
                    for ( i = 0; i < temp.Length; i++)
                    {
                        if (Convert.ToString( temp[i])=="\\s" )
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
    }
}
