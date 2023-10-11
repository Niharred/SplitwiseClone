using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseCLI.Models
{
    public class group_admins
    {
        public int? User_Id { get; set; }

        public int? group_Id { get; set; }

        public Users? admin { get; set; }

        public Groups? group { get; set; }
    }
    public class GroupAdminsEntityConfiguration : IEntityTypeConfiguration<group_admins>
    {
        public void Configure(EntityTypeBuilder<group_admins> builder)
        {
            builder.HasKey(x => new { x.User_Id, x.group_Id });

            // many to many relationship between admins and groups.
            builder.HasOne<Users>(x => x.admin).WithMany(x => x.group_admins).HasForeignKey(x => x.User_Id).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne<Groups>(x => x.group).WithMany(x => x.group_admins).HasForeignKey(x => x.group_Id).OnDelete(DeleteBehavior.ClientSetNull);

        }

    }
}
