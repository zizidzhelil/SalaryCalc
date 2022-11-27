using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    MinThreshold = table.Column<double>(type: "float", nullable: false),
                    TotalIncomeTaxPercentage = table.Column<double>(type: "float", nullable: false),
                    HealthAndSocialInsurancePercentage = table.Column<double>(type: "float", nullable: false),
                    MaxThreshold = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeParameter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ParameterId = table.Column<int>(type: "int", nullable: false),
                    AnnualSalary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeParameter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeParameter_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeParameter_Parameters_ParameterId",
                        column: x => x.ParameterId,
                        principalTable: "Parameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "Id", "HealthAndSocialInsurancePercentage", "MaxThreshold", "MinThreshold", "TotalIncomeTaxPercentage", "Year" },
                values: new object[,]
                {
                    { 1, 16.0, 3300.0, 1200.0, 12.0, 2023 },
                    { 2, 15.0, 3000.0, 1000.0, 10.0, 2022 },
                    { 3, 15.0, 3000.0, 950.0, 9.0, 2021 },
                    { 4, 13.0, 2800.0, 900.0, 9.0, 2020 },
                    { 5, 12.0, 2700.0, 850.0, 8.0, 2019 },
                    { 6, 12.0, 2500.0, 800.0, 8.0, 2018 },
                    { 7, 10.0, 2400.0, 700.0, 8.0, 2017 },
                    { 8, 10.0, 2300.0, 650.0, 7.0, 2016 },
                    { 9, 9.0, 2000.0, 600.0, 7.0, 2015 }
                });

            migrationBuilder.InsertData(
                table: "EmployeeParameter",
                columns: new[] { "Id", "AnnualSalary", "EmployeeId", "ParameterId" },
                values: new object[,]
                {
                    { 1, 80000.0, 1, 2 },
                    { 2, 79000.0, 1, 3 },
                    { 3, 70000.0, 2, 2 },
                    { 4, 75000.0, 3, 2 },
                    { 5, 73000.0, 4, 2 },
                    { 6, 71000.0, 4, 3 },
                    { 7, 60000.0, 5, 2 },
                    { 8, 59000.0, 5, 3 },
                    { 9, 50000.0, 6, 2 },
                    { 10, 48000.0, 6, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeParameter_EmployeeId",
                table: "EmployeeParameter",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeParameter_ParameterId",
                table: "EmployeeParameter",
                column: "ParameterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeParameter");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Parameters");
        }
    }
}
