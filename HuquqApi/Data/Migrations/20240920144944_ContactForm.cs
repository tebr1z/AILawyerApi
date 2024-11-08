using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HuquqApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class ContactForm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contactForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contactForms", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe93b10c-a808-42c3-9e70-8d1f501746ce", "AQAAAAIAAYagAAAAEOvKDrewHxUJ8Dlm1Sligx8kt19YGFNoC4PyIL48SPtCocX4mc8VwG/jUA1bsrzCHg==", "935a0325-ad0a-438c-b3ae-11b941e739c4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bcf92b26-a1bf-428e-854d-154ee4fd9f22", "AQAAAAIAAYagAAAAEB3Ts6mcCIW1KjzPHtjDVE4sX086JIj+BX3iCM7uc9w8lyPry9191e3f2G/53SGdLw==", "fd228ab6-3d6b-4270-808f-c827dd0a40fe" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contactForms");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c30f4dc-c057-411e-bbf7-d1cf785f10a7", "AQAAAAIAAYagAAAAELbsjOAUswJPR4T2uFE8wbEmLWX7wkkA8C/NquwFTI5YcYdy1182NucUycqWp2rrbA==", "68b3bda3-beac-4f2f-ad1c-1127031c14ce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1bcb20fa-2e05-423c-8b4a-b5a48e06d894", "AQAAAAIAAYagAAAAECc7o7xV5AziHIY/KTF4+92w8i301EsbuD8pY7zqXtwSeaGi3iwSNGa/CXJjN3BbZg==", "8dd4acad-5a73-4c88-8816-64f87d08390e" });
        }
    }
}
