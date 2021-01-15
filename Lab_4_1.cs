using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> products = new List<int>();
            string overflowPath = "overflow.txt";
            string noFilePath = "no_file.txt";
            string badDataPath = "bad_data.txt";
            using (StreamWriter sw = new StreamWriter(noFilePath, false, System.Text.Encoding.Default)){}
            using (StreamWriter sw = new StreamWriter(badDataPath, false, System.Text.Encoding.Default)){}
            using (StreamWriter sw = new StreamWriter(overflowPath, false, System.Text.Encoding.Default)){}
            for (int i = 10; i < 30; i++)
            {
                string path = i + ".txt";
                try
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        int i1 = Convert.ToInt32(sr.ReadLine());
                        int i2 = Convert.ToInt32(sr.ReadLine());
                        checked
                        {
                            products.Add(i1 * i2);
                        }
                    }
                }
                catch (FileNotFoundException)
                {
                    using (StreamWriter sw = new StreamWriter(noFilePath, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(path);
                    }
                }
                catch (FormatException )
                {
                    using (StreamWriter sw = new StreamWriter(badDataPath, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(path);
                    }
                }
                catch (OverflowException)
                {
                    using (StreamWriter sw = new StreamWriter(overflowPath, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(path);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(products.Sum() / products.Count);
        }
    }
}