namespace Shapes
{
    using System;

    public class Rectangle : IDrawable
    {
        private const char symbol = '*';
        private const char midSymbol = ' ';

        private int width;
        private int height;

        public Rectangle(int widht, int height)
        {
            this.width = widht;
            this.height = height;
        }

        public void Draw()
        {
            DrawLine(symbol, symbol);

            for (int i = 0; i < this.height - 2; i++)
            {
                DrawLine(symbol, midSymbol);
            }

            DrawLine(symbol, symbol);
        }

        private void DrawLine(char symbol, char midSymbol)
        {
            Console.WriteLine(symbol + new string(midSymbol, this.width - 2) + symbol);
        }
    }
}