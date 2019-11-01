namespace RawData.DataTire
{
    public class TireFactory
    {
        public Tire Create(double pressure, int age)
        {
            return new Tire(pressure, age);
        }
    }
}
