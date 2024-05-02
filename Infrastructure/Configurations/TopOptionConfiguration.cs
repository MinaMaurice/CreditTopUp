using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class TopOptionConfiguration : IEntityTypeConfiguration<TopUpOption>
    {
        public void Configure(EntityTypeBuilder<TopUpOption> builder)
        {
            builder.HasKey(o => o.OptionID);
            builder.Property(o => o.Amount).IsRequired();
            // Configure other entity properties, constraints, and relationships if needed
        }
    }

}
