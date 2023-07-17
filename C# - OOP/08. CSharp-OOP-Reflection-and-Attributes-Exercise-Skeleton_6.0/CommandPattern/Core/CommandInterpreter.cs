using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] tokens = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commandName = tokens[0];

            string[] commandArgs = tokens.Skip(1).ToArray();

            Type type = Assembly.GetEntryAssembly().GetTypes().FirstOrDefault(t=> t.Name == $"{commandName}Command");

            if(type is null)
            {
                throw new InvalidOperationException("Command not found.");
            }

            ICommand commandIstance = Activator.CreateInstance(type) as ICommand;   

            string result = commandIstance.Execute(commandArgs);

            return result.ToString() ;
        }
    }
}
