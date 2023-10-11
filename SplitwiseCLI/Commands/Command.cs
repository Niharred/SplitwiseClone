using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseCLI.Commands
{
    public interface Command
    {

        bool matches(string input);

        void execute(string input);

    }
}
