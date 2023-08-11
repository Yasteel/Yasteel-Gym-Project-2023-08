﻿// <auto-generated />
using System;
using GymApp.API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GymApp.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230811224730_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.Models.MemberBmiRecord", b =>
                {
                    b.Property<int>("BmiRecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("pkBmiRecordId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BmiRecordId"));

                    b.Property<double>("BMI")
                        .HasColumnType("float");

                    b.Property<int>("MemberId")
                        .HasColumnType("int")
                        .HasColumnName("fkMemberId");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("BmiRecordId");

                    b.ToTable("BmiRecords");
                });

            modelBuilder.Entity("Models.Models.MemberHrRecord", b =>
                {
                    b.Property<int>("HrRecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("pkHrRecordId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HrRecordId"));

                    b.Property<double>("HRmax")
                        .HasColumnType("float");

                    b.Property<double>("HRrest")
                        .HasColumnType("float");

                    b.Property<int>("MemberId")
                        .HasColumnType("int")
                        .HasColumnName("fkMemberId");

                    b.Property<double>("OTWOmax")
                        .HasColumnType("float");

                    b.HasKey("HrRecordId");

                    b.ToTable("HrRecords");
                });

            modelBuilder.Entity("Models.Models.MemberTrainerLink", b =>
                {
                    b.Property<int>("LinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("pkLinkId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LinkId"));

                    b.Property<int>("MemberId")
                        .HasColumnType("int")
                        .HasColumnName("fkMemberId");

                    b.Property<int>("TrainerId")
                        .HasColumnType("int")
                        .HasColumnName("fkTrainerId");

                    b.HasKey("LinkId");

                    b.HasIndex("MemberId");

                    b.HasIndex("TrainerId");

                    b.ToTable("MemberTrainerLink");
                });

            modelBuilder.Entity("Models.Models.Members", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("pkMemberId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberId"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("ContactNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Gender")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<string>("IdNumber")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MembershipType")
                        .HasColumnType("int")
                        .HasColumnName("fkMembershipType");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Surname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MemberId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Models.Models.Trainers", b =>
                {
                    b.Property<int>("TrainerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("pkTrainerId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrainerId"));

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrainerClass")
                        .HasColumnType("int");

                    b.HasKey("TrainerId");

                    b.ToTable("Trainers");
                });

            modelBuilder.Entity("Models.Models.MemberTrainerLink", b =>
                {
                    b.HasOne("Models.Models.Members", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Models.Trainers", "Trainer")
                        .WithMany()
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Trainer");
                });
#pragma warning restore 612, 618
        }
    }
}
