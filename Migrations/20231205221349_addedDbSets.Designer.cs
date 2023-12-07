﻿// <auto-generated />
using System;
using FitnessPortal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FitnessPortal.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231205221349_addedDbSets")]
    partial class addedDbSets
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FitnessPortal.Data.Entities.FoodJournal", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FoodID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FoodNutritionID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("KcalTotal")
                        .HasColumnType("real");

                    b.Property<float>("Quantity")
                        .HasColumnType("real");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("FoodNutritionID");

                    b.HasIndex("UserID");

                    b.ToTable("FoodsJournal");
                });

            modelBuilder.Entity("FitnessPortal.Data.Entities.FoodNutrition", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<float>("Kcal")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("FoodsNutrition");
                });

            modelBuilder.Entity("FitnessPortal.Data.Entities.SleepJournal", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("SleepJournal");
                });

            modelBuilder.Entity("FitnessPortal.Data.Entities.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Roles")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FitnessPortal.Data.Entities.UserDetails", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<float?>("BMI")
                        .HasColumnType("real");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Height")
                        .HasColumnType("real");

                    b.Property<int?>("KCalGoal")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float?>("Weight")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("UsersDetails");
                });

            modelBuilder.Entity("FitnessPortal.Data.Entities.FoodJournal", b =>
                {
                    b.HasOne("FitnessPortal.Data.Entities.FoodNutrition", "FoodNutrition")
                        .WithMany("FoodJournals")
                        .HasForeignKey("FoodNutritionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessPortal.Data.Entities.User", "User")
                        .WithMany("FoodJournals")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodNutrition");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessPortal.Data.Entities.SleepJournal", b =>
                {
                    b.HasOne("FitnessPortal.Data.Entities.User", "User")
                        .WithMany("SleepJournals")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessPortal.Data.Entities.UserDetails", b =>
                {
                    b.HasOne("FitnessPortal.Data.Entities.User", "User")
                        .WithOne("UserDetails")
                        .HasForeignKey("FitnessPortal.Data.Entities.UserDetails", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessPortal.Data.Entities.FoodNutrition", b =>
                {
                    b.Navigation("FoodJournals");
                });

            modelBuilder.Entity("FitnessPortal.Data.Entities.User", b =>
                {
                    b.Navigation("FoodJournals");

                    b.Navigation("SleepJournals");

                    b.Navigation("UserDetails")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
