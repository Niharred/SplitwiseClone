using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SplitwiseCLI.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string userName { get; set; }
        public string phone { get; set; }

        public List<Groups>? groups { get; set; }

        public Groups? groupes { get; set; }

        public virtual List<group_member>? group_member { get; set; }


        public virtual List<group_admins>? group_admins { get; set; }


        public virtual List<ExpenseUsers>? expense_users { get; set; }

    }
    public class UsersEntityConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(x => x.UserId);

        }

    }
}
