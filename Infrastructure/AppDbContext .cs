using Domain.Entities;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Beneficiary> Beneficiaries { get; set; }
        public DbSet<TopUpOption> Options { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Apply EntityTypeConfigurations
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BeneficiaryConfiguration());
            modelBuilder.ApplyConfiguration(new TopOptionConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
