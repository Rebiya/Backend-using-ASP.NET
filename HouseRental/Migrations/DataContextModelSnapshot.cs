﻿// <auto-generated />
using HouseRental.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HouseRental1.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("HouseRental.Modules.Property", b =>
                {
                    b.Property<int>("PropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Bathroom")
                        .HasColumnType("int");

                    b.Property<int>("Bedrooms")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Imgurl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(15,2)");

                    b.Property<string>("PropertyType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Subcity")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PropertyId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("HouseRental.Modules.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("longtext");

                    b.Property<string>("StaffEmail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StaffName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StaffPassword")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StaffPhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("branch")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("StaffId");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("HouseRental.Modules.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserPhoneNUmber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserProfilePicture")
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
