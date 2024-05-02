﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Beneficiary", b =>
                {
                    b.Property<int>("BeneficiaryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BeneficiaryID"), 1L, 1);

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("BeneficiaryID");

                    b.HasIndex("UserID");

                    b.ToTable("Beneficiaries");
                });

            modelBuilder.Entity("Domain.Entities.TopUpOption", b =>
                {
                    b.Property<int>("OptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OptionID"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OptionID");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("Domain.Entities.Transaction", b =>
                {
                    b.Property<int>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionID"), 1L, 1);

                    b.Property<int>("BeneficiaryID")
                        .HasColumnType("int");

                    b.Property<int>("OptionID")
                        .HasColumnType("int");

                    b.Property<decimal>("TransactionAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("TransactionID");

                    b.HasIndex("BeneficiaryID");

                    b.HasIndex("OptionID");

                    b.HasIndex("UserID");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("VerificationStatus")
                        .HasColumnType("bit");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entities.Beneficiary", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Beneficiaries")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Transaction", b =>
                {
                    b.HasOne("Domain.Entities.Beneficiary", "Beneficiary")
                        .WithMany()
                        .HasForeignKey("BeneficiaryID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.TopUpOption", "TopUpOption")
                        .WithMany()
                        .HasForeignKey("OptionID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Beneficiary");

                    b.Navigation("TopUpOption");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Beneficiaries");
                });
#pragma warning restore 612, 618
        }
    }
}
