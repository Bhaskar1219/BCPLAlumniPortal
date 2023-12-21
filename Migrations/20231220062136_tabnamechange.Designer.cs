﻿// <auto-generated />
using System;
using BCPLAlumniPortal.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BCPLAlumniPortal.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20231220062136_tabnamechange")]
    partial class tabnamechange
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BCPLAlumniPortal.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNUmber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("BCPLAlumniPortal.Models.UserMedicalClaim", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("claimAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("claimDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isEmpanelled")
                        .HasColumnType("bit");

                    b.Property<string>("patientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("patientRelationship")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("UserId");

                    b.ToTable("UserMedicalClaim");
                });

            modelBuilder.Entity("BCPLAlumniPortal.Models.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("BCPLAlumniPortal.Models.UserMedicalClaim", b =>
                {
                    b.HasOne("BCPLAlumniPortal.Models.User", null)
                        .WithMany("medicalClaims")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("BCPLAlumniPortal.Models.UserRole", b =>
                {
                    b.HasOne("BCPLAlumniPortal.Models.User", null)
                        .WithMany("Roles")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("BCPLAlumniPortal.Models.User", b =>
                {
                    b.Navigation("Roles");

                    b.Navigation("medicalClaims");
                });
#pragma warning restore 612, 618
        }
    }
}
