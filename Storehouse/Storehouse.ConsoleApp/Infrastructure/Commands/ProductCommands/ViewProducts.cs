using Storehouse.Core;
using Storehouse.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Storehouse.ConsoleApp.Infrastructure.Commands.ProductCommands
{
    public class ViewProduct : ICommand
    {
        protected readonly UnitOfWork unitOfWork;
        public ViewProduct(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public virtual string CommandKey
        {
            get { return "view product"; }
        }

        public virtual string Description
        {
            get { return "Dispaly all available products"; }
        }

        public void Execute(string[] args, string enteredCommandKey)
        {
            var products = unitOfWork.Products.GetAll().ToArray();
            DisplayProviders(products);
        }
        protected virtual void DisplayProviders(ICollection<Product> products)
        {
            //var ProvName = providers.Max(p => p.ProviderName.ToString().Length);
            foreach (var product in products)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}",
                    product.Id.ToString(),
                    product.Name.ToString(),
                    product.BrandName.ToString(),
                    product.Price.ToString(),
                    product.Quantity.ToString(),
                    product.Storage.Name.ToString(),
                    product.TypeProduct.TypeName.ToString(),
                    product.Provider.ProviderName.ToString());
            }
        }
    }
}
