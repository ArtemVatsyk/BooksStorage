using Storehouse.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storehouse.ConsoleApp.Infrastructure.Commands.TypeProductCommands
{
    public class DeleteTypeProduct : ICommand
    {
        private readonly UnitOfWork unitOfWork;
        public DeleteTypeProduct(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public string CommandKey
        {
            get { return "delete type"; }
        }

        public string Description
        {
            get { return "delete type through id"; }
        }

        public void Execute(string[] args, string enteredCommandKey)
        {
            Console.Write("Write id - ");
            int id = Convert.ToInt32(Console.ReadLine());
            unitOfWork.TypeProducts.Delete(id);
            Console.WriteLine("Deleted");
        }
    }
}
