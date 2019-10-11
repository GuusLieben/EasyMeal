﻿// <auto-generated />
using System;
using Infrastructure.Meals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(MealDbContext))]
    [Migration("20191011100430_FirstVersion")]
    partial class FirstVersion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Cook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnName("FirstName");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnName("LastName");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("Hash");

                    b.Property<string>("Phonenumber")
                        .IsRequired()
                        .HasColumnName("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Cooks");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            Email = "h.d@gmail.com",
                            Firstname = "Henk",
                            Lastname = "Dekker",
                            Password = "1234",
                            Phonenumber = "0612345678"
                        });
                });

            modelBuilder.Entity("Domain.DietRestrictions", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RestrictionId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DishId");

                    b.Property<int>("_setting")
                        .HasColumnName("Setting");

                    b.HasKey("_id");

                    b.HasIndex("DishId");

                    b.ToTable("DietRestrictions");
                });

            modelBuilder.Entity("Domain.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DishId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("Description");

                    b.Property<int?>("DishId")
                        .HasColumnName("DishId1");

                    b.Property<int>("DishSize")
                        .HasColumnName("DishSize");

                    b.Property<int>("DishType")
                        .HasColumnName("Type");

                    b.Property<string>("ImageUri")
                        .IsRequired()
                        .HasColumnName("ImageUri");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name");

                    b.Property<double>("Price")
                        .HasColumnName("Price");

                    b.HasKey("Id");

                    b.HasIndex("DishId");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("Domain.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateValid")
                        .HasColumnName("DateValid");

                    b.Property<int?>("MenuId");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("MealOptionals");
                });

            modelBuilder.Entity("Domain.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MenuId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Week");

                    b.HasKey("Id");

                    b.ToTable("WeekMenus");
                });

            modelBuilder.Entity("Domain.DietRestrictions", b =>
                {
                    b.HasOne("Domain.Dish")
                        .WithMany("DietRestrictions")
                        .HasForeignKey("DishId");
                });

            modelBuilder.Entity("Domain.Dish", b =>
                {
                    b.HasOne("Domain.Meal")
                        .WithMany("Dishes")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.Meal", b =>
                {
                    b.HasOne("Domain.Menu")
                        .WithMany("Meals")
                        .HasForeignKey("MenuId");
                });
#pragma warning restore 612, 618
        }
    }
}