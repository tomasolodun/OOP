using System;
using System.Collections.Generic;
using System.Text;

namespace Circle
{
    public class Circle
    {
        private Dot centerDot;
        private Dot externalDot;
        private double radius;
        private const double PI = Math.PI;

        public Circle(Dot center, Dot external)
        {
            centerDot = center;
            externalDot = external;
            CalculateRadius();
        }
        public Circle() { } 

        public Dot CenterDot //властивість
        {
            get
            {
                return centerDot;
            }

            set
            {
                centerDot = value;
                if (centerDot != null && externalDot != null) //рахуємо радіус тільки якщо точки не пусті
                    CalculateRadius();
            }
        }
        public Dot ExternalDot
        {
            get
            {
                return externalDot;
            }

            set
            {
                externalDot = value;
                if (centerDot != null && externalDot != null)
                    CalculateRadius();
            }
        }

        public double Radius
        {
            get
            {
                return radius;
            }
            private set
            {
                radius = value;
            }
        }

        private void CalculateRadius()
        {
            Radius = Math.Sqrt(Math.Pow(ExternalDot.X - CenterDot.X, 2) + Math.Pow(ExternalDot.Y - CenterDot.Y, 2));//знаходимо радіус
        }

        public double GetSquare()
        {
            return PI * Math.Pow(Radius, 2);//знаходимо площу
        }

        public double GetCircleLenght()
        {
            return 2 * PI * Radius;//знаходимо довжину
        }

        public Circle GetNewScaledCopyOfCircle(int index)
        {
            Dot newExternalDot = new Dot(this.ExternalDot.X * index, this.ExternalDot.Y * index); //множимо кожну координату крайньої точки на індекс
            if (newExternalDot == null) //якщо змінній не присвоєно значення, повідомляємо про це користувачу
            {
                throw new ArgumentException("External dot can not be null!");
            }
            else
            {
                return new Circle(CenterDot, newExternalDot); //використовуємо
            }
        }
        public override string ToString()
        {
            return $"X1 = {CenterDot.X}\n" +
                            $"Y1 = {CenterDot.Y}\n" +
                            $"X2 = {ExternalDot.X}\n" +
                            $"Y2 = {ExternalDot.Y}\n" +
                            $"Radius = {Radius}\n" +
                            $"Lenght = {GetCircleLenght()}\n" +
                            $"Square = {GetSquare()}";
        }

    }
}
