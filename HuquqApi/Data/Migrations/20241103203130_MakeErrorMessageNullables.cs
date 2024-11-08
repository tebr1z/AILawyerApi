using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HuquqApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class MakeErrorMessageNullables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "278db22c-f9a4-4d43-bddd-cc3ab0ed9df7", "AQAAAAIAAYagAAAAEM/F8I+D8Jo1mY5bENy2HTaj/fSy+i/qEDvo7nNSKfrUP72MiiXqBSFKpvI1CQjd2g==", "c5a1ee6b-4864-4af0-97bc-38d9d4f35ed6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c9b0c8f-131d-4c0c-9338-de2e452e039e", "AQAAAAIAAYagAAAAEBJEHpY6UVQXl7gO1sw0soXKjUXfQYhn43b8Wz1Uq9u1U4K145WTPKQAtoQwCSsyLg==", "8925f62b-c753-4b7f-aeab-5774f2aaf5e9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
