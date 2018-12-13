using Storehouse.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storehouse.ConsoleApp.Infrastructure.Commands.ProductCommands
{
    public class UpdateProduct : ICommand
    {
        private readonly UnitOfWork unitOfWork;
        public UpdateProduct(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public string CommandKey
        {
            get { return "update product"; }
        }

        public string Description
        {
            get { return "Update product through id"; }
        }

        public void Execute(string[] args, string enteredCommandKey)
        {
            Console.Write("Write id - ");
            int id = Convert.ToInt32(Console.ReadLine());
            var item = unitOfWork.Products.GetAll().FirstOrDefault(p => p.Id == id);
            if (item == null)
            {
                throw new Exception($"Storage with id '{id}' doesn't exist");
            }

            Console.Write("Please enter new Name (empty to skip): ");
            var name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
            {
                item.Name = name;
            }

            Console.Write("Please enter new Brand (empty to skip): ");
            var brand = Console.ReadLine();
            if (!string.IsNullOrEmpty(brand))
            {
                item.BrandName = brand;
            }

            Console.Write("Please enter new Price (empty to skip): ");
            var price = Convert.ToInt32(Console.ReadLine());
            if (price != null)
            {
                item.Price = price;
            }

            Console.Write("Please enter new Quantity (empty to skip): ");
            var quantity = Convert.ToInt32(Console.ReadLine());
            if (quantity != null)
            {
                item.Quantity = quantity;
            }

            Console.Write("Please enter new StorageId (empty to skip): ");
            var storageId = Convert.ToInt32(Console.ReadLine());
            if (storageId != null)
            {
                item.StorageId = storageId;
            }

            Console.Write("Please enter new TypeId (empty to skip): ");
            var typeId = Convert.ToInt32(Console.ReadLine());
            if (typeId != null)
            {
                item.TypeId = typeId;
            }

            Console.Write("Please enter new ProviderId (empty to skip): ");
            var providerId = Convert.ToInt32(Console.ReadLine());
            if (providerId != null)
            {
                item.ProviderId = providerId;
            }

            unitOfWork.Products.Update(item);
            Console.WriteLine("Updated");
        }
    }
}
