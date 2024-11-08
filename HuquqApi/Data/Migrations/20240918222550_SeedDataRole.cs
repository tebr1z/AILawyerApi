using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HuquqApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "User", "USER" },
                    { "3", null, "Super-User", "SUPER-USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "IsPremium", "LastName", "LastQuestionDate", "LockoutEnabled", "LockoutEnd", "MonthlyQuestionCount", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PremiumExpirationDate", "RequestCount", "RequestCountTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "b26ae5d7-59df-49ee-b05c-d639f7a9eda2", "hasimovtabriz@gmail.com", true, "Tabriz ", false, "Hashimov", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0, "HASIMOVTABRIZ@GMAIL.COM", "ADMINUSER", "AQAAAAIAAYagAAAAEOvgfhzs4V3TUW2SpnZAp92F8x5oazYT36n4sen5kU/lH/j+1ZBUZ+J+sVqL/RRuqw==", null, false, null, 0, 0, "0c8cf2e2-0d61-416d-9d43-8cffa891fcba", false, "tabriz" },
                    { "2", 0, "a4ea24fc-5912-4008-957e-0138b6415dd8", "tebitebo2001@gmail.com", true, "Admin", false, "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0, "TEBITEBO2001@GMAIL.COM", "ADMINUSER1", "AQAAAAIAAYagAAAAEBdaAO/bSrPYgWoetdudnWc8n0eJMQjuXL5n32GH+xTuzWd3/sWc6ZanRlUwjGR32g==", null, false, null, 0, 0, "29d5c1e6-5771-4a68-8b57-4fb406c415d4", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "2", "2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");
        }
    }
}
