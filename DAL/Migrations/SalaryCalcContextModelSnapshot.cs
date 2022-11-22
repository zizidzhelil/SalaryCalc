﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(SalaryCalcContext))]
    partial class SalaryCalcContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1989, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Martin",
                            LastName = "Bozhilov",
                            MiddleName = "Jelev"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1990, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Ivan",
                            LastName = "Ivanov",
                            MiddleName = "Stoqnov"
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(1997, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Bella",
                            LastName = "Ivanova",
                            MiddleName = "Stancheva"
                        },
                        new
                        {
                            Id = 4,
                            BirthDate = new DateTime(1985, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Svetla",
                            LastName = "Ilieva",
                            MiddleName = "Marinova"
                        },
                        new
                        {
                            Id = 5,
                            BirthDate = new DateTime(1993, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Marin",
                            LastName = "Marinov",
                            MiddleName = "Hristov"
                        },
                        new
                        {
                            Id = 6,
                            BirthDate = new DateTime(1994, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Georgi",
                            LastName = "Georgiev",
                            MiddleName = "Petrov"
                        },
                        new
                        {
                            Id = 7,
                            BirthDate = new DateTime(1983, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Ekaterina",
                            LastName = "Kuzmanova",
                            MiddleName = "Stancheva"
                        },
                        new
                        {
                            Id = 8,
                            BirthDate = new DateTime(1996, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Nikola",
                            LastName = "Uzunov",
                            MiddleName = "Ivanov"
                        },
                        new
                        {
                            Id = 9,
                            BirthDate = new DateTime(1991, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Sofia",
                            LastName = "Marinova",
                            MiddleName = "Marinova"
                        },
                        new
                        {
                            Id = 10,
                            BirthDate = new DateTime(1992, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Marina",
                            LastName = "Ilieva",
                            MiddleName = "Ilieva"
                        });
                });

            modelBuilder.Entity("Core.Entities.EmployeeParameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AnnualSalary")
                        .HasColumnType("float");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("Year");

                    b.ToTable("EmployeeParameter");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnnualSalary = 80000.0,
                            EmployeeId = 1,
                            Year = 2022
                        },
                        new
                        {
                            Id = 2,
                            AnnualSalary = 79000.0,
                            EmployeeId = 1,
                            Year = 2021
                        },
                        new
                        {
                            Id = 3,
                            AnnualSalary = 70000.0,
                            EmployeeId = 2,
                            Year = 2022
                        },
                        new
                        {
                            Id = 4,
                            AnnualSalary = 75000.0,
                            EmployeeId = 3,
                            Year = 2022
                        },
                        new
                        {
                            Id = 5,
                            AnnualSalary = 73000.0,
                            EmployeeId = 4,
                            Year = 2022
                        },
                        new
                        {
                            Id = 6,
                            AnnualSalary = 71000.0,
                            EmployeeId = 4,
                            Year = 2021
                        },
                        new
                        {
                            Id = 7,
                            AnnualSalary = 60000.0,
                            EmployeeId = 5,
                            Year = 2022
                        },
                        new
                        {
                            Id = 8,
                            AnnualSalary = 59000.0,
                            EmployeeId = 5,
                            Year = 2021
                        },
                        new
                        {
                            Id = 9,
                            AnnualSalary = 50000.0,
                            EmployeeId = 6,
                            Year = 2022
                        },
                        new
                        {
                            Id = 10,
                            AnnualSalary = 48000.0,
                            EmployeeId = 6,
                            Year = 2021
                        });
                });

            modelBuilder.Entity("Core.Entities.Parameter", b =>
                {
                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.Property<double>("HealthAndSocialInsurancePercentage")
                        .HasColumnType("float");

                    b.Property<double>("MaxThreshold")
                        .HasColumnType("float");

                    b.Property<double>("MinThreshold")
                        .HasColumnType("float");

                    b.Property<double>("TotalIncomeTaxPercentage")
                        .HasColumnType("float");

                    b.HasKey("Year");

                    b.ToTable("Parameters");

                    b.HasData(
                        new
                        {
                            Year = 2023,
                            HealthAndSocialInsurancePercentage = 16.0,
                            MaxThreshold = 3300.0,
                            MinThreshold = 1200.0,
                            TotalIncomeTaxPercentage = 12.0
                        },
                        new
                        {
                            Year = 2022,
                            HealthAndSocialInsurancePercentage = 15.0,
                            MaxThreshold = 3000.0,
                            MinThreshold = 1000.0,
                            TotalIncomeTaxPercentage = 10.0
                        },
                        new
                        {
                            Year = 2021,
                            HealthAndSocialInsurancePercentage = 15.0,
                            MaxThreshold = 3000.0,
                            MinThreshold = 950.0,
                            TotalIncomeTaxPercentage = 9.0
                        },
                        new
                        {
                            Year = 2020,
                            HealthAndSocialInsurancePercentage = 13.0,
                            MaxThreshold = 2800.0,
                            MinThreshold = 900.0,
                            TotalIncomeTaxPercentage = 9.0
                        },
                        new
                        {
                            Year = 2019,
                            HealthAndSocialInsurancePercentage = 12.0,
                            MaxThreshold = 2700.0,
                            MinThreshold = 850.0,
                            TotalIncomeTaxPercentage = 8.0
                        },
                        new
                        {
                            Year = 2018,
                            HealthAndSocialInsurancePercentage = 12.0,
                            MaxThreshold = 2500.0,
                            MinThreshold = 800.0,
                            TotalIncomeTaxPercentage = 8.0
                        },
                        new
                        {
                            Year = 2017,
                            HealthAndSocialInsurancePercentage = 10.0,
                            MaxThreshold = 2400.0,
                            MinThreshold = 700.0,
                            TotalIncomeTaxPercentage = 8.0
                        },
                        new
                        {
                            Year = 2016,
                            HealthAndSocialInsurancePercentage = 10.0,
                            MaxThreshold = 2300.0,
                            MinThreshold = 650.0,
                            TotalIncomeTaxPercentage = 7.0
                        },
                        new
                        {
                            Year = 2015,
                            HealthAndSocialInsurancePercentage = 9.0,
                            MaxThreshold = 2000.0,
                            MinThreshold = 600.0,
                            TotalIncomeTaxPercentage = 7.0
                        });
                });

            modelBuilder.Entity("Core.Entities.EmployeeParameter", b =>
                {
                    b.HasOne("Core.Entities.Employee", "Employee")
                        .WithMany("Parameters")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Parameter", "Parameter")
                        .WithMany("Parameters")
                        .HasForeignKey("Year")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Parameter");
                });

            modelBuilder.Entity("Core.Entities.Employee", b =>
                {
                    b.Navigation("Parameters");
                });

            modelBuilder.Entity("Core.Entities.Parameter", b =>
                {
                    b.Navigation("Parameters");
                });
#pragma warning restore 612, 618
        }
    }
}
