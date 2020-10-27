using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Toma_sLaboratory
{
    public class Extensions
    {
        private string defaultPath = "Storage.txt";
        public bool WriteToFile(string input)
        {
            try
            {
                // запис в файл
                using (FileStream fstream = new FileStream(defaultPath, FileMode.OpenOrCreate)) 
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

        public string ReadFromFile()
        {
            try
            {
                using (FileStream fstream = File.OpenRead(defaultPath))
                {
                    // перетворюємо строку в байти
                    byte[] array = new byte[fstream.Length];
                    // зчитуємо дані
                    fstream.Read(array, 0, array.Length);
                    // декодируємо байти в строку
                    return(Encoding.Default.GetString(array));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
