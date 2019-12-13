namespace MXGP.Repositories
{
    using Contracts;
    using System.Collections.Generic;

    public abstract class Repository<T> : IRepository<T>
    {
        public Repository()
        {
            this.Models = new List<T>();
        }

        protected List<T> Models { get; set; }

        public void Add(T model)
        {
            this.Models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return this.Models.AsReadOnly();
        }

        public abstract T GetByName(string name);

        public bool Remove(T model)
        {
            return this.Models.Remove(model);
        }
    }
}
