using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseCLI.Models
{
    public class Expense
    {
        [Key]
        public int expenseId { get; set; }
        public string description { get; set; }

        public double amount { get; set; }

        public DateTime date { get; set; }


        public Groups? group { get; set; }


        public virtual List<UserExpense>? paidBy { get; set; }


        public virtual List<UserExpense>? owedBy { get; set; }

        public virtual List<ExpenseUsers>? expense_users { get; set; }
    }

    public class ExpenseEntityConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(x => x.expenseId);
            // one to many relationship between created by and groups.



        }

    }

}
