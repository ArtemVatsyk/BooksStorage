using Storehouse.Core;
using Storehouse.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storehouse.ConsoleApp.Infrastructure.Commands.StorageCommands
{
    public class ViewStorages : ICommand
    {
        protected readonly UnitOfWork unitOfWork;
        public ViewStorages(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public virtual string CommandKey
        {
            get { return "view storages"; }
        }

        public virtual string Description
        {
            get { return "Dispaly all available storages"; }
        }

        public void Execute(string[] args, string enteredCommandKey)
        {
            var storages = unitOfWork.Storages.GetAll().ToArray();
            DisplayStorages(storages);
        }
        protected virtual void DisplayStorages(ICollection<Storage> storages)
        {
            //var ProvName = providers.Max(p => p.ProviderName.ToString().Length);
            foreach (var storage in storages)
            {
                Console.WriteLine("{0} {1} {2} {3}",
                    storage.Id.ToString(),
                    storage.Name.ToString(),
                    storage.PhoneNumber.ToString(),
                    storage.Address.ToString());
            }
        }
    }
}
