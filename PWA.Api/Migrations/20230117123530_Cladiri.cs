using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PWA.Api.Migrations
{
    /// <inheritdoc />
    public partial class Cladiri : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73a00c34-3935-4b52-90e0-9f4137bc39ca");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c22a4ebc-1b89-4270-aed9-b9c2ad163212", "5e4649d7-e7d3-4abc-a14e-72acd2e29008" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c22a4ebc-1b89-4270-aed9-b9c2ad163212");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e4649d7-e7d3-4abc-a14e-72acd2e29008");

            migrationBuilder.CreateTable(
                name: "Cladiri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipStrada = table.Column<string>(name: "Tip_Strada", type: "TEXT", nullable: false),
                    DenumireStrada = table.Column<string>(name: "Denumire_Strada", type: "TEXT", nullable: false),
                    Numar = table.Column<string>(type: "TEXT", nullable: false),
                    Bloc = table.Column<string>(type: "TEXT", nullable: true),
                    Scara = table.Column<string>(type: "TEXT", nullable: true),
                    StadiulBlocului = table.Column<string>(name: "Stadiul_Blocului", type: "TEXT", nullable: false),
                    AnulConstruirii = table.Column<string>(name: "Anul_Construirii", type: "TEXT", nullable: false),
                    RegimInaltime = table.Column<string>(name: "Regim_Inaltime", type: "TEXT", nullable: true),
                    Sistemulconstructiv = table.Column<string>(name: "Sistemul_constructiv", type: "TEXT", nullable: true),
                    Numarapartamente = table.Column<int>(name: "Numar_apartamente", type: "INTEGER", nullable: false),
                    Longitudine = table.Column<float>(type: "REAL", nullable: true),
                    Latitudine = table.Column<float>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cladiri", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cladiri");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "73a00c34-3935-4b52-90e0-9f4137bc39ca", "3c215506-62c2-47a8-8754-9f97ac1fe895", "User", "user" },
                    { "c22a4ebc-1b89-4270-aed9-b9c2ad163212", "453542d4-ca3a-4a3c-8f1f-9ababdbced9b", "Admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5e4649d7-e7d3-4abc-a14e-72acd2e29008", 0, "da43dfcd-2fc4-4387-8cb9-653a59f3f361", "admin@adminEmail.com", true, "Admin", "Admin", false, null, "ADMIN@ADMINEMAIL.COM", "ADMIN@ADMINEMAIL.COM", "AQAAAAEAACcQAAAAEKveHxfSN+7eWQwDBf6X8uuJAF/sFCzVvjgKzPLJ5cfT//9XjMrDg4IqvxzMyV8xlQ==", null, false, "", false, "admin@adminEmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c22a4ebc-1b89-4270-aed9-b9c2ad163212", "5e4649d7-e7d3-4abc-a14e-72acd2e29008" });
        }
    }
}
