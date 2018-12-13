using Storehouse.Core.Services.Interfaces;
using System.Data.Entity;
using System.Collections.Generic;


namespace Storehouse.Core.Services.Implementations
{
    public class ProviderReposetory : IReposetory<Provider>
    {
        private Provider provider = new Provider();
        private readonly WarehouseOneEntitiesL _context;
        public ProviderReposetory(WarehouseOneEntitiesL context)
        {
            _context = context;
        }
        public void Create(Provider item)
        {
            _context.Providers.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Provider provider = _context.Providers.Find(id);
            if(provider != null)
            {
                _context.Providers.Remove(provider);
            }
            _context.Entry(provider).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public IEnumerable<Provider> GetAll()
        {
            return _context.Providers;
        }

        public void Update(Provider item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public Provider Get(int id)
        {
            return _context.Providers.Find(id);
        }
    }
}
