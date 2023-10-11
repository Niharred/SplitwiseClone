using Microsoft.EntityFrameworkCore;
using SplitwiseCLI.Models;
using SplitwiseCLI.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseCLI.Services
{
    public class GroupService :IGroupService
    {

        private readonly DbContext _dbContext;

        public GroupService()
        {

        }
        public GroupService(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }



        public async Task<int> CreateGroup(Groups group)
        {
            var users = await _dbContext.AddAsync(group);
             _dbContext.SaveChangesAsync();

            return 1;
        }


        public async Task<int> AddMember(Users user) {
            var users = await _dbContext.AddAsync(user);
            _dbContext.SaveChangesAsync();

            return 1;
        }

        public async Task<int> RemoveUser(Users user) {
            var users = await _dbContext.AddAsync(user);
            _dbContext.SaveChangesAsync();

            return 1;
        }

        public async Task<int> AddExpense(Expense expense) {
            var users = await _dbContext.AddAsync(expense);
            _dbContext.SaveChangesAsync();

            return 1;
        }
    }
}
