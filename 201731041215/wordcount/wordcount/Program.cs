using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WY
{
    class Program
    {
        static Dictionary<string, string> GetMand(string[] temp)
        {
            //将命令参数保存进入字典
            Dictionary<string, string> command = new Dictionary<string, string>();
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == "-i")
                {
                    command["-i"] = temp[i + 1];
                }
                else if (temp[i] == "-o")
                {
                    command["-o"] = temp[i + 1];
                }
                else if (temp[i] == "-n")
                {
                    command["-n"] = temp[i + 1];
                }
                else if (temp[i] == "-m")
                {
                    command["-m"] = temp[i + 1];
                }
            }
            return command;
        }
        static void Main(string[] args)
        {
            Dictionary<string, string> command = GetMand(args);
            //对得到内容进行处理 - n参数内容转为int - i参数确定文件是否存在
            FileInfo judge = new FileInfo(command["-i"]);
            if (judge.Exists)
            {
                Function f = new Function(command["-i"]);
                f.ToFile(command["-o"]);
                if (command.ContainsKey("-n"))
                {
                    int nums = Convert.ToInt32(command["-n"]);
                    f.Cut(nums);
                    if (command.ContainsKey("-m"))
                    {
                        int length = Convert.ToInt32(command["-m"]);
                        f.PutN(length);
                    }
                }
                else
                {

                }
            }
            else
            {
                Console.WriteLine("需处理的文件不存在!请检查路径重新运行！");
            }
        }
    }
}
