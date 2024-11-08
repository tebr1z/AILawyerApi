using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HuquqApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMessagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4fadab10-cf72-4360-8f0d-01edde1968f2", "AQAAAAIAAYagAAAAELLsw8Gcxdb/Mby6C91N4USIJLr8kz9+9s5nU1AX/CwAEmsots28/dOgg9/0uL20CA==", "4b0776d1-48b5-44a0-b638-e85441de72b0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b3a959a-1bf1-4063-9703-f430615cb6ca", "AQAAAAIAAYagAAAAENZxtlvn/keTuo0F0R9dBSkHPD+DTf6CP88xgWhncejIGmIFhG7GSrruoQx63Rq+jA==", "ab32add0-3b2e-4164-8145-7a40a3e1294b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
