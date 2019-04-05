using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp2
{
    class Menu//菜单类
    {
        string choice;
        public Menu()
        {
            Console.WriteLine("1.普通功能");
            Console.WriteLine("2.新增功能");
            Console.Write("功能选择: ");
            choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    BaseOperation operation = new BaseOperation();//基本类
                    operation.Character_Read();
                    operation.Word_Read();
                    operation.Line_Read();
                    operation.Word_Sort();
                    break;
                case "2":
                    NewFunction function = new NewFunction();//新功能类
                    function.New_AdFunction();
                    function.Save_Data();
                    break;
                default:
                    Console.WriteLine("错误!请重新选择!");
                    Console.ReadKey();
                    Console.Clear();
                    choice = string.Empty;
                    Menu menu = new Menu();
                    break;
            }
        }
    }

    class OpenFile
    {
        private string F_address;//获取文件位置
        string F_data;
        public StreamReader F_reader;
        public OpenFile()//打开文件
        {
            Console.Write("输入文档位置及文档名(格式如:D:\\XXX\\XXX\\XXX.txt,两斜杠):");
            F_address = Console.ReadLine();
            F_reader = new StreamReader(F_address, Encoding.Default);
        }
        public string F_ToEnd()//读取文件全部内容并返回、关闭文件
        {
            F_data = F_reader.ReadToEnd();
            F_reader.Close();
            return F_data;
        }
    }

    public class BaseOperation//基本功能
    {
        OpenFile file = new OpenFile();
        public string F_dataread;//用于获取F_ToEnd的内容
        public string[] F_data;//定义了全局字符串数组的变量
        public int F_lines = 0;//获取行数
        public Dictionary<string, int> word_list = new Dictionary<string, int>();//创建Dictionary<string,int>的对象，储存一一对应的单词和该单词频数

        public string Line_Read()//输出行数，统计行数的代码见Word_Read
        {
            Console.WriteLine("lines: " + F_lines);
            return "lines:" + F_lines.ToString() + "\r\n";

        }

        public string Character_Read()//获取字符数
        {
            F_dataread = file.F_ToEnd();
            Console.WriteLine("characters: " + F_dataread.Length);
            return "characters:" + F_dataread.Length.ToString() + "\r\n";
        }

        public string Word_Read()//获取单词总数
        {
            int F_words = 0;//储存单词数
            int i = 0, j;
            string[] F_datasave = F_dataread.ToLower().Split(' ', ',');//将文件内容中的大写字母换成小写后再按照空格分隔为数组
            F_words = F_datasave.Length;//假设文件中所有单元都为单词

            while (i < F_datasave.Length)
            {
                F_lines = F_datasave[i].IndexOfAny(new char[] { '\r' });//统计行数
                if (F_datasave[i].Length < 4)//若为数组元素长度（单词字母数）小于4，则单词数减一
                {
                    F_words--;
                }
                else
                {
                    for (j = 0; j < 4; j++)//数组元素长度（单词字母数）大于4时，判断前4个字符是否为字母（之前改为小写，所以只用判断是否在a—z）
                    {
                        if ((int)F_datasave[i][j] < 97 || (int)F_datasave[i][j] > 122)
                            F_words--;
                    }
                }
                i++;
            }
            Console.WriteLine("words: " + F_words);//输出符合要求的单词总数
            return "words: " + F_words.ToString() + "\r\n";
        }

        public void Word_Sort()//找到单词的出现频数
        {
            F_data = F_dataread.ToLower().Replace("\n", " ").Replace("\r", " ").Replace("\t", " ").Split(' ', ',');//去掉单词中的换行符、制表符，并按空格和“，”改为数组
            int i, j, k;
            List<string> F_data_L = F_data.ToList<string>();
            for (i = 0; i < F_data_L.Count; i++)//排错，哈希代码为757603046时，会额外占有一个数组且为空，但无法去除
            {
                if (F_data_L[i].GetHashCode() == 757602046)
                {
                    F_data_L.RemoveAt(i);
                }
            }
            F_data = F_data_L.ToArray<string>();
            int[] word_quantity_r = new int[F_data.Length];//定义与单词数组长度相同的整型数组


            for (i = 0; i < F_data.Length; i++)//初始化整型数组的值
            {
                word_quantity_r[i] = 1;
            }

            word_list = new Dictionary<string, int>();//创建Dictionary<string,int>的对象，储存一一对应的单词和该单词频数
            for (i = 0; i < F_data.Length; i++)
            {
                if (F_data[i] == "")
                {
                    F_data[i].Trim(' ', ',');//为保险起见，再次去除数组元素前后的空格及“，”
                    continue;
                }
                for (j = i + 1; j < F_data.Length; j++)
                {
                    if (F_data[i] == F_data[j])//若第i个单词与第j个单词相等，频数加一，第j个单词改为空字符串（避免重复读入不同位置的同一单词）
                    {
                        word_quantity_r[i]++;
                        F_data[j] = "";
                    }
                }
                word_list.Add(F_data[i], word_quantity_r[i]);//将单词与对应频数放入集合（Dictionary）
                if (F_data[i].Length < 4)//排除非单词
                {
                    word_list.Remove(F_data[i]);
                }
                else
                {
                    for (k = 0; k < 4; k++)
                    {
                        if ((int)F_data[i][k] < 97 || (int)F_data[i][k] > 122)
                            word_list.Remove(F_data[i]);
                    }
                    for (k = 4; k < F_data[i].Length; k++)
                        if ((int)F_data[i][k] < 97 && (int)F_data[i][k] > 122)
                            word_list.Remove(F_data[i]);
                }
            }
            var Sort = word_list.OrderByDescending(objDic => objDic.Value).ThenByDescending(objDic => objDic.Key);//先按照频数降序排序，再按照单词对应ASC码进行排序

            foreach (KeyValuePair<string, int> pair in Sort)
            {
                Console.WriteLine("< " + pair.Key + " >: " + pair.Value);//输出单词及频数
            }
        }

    }

    class NewFunction : BaseOperation
    {
        public string file_writer_saver = null;
        static string file_saver = "D:\\Git\\第三次作业\\WordCount\\o";
        StreamWriter file_writer = new StreamWriter(file_saver);
        public NewFunction()
        {
            file_writer_saver = Character_Read() + Word_Read() + Line_Read();
            Word_Sort();
            Console.WriteLine("基本功能已实现，输入任意键进行新增功能操作");
            Console.ReadKey();
            Console.Clear();
        }

        public void New_AdFunction()//新功能（-n参数设定输出的单词数量）
        {
            F_data = F_dataread.ToLower().Replace("\r", " ").Replace("\n", " ").Split(' ');
            int i, j, k;
            List<string> F_data_L = F_data.ToList<string>();
            for (i = 0; i < F_data_L.Count; i++)//排错，哈希代码为757603046时，会额外占有一个数组且为空，但无法去除
            {
                if (F_data_L[i].GetHashCode() == 757602046)
                {
                    F_data_L.RemoveAt(i);
                }
            }
            for (i = 0; i < F_data.Length; i++)
            {
                if (F_data[i].Length < 4)//排除非单词
                {
                    F_data_L.Remove(F_data[i]);
                }
                else
                {
                    for (k = 0; k < 4; k++)
                    {
                        if ((int)F_data[i][k] < 97 || (int)F_data[i][k] > 122)
                            F_data_L.Remove(F_data[i]);
                    }
                    for (k = 4; k < F_data[i].Length; k++)
                        if ((int)F_data[i][k] < 97 && (int)F_data[i][k] > 122)
                            F_data_L.Remove(F_data[i]);
                }
            }
            F_data = F_data_L.ToArray<string>();
            Console.Write("请指定读出n个单词：");
            int number = int.Parse(Console.ReadLine());
            string[] F_AdData = new string[F_data.Length];

            for (i = 0; i < F_data.Length - number + 1; i++)
            {
                for (j = i; j < number + i; j++)
                {
                    if (j == number) F_AdData[i] += F_data[j];
                    else F_AdData[i] += F_data[j] + " ";
                }
            }

            int[] F_AdData_r = new int[F_AdData.Length];//定义与单词组数组长度相同的整型数组

            for (i = 0; i < F_AdData.Length; i++)//初始化整型数组的值
            {
                F_AdData_r[i] = 1;
            }

            Dictionary<string, int> new_word_list = new Dictionary<string, int>();//创建新的Dictionary<string,int>的对象，储存一一对应的单词和该单词频数
            for (i = 0; i < F_AdData.Length - number + 1; i++)
            {
                if (F_AdData[i] == "")
                {
                    F_AdData[i].Trim(' ', ',');//为保险起见，再次去除数组元素前后的空格及“，”
                    continue;
                }
                for (j = i + 1; j < F_AdData.Length; j++)
                {
                    if (F_AdData[i] == F_AdData[j])//若第i个单词与第j个单词相等，频数加一，第j个单词改为空字符串（避免重复读入不同位置的同一单词）
                    {
                        F_AdData_r[i]++;
                        F_AdData[j] = "";
                    }
                }
                new_word_list.Add(F_AdData[i], F_AdData_r[i]);//将单词与对应频数放入集合（Dictionary）
            }
            var Sort = new_word_list.OrderByDescending(objDic => objDic.Value).ThenByDescending(objDic => objDic.Key);//先按照频数降序排序，再按照单词对应ASC码进行排序

            foreach (KeyValuePair<string, int> pair in Sort)
            {
                Console.WriteLine("< " + pair.Key + " >: " + pair.Value);
            }

        }

        public void Save_Data()//储存值到文件
        {
            var Sort = word_list.OrderByDescending(objDic => objDic.Value).ThenByDescending(objDic => objDic.Key);//先按照频数降序排序，再按照单词对应ASC码进行排序

            foreach (KeyValuePair<string, int> pair in Sort)
            {
                file_writer_saver += "< " + pair.Key + " >: " + pair.Value + "\r\n";
            }
            try//将file_writer_saver储存入文件：D:\\AchaoCalculator\\ArthurUnreal\\output.txt
            {
                file_writer.Write(file_writer_saver);
                Console.WriteLine("基本功能的输出已储存成功！");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("储存出现问题");
            }
            file_writer.Flush();//清除缓冲流数据
            file_writer.Close();//关闭文件
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();//进入菜单
        }
    }
}
