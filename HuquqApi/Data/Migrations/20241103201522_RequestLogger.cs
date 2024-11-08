using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HuquqApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class RequestLogger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage",
                table: "RequestLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MacAddress",
                table: "RequestLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StackTrace",
                table: "RequestLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ErrorMessage",
                table: "RequestLogs");

            migrationBuilder.DropColumn(
                name: "MacAddress",
                table: "RequestLogs");

            migrationBuilder.DropColumn(
                name: "StackTrace",
                table: "RequestLogs");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79f1a0bc-3ab8-43f7-908b-6d47820e2f8c", "AQAAAAIAAYagAAAAEKvQMux2M86bTdWkvwzfTIWJhBzyCBdT2n28HqractSUsLCClG1+JwQTW1O+XDrBgw==", "3d5fa47d-f458-4dec-8552-3ea91238090f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6071e0b3-8aa4-4920-89eb-d14077abefbb", "AQAAAAIAAYagAAAAEL5FEiA9r3rsF28oGC18fJSSWHXmh5cb3Lpt0sasLLuump/rZdZN/lqndLAtS3pGMg==", "28c40c06-3fcc-4aa8-b4b1-a575e4500b7d" });
        }
    }
}
