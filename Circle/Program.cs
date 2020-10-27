using System;
using System.Linq.Expressions;
using System.Text.Json;

namespace Toma_sLaboratory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello User!");
            Console.WriteLine("Please choose information input option:\n1.Keyboard (enter '1')\n2.File (enter '2')\n\nAny another input will finish execution");
            while (true)
            {
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

                        Console.WriteLine($"Radius = {circle.Radius}\n" +
                            $"Lenght = {circle.GetCircleLenght()}\n" +
                            $"Square = {circle.GetSquare()}");

                        Console.WriteLine("If you want to scale and rewrite to file new circle, please enter 'Scale'");
                        if (Console.ReadLine().Equals("Scale"))
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
                                    Dot newExternalDot = new Dot(circle.ExternalDot.X * index, circle.ExternalDot.Y * index); //множимо кожну координату крайньої точки на індекс
                                    
                                    Console.WriteLine( );
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


                        Console.WriteLine("Enter something!");
                    }
                    else if (userInput.Equals("2"))
                    {
                        string jsonStringFromFile = new Extensions().ReadFromFile(); //зчитування даних з файлу
                        Circle circle = JsonSerializer.Deserialize<Circle>(jsonStringFromFile); //десереалізація отриманої стрічки у форматі json в об'єкт
                        Console.WriteLine($"X1 = {circle.CenterDot.X}\n" +
                            $"Y1 = {circle.CenterDot.Y}\n" +
                            $"X2 = {circle.ExternalDot.X}\n" +
                            $"Y2 = {circle.ExternalDot.Y}\n" +
                            $"Radius = {circle.Radius}\n" +
                            $"Lenght = {circle.GetCircleLenght()}\n" +
                            $"Square = {circle.GetSquare()}");

                        Console.WriteLine("If you want to scale and rewrite to file new circle, please enter 'Scale'");
                        if (Console.ReadLine().Equals("Scale"))
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
                                    Dot newExternalDot = new Dot(circle.ExternalDot.X * index, circle.ExternalDot.Y * index); //множимо кожну координату крайньої точки на індекс
                                    new Extensions().WriteToFile(JsonSerializer.Serialize(circle.GetNewScaledCopyOfCircle(newExternalDot))); //отримуємо нову копію кола зі зміщеною у index разів зовнішньою точкою
                                    Console.WriteLine("Scaled copy saved to file.");
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
