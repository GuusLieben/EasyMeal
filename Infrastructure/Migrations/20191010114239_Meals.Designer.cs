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
    [Migration("20191010114239_Meals")]
    partial class Meals
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

                    b.HasIndex("Email");

                    b.ToTable("Cooks");
                });

            modelBuilder.Entity("Domain.DietRestrictions", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RestrictionId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RestrictionId")
                        .HasColumnName("DietRestrictions_RestrictionId");

                    b.Property<int>("_setting")
                        .HasColumnName("Setting");

                    b.HasKey("_id");

                    b.HasIndex("RestrictionId");

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

                    b.HasIndex("Name");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("Domain.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateValid");

                    b.Property<int>("DessertId");

                    b.Property<int>("MainId");

                    b.Property<int?>("MenuId");

                    b.Property<int>("StarterId");

                    b.HasKey("Id");

                    b.HasIndex("DateValid");

                    b.HasIndex("DessertId");

                    b.HasIndex("MainId");

                    b.HasIndex("MenuId");

                    b.HasIndex("StarterId");

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
                        .HasForeignKey("RestrictionId");
                });

            modelBuilder.Entity("Domain.Meal", b =>
                {
                    b.HasOne("Domain.Dish", "Dessert")
                        .WithMany()
                        .HasForeignKey("DessertId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Dish", "Main")
                        .WithMany()
                        .HasForeignKey("MainId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Menu")
                        .WithMany("Meals")
                        .HasForeignKey("MenuId");

                    b.HasOne("Domain.Dish", "Starter")
                        .WithMany()
                        .HasForeignKey("StarterId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
