namespace Shapes
{
    using System;

    public class Circle : IDrawable
    {
        private const char symbol = '*';
        private const char midSymbol = ' ';

        private int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public void Draw()
        {
            double rIn = this.radius - 0.4;
            double rOut = this.radius + 0.4;

            for (double y = this.radius; y >= -this.radius; y--)
            {
                for (double x = -this.radius; x < rOut; x+=0.5)
                {
                    double point = x * x + y * y;

                    if(point >= rIn * rIn &&  point <= rOut * rOut)
                    {
                        Console.Write(symbol);
                    }
                    else
                    {
                        Console.Write(midSymbol);
                    }
                }

                Console.WriteLine();
            }
        }
    }
}