﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CaExam.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240820192733_addedWorkingInitialData")]
    partial class addedWorkingInitialData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CaExam.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ApartamentNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1c2cf5fb-eec0-4c96-8430-ba9a19583742"),
                            ApartamentNumber = "1",
                            City = "Vilnius",
                            HouseNumber = "2",
                            UserId = new Guid("5e3268d1-7911-4acc-bf62-f3f5c7e1f038"),
                            street = "Kauno"
                        });
                });

            modelBuilder.Entity("CaExam.Models.UserDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalIdNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PicturePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserDetails");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c2c8cedc-1045-42f5-a04d-75daf71c79ed"),
                            Email = "tele2@hotmail.com",
                            Name = "zmogus",
                            PersonalIdNumber = "37707727776",
                            PhoneNumber = "8644785417",
                            PicturePath = "somewhere in server",
                            Surname = "zmogaitis",
                            UserId = new Guid("5e3268d1-7911-4acc-bf62-f3f5c7e1f038")
                        });
                });

            modelBuilder.Entity("CaExam.Models.UserModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5e3268d1-7911-4acc-bf62-f3f5c7e1f038"),
                            Password = new byte[] { 106, 183, 187, 160, 69, 146, 147, 71, 26, 50, 41, 214, 255, 67, 241, 247, 124, 60, 109, 87, 29, 56, 82, 71, 2, 227, 67, 143, 219, 52, 166, 194 },
                            Role = 0,
                            Salt = new byte[] { 104, 88, 166, 31, 73, 34, 115, 59, 147, 237, 243, 4, 117, 167, 178, 26 },
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("CaExam.Models.Address", b =>
                {
                    b.HasOne("CaExam.Models.UserModel", "User")
                        .WithOne("Address")
                        .HasForeignKey("CaExam.Models.Address", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CaExam.Models.UserDetails", b =>
                {
                    b.HasOne("CaExam.Models.UserModel", "User")
                        .WithOne("UserDetails")
                        .HasForeignKey("CaExam.Models.UserDetails", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CaExam.Models.UserModel", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("UserDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
