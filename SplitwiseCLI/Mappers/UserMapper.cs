using SplitwiseCLI.dtos;
using SplitwiseCLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseCLI.Mappers
{
    public static class UserMapper
    {
        public static Users UserDtoToUserModel(CreateUserRequest request)
        { 
            Users users = new Users();
            users.Name = request.Name;
            users.Password = request.Password;
            users.Email = request.Email;
            users.phone = request.phone;
            users.userName= request.userName;

            return users;
        
        }

    }
}
