using Storehouse.Core;
using Storehouse.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Storehouse.ConsoleApp.Infrastructure.Commands.ProviderCommands
{
    public class ViewProviders : ICommand
    {
        protected readonly UnitOfWork unitOfWork;
        public ViewProviders(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public virtual string CommandKey
        {
            get { return "view provider"; }
        }

        public virtual string Description
        {
            get { return "Dispaly all available providers"; }
        }

        public void Execute(string[] args, string enteredCommandKey)
        {
            var providers = unitOfWork.Providers.GetAll().ToArray();
            DisplayProviders(providers);
        }
        protected virtual void DisplayProviders(ICollection<Provider> providers)
        {
            //var ProvName = providers.Max(p => p.ProviderName.ToString().Length);
            foreach (var provider in providers)
            {
                Console.WriteLine("{0} {1} {2}",
                    provider.Id.ToString(),
                    provider.ProviderName.ToString(),
                    provider.Phone.ToString());
            }
        }
    }
}
