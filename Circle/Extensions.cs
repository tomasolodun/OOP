using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Circle
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
                    byte[] array = Encoding.Default.GetBytes(input);
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
                    // декодуємо байти в строку
                    return Encoding.Default.GetString(array);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CircleScaling(Circle circle, int type)
        {
            Console.WriteLine("Please enter scale index in range 2-9");
            int index;
            while (true)
            {
                try
                {
                    index = Int32.Parse(Console.ReadLine());
                    if (index > 9 || index < 2)
                    {
                        throw new Exception();
                    }
                    Circle scaledCircle = circle.GetNewScaledCopyOfCircle(index); //отримуємо нову копію кола зі зміщеною у index разів зовнішньою точкою
                    Console.WriteLine(scaledCircle.ToString());
                    if (type == 2)
                    {
                        Console.WriteLine("Do you want to save new circle to file? Enter 'YES', any other input will continue execution.");
                        if (Console.ReadLine().Equals("YES"))
                        {
                            WriteToFile(JsonSerializer.Serialize(scaledCircle)); //записуємо масштабовану копію кола у файл
                        }

                        Console.WriteLine("Scaled copy saved to file.");
                    }
                    
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Please enter correct input (number in range 2 - 9)");
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }
    }
}
