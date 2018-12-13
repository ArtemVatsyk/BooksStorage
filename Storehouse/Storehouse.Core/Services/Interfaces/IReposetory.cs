using System.Collections.Generic;

namespace Storehouse.Core.Services.Interfaces
{
    interface IReposetory<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Delete(int id);
        void Update(T item);
    }
}
