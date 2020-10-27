using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello User!");
            Console.WriteLine("Please input 'yes' if you want to fill the array with data from this file \nAny another input will finish execution");
            while (true)
            {

                string userInput = Console.ReadLine();
                Extensions extensions = new Extensions();
                if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Enter something!");
                    continue;
                }
                
                
                else if (userInput.Equals("yes"))
                {
                    List<int> x = JsonSerializer.Deserialize<List<int>>(extensions.ReadFromFile("x.txt")); //зчитуємо дані з масиву у список, виводимо елементи користувачу
                    x.ForEach(i => Console.WriteLine(i));
                    List<int> y = JsonSerializer.Deserialize<List<int>>(extensions.ReadFromFile("y.txt"));
                    y.ForEach(i => Console.WriteLine(i));

                    for (int i = 0; i < x.Count; i++) //перевірка кожного елементу заданій умові
                    {
                        if (x[i] % 5 == 0)
                        {
                            x[i] -= 8;
                        }
                    }

                    x.ForEach(i => Console.WriteLine(i)); //вивід нового масиву х
                    extensions.WriteToFile(JsonSerializer.Serialize(x), "x2.txt");

                    extensions.ConvertList(x, y, out List<double> z); //створення нового масиву та виведення користувачу

                    z.ForEach(i => Console.WriteLine(i));



                    extensions.WriteToFile(JsonSerializer.Serialize(z), "z.txt");
                
            }
        }
    }
}
    }