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
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(t => t.TransactionID);
            builder.Property(t => t.TransactionAmount).IsRequired();
            builder.Property(t => t.TransactionDate).IsRequired();


            builder.HasOne(t => t.User)
              .WithMany()
              .HasForeignKey(t => t.UserID)
              .OnDelete(DeleteBehavior.NoAction); 

            builder.HasOne(t => t.Beneficiary)
                   .WithMany()
                   .HasForeignKey(t => t.BeneficiaryID)
                   .OnDelete(DeleteBehavior.NoAction); 

            builder.HasOne(t => t.TopUpOption)
                   .WithMany()
                   .HasForeignKey(t => t.OptionID)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
