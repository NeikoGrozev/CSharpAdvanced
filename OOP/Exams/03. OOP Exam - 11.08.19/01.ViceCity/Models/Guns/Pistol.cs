namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int bulletsPerBarrel = 10;
        private const int totalBullets = 100;
        private const int gunShoot = 1;

        public Pistol(string name)
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