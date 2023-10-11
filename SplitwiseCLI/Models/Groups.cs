using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseCLI.Models
{
    public class Groups
    {
        public int GroupId { get; set; }

        public string Name { get; set; }

        public int? userId { get; set; }
        public Users? createdBy { get; set; }

        public Expense? expense { get; set; }

        public int? expenseId { get; set; }


        public virtual List<group_member>? group_member { get; set; }


        public virtual List<group_admins>? group_admins { get; set; }
    }
    public class GroupsEntityConfiguration : IEntityTypeConfiguration<Groups>
    {
        public void Configure(EntityTypeBuilder<Groups> builder)
        {   
            builder.HasKey(x => x.GroupId);
            // one to many relationship between created by and groups.
            builder.HasOne(x => x.createdBy).WithMany(x => x.groups).HasForeignKey(x => x.userId).OnDelete(DeleteBehavior.ClientSetNull); ;
            builder.HasOne(x => x.expense).WithOne(x => x.group).HasForeignKey<Groups>(x => x.expenseId);


        }

    }
}
