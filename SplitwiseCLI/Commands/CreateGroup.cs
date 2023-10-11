using SplitwiseCLI.Controllers;
using SplitwiseCLI.dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseCLI.Commands
{
    public class CreateGroup : Command
    {


        private GroupController _groupController;

        public CreateGroup()
        {

        }
        public CreateGroup(GroupController groupController)
        {
            this._groupController = groupController;
        }

        public bool matches(string input)

        {
            List<string> inputs = input.Split(" ").ToList();
            if (!inputs[0].Equals(Commands.REGISTER_GROUP_COMMAND))
                return false;
            if (inputs.Count > 2)
                return false;

            return true;
        }

        public void execute(string input)
        {
            List<string> inputs = input.Split(" ").ToList();
            CreateGroupRequest request = new CreateGroupRequest();
            request.Name = inputs[1];
            _groupController.CreateGroup(request);
            Console.WriteLine("Group created successfully");


        }

    }
}
