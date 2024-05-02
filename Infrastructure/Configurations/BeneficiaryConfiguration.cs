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
    public class BeneficiaryConfiguration : IEntityTypeConfiguration<Beneficiary>
    {
        public void Configure(EntityTypeBuilder<Beneficiary> builder)
        {
            builder.HasKey(b => b.BeneficiaryID);
            builder.Property(b => b.Nickname).IsRequired().HasMaxLength(20);
            builder.HasOne(b => b.User)
               .WithMany(u => u.Beneficiaries)
               .HasForeignKey(b => b.UserID)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
