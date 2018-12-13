using Storehouse.Core.Services.Implementations;
using System;


namespace Storehouse.Core.Services
{
    public class UnitOfWork : IDisposable
    {
        WarehouseOneEntitiesL dbContext = new WarehouseOneEntitiesL();
        private ProviderReposetory providerReposetory;
        private TypeProductReposetory typeProductReposetory;
        private StorageReposetory storageReposetory;
        private ProductReposetory productReposetory;
        
        public ProviderReposetory Providers
        {
            get
            {
                if(providerReposetory == null)
                {
                    providerReposetory = new ProviderReposetory(dbContext);
                }
                return providerReposetory;
            }
        }
        public TypeProductReposetory TypeProducts
        {
            get
            {
                if(typeProductReposetory == null)
                {
                    typeProductReposetory = new TypeProductReposetory(dbContext);
                }
                return typeProductReposetory;
            }
        }
        public StorageReposetory Storages
        {
            get
            {
                if(storageReposetory == null)
                {
                    storageReposetory = new StorageReposetory(dbContext);
                }
                return storageReposetory;
            }
        }
        public ProductReposetory Products
        {
            get
            {
                if(productReposetory == null)
                {
                    productReposetory = new ProductReposetory(dbContext);
                }
                return productReposetory;
            }
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}