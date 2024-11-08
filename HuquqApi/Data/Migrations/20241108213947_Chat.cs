using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HuquqApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Chat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Messages",
                newName: "ContentUser");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Messages",
                newName: "ContentBot");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "MasterAdmin", "MASTERADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ec6dafd-959f-40af-9767-083b6b4e1f37", "AQAAAAIAAYagAAAAEHFGpxjex4mKwfCP9xYw3Fsh8eOm4Isg0TPv141xLDyc8sK+d9nip0bpqX0M7qpEIQ==", "c18f0e50-7080-478c-a1a3-4e7f5cee9492" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "IsPremium", "LastName", "LastQuestionDate", "LockoutEnabled", "LockoutEnd", "MonthlyQuestionCount", "NormalizedEmail", "NormalizedUserName", "OtpExpiryTime", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PremiumExpirationDate", "RequestCount", "RequestCountTime", "ResetPasswordOtp", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "14", 0, "bc57177c-4016-4764-9740-6784db204dd6", "hasimovtabriz@gmail.com", true, "Tabriz ", false, "Hashimov", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0, "HASIMOVTABRIZ@GMAIL.COM", "ADMINUSER", null, "AQAAAAIAAYagAAAAEA3IzUKlK3rKzR5dE0TE5nKRULsLZkAwER2v+G5Tdgx/ikp61no4GlhlLR55FL99kg==", null, false, null, 0, 0, null, "d2b4d8f7-17bf-423c-b88a-dfc94614519e", false, "tabriz" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14");

            migrationBuilder.RenameColumn(
                name: "ContentUser",
                table: "Messages",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "ContentBot",
                table: "Messages",
                newName: "Content");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Super-User", "SUPER-USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c9b0c8f-131d-4c0c-9338-de2e452e039e", "AQAAAAIAAYagAAAAEBJEHpY6UVQXl7gO1sw0soXKjUXfQYhn43b8Wz1Uq9u1U4K145WTPKQAtoQwCSsyLg==", "8925f62b-c753-4b7f-aeab-5774f2aaf5e9" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "IsPremium", "LastName", "LastQuestionDate", "LockoutEnabled", "LockoutEnd", "MonthlyQuestionCount", "NormalizedEmail", "NormalizedUserName", "OtpExpiryTime", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PremiumExpirationDate", "RequestCount", "RequestCountTime", "ResetPasswordOtp", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "278db22c-f9a4-4d43-bddd-cc3ab0ed9df7", "hasimovtabriz@gmail.com", true, "Tabriz ", false, "Hashimov", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0, "HASIMOVTABRIZ@GMAIL.COM", "ADMINUSER", null, "AQAAAAIAAYagAAAAEM/F8I+D8Jo1mY5bENy2HTaj/fSy+i/qEDvo7nNSKfrUP72MiiXqBSFKpvI1CQjd2g==", null, false, null, 0, 0, null, "c5a1ee6b-4864-4af0-97bc-38d9d4f35ed6", false, "tabriz" });
        }
    }
}
