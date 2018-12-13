using Storehouse.Core.Services;
using System;
using System.Linq;

namespace Storehouse.ConsoleApp.Infrastructure.Commands.TypeProductCommands
{
    public class UpdateTypeProduct : ICommand
    {
        private readonly UnitOfWork unitOfWork;
        public UpdateTypeProduct(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public string CommandKey
        {
            get { return "Update Type"; }
        }

        public string Description
        {
            get { return "Edit type through Id"; }
        }

        public void Execute(string[] args, string enteredCommandKey)
        {
            Console.Write("Write id - ");
            int id = Convert.ToInt32(Console.ReadLine());
            var item = unitOfWork.TypeProducts.GetAll().FirstOrDefault(p => p.Id == id);
            if (item == null)
            {
                throw new Exception($"Types with id '{id}' doesn't exist");
            }

            Console.Write("Please enter new Name (empty to skip): ");
            var name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
            {
                item.TypeName = name;
            }           
            unitOfWork.TypeProducts.Update(item);
            Console.WriteLine("Updated");
        }
    }
}
