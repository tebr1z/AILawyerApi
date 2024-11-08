using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HuquqApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Settings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

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
    }
}
