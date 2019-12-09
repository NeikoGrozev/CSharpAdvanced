namespace ViceCity.Repositories.Contracts
{
    using Models.Guns.Contracts;
    using System.Collections.Generic;

    public interface IRepository<T>
    {
        IReadOnlyCollection<T> Models { get; }

        void Add(IGun model);

        bool Remove(IGun model);

        IGun Find(string name);

    }
}