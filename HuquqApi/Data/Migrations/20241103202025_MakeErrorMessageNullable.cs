using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HuquqApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class MakeErrorMessageNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StackTrace",
                table: "RequestLogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "RequestLogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MacAddress",
                table: "RequestLogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "IpAddress",
                table: "RequestLogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ErrorMessage",
                table: "RequestLogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4203e67-f44c-4d01-96fd-77dc3c2a2491", "AQAAAAIAAYagAAAAEGixq+9o5P2RU2zIqM6sEH5rA84Vf5alwJFVBPW+cabNsPggjqt6WVCrJyuVqwPEDg==", "c4d38952-f8f8-457f-a67e-84400490ba29" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "685b44b7-ee3f-42de-aff2-ae4c33d140d0", "AQAAAAIAAYagAAAAEDUv2lyjMC9cfIirl1xGvdVrWepC7Sx8hFzecX7lmRA3TG1/Temn6bBCexMdl4HAWQ==", "a35cd37d-3422-46e5-a000-07a34a457e9e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StackTrace",
                table: "RequestLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "RequestLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MacAddress",
                table: "RequestLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IpAddress",
                table: "RequestLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ErrorMessage",
                table: "RequestLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c538c4b8-5210-404d-872f-e78841d7628a", "AQAAAAIAAYagAAAAEFz8B0QPJF0nZdDIOnr8vtVYo1sPsOwLZWOkMxpX6XBWJqMxLnlrzwuf8kZaDvuXCA==", "136cf5a1-8eed-40c8-8138-ca8633fb015b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1565ed07-2c31-472a-a4af-947828818925", "AQAAAAIAAYagAAAAEEAdd0XpmLOhV1kfniTqvbbXdny/7Um/ACCgdAg6vwsaPri5t/onlhBwIDp9v/JmDQ==", "fa552527-1f19-4872-a0a6-db064f7b6bbb" });
        }
    }
}
