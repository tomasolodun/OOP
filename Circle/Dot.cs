using System;
using System.Collections.Generic;
using System.Text;

namespace Circle
{
    public class Dot
    {
        private int x;
        private int y;

        public Dot(int firstCoordinate, int secondCoordinate) //конструктор з полями x та y
        {
            X = firstCoordinate;
            Y = secondCoordinate;
        }
        public Dot() { }

        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }
    }
}
