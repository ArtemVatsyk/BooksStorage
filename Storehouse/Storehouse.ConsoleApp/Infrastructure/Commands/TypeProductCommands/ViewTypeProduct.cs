using Storehouse.Core;
using Storehouse.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storehouse.ConsoleApp.Infrastructure.Commands.TypeProductCommands
{
    public class ViewTypeProduct : ICommand
    {
        private readonly UnitOfWork unitOfWork;
        public ViewTypeProduct(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public string CommandKey
        {
            get { return "view types"; }
        }

        public string Description
        {
            get { return "view types for products"; }
        }

        public void Execute(string[] args, string enteredCommandKey)
        {
            var typeProducts = unitOfWork.TypeProducts.GetAll().ToArray();
            DisplayTypes(typeProducts);
        }
        protected virtual void DisplayTypes(ICollection<TypeProduct> typeProducts)
        {
            //var ProvName = providers.Max(p => p.ProviderName.ToString().Length);
            foreach (var typeProduct in typeProducts)
            {
                Console.WriteLine("{0} {1}",
                    typeProduct.Id.ToString(),
                    typeProduct.TypeName.ToString());
            }
        }
    }
}
