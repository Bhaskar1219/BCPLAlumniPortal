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
    [Migration("20240101055616_claimattacupdate2")]
    partial class claimattacupdate2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BCPLAlumniPortal.Models.MedicalClaimCharges", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserMedicalClaimid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float?>("amountApproved")
                        .HasColumnType("real");

                    b.Property<float?>("amountClaimed")
                        .HasColumnType("real");

                    b.Property<string>("chargeType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("endDate")
                        .HasColumnType("date");

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isEmpanelled")
                        .HasColumnType("bit");

                    b.Property<string>("isRecommended")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("particulars")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("patientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("patientRelationship")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("placeOfTreatment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("serviceProviderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("serviceRefNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("startDate")
                        .HasColumnType("date");

                    b.Property<string>("treatmentType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("UserMedicalClaimid");

                    b.ToTable("MedicalClaimCharges");
                });

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

                    b.Property<string>("PasswordResetCode")
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

                    b.Property<DateTime>("claimDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("employeeNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isSubmitted")
                        .HasColumnType("bit");

                    b.Property<float?>("totalAmountApproved")
                        .HasColumnType("real");

                    b.Property<float?>("totalAmountClaimed")
                        .HasColumnType("real");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("UserId");

                    b.ToTable("UserMedicalClaim");
                });

            modelBuilder.Entity("BCPLAlumniPortal.Models.UserMedicalClaimAttachment", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("FileSize")
                        .HasColumnType("float");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("MedicalClaimChargesid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("MedicalClaimChargesid");

                    b.ToTable("UserMedicalClaimAttachment");
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

            modelBuilder.Entity("BCPLAlumniPortal.Models.MedicalClaimCharges", b =>
                {
                    b.HasOne("BCPLAlumniPortal.Models.UserMedicalClaim", null)
                        .WithMany("charges")
                        .HasForeignKey("UserMedicalClaimid");
                });

            modelBuilder.Entity("BCPLAlumniPortal.Models.UserMedicalClaim", b =>
                {
                    b.HasOne("BCPLAlumniPortal.Models.User", null)
                        .WithMany("medicalClaims")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("BCPLAlumniPortal.Models.UserMedicalClaimAttachment", b =>
                {
                    b.HasOne("BCPLAlumniPortal.Models.MedicalClaimCharges", null)
                        .WithMany("attachments")
                        .HasForeignKey("MedicalClaimChargesid");
                });

            modelBuilder.Entity("BCPLAlumniPortal.Models.UserRole", b =>
                {
                    b.HasOne("BCPLAlumniPortal.Models.User", null)
                        .WithMany("Roles")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("BCPLAlumniPortal.Models.MedicalClaimCharges", b =>
                {
                    b.Navigation("attachments");
                });

            modelBuilder.Entity("BCPLAlumniPortal.Models.User", b =>
                {
                    b.Navigation("Roles");

                    b.Navigation("medicalClaims");
                });

            modelBuilder.Entity("BCPLAlumniPortal.Models.UserMedicalClaim", b =>
                {
                    b.Navigation("charges");
                });
#pragma warning restore 612, 618
        }
    }
}
