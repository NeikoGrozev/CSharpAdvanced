namespace SpaceStation.Repositories
{
    using Contracts;
    using Models.Planets;
    using System.Collections.Generic;
    using System.Linq;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> models;

        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => this.models.AsReadOnly();

        public void Add(IPlanet model)
        {
            this.models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            IPlanet planet = this.models.FirstOrDefault(x => x.Name == name);

            return planet;
        }

        public bool Remove(IPlanet model)
        {
            bool isRemove = this.models.Remove(model);

            return isRemove;
        }
    }
}