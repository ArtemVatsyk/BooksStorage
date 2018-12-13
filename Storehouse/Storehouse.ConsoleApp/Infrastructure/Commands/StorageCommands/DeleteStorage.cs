using Storehouse.Core.Services;
using System;

namespace Storehouse.ConsoleApp.Infrastructure.Commands.StorageCommands
{
    public class DeleteStorage : ICommand
    {
        private readonly UnitOfWork unitOfWork;
        public DeleteStorage(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public string CommandKey
        {
            get { return "delete storage"; }
        }

        public string Description
        {
            get { return "delete storage through id"; }
        }

        public void Execute(string[] args, string enteredCommandKey)
        {
            Console.Write("Write id - ");
            int id = Convert.ToInt32(Console.ReadLine());
            unitOfWork.Storages.Delete(id);
            Console.WriteLine("Deleted");
        }
    }
}
