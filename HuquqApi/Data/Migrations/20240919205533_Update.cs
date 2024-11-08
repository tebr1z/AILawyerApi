using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HuquqApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c30f4dc-c057-411e-bbf7-d1cf785f10a7", "AQAAAAIAAYagAAAAELbsjOAUswJPR4T2uFE8wbEmLWX7wkkA8C/NquwFTI5YcYdy1182NucUycqWp2rrbA==", "68b3bda3-beac-4f2f-ad1c-1127031c14ce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1bcb20fa-2e05-423c-8b4a-b5a48e06d894", "AQAAAAIAAYagAAAAECc7o7xV5AziHIY/KTF4+92w8i301EsbuD8pY7zqXtwSeaGi3iwSNGa/CXJjN3BbZg==", "8dd4acad-5a73-4c88-8816-64f87d08390e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b26ae5d7-59df-49ee-b05c-d639f7a9eda2", "AQAAAAIAAYagAAAAEOvgfhzs4V3TUW2SpnZAp92F8x5oazYT36n4sen5kU/lH/j+1ZBUZ+J+sVqL/RRuqw==", "0c8cf2e2-0d61-416d-9d43-8cffa891fcba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4ea24fc-5912-4008-957e-0138b6415dd8", "AQAAAAIAAYagAAAAEBdaAO/bSrPYgWoetdudnWc8n0eJMQjuXL5n32GH+xTuzWd3/sWc6ZanRlUwjGR32g==", "29d5c1e6-5771-4a68-8b57-4fb406c415d4" });
        }
    }
}
