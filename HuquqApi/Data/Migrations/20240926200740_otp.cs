using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HuquqApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class otp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OtpExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResetPasswordOtp",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "OtpExpiryTime", "PasswordHash", "ResetPasswordOtp", "SecurityStamp" },
                values: new object[] { "476fc487-e24d-49c9-b1b2-28654e5f2ed3", null, "AQAAAAIAAYagAAAAEIZGd7ad62U2NYv//oyq2L27d+oH0Knxd9w7hJpckkkF6+uYbzh8SnRUCq1l9YQulg==", null, "d5b065be-131a-4f72-b7c2-31dcac1c80ca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "OtpExpiryTime", "PasswordHash", "ResetPasswordOtp", "SecurityStamp" },
                values: new object[] { "48b7b6a8-3f92-4e65-a1e8-8a33e9caab02", null, "AQAAAAIAAYagAAAAEJ78aacWB1P35l3gSqXXiIwvPPARq0DL38dlb29EJwr/CZ48wPKe3H5EvrxlFmgulw==", null, "7c516694-005c-4dfd-90c1-ddd8f08a609b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OtpExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ResetPasswordOtp",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bfcfb2b3-41e8-4bb6-baf1-c78f9199ad69", "AQAAAAIAAYagAAAAELwzHCLMCvjZFtZZT9dx55sN0NfHEYP4Lx1021/4N9PfWwSQpSYTnm4jH6l9ufPajQ==", "775dfe53-8715-4693-b2e4-b881bc5e9c77" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "363fc393-231b-4f61-b924-f42b9355cf3d", "AQAAAAIAAYagAAAAELM4Qbwdm5/y+E+WJ86x2AanzaAjqyxD+Pgpjt/fpj6haWphMKkolTzb7CsFihiTWg==", "e2ee311b-2678-46ec-bef3-cdd3e2b71e95" });
        }
    }
}
