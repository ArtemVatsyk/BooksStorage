using Storehouse.Core;
using Storehouse.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storehouse.ConsoleApp.Infrastructure.Commands.ProductCommands
{
    public class CreateProduct : ICommand
    {
        protected readonly UnitOfWork unitOfWork;
        public CreateProduct(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public string CommandKey
        {
            get { return "add product"; }
        }
        public string Description
        {
            get { return "add a product for products"; }
        }
        public void Execute(string[] args, string enteredCommandKey)
        {
            Product item = new Product();
            Console.WriteLine("Write name");
            item.Name = Console.ReadLine();
            Console.WriteLine("Write brand");
            item.BrandName = Console.ReadLine();
            Console.WriteLine("Write brand");
            item.Price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Write id provider");
            item.ProviderId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Write id type");
            item.TypeId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Write id storage");
            item.StorageId = Convert.ToInt32(Console.ReadLine());
            unitOfWork.Products.Create(item);
            Console.WriteLine("Added!");
        }
    }
}
