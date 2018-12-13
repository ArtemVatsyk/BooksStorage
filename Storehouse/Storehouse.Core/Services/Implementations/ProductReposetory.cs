using Storehouse.Core.Services.Interfaces;
using System.Collections.Generic;

namespace Storehouse.Core.Services.Implementations
{
    public class ProductReposetory : IReposetory<Product>
    {
        private Product product = new Product();
        private readonly WarehouseOneEntitiesL _context;
        public ProductReposetory(WarehouseOneEntitiesL context)
        {
            _context = context;
        }

        public void Create(Product item)
        {
            _context.Products.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Product product = _context.Products.Find(id);
            if(product != null)
            {
                _context.Products.Remove(product);
            }

            _context.Entry(product).State = System.Data.Entity.EntityState.Deleted;
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products;
        }

        public void Update(Product item)
        {
            _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public Product Get(int id)
        {
            return _context.Products.Find(id);
        }
    }
}
