using Storehouse.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storehouse.ConsoleApp.Infrastructure.Commands.StorageCommands
{
    public class UpdateStorage : ICommand
    {
        private readonly UnitOfWork unitOfWork;
        public UpdateStorage(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public string CommandKey
        {
            get { return "update storage"; }
        }

        public string Description
        {
            get { return "Update storage through id"; }
        }

        public void Execute(string[] args, string enteredCommandKey)
        {
            Console.Write("Write id - ");
            int id = Convert.ToInt32(Console.ReadLine());
            var item = unitOfWork.Storages.GetAll().FirstOrDefault(p => p.Id == id);
            if (item == null)
            {
                throw new Exception($"Storage with id '{id}' doesn't exist");
            }

            Console.Write("Please enter new ProviderName (empty to skip): ");
            var name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
            {
                item.Name = name;
            }

            Console.Write("Please enter new Phone (empty to skip): ");
            var phone = Console.ReadLine();
            if (!string.IsNullOrEmpty(phone))
            {
                item.PhoneNumber = phone;
            }

            Console.Write("Please enter new Address (empty to skip): ");
            var address = Console.ReadLine();
            if (!string.IsNullOrEmpty(address))
            {
                item.Address = address;
            }

            unitOfWork.Storages.Update(item);
            Console.WriteLine("Updated");
        }
    }
}
