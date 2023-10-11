using Microsoft.EntityFrameworkCore;
using SplitwiseCLI.dtos;
using SplitwiseCLI.Mappers;
using SplitwiseCLI.Models;
using SplitwiseCLI.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SplitwiseCLI.Controllers
{
    public class UserController 
    {

        private readonly IUserService _userService;

        public UserController()
        { 
        
        
        }

        public UserController(IUserService userService)
        { 
        
            this._userService = userService;
        }
        public async Task<int> CreateUser(CreateUserRequest request)
        {
            Users users = UserMapper.UserDtoToUserModel(request);
           _userService.AddUser(users);
            return 1;
        }


    }
}
