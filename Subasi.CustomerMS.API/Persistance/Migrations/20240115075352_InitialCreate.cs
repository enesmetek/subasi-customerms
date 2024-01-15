using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Subasi.CustomerMS.API.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Definition = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TokenCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TokenExpires = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppRoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppRoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AppUsers_AppRoles_AppRoleID",
                        column: x => x.AppRoleID,
                        principalTable: "AppRoles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressType = table.Column<int>(type: "int", nullable: false),
                    AddressLine = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    District = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Addresses_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "ID", "Definition" },
                values: new object[,]
                {
                    { new Guid("0910659f-670a-47d2-aa00-6a343dbaae48"), "Member" },
                    { new Guid("b1803d37-f260-4135-afb2-b44ae26c58ed"), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("22d85348-00dc-4ec4-a5f4-e7db6dc5c652"), "kafali22@gmail.com", "Mustafa", "Kafali", "542-366-6688" },
                    { new Guid("29127229-8503-4e7b-b91f-249ef2a6161c"), "yildirimgul@gmail.com", "Yildirim", "Gul", "545-332-2239" },
                    { new Guid("46e61ab0-946a-4e6f-901b-9cc4a919c748"), "emkafali@gmail.com", "Enes Mete", "Kafali", "553-580-9653" },
                    { new Guid("58a451ed-ae3e-40fe-b118-708c0f9872f4"), "tktaskiran@gmail.com", "Tolga Kagan", "Taskiran", "546-602-3272" },
                    { new Guid("611165a4-b4c1-4ce4-aca5-2d70ee35db5a"), "mert@outlook.com", "Mert", "Kafali", "546-297-5518" },
                    { new Guid("7b6d363e-6fe9-4955-b8bb-36b4d535e3a6"), "temelatanc@gmail.com", "Can", "Temelatan", "533-559-0511" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "ID", "AddressLine", "AddressType", "CustomerID", "District", "Province" },
                values: new object[,]
                {
                    { new Guid("1f4cba7e-dd74-4e76-9a92-ca766a4b70d7"), "Ali Riza Efendi St. No:22", 1, new Guid("58a451ed-ae3e-40fe-b118-708c0f9872f4"), "Kesan", "Edirne" },
                    { new Guid("7aff0742-36d6-4630-b1b4-68538ad56d64"), "Seher St. No:16/60", 1, new Guid("611165a4-b4c1-4ce4-aca5-2d70ee35db5a"), "Maltepe", "Istanbul" },
                    { new Guid("c1b4eeb9-dfec-4e38-b0e8-311db9edfec4"), "Lalegul St. No:5", 0, new Guid("46e61ab0-946a-4e6f-901b-9cc4a919c748"), "Kagithane", "Istanbul" },
                    { new Guid("ffab8c77-239f-4d24-ba12-5d9aca99dbb4"), "Yavrukus St. No:19/1", 1, new Guid("46e61ab0-946a-4e6f-901b-9cc4a919c748"), "Sisli", "Istanbul" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerID",
                table: "Addresses",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_AppRoleID",
                table: "AppUsers",
                column: "AppRoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "AppRoles");
        }
    }
}
