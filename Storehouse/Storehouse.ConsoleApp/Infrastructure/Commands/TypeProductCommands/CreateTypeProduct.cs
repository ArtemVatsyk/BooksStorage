using Storehouse.Core;
using Storehouse.Core.Services;
using System;

namespace Storehouse.ConsoleApp.Infrastructure.Commands.TypeProductCommands
{
    public class CreateTypeProduct : ICommand
    {
        protected readonly UnitOfWork unitOfWork;
        public CreateTypeProduct(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public string CommandKey
        {
            get { return "create type"; }
        }

        public string Description
        {
            get { return "create a type for products"; }
        }

        public void Execute(string[] args, string enteredCommandKey)
        {
            TypeProduct item = new TypeProduct();
            Console.Write("Write type names - ");
            item.TypeName = Console.ReadLine();
            unitOfWork.TypeProducts.Create(item);
            Console.WriteLine("Added");
        }
    }
}
