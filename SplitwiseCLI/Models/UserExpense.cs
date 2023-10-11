using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseCLI.Models
{
    public class UserExpense
    {
        public int UserExpenseId { get; set; }
        public Users User { get; set; }

        public double amount { get; set; }

        //change to enum
        public string currency { get; set; }

        public string type { get; set; }

        public Expense? PaidByExpense { get; set; }

        public Expense? OwedByExpense { get; set; }

        public int? paidById { get; set; }

        public int? owedById { get; set; }
    }
    public class UserExpenseEntityConfiguration : IEntityTypeConfiguration<UserExpense>
    {
        public void Configure(EntityTypeBuilder<UserExpense> builder)
        {
            builder.HasKey(x => x.UserExpenseId);
            // one to many relationship between created by and groups.
            builder.HasOne(x => x.PaidByExpense).WithMany(x => x.paidBy).HasForeignKey(x => x.paidById).OnDelete(DeleteBehavior.ClientSetNull); ;
            builder.HasOne(x => x.OwedByExpense).WithMany(x => x.owedBy).HasForeignKey(x => x.owedById).OnDelete(DeleteBehavior.ClientSetNull); ;

        }

    }
}
