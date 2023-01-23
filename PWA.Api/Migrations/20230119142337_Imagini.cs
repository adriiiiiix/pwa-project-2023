using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PWA.Api.Migrations
{
    /// <inheritdoc />
    public partial class Imagini : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15c0a657-92cf-46b0-add0-bff24ac468a0");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b9959fef-efa7-4db2-a5ec-12932f0c1a17", "2969d004-a65d-4d2b-bd6a-92fb77ed62da" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9959fef-efa7-4db2-a5ec-12932f0c1a17");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2969d004-a65d-4d2b-bd6a-92fb77ed62da");

            migrationBuilder.CreateTable(
                name: "Imagini",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CladireId = table.Column<int>(type: "INTEGER", nullable: false),
                    ImagineData = table.Column<byte[]>(type: "BLOB", nullable: false),
                    ImagineName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagini", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a45336f0-a92b-4fdb-81dd-8d73e60563ce", null, "Admin", "admin" },
                    { "f45df783-414f-4eb1-a492-cd76af118964", null, "User", "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b58652ec-68fc-448e-a2c9-5ca961b457b3", 0, "542d8a79-4cc1-4efa-a87c-db5adcb4ae56", "admin@adminEmail.com", true, "Admin", "Admin", false, null, "ADMIN@ADMINEMAIL.COM", "ADMIN@ADMINEMAIL.COM", "AQAAAAIAAYagAAAAEJRs2sUwlIH6n+6bzYiyaLoqiVUh+WcKI8DuZoAFmFJClPZOKMOJ07OU+JZ3mApfIw==", null, false, "", false, "admin@adminEmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a45336f0-a92b-4fdb-81dd-8d73e60563ce", "b58652ec-68fc-448e-a2c9-5ca961b457b3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Imagini");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f45df783-414f-4eb1-a492-cd76af118964");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a45336f0-a92b-4fdb-81dd-8d73e60563ce", "b58652ec-68fc-448e-a2c9-5ca961b457b3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a45336f0-a92b-4fdb-81dd-8d73e60563ce");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b58652ec-68fc-448e-a2c9-5ca961b457b3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "15c0a657-92cf-46b0-add0-bff24ac468a0", null, "User", "user" },
                    { "b9959fef-efa7-4db2-a5ec-12932f0c1a17", null, "Admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2969d004-a65d-4d2b-bd6a-92fb77ed62da", 0, "3dd99539-70ab-4c37-9ed2-73cb002b0006", "admin@adminEmail.com", true, "Admin", "Admin", false, null, "ADMIN@ADMINEMAIL.COM", "ADMIN@ADMINEMAIL.COM", "AQAAAAIAAYagAAAAEN4SLeD4ONQIccv/GO5O+p0qgQCA1ST2HtKre7mq6MjUp1oHVRShRXmu4OVOkMAzDA==", null, false, "", false, "admin@adminEmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b9959fef-efa7-4db2-a5ec-12932f0c1a17", "2969d004-a65d-4d2b-bd6a-92fb77ed62da" });
        }
    }
}
