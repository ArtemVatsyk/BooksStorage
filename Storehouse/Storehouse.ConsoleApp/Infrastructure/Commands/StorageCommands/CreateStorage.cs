using Storehouse.Core;
using Storehouse.Core.Services;
using System;

namespace Storehouse.ConsoleApp.Infrastructure.Commands.StorageCommands
{
    public class CreateStorage : ICommand
    {
        protected readonly UnitOfWork unitOfWork;
        public CreateStorage(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public string CommandKey
        {
            get { return "add storage"; }
        }
        public string Description
        {
            get { return "add a storage for storages"; }
        }
        public void Execute(string[] args, string enteredCommandKey)
        {
            Storage item = new Storage();
            Console.Write("Type storage name");
            item.Name = Console.ReadLine();
            Console.Write("Type phone number");
            item.PhoneNumber = Console.ReadLine();
            Console.Write("Type address");
            item.Address = Console.ReadLine();

            unitOfWork.Storages.Create(item);
            Console.WriteLine("Created");
        }
    }
}
