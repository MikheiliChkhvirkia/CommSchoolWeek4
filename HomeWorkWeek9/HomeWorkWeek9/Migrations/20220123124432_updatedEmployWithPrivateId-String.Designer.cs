﻿// <auto-generated />
using System;
using HomeWorkWeek9;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HomeWorkWeek9.Migrations
{
    [DbContext(typeof(HomeWorkDbContext))]
    [Migration("20220123124432_updatedEmployWithPrivateId-String")]
    partial class updatedEmployWithPrivateIdString
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("HomeWorkWeek9.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Foreign")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("HomeWorkWeek9.Employ", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PossitionId")
                        .HasColumnType("int");

                    b.Property<string>("PrivateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WeekDayWorkHour")
                        .HasColumnType("int");

                    b.Property<int?>("WeekendWorkHour")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("PossitionId");

                    b.ToTable("Employs");
                });

            modelBuilder.Entity("HomeWorkWeek9.Possition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Possitions");
                });

            modelBuilder.Entity("HomeWorkWeek9.Employ", b =>
                {
                    b.HasOne("HomeWorkWeek9.Company", "Company")
                        .WithMany("Employs")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeWorkWeek9.Possition", "Possition")
                        .WithMany("Employs")
                        .HasForeignKey("PossitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Possition");
                });

            modelBuilder.Entity("HomeWorkWeek9.Company", b =>
                {
                    b.Navigation("Employs");
                });

            modelBuilder.Entity("HomeWorkWeek9.Possition", b =>
                {
                    b.Navigation("Employs");
                });
#pragma warning restore 612, 618
        }
    }
}
