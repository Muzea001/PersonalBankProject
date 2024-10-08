﻿// <auto-generated />
using System;
using BankApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BankApp.Migrations
{
    [DbContext(typeof(BankDbContext))]
    [Migration("20240828121145_mig1")]
    partial class mig1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("BankApp.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Balance")
                        .HasColumnType("TEXT");

                    b.Property<int>("BankId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("DebtSum")
                        .HasColumnType("TEXT");

                    b.Property<int>("LoanId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("userId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AccountId");

                    b.HasIndex("userId")
                        .IsUnique();

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            AccountId = 1,
                            AccountType = "Regular",
                            Balance = 0m,
                            BankId = 1,
                            DebtSum = 0m,
                            LoanId = 0,
                            userId = 1
                        },
                        new
                        {
                            AccountId = 2,
                            AccountType = "Savings",
                            Balance = 0m,
                            BankId = 1,
                            DebtSum = 0m,
                            LoanId = 0,
                            userId = 2
                        });
                });

            modelBuilder.Entity("BankApp.Models.AccountTransaction", b =>
                {
                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TransactionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AccountId", "TransactionId");

                    b.HasIndex("TransactionId");

                    b.ToTable("accountTransactions");

                    b.HasData(
                        new
                        {
                            AccountId = 1,
                            TransactionId = 1
                        },
                        new
                        {
                            AccountId = 2,
                            TransactionId = 1
                        });
                });

            modelBuilder.Entity("BankApp.Models.Bank", b =>
                {
                    b.Property<int>("BankId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("SumOfDebt")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("SumOfHoldings")
                        .HasColumnType("TEXT");

                    b.HasKey("BankId");

                    b.ToTable("Bank");

                    b.HasData(
                        new
                        {
                            BankId = 1,
                            BankName = "MyBank1",
                            SumOfDebt = 0m,
                            SumOfHoldings = 100000000m
                        });
                });

            modelBuilder.Entity("BankApp.Models.Downpayment", b =>
                {
                    b.Property<int>("DownpaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("LoanId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TransactionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DownpaymentId");

                    b.HasIndex("LoanId");

                    b.ToTable("Downpayments");

                    b.HasData(
                        new
                        {
                            DownpaymentId = 1,
                            LoanId = 1,
                            TransactionId = 2
                        });
                });

            modelBuilder.Entity("BankApp.Models.Loan", b =>
                {
                    b.Property<int>("LoanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BankId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DeadLine")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("RentPercentage")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("totalAmount")
                        .HasColumnType("TEXT");

                    b.HasKey("LoanId");

                    b.HasIndex("AccountId");

                    b.HasIndex("BankId");

                    b.ToTable("Loans");

                    b.HasData(
                        new
                        {
                            LoanId = 1,
                            AccountId = 1,
                            BankId = 1,
                            DeadLine = new DateTime(2026, 8, 28, 14, 11, 45, 12, DateTimeKind.Local).AddTicks(3618),
                            RentPercentage = 5m,
                            totalAmount = 150.000m
                        });
                });

            modelBuilder.Entity("BankApp.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DownpaymentId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsProcessed")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("TransactionAmount")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isDeposit")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("isLoan")
                        .HasColumnType("INTEGER");

                    b.HasKey("TransactionId");

                    b.HasIndex("DownpaymentId")
                        .IsUnique();

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            TransactionId = 1,
                            IsProcessed = true,
                            TransactionAmount = 1000m,
                            TransactionDate = new DateTime(2024, 8, 28, 14, 11, 45, 12, DateTimeKind.Local).AddTicks(3677),
                            isDeposit = true,
                            isLoan = false
                        },
                        new
                        {
                            TransactionId = 2,
                            DownpaymentId = 1,
                            IsProcessed = true,
                            TransactionAmount = 2000m,
                            TransactionDate = new DateTime(2024, 8, 28, 14, 11, 45, 12, DateTimeKind.Local).AddTicks(3681),
                            isDeposit = false,
                            isLoan = true
                        });
                });

            modelBuilder.Entity("BankApp.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BankId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Member")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.HasIndex("BankId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            BankId = 1,
                            Member = false,
                            UserName = "Mike Smith"
                        },
                        new
                        {
                            UserId = 2,
                            BankId = 1,
                            Member = true,
                            UserName = "John Johnson"
                        });
                });

            modelBuilder.Entity("BankApp.Models.Account", b =>
                {
                    b.HasOne("BankApp.Models.Bank", "bank")
                        .WithMany("Accounts")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BankApp.Models.User", "user")
                        .WithOne("UserAccount")
                        .HasForeignKey("BankApp.Models.Account", "userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("bank");

                    b.Navigation("user");
                });

            modelBuilder.Entity("BankApp.Models.AccountTransaction", b =>
                {
                    b.HasOne("BankApp.Models.Account", "Account")
                        .WithMany("AccountTransactions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankApp.Models.Transaction", "Transaction")
                        .WithMany("AccountTransactions")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("BankApp.Models.Downpayment", b =>
                {
                    b.HasOne("BankApp.Models.Loan", "loan")
                        .WithMany("associatedPayments")
                        .HasForeignKey("LoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("loan");
                });

            modelBuilder.Entity("BankApp.Models.Loan", b =>
                {
                    b.HasOne("BankApp.Models.Account", "Account")
                        .WithMany("LoanList")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankApp.Models.Bank", "Bank")
                        .WithMany("Loans")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Bank");
                });

            modelBuilder.Entity("BankApp.Models.Transaction", b =>
                {
                    b.HasOne("BankApp.Models.Downpayment", "Downpayment")
                        .WithOne("Transaction")
                        .HasForeignKey("BankApp.Models.Transaction", "DownpaymentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Downpayment");
                });

            modelBuilder.Entity("BankApp.Models.User", b =>
                {
                    b.HasOne("BankApp.Models.Bank", "Bank")
                        .WithMany("Users")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");
                });

            modelBuilder.Entity("BankApp.Models.Account", b =>
                {
                    b.Navigation("AccountTransactions");

                    b.Navigation("LoanList");
                });

            modelBuilder.Entity("BankApp.Models.Bank", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Loans");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("BankApp.Models.Downpayment", b =>
                {
                    b.Navigation("Transaction")
                        .IsRequired();
                });

            modelBuilder.Entity("BankApp.Models.Loan", b =>
                {
                    b.Navigation("associatedPayments");
                });

            modelBuilder.Entity("BankApp.Models.Transaction", b =>
                {
                    b.Navigation("AccountTransactions");
                });

            modelBuilder.Entity("BankApp.Models.User", b =>
                {
                    b.Navigation("UserAccount")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
