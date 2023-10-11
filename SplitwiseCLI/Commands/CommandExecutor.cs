using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseCLI.Commands
{
    public class CommandExecutor
    {
        private List<Command> _commands = new List<Command>();

        public void addCommands(Command command)
        {
            _commands.Add(command);
        }

        public void removeCommands(Command command)
        {
            _commands.Remove(command);
        }

        public void Execute(string input)
        {
            foreach (Command cmd in _commands)
            {
                if (cmd.matches(input))
                {
                    cmd.execute(input);
                    
                    break;
                }

            }

        }
    }
}
