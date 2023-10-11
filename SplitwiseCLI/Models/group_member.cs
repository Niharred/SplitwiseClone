using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseCLI.Models
{
    public class group_member
    {
        public int? UserId { get; set; }

        public int? groupId { get; set; }

        public Users? member { get; set; }

        public Groups? group { get; set; }
    }
    public class GroupMembersEntityConfiguration : IEntityTypeConfiguration<group_member>
    {
        public void Configure(EntityTypeBuilder<group_member> builder)
        {
            builder.HasKey(x => new { x.UserId, x.groupId });
            // many to many relationship between members and groups.
            builder.HasOne<Users>(x => x.member).WithMany(x => x.group_member).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne<Groups>(x => x.group).WithMany(x => x.group_member).HasForeignKey(x => x.groupId).OnDelete(DeleteBehavior.Restrict);

        }

    }
}
