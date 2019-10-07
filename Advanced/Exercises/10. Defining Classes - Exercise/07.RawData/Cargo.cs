namespace RawData
{
    public class Cargo
    {
        public Cargo(int cargoWeight, string cargoType)
        {
            this.Weigth = cargoWeight;
            this.Type = cargoType;
        }
        public int Weigth { get; set; }

        public string Type { get; set; }
    }
}
