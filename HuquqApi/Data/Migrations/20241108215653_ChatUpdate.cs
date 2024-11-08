using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HuquqApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChatUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ContentUser",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ContentBot",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "47100af5-cfd0-4ea7-a8e7-abafb66811bb", "AQAAAAIAAYagAAAAEPKd6NIQU8YUuDTwOKR4M7ofgfG3jX8nmC6h0h5IOqIyP+WJLDzmNVKZfYvjYmrwGw==", "b031075b-9cac-465a-8178-03e18fc7ce24" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6b4fcf9-8790-41a3-951e-e952c559863b", "AQAAAAIAAYagAAAAEEnMYXRUjggWUNa7wFxrKWVnMsNVVFVqklxlV4lW4ok2Tn2BpTkEP/NjQnTnZF6rog==", "605d47c4-65df-4d0a-b04f-2351f6b0018d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ContentUser",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContentBot",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc57177c-4016-4764-9740-6784db204dd6", "AQAAAAIAAYagAAAAEA3IzUKlK3rKzR5dE0TE5nKRULsLZkAwER2v+G5Tdgx/ikp61no4GlhlLR55FL99kg==", "d2b4d8f7-17bf-423c-b88a-dfc94614519e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ec6dafd-959f-40af-9767-083b6b4e1f37", "AQAAAAIAAYagAAAAEHFGpxjex4mKwfCP9xYw3Fsh8eOm4Isg0TPv141xLDyc8sK+d9nip0bpqX0M7qpEIQ==", "c18f0e50-7080-478c-a1a3-4e7f5cee9492" });
        }
    }
}
