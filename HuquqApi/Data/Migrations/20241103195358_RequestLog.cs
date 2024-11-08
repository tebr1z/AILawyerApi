using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HuquqApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class RequestLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSuccessful = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestLogs", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestLogs");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "476fc487-e24d-49c9-b1b2-28654e5f2ed3", "AQAAAAIAAYagAAAAEIZGd7ad62U2NYv//oyq2L27d+oH0Knxd9w7hJpckkkF6+uYbzh8SnRUCq1l9YQulg==", "d5b065be-131a-4f72-b7c2-31dcac1c80ca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48b7b6a8-3f92-4e65-a1e8-8a33e9caab02", "AQAAAAIAAYagAAAAEJ78aacWB1P35l3gSqXXiIwvPPARq0DL38dlb29EJwr/CZ48wPKe3H5EvrxlFmgulw==", "7c516694-005c-4dfd-90c1-ddd8f08a609b" });
        }
    }
}
