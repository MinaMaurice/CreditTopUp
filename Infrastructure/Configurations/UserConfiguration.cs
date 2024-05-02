using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserID);
            builder.Property(u => u.UserName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.VerificationStatus).IsRequired();
            builder.Property(u => u.Balance).IsRequired();
            builder.HasMany(u => u.Beneficiaries)
               .WithOne(b => b.User)
               .HasForeignKey(b => b.UserID)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
