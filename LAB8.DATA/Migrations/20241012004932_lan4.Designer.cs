﻿// <auto-generated />
using System;
using LAB8.DATA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LAB8.DATA.Migrations
{
    [DbContext(typeof(AppAPIDbContext))]
    [Migration("20241012004932_lan4")]
    partial class lan4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LAB8.DATA.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Desception")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("HangXe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdPeople")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("NgaySanXuat")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("LAB8.DATA.Models.Car_People", b =>
                {
                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("PeopleId")
                        .HasColumnType("int");

                    b.HasKey("CarId", "PeopleId");

                    b.ToTable("Car_Peoples");
                });

            modelBuilder.Entity("LAB8.DATA.Models.Laptop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Desception")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("HangMay")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdPeople")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaLaptop")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("NgaySanXuat")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Laptops");
                });

            modelBuilder.Entity("LAB8.DATA.Models.Laptop_People", b =>
                {
                    b.Property<int>("LaptopId")
                        .HasColumnType("int");

                    b.Property<int>("PeopleId")
                        .HasColumnType("int");

                    b.HasKey("LaptopId", "PeopleId");

                    b.HasIndex("PeopleId");

                    b.ToTable("Laptop_Peoples");
                });

            modelBuilder.Entity("LAB8.DATA.Models.People", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("IdCar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdLaptop")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTa")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Peoples");
                });

            modelBuilder.Entity("LAB8.DATA.Models.Car_People", b =>
                {
                    b.HasOne("LAB8.DATA.Models.People", "People")
                        .WithMany("Car_Peoples")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LAB8.DATA.Models.Car", "Car")
                        .WithMany("Car_Peoples")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("People");
                });

            modelBuilder.Entity("LAB8.DATA.Models.Laptop_People", b =>
                {
                    b.HasOne("LAB8.DATA.Models.Laptop", "Laptop")
                        .WithMany("Laptop_Peoples")
                        .HasForeignKey("LaptopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LAB8.DATA.Models.People", "People")
                        .WithMany("Laptop_Peoples")
                        .HasForeignKey("PeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Laptop");

                    b.Navigation("People");
                });

            modelBuilder.Entity("LAB8.DATA.Models.Car", b =>
                {
                    b.Navigation("Car_Peoples");
                });

            modelBuilder.Entity("LAB8.DATA.Models.Laptop", b =>
                {
                    b.Navigation("Laptop_Peoples");
                });

            modelBuilder.Entity("LAB8.DATA.Models.People", b =>
                {
                    b.Navigation("Car_Peoples");

                    b.Navigation("Laptop_Peoples");
                });
#pragma warning restore 612, 618
        }
    }
}
