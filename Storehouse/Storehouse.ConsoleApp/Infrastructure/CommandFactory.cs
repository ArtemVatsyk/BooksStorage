using Storehouse.Core.Services;
using System;
using System.Linq;
using Storehouse.ConsoleApp.Infrastructure.Commands.ProviderCommands;
using Storehouse.ConsoleApp.Infrastructure.Commands.TypeProductCommands;
using Storehouse.ConsoleApp.Infrastructure.Commands.StorageCommands;
using Storehouse.ConsoleApp.Infrastructure.Commands.ProductCommands;

namespace Storehouse.ConsoleApp.Infrastructure
{
    public static class CommandFactory
    {
        public static ICommand ResolveCommand(string key)
        {
            return Commands.FirstOrDefault(c => key.StartsWith(c.CommandKey, StringComparison.OrdinalIgnoreCase));
        }

        private static ICommand[] _commands;
        private static ICommand[] Commands
        {
            get
            {
                if (_commands == null)
                {
                    var unitOfWork = new UnitOfWork();
                    _commands = GetCommands(unitOfWork);
                }

                return _commands;
            }
        }

        private static ICommand[] GetCommands(UnitOfWork unitOfWork)
        {
            var commands = new ICommand[]
            {
                new ViewProviders(unitOfWork),
                new CreateProvider(unitOfWork),
                new DeleteProvider(unitOfWork),
                new UpdateProvider(unitOfWork),

                new CreateTypeProduct(unitOfWork),
                new ViewTypeProduct(unitOfWork),
                new DeleteTypeProduct(unitOfWork),
                new UpdateTypeProduct(unitOfWork),

                new ViewProduct(unitOfWork),
                new CreateProduct(unitOfWork),
                new DeleteProduct(unitOfWork),
                new UpdateProduct(unitOfWork),

                new CreateStorage(unitOfWork),
                new ViewStorages(unitOfWork),
                new DeleteStorage(unitOfWork),
                new UpdateStorage(unitOfWork)
            };
            return commands;
        }
    }
}
