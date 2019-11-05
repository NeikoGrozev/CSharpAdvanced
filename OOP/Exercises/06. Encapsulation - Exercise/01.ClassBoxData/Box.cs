using System;

namespace ClassBoxData
{
    public class Box
    {

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;

        }

        public double Length
        {
            get => this.length;
            private set
            {
                ValidateValue(value, nameof(this.Length));
                this.length = value;
            }
        }

        public double Width
        {
            get => this.width;
            private set
            {
                ValidateValue(value, nameof(this.Width));
                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;
            private set
            {
                ValidateValue(value, nameof(this.Height));
                this.height = value;
            }
        }

        public double GetSurfaceArea()
        {
            return 2 * (this.Length * this.Width) + GetLiteralSurfaceArea();
        }

        public double GetLiteralSurfaceArea()
        {
            return 2 * (this.Length * this.Height + this.Width * this.Height);
        }

        public double GetVolume()
        {
            return this.Length * this.Width * this.Height;
        }

        private void ValidateValue(double value, string parameters)
        {
            if (value < 0)
            {
                throw new ArgumentException($"{parameters} cannot be zero or negative.");
            }
        }
    }
}
