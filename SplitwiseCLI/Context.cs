using Microsoft.EntityFrameworkCore;
using SplitwiseCLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseCLI
{
    public class Context: DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        { 
        
        }
        DbSet<Users> Users { get; set; }

        DbSet<Groups> Groups { get; set; }

        DbSet<group_member> Group_Members { get; set; }

        DbSet<group_admins> Group_Admins { get; set; }

        DbSet<UserExpense> userExpenses { get; set; }

        DbSet<Expense> expenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UsersEntityConfiguration());
            modelBuilder.ApplyConfiguration(new GroupsEntityConfiguration());

            modelBuilder.ApplyConfiguration(new GroupAdminsEntityConfiguration());
            modelBuilder.ApplyConfiguration(new GroupMembersEntityConfiguration());

            modelBuilder.ApplyConfiguration(new UserExpenseEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseUsersEntityConfiguration());


            modelBuilder.ApplyConfiguration(new ExpenseEntityConfiguration());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SURUKK;Database=SplitwiseCloneCLI;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
