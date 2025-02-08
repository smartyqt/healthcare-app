using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedPatientsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "ContactInfo", "DateOfBirth", "Gender", "Name" },
                values: new object[,]
                {
                    { 1, "555-1234", new DateTime(1985, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "John Doe" },
                    { 2, "555-5678", new DateTime(1992, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "Jane Smith" },
                    { 3, "555-4321", new DateTime(2000, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Non-binary", "Alex Johnson" },
                    { 4, "555-7890", new DateTime(1978, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "Michael Brown" },
                    { 5, "555-2468", new DateTime(1995, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "Sarah Wilson" },
                    { 6, "555-1357", new DateTime(1989, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "Emily Davis" },
                    { 7, "555-9876", new DateTime(1980, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "James Miller" },
                    { 8, "555-6543", new DateTime(1993, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "Olivia Martinez" },
                    { 9, "555-3214", new DateTime(1975, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "William Anderson" },
                    { 10, "555-7894", new DateTime(2002, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "Sophia Thomas" }
                });

            migrationBuilder.InsertData(
                table: "Recommendations",
                columns: new[] { "Id", "Description", "IsCompleted", "PatientId", "Type" },
                values: new object[,]
                {
                    { 1, "Annual allergy test", false, 1, "Allergy Check" },
                    { 2, "General health screening", false, 2, "Screening" },
                    { 3, "Routine BP monitoring", false, 3, "Blood Pressure Check" },
                    { 4, "Cholesterol level check", false, 4, "Cholesterol Screening" },
                    { 5, "Check for required vaccinations", false, 5, "Vaccination Update" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
