﻿// <auto-generated />
using System;
using EmployeeControlWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeControlWebAPI.Migrations
{
    [DbContext(typeof(EmployeeControlWebAPIContext))]
    [Migration("20240506153618_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EmployeeControlWebAPI.Model.Employees", b =>
                {
                    b.Property<int>("EmployeesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("EmployeesId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeeControlWebAPI.Model.Shifts", b =>
                {
                    b.Property<int>("ShiftsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EmployeesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("QuantityHoursWorked")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ShiftsId");

                    b.HasIndex("EmployeesId");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("EmployeeControlWebAPI.Model.Shifts", b =>
                {
                    b.HasOne("EmployeeControlWebAPI.Model.Employees", null)
                        .WithMany("Shifts")
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeControlWebAPI.Model.Employees", b =>
                {
                    b.Navigation("Shifts");
                });
#pragma warning restore 612, 618
        }
    }
}
