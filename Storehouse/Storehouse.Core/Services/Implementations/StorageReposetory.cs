using Storehouse.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storehouse.Core.Services.Implementations
{
    public class StorageReposetory : IReposetory<Storage>
    {
        private Storage storage = new Storage();
        private readonly WarehouseOneEntitiesL _context;
        public StorageReposetory(WarehouseOneEntitiesL context)
        {
            _context = context;
        }
        public void Create(Storage item)
        {
            _context.Storages.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Storage storage = _context.Storages.Find(id);
            if(storage != null)
            {
                _context.Storages.Remove(storage);
            }
            _context.Entry(storage).State = System.Data.Entity.EntityState.Deleted;
            _context.SaveChanges();
        }

        public IEnumerable<Storage> GetAll()
        {
            return _context.Storages;
        }

        public void Update(Storage item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public Storage Get(int id)
        {
            return _context.Storages.Find(id);
        }
    }
}
