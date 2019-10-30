namespace PointInRectangle
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                  .Split()
                  .Select(int.Parse)
                  .ToArray();

            var topLeftX = input[0];
            var topLeftY = input[1];
            var bottomRightX = input[2];
            var bottomRightY = input[3];

            var rectangle = new Rectangle(topLeftX, topLeftY, bottomRightX, bottomRightY);

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var inputCoordinates = Console.ReadLine()
                  .Split()
                  .Select(int.Parse)
                  .ToArray();

                var x = inputCoordinates[0];
                var y = inputCoordinates[1];

                var point = new Point(x, y);

                bool isInSide = rectangle.Contains(point);

                Console.WriteLine(isInSide);
            }
        }
    }
}
