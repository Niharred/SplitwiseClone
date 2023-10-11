using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseCLI.Models
{
    public class ExpenseUsers
    {
        public int? userId { get; set; }

        public int? ExpenseId { get; set; }

        public Users? users { get; set; }


        public Expense? expenses { get; set; }
    }

    public class ExpenseUsersEntityConfiguration : IEntityTypeConfiguration<ExpenseUsers>
    {
        public void Configure(EntityTypeBuilder<ExpenseUsers> builder)
        {
            builder.HasKey(x => new { x.userId, x.ExpenseId });

            builder.HasOne(x => x.users).WithMany(x => x.expense_users).HasForeignKey(x => x.userId).OnDelete(DeleteBehavior.ClientSetNull); ;

            builder.HasOne(x => x.expenses).WithMany(x => x.expense_users).HasForeignKey(x => x.ExpenseId).OnDelete(DeleteBehavior.ClientSetNull); ;
        }

    }
}
