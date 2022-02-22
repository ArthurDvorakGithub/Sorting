using Bogus.DataSets;
using DocumentFormat.OpenXml.Wordprocessing;
using Nest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections;

namespace Sorting
{
 
    class Line
    {
        public int Convert { get; set; }
        public string Input { get; set; }
    }
    class Program
    {

        static public void Main(string[] args)
        {
        
            string textFromFile;

            // создаем каталог для файла
            string path = @"C:\SortFolder";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            // чтение из файла
            using (FileStream fstream = File.OpenRead(@"C:\SortFolder\input.txt"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string text = System.Text.Encoding.Default.GetString(array);

                textFromFile = text;

            }


            //запись в файл 
            using (FileStream fstream = new FileStream(@"C:\SortFolder\output.txt", FileMode.Create))
            {

                string[] nums = textFromFile.Split(separator: new string[] { "\r", "\n" }, StringSplitOptions.None);

                var lines = new List<Line>();

                //---------Конвертация по единицам измерения в m/s

                for (int i = 0; i < nums.Length; i++)
                {
                    
                    string[] wordAndNumber1 = nums[i].Split(new char[] { ' ' }, StringSplitOptions.None);

                    if (wordAndNumber1[0] != "")
                    {

                        int count1 = Convert.ToInt32(wordAndNumber1[0]);

                        if (nums[i].EndsWith("kmh"))
                        {
                            count1 = count1 * 1000;
                        }

                        if (nums[i].EndsWith("mph"))
                        {
                            count1 = count1 * 1609;
                        }

                        if (nums[i].EndsWith("kn"))
                        {
                            count1 = count1 * 1852;
                        }

                        if (nums[i].EndsWith("m/s"))
                        {
                            count1 = count1 * 3600;
                        }
                        

                        lines.Add(new Line { Input = nums[i], Convert = count1 });

                    }
                        
                    
                }

                lines = lines.OrderBy(x => x.Convert).ToList();

                foreach (Line l in lines)
                //Console.WriteLine($"{l.Input} - {l.Convert}");
                {
                    textFromFile = ($"{l.Convert} - {l.Input}\n");
                    byte[] array = System.Text.Encoding.Default.GetBytes(textFromFile);
                    // запись массива байтов в файл
                    fstream.Write(array, 0, array.Length);
                }


                //---------Конвертация по единицам измерения kmh, mph , kn , m/s--------------------------------------------------------------------------------

                for (int i = 0; i < nums.Length; i++)
                {
                    // преобразуем строку в байты
                    if (nums[i].EndsWith("kmh"))
                    {
                        textFromFile = nums[i] + "\n";
                        byte[] array = System.Text.Encoding.Default.GetBytes(textFromFile);
                        // запись массива байтов в файл
                        fstream.Write(array, 0, array.Length);
                    }
                }

                for (int i = 0; i < nums.Length; i++)
                {
                    // преобразуем строку в байты
                    if (nums[i].EndsWith("mph"))
                    {
                        textFromFile = nums[i] + "\n";
                        byte[] array = System.Text.Encoding.Default.GetBytes(textFromFile);
                        // запись массива байтов в файл
                        fstream.Write(array, 0, array.Length);
                    }
                }

                for (int i = 0; i < nums.Length; i++)
                {
                    // преобразуем строку в байты
                    if (nums[i].EndsWith("kn"))
                    {
                        textFromFile = nums[i] + "\n";
                        byte[] array = System.Text.Encoding.Default.GetBytes(textFromFile);
                        // запись массива байтов в файл
                        fstream.Write(array, 0, array.Length);
                    }
                }

                for (int i = 0; i < nums.Length; i++)
                {
                    // преобразуем строку в байты
                    if (nums[i].EndsWith("m/s"))
                    {
                        textFromFile = nums[i] + "\n";
                        byte[] array = System.Text.Encoding.Default.GetBytes(textFromFile);
                        // запись массива байтов в файл
                        fstream.Write(array, 0, array.Length);
                    }
                }




                //---------Конвертация по единицам измерения в m/s---------------------------------------------------------------------------

                for (int i = 0; i < nums.Length; i++)
                {

                    string[] wordAndNumber = nums[i].Split(new char[] { ' ' }, StringSplitOptions.None);

                    if(wordAndNumber[0] != "")
                    {

                        int count = Convert.ToInt32(wordAndNumber[0]);

                        if (nums[i].EndsWith("kmh"))
                        {
                            textFromFile = nums[i] + " = " + count * 0.278 + " m/s" + "\n";

                        }

                        if (nums[i].EndsWith("mph"))
                        {
                            textFromFile = nums[i] + " = " + count * 0.447 + " m/s" + "\n";

                        }

                        if (nums[i].EndsWith("kn"))
                        {
                            textFromFile = nums[i] + " = " + count * 0.514 + " m/s" + "\n";

                        }

                        if (nums[i].EndsWith("m/s"))
                        {
                            textFromFile = nums[i] + " = " + count + " m/s" + "\n";

                        }

                        byte[] array = System.Text.Encoding.Default.GetBytes(textFromFile);
                        // запись массива байтов в файл
                        fstream.Write(array, 0, array.Length);

                    } 

                }

                Console.WriteLine("Текст записан в файл");

            }

            Console.ReadLine();
        }
    }
}
