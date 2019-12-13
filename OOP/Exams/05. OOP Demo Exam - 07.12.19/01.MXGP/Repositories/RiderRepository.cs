namespace MXGP.Repositories
{
    using Models.Riders.Contracts;
    using System.Linq;

    public class RiderRepository : Repository<IRider>
    {
        public override IRider GetByName(string name)
        {
            return this.Models.FirstOrDefault(x => x.Name == name);
        }
    }
}
