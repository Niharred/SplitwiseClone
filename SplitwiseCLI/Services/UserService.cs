using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SplitwiseCLI.Models;
using SplitwiseCLI.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseCLI.Services
{
    public class UserService : IUserService
    {
        private readonly DbContext _dbContext;

        public UserService()
        { 
        
        }
        public UserService(DbContext dbContext)
        { 
        this._dbContext = dbContext;
        }
        
        public async Task<int> AddUser(Users user)
        {

            var users = await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return 1;
            
        
        }


    }
}
