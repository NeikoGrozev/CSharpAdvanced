namespace ViceCity.Repositories
{
    using Contracts;
    using Models.Guns.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> gunRepository;

        public GunRepository()
        {
            this.gunRepository = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => this.gunRepository.AsReadOnly();

        public void Add(IGun model)
        {
            if (!this.gunRepository.Any(x => x.Name == model.Name))
            {
                this.gunRepository.Add(model);
            }
        }

        public IGun Find(string name)
        {
            IGun gun = this.gunRepository.Find(x => x.Name == name);

            return gun;
        }

        public bool Remove(IGun model)
        {
            return this.gunRepository.Remove(model);
        }
    }
}