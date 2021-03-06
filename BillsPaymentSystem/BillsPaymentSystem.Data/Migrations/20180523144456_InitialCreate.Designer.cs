﻿// <auto-generated />
using BillsPaymentSystem.Data;
using BillsPaymentSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BillsPaymentSystem.Data.Migrations
{
    [DbContext(typeof(BillsPaymentSystemDbContext))]
    [Migration("20180523144456_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BillsPaymentSystem.Models.BankAccount", b =>
                {
                    b.Property<int>("BankAccountId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Balance");

                    b.Property<string>("BankName");

                    b.Property<string>("SwiftCode");

                    b.HasKey("BankAccountId");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("BillsPaymentSystem.Models.CreditCard", b =>
                {
                    b.Property<int>("CreditCardId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ExpirationDate");

                    b.Property<decimal>("Limit");

                    b.Property<decimal>("MoneyOwed");

                    b.HasKey("CreditCardId");

                    b.ToTable("CreditCards");
                });

            modelBuilder.Entity("BillsPaymentSystem.Models.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BankAccountId");

                    b.Property<int?>("CreditCardId");

                    b.Property<int>("Type");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BankAccountId")
                        .IsUnique()
                        .HasFilter("[BankAccountId] IS NOT NULL");

                    b.HasIndex("CreditCardId")
                        .IsUnique()
                        .HasFilter("[CreditCardId] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("BillsPaymentSystem.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BillsPaymentSystem.Models.PaymentMethod", b =>
                {
                    b.HasOne("BillsPaymentSystem.Models.BankAccount", "BankAccount")
                        .WithOne("PaymentMethod")
                        .HasForeignKey("BillsPaymentSystem.Models.PaymentMethod", "BankAccountId");

                    b.HasOne("BillsPaymentSystem.Models.CreditCard", "CreditCard")
                        .WithOne("PaymentMethod")
                        .HasForeignKey("BillsPaymentSystem.Models.PaymentMethod", "CreditCardId");

                    b.HasOne("BillsPaymentSystem.Models.User", "User")
                        .WithMany("PaymentMethods")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
