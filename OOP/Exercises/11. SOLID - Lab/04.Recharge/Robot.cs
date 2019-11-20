namespace Recharge
{
    public class Robot : Worker, IRechargeable
    {
        private int capacity;
        private int currentPower;

        public Robot(string id, int capacity) 
            : base(id)
        {
            this.Capacity = capacity;
        }

        public int Capacity
        {
            get => this.capacity; 
            private set
            {
                this.capacity = value;
            }
        }

        public int CurrentPower
        {
            get => this.currentPower; 
            private set 
            { 
                this.currentPower = value;
            }
        }

        public override void Work(int hours)
        {
            if (hours > this.currentPower)
            {
                hours = currentPower;
            }

            base.Work(hours);
            this.currentPower -= hours;
        }

        public void Recharge()
        {
            this.currentPower = this.capacity;
        }        
    }
}