using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BirthDate", "FirstName", "LastName", "MiddleName" },
                values: new object[,]
                {
                    { 1, new DateTime(1989, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martin", "Bozhilov", "Jelev" },
                    { 2, new DateTime(1990, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ivan", "Ivanov", "Stoqnov" },
                    { 3, new DateTime(1997, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bella", "Ivanova", "Stancheva" },
                    { 4, new DateTime(1985, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Svetla", "Ilieva", "Marinova" },
                    { 5, new DateTime(1993, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marin", "Marinov", "Hristov" },
                    { 6, new DateTime(1994, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Georgi", "Georgiev", "Petrov" },
                    { 7, new DateTime(1983, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ekaterina", "Kuzmanova", "Stancheva" },
                    { 8, new DateTime(1996, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nikola", "Uzunov", "Ivanov" },
                    { 9, new DateTime(1991, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sofia", "Marinova", "Marinova" },
                    { 10, new DateTime(1992, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marina", "Ilieva", "Ilieva" }
                });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Year", "HealthAndSocialInsurancePercentage", "MaxThreshold", "MinThreshold", "TotalIncomeTaxPercentage" },
                values: new object[,]
                {
                    { 2015, 9.0, 2000.0, 600.0, 7.0 },
                    { 2016, 10.0, 2300.0, 650.0, 7.0 },
                    { 2017, 10.0, 2400.0, 700.0, 8.0 },
                    { 2018, 12.0, 2500.0, 800.0, 8.0 },
                    { 2019, 12.0, 2700.0, 850.0, 8.0 },
                    { 2020, 13.0, 2800.0, 900.0, 9.0 },
                    { 2021, 15.0, 3000.0, 950.0, 9.0 },
                    { 2022, 15.0, 3000.0, 1000.0, 10.0 },
                    { 2023, 16.0, 3300.0, 1200.0, 12.0 }
                });

            migrationBuilder.InsertData(
                table: "EmployeeParameter",
                columns: new[] { "Id", "AnnualSalary", "EmployeeId", "Year" },
                values: new object[,]
                {
                    { 1, 80000.0, 1, 2022 },
                    { 2, 79000.0, 1, 2021 },
                    { 3, 70000.0, 2, 2022 },
                    { 4, 75000.0, 3, 2022 },
                    { 5, 73000.0, 4, 2022 },
                    { 6, 71000.0, 4, 2021 },
                    { 7, 60000.0, 5, 2022 },
                    { 8, 59000.0, 5, 2021 },
                    { 9, 50000.0, 6, 2022 },
                    { 10, 48000.0, 6, 2021 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeParameter",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmployeeParameter",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EmployeeParameter",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EmployeeParameter",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EmployeeParameter",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EmployeeParameter",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EmployeeParameter",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "EmployeeParameter",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "EmployeeParameter",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "EmployeeParameter",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Parameters",
                keyColumn: "Year",
                keyValue: 2015);

            migrationBuilder.DeleteData(
                table: "Parameters",
                keyColumn: "Year",
                keyValue: 2016);

            migrationBuilder.DeleteData(
                table: "Parameters",
                keyColumn: "Year",
                keyValue: 2017);

            migrationBuilder.DeleteData(
                table: "Parameters",
                keyColumn: "Year",
                keyValue: 2018);

            migrationBuilder.DeleteData(
                table: "Parameters",
                keyColumn: "Year",
                keyValue: 2019);

            migrationBuilder.DeleteData(
                table: "Parameters",
                keyColumn: "Year",
                keyValue: 2020);

            migrationBuilder.DeleteData(
                table: "Parameters",
                keyColumn: "Year",
                keyValue: 2023);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Parameters",
                keyColumn: "Year",
                keyValue: 2021);

            migrationBuilder.DeleteData(
                table: "Parameters",
                keyColumn: "Year",
                keyValue: 2022);
        }
    }
}
