using Storehouse.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storehouse.ConsoleApp.Infrastructure.Commands.ProductCommands
{
    public class DeleteProduct : ICommand
    {
        private readonly UnitOfWork unitOfWork;
        public DeleteProduct(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public string CommandKey
        {
            get { return "delete product"; }
        }

        public string Description
        {
            get { return "delete product through id"; }
        }

        public void Execute(string[] args, string enteredCommandKey)
        {
            Console.Write("Write id - ");
            int id = Convert.ToInt32(Console.ReadLine());
            unitOfWork.Products.Delete(id);
            Console.WriteLine("Deleted");
        }
    }
}
