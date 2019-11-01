namespace PointInRectangle
{
    public class Rectangle
    {
        public Rectangle(int topLeftX, int topLeftY, int bottomRightX, int bottomRightY)
        {
            this.TopLeftX = topLeftX;
            this.TopLeftY = topLeftY;
            this.BottomRightX = bottomRightX;
            this.BottomRightY = bottomRightY;
        }

        public int TopLeftX { get; set; }

        public int TopLeftY { get; set; }

        public int BottomRightX { get; set; }

        public int BottomRightY { get; set; }

        public bool Contains(Point point)
        {
            bool isInsideX = this.TopLeftX <= point.X &&
               this.BottomRightX >= point.X;

            bool isInsideY = this.TopLeftY <= point.Y &&
               this.BottomRightY >= point.Y;

            if (isInsideX && isInsideY)
            {
                return true;
            }

            return false;
        }
    }
}
