using Storehouse.Core;
using Storehouse.Core.Services;
using System;

namespace Storehouse.ConsoleApp.Infrastructure.Commands.ProviderCommands
{
    public class CreateProvider : ICommand
    {
        protected readonly UnitOfWork unitOfWork;
        public CreateProvider(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public string CommandKey
        {
            get { return "add provider"; }
        }
        public string Description {
            get { return "add a provider for providers"; }
        }
        public void Execute(string[] args, string enteredCommandKey)
        {
            Provider item = new Provider();
            Console.WriteLine("Type provider name");
            item.ProviderName = Console.ReadLine();
            Console.WriteLine("Type number phone");
            item.Phone = Console.ReadLine();
            unitOfWork.Providers.Create(item);
            Console.WriteLine("Added!");
        }
    }
}