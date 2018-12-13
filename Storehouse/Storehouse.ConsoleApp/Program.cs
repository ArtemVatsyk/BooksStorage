using System;
using Storehouse.ConsoleApp.Infrastructure;

namespace Storehouse.ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Please enter command: ");
                var enteredCommandKey = Console.ReadLine();
                if (enteredCommandKey == null)
                    continue;

                var command = CommandFactory.ResolveCommand(enteredCommandKey);
                if (command == null)
                {
                    Console.WriteLine("Command doesn't found");
                    continue;
                }

                try
                {
                    command.Execute(args, enteredCommandKey);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
