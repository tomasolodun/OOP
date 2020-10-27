using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Arrays
{
    public class Extensions
    {
        public bool WriteToFile(string input, string filePath)
        {
            try
            {
                // запис в файл
                using (FileStream fstream = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    // перетворюємо строку в байти
                    byte[] array = System.Text.Encoding.Default.GetBytes(input);
                    // запис масива байтів в файл
                    fstream.Write(array, 0, array.Length);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ReadFromFile(string filePath)
        {
            try
            {
                using (FileStream fstream = File.OpenRead(filePath))
                {
                    // перетворюємо строку в байти
                    byte[] array = new byte[fstream.Length];
                    // зчитуємо данні
                    fstream.Read(array, 0, array.Length);
                    // декодируємо байти в строку
                    return (Encoding.Default.GetString(array));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ConvertList (List<int> x, List<int> y, out List<double> z)
        {
            z = new List<double>();
            for (int i = 0; i < x.Count; i++) //створення нового масиву за заданою умовою
            {
                z.Add((Math.Pow(x[i], 2) + Math.Pow(y[i], 2)) / 2);
            }
        }
    }
}
