using SplitwiseCLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseCLI.repositories
{
    public interface IGroupService
    {
        public Task<int> CreateGroup(Groups group);


        public Task<int> AddMember(Users user);

        public Task<int> RemoveUser(Users user);

        public Task<int> AddExpense(Expense expense);

    }
}
