using System;
using System.Linq.Expressions;
using System.Text.Json;

namespace Circle
{
    class Program
    {
        static void Main(string[] args)
        {
            Extensions extensions = new Extensions();
            Console.WriteLine("Hello User!");
            Console.WriteLine("Please choose information input option:\n1.Keyboard (enter '1')\n2.File (enter '2')\n\nAny another input will finish execution");
            while (true)
            {
                Console.WriteLine("Choose option!");
                try
                {
                    string userInput = Console.ReadLine();

                    if (string.IsNullOrEmpty(userInput)) //перевірка пустого введення
                    {
                        Console.WriteLine("Enter something!");
                        continue;
                    }
                    else if (userInput.Equals("1"))
                    {
                        Console.WriteLine("Manual input was chosen. \nPlease enter first dot coordinates:");

                        Dot centerDot = new Dot(Int32.Parse(Console.ReadLine()), Int32.Parse(Console.ReadLine())); //введення координати центральної точки
                        Console.WriteLine("Please enter second dot coordinates:");
                        Dot externalDot = new Dot(Int32.Parse(Console.ReadLine()), Int32.Parse(Console.ReadLine())); //введення координати крайньої точки
                        Circle circle = new Circle(centerDot, externalDot); //створення екзепмляру кола через конструктор який приймає центральну і крайню точки (у ньому ж відбувається обрахунок радіуса)

                        Console.WriteLine(circle.ToString());

                        Console.WriteLine("If you want to scale, please enter 'Scale'");
                        if (Console.ReadLine().Equals("Scale"))
                        {
                            extensions.CircleScaling(circle, 1);
                        }
                    }
                    else if (userInput.Equals("2"))
                    {
                        string jsonStringFromFile = extensions.ReadFromFile(); //зчитування даних з файлу
                        Circle circle = JsonSerializer.Deserialize<Circle>(jsonStringFromFile); //десереалізація отриманої стрічки у форматі json в об'єкт
                        Console.WriteLine(circle.ToString());

                        Console.WriteLine("If you want to scale, please enter 'Scale'");
                        if (Console.ReadLine().Equals("Scale"))
                        {
                            extensions.CircleScaling(circle, 2);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bye!");
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }  
            }
        }
    }
}
