using Storehouse.Core.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Storehouse.Core.Services.Implementations
{
    public class TypeProductReposetory : IReposetory<TypeProduct>
    {
        private TypeProduct TypeProduct = new TypeProduct();
        private readonly WarehouseOneEntitiesL _context;
        public TypeProductReposetory(WarehouseOneEntitiesL context)
        {
            _context = context;
        }
        public void Create(TypeProduct item)
        {
            _context.TypeProducts.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            TypeProduct typeProduct = _context.TypeProducts.Find(id);
            if(typeProduct != null)
            {
                _context.TypeProducts.Remove(typeProduct);
            }
            _context.Entry(typeProduct).State = System.Data.Entity.EntityState.Deleted;
            _context.SaveChanges();
        }

        public IEnumerable<TypeProduct> GetAll()
        {
            return _context.TypeProducts;
        }

        public void Update(TypeProduct item)
        {
            _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public TypeProduct Get(int id)
        {
            return _context.TypeProducts.Find(id);
        }
    }
}
