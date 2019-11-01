namespace RhombusOfStars
{
    using System.Text;

    public class Rhombus
    {
        private StringBuilder sb;

        public Rhombus(int n)
        {
            this.sb = new StringBuilder();
            CreateTopRowOfRhombus(n);
            CreateBottomRowOfRhombus(n);
        }

        public void CreateTopRowOfRhombus(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                sb.Append(new string(' ', n - i));

                for (int j = 1; j <= i; j++)
                {
                    sb.Append("*");

                    if (j != i)
                    {
                        sb.Append(" ");
                    }
                }

                sb.AppendLine();
            }
        }

        public void CreateBottomRowOfRhombus(int n)
        {
            for (int i = n - 1; i >= 1; i--)
            {
                sb.Append(new string(' ', n - i));

                for (int j = 1; j <= i; j++)
                {
                    sb.Append("*");

                    if (j != i)
                    {
                        sb.Append(" ");
                    }
                }

                sb.AppendLine();
            }
        }

        public string PrintRow()
        {
            return sb.ToString().TrimEnd();
        }
    }
}
