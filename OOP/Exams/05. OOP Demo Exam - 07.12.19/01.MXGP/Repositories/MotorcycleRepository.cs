namespace MXGP.Repositories
{
    using Models.Motorcycles.Contracts;
    using System.Linq;

    public class MotorcycleRepository : Repository<IMotorcycle>
    {
        public override IMotorcycle GetByName(string name)
        {
            return this.Models.FirstOrDefault(x => x.Model == name);
        }
    }    
}
