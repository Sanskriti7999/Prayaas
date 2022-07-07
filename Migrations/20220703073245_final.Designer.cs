﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prayaas_Website.Models;

namespace Prayaas_Website.Migrations
{
    [DbContext(typeof(PrayaasDbContext))]
    [Migration("20220703073245_final")]
    partial class final
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Prayaas_Website.Models.AccountStatusT", b =>
                {
                    b.Property<int>("accountStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("accountStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("accountStatusID");

                    b.ToTable("accountStatus");

                    b.HasData(
                        new
                        {
                            accountStatusID = 1,
                            accountStatus = "Pending"
                        },
                        new
                        {
                            accountStatusID = 2,
                            accountStatus = "Approved"
                        },
                        new
                        {
                            accountStatusID = 3,
                            accountStatus = "Denied"
                        },
                        new
                        {
                            accountStatusID = 4,
                            accountStatus = "Open"
                        },
                        new
                        {
                            accountStatusID = 5,
                            accountStatus = "Closed"
                        });
                });

            modelBuilder.Entity("Prayaas_Website.Models.BloodGroups", b =>
                {
                    b.Property<int>("BloodGroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BloodGroup")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("BloodGroupID");

                    b.ToTable("bloodGroups");

                    b.HasData(
                        new
                        {
                            BloodGroupID = 1,
                            BloodGroup = "AB+"
                        },
                        new
                        {
                            BloodGroupID = 2,
                            BloodGroup = "B+"
                        },
                        new
                        {
                            BloodGroupID = 3,
                            BloodGroup = "O+"
                        },
                        new
                        {
                            BloodGroupID = 4,
                            BloodGroup = "A-"
                        },
                        new
                        {
                            BloodGroupID = 5,
                            BloodGroup = "B-"
                        },
                        new
                        {
                            BloodGroupID = 6,
                            BloodGroup = "A+"
                        });
                });

            modelBuilder.Entity("Prayaas_Website.Models.BloodStock", b =>
                {
                    b.Property<int>("BloodStockID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BloodGroupID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("InstitutionID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("BloodStockID");

                    b.HasIndex("BloodGroupID");

                    b.HasIndex("InstitutionID");

                    b.ToTable("bloodStock");
                });

            modelBuilder.Entity("Prayaas_Website.Models.CityT", b =>
                {
                    b.Property<int>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CityID");

                    b.ToTable("city");

                    b.HasData(
                        new
                        {
                            CityID = 1,
                            City = "Pune"
                        },
                        new
                        {
                            CityID = 2,
                            City = "Mumbai"
                        },
                        new
                        {
                            CityID = 3,
                            City = "Nashik"
                        },
                        new
                        {
                            CityID = 4,
                            City = "Bhopal"
                        },
                        new
                        {
                            CityID = 5,
                            City = "Ahmedabad"
                        },
                        new
                        {
                            CityID = 6,
                            City = "Nagpur"
                        },
                        new
                        {
                            CityID = 7,
                            City = "Indore"
                        });
                });

            modelBuilder.Entity("Prayaas_Website.Models.Donor", b =>
                {
                    b.Property<int>("DonorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adhaar")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<int>("BloodGroupID")
                        .HasColumnType("int");

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("GenderID")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastDonationDate")
                        .HasColumnType("date");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("DonorID");

                    b.HasIndex("BloodGroupID");

                    b.HasIndex("CityID");

                    b.HasIndex("GenderID");

                    b.HasIndex("UserID");

                    b.ToTable("donor");
                });

            modelBuilder.Entity("Prayaas_Website.Models.GenderT", b =>
                {
                    b.Property<int>("GenderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("GenderID");

                    b.ToTable("Gender");

                    b.HasData(
                        new
                        {
                            GenderID = 1,
                            Gender = "Male"
                        },
                        new
                        {
                            GenderID = 2,
                            Gender = "Female"
                        },
                        new
                        {
                            GenderID = 3,
                            Gender = "Others"
                        });
                });

            modelBuilder.Entity("Prayaas_Website.Models.Institution", b =>
                {
                    b.Property<int>("InstitutionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("InstituionTypeID")
                        .HasColumnType("int");

                    b.Property<string>("InstitutionName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("InstitutionTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("InstitutionID");

                    b.HasIndex("CityID");

                    b.HasIndex("InstituionTypeID");

                    b.HasIndex("UserID");

                    b.ToTable("institution");
                });

            modelBuilder.Entity("Prayaas_Website.Models.InstitutionTypeT", b =>
                {
                    b.Property<int>("InstitutionTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InstituitonType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstitutionTypeID");

                    b.ToTable("institutionType");
                });

            modelBuilder.Entity("Prayaas_Website.Models.Request", b =>
                {
                    b.Property<int>("RequestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BloodGroupID")
                        .HasColumnType("int");

                    b.Property<int?>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quantity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("date");

                    b.Property<int?>("RequestTypeID")
                        .HasColumnType("int");

                    b.Property<int?>("UserTypeID")
                        .HasColumnType("int");

                    b.HasKey("RequestID");

                    b.HasIndex("BloodGroupID");

                    b.HasIndex("CityID");

                    b.HasIndex("RequestTypeID");

                    b.HasIndex("UserTypeID");

                    b.ToTable("request");
                });

            modelBuilder.Entity("Prayaas_Website.Models.RequestTypeT", b =>
                {
                    b.Property<int>("RequestTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RequestType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RequestTypeID");

                    b.ToTable("requestType");

                    b.HasData(
                        new
                        {
                            RequestTypeID = 1,
                            RequestType = "Seeker"
                        },
                        new
                        {
                            RequestTypeID = 2,
                            RequestType = "Institution"
                        });
                });

            modelBuilder.Entity("Prayaas_Website.Models.Seeker", b =>
                {
                    b.Property<int>("SeekerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adhaar")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("BloodGroupID")
                        .HasColumnType("int");

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("ContactNo")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("GenderID")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("date");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("SeekerID");

                    b.HasIndex("BloodGroupID");

                    b.HasIndex("CityID");

                    b.HasIndex("GenderID");

                    b.HasIndex("UserID");

                    b.ToTable("seeker");
                });

            modelBuilder.Entity("Prayaas_Website.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountStatusID")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("UserTypeID")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.HasIndex("AccountStatusID");

                    b.HasIndex("UserTypeID");

                    b.ToTable("user");
                });

            modelBuilder.Entity("Prayaas_Website.Models.UserTypeT", b =>
                {
                    b.Property<int>("UserTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserTypeID");

                    b.ToTable("userType");

                    b.HasData(
                        new
                        {
                            UserTypeID = 1,
                            UserType = "Donor"
                        },
                        new
                        {
                            UserTypeID = 2,
                            UserType = "Seeker"
                        },
                        new
                        {
                            UserTypeID = 3,
                            UserType = "Admin"
                        });
                });

            modelBuilder.Entity("Prayaas_Website.Models.BloodStock", b =>
                {
                    b.HasOne("Prayaas_Website.Models.BloodGroups", "BloodGroups")
                        .WithMany()
                        .HasForeignKey("BloodGroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prayaas_Website.Models.Institution", "Institution")
                        .WithMany()
                        .HasForeignKey("InstitutionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BloodGroups");

                    b.Navigation("Institution");
                });

            modelBuilder.Entity("Prayaas_Website.Models.Donor", b =>
                {
                    b.HasOne("Prayaas_Website.Models.BloodGroups", "BloodGroups")
                        .WithMany()
                        .HasForeignKey("BloodGroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prayaas_Website.Models.CityT", "City")
                        .WithMany()
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prayaas_Website.Models.GenderT", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prayaas_Website.Models.User", "User")
                        .WithMany("Donor")
                        .HasForeignKey("UserID");

                    b.Navigation("BloodGroups");

                    b.Navigation("City");

                    b.Navigation("Gender");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Prayaas_Website.Models.Institution", b =>
                {
                    b.HasOne("Prayaas_Website.Models.CityT", "City")
                        .WithMany()
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prayaas_Website.Models.InstitutionTypeT", "InstitutionType")
                        .WithMany()
                        .HasForeignKey("InstituionTypeID");

                    b.HasOne("Prayaas_Website.Models.User", "User")
                        .WithMany("Institution")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("InstitutionType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Prayaas_Website.Models.Request", b =>
                {
                    b.HasOne("Prayaas_Website.Models.BloodGroups", "BloodGroups")
                        .WithMany()
                        .HasForeignKey("BloodGroupID");

                    b.HasOne("Prayaas_Website.Models.CityT", "City")
                        .WithMany()
                        .HasForeignKey("CityID");

                    b.HasOne("Prayaas_Website.Models.RequestTypeT", "RequestType")
                        .WithMany()
                        .HasForeignKey("RequestTypeID");

                    b.HasOne("Prayaas_Website.Models.UserTypeT", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeID");

                    b.Navigation("BloodGroups");

                    b.Navigation("City");

                    b.Navigation("RequestType");

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("Prayaas_Website.Models.Seeker", b =>
                {
                    b.HasOne("Prayaas_Website.Models.BloodGroups", "BloodGroups")
                        .WithMany()
                        .HasForeignKey("BloodGroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prayaas_Website.Models.CityT", "City")
                        .WithMany()
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prayaas_Website.Models.GenderT", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prayaas_Website.Models.User", "User")
                        .WithMany("Seeker")
                        .HasForeignKey("UserID");

                    b.Navigation("BloodGroups");

                    b.Navigation("City");

                    b.Navigation("Gender");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Prayaas_Website.Models.User", b =>
                {
                    b.HasOne("Prayaas_Website.Models.AccountStatusT", "AccountStatus")
                        .WithMany()
                        .HasForeignKey("AccountStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prayaas_Website.Models.UserTypeT", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeID");

                    b.Navigation("AccountStatus");

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("Prayaas_Website.Models.User", b =>
                {
                    b.Navigation("Donor");

                    b.Navigation("Institution");

                    b.Navigation("Seeker");
                });
#pragma warning restore 612, 618
        }
    }
}
