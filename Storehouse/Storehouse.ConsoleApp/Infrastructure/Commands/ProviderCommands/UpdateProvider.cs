using Storehouse.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storehouse.ConsoleApp.Infrastructure.Commands.ProviderCommands
{
    public class UpdateProvider : ICommand
    {
        private readonly UnitOfWork unitOfWork;
        public UpdateProvider(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public string CommandKey
        {
            get { return "update provider"; }
        }

        public string Description
        {
            get { return "Update provider through id"; }
        }

        public void Execute(string[] args, string enteredCommandKey)
        {
            Console.Write("Write id - ");
            int id = Convert.ToInt32(Console.ReadLine());
            var item = unitOfWork.Providers.GetAll().FirstOrDefault(p => p.Id == id);
            if(item == null)
            {
                throw new Exception($"Provider with id '{id}' doesn't exist");
            }

            Console.Write("Please enter new ProviderName (empty to skip): ");
            var name = Console.ReadLine();
            if(!string.IsNullOrEmpty(name))
            {
                item.ProviderName = name;
            }

            Console.Write("Please enter new Phone (empty to skip): ");
            var phone = Console.ReadLine();
            if(!string.IsNullOrEmpty(phone))
            {
                item.Phone = phone;
            }
            unitOfWork.Providers.Update(item);
            Console.WriteLine("Updated");
        }
    }
}
