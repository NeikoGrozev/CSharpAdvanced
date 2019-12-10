namespace SpaceStation.Repositories
{
    using Contracts;
    using Models.Astronauts.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class AstronautRepository : IRepository<IAstronaut>
    {
        private List<IAstronaut> models;

        public AstronautRepository()
        {
            this.models = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => this.models.AsReadOnly();

        public void Add(IAstronaut model)
        {
            this.models.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
            IAstronaut astronaut = this.models.FirstOrDefault(x => x.Name == name);

            return astronaut;
        }

        public bool Remove(IAstronaut model)
        {
            bool isRemove = this.models.Remove(model);

            return isRemove;
        }
    }
}