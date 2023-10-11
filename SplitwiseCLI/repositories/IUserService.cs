using SplitwiseCLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseCLI.repositories
{
    public interface IUserService
    {

        public Task<int> AddUser(Users users);

    }
}
