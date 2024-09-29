using System;
using System.Drawing;

namespace showfall
{
    internal class Snowflake
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int PrevX { get; private set; }
        public int PrevY { get; private set; }
        public int Speed { get; set; }
        private int formWidth;
        private int formHeight;
        private static Random random = new Random();

        public const int ShowWidth = 20, ShowHeigth = 20;

        public Snowflake(int formWidth, int formHeight)
        {
            this.formWidth = formWidth;
            this.formHeight = formHeight;

            X = random.Next(0, formWidth);
            Y = random.Next(-formHeight, 0);
            Speed = random.Next(2, 10);
        }

        public void Fall()
        {
            PrevX = X;
            PrevY = Y;

            Y += Speed;

            if (Y > formHeight)
            {
                Y = -10;
                X = random.Next(0, formWidth);
                Speed = random.Next(2, 10);
            }
        }

        public Rectangle GetBounds()
        {
            return new Rectangle(X, Y, ShowWidth, ShowHeigth);
        }

        public Rectangle GetPrevBounds()
        {
            return new Rectangle(PrevX, PrevY, ShowWidth, ShowHeigth);
        }
    }
}
