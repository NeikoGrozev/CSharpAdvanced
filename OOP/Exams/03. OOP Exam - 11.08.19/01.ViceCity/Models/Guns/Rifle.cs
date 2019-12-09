namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int bulletsPerBarrel = 50;
        private const int totalBullets = 500;
        private const int gunShoot = 5;

        public Rifle(string name) 
            : base(name, bulletsPerBarrel, totalBullets)
        {
        }

        public override int Fire()
        {
            int shoot = 0;

            if (this.BulletsPerBarrel > 0)
            {
                shoot = gunShoot;
                this.BulletsPerBarrel -= gunShoot;
            }
            else if (this.TotalBullets > 0)
            {
                this.BulletsPerBarrel = bulletsPerBarrel;
                this.TotalBullets -= bulletsPerBarrel;
            }

            return shoot;
        }
    }
}