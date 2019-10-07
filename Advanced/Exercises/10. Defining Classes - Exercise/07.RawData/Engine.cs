namespace RawData
{
    public class Engine
    {
        public Engine(int engineSpeed, int enginePower)
        {
            this.Speed = engineSpeed;
            this.Power = enginePower;
        }
        public int Speed { get; set; }

        public int Power { get; set; }
    }
}
