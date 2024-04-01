using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TruckPlan.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "BirthDate", "DrivingLicenseNumber", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1974, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12345, "Michael Lund" },
                    { 2, new DateTime(1990, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 6789, "Jeppe Wilson" },
                    { 3, new DateTime(1984, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 76543, "Sophia Garcia" }
                });

            migrationBuilder.InsertData(
                table: "TripPlans",
                columns: new[] { "Id", "DriverId", "TripEndDate", "TripEndLatitude", "TripEndLongitude", "TripStartDate", "TripStartLatitude", "TripStartLongitude" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2018, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 53.551085999999998, 9.9936819999999997, new DateTime(2018, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 52.520007999999997, 13.404954 },
                    { 2, 2, new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.396228999999998, 10.390599999999999, new DateTime(2020, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.676098000000003, 12.568337 },
                    { 3, 3, new DateTime(2021, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.605293099999997, 13.0001566, new DateTime(2021, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 59.325117200000001, 18.0710935 },
                    { 4, 3, new DateTime(2018, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 48.778448500000003, 9.1800131999999994, new DateTime(2018, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.110644399999998, 8.6820917000000009 },
                    { 5, 2, new DateTime(2019, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 52.517036500000003, 13.3888599, new DateTime(2019, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.938361, 6.9599739999999999 }
                });

            migrationBuilder.InsertData(
                table: "Trucks",
                columns: new[] { "Id", "DriverId", "ModelName", "Vin" },
                values: new object[,]
                {
                    { 1, 1, "Volvo", "ABC12345" },
                    { 2, 2, "Tesla", "MMO12345" },
                    { 3, 3, "Scania", "QWER12345" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TripPlans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TripPlans",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TripPlans",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TripPlans",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TripPlans",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
