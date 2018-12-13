using Storehouse.Core.Services;
using System;

namespace Storehouse.ConsoleApp.Infrastructure.Commands.ProviderCommands
{
    public class DeleteProvider : ICommand
    {
        private readonly UnitOfWork unitOfWork;
        public DeleteProvider(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public string CommandKey
        {
            get { return "delete provider"; }
        }

        public string Description
        {
            get { return "delete provider through id"; }
        }

        public void Execute(string[] args, string enteredCommandKey)
        {
            Console.Write("Write id - ");
            int id = Convert.ToInt32(Console.ReadLine());
            unitOfWork.Providers.Delete(id);
            Console.WriteLine("Deleted");
        }
    }
}
