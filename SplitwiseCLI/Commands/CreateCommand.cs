using SplitwiseCLI.Controllers;
using SplitwiseCLI.dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseCLI.Commands
{
    public class CreateCommand : Command
    {
        private UserController _userController;

        public CreateCommand()
        { 
        
        }
        public CreateCommand(UserController userController)
        {
            this._userController = userController;
        }

        public bool matches(string input)

        {
            List<string> inputs = input.Split(" ").ToList();
            if(!inputs[0].Equals(Commands.REGISTER_USER_COMMAND))
                return false;
            if(inputs.Count<4)
                return false;

            return true;
        }

        public void execute(string input)
        {
            List<string> inputs = input.Split(" ").ToList();
            CreateUserRequest request=  new CreateUserRequest();
            request.Name = inputs[0];
            request.Password = inputs[1];
            request.Email = inputs[2];
            request.userName= inputs[3];
            request.phone = inputs[4];
            _userController.CreateUser(request);
            Console.WriteLine("user created successfully");


        }

    }
}
