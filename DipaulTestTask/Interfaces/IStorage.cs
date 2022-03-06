using System.Collections.Generic;

using DipaulTestTask.Models;

namespace DipaulTestTask.Interfaces
{
    public interface IStorage<T>
    {
        ICollection<T> Items { get; }

        void Load();

        void SaveChanges();
    }

    public interface ICompanyStorage : IStorage<Company> { }

}
