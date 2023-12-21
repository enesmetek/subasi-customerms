using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Subasi.CustomerMS.API.Persistance.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false)
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
                table: "Customers",
                columns: new[] { "ID", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "emkafali@gmail.com", "Enes Mete", "Kafali", "553-580-9653" },
                    { 2, "tktaskiran@gmail.com", "Tolga Kagan", "Taskiran", "546-602-3272" },
                    { 3, "temelatanc@gmail.com", "Can", "Temelatan", "533-559-0511" },
                    { 4, "yildirimgul@gmail.com", "Yildirim", "Gul", "545-332-2239" },
                    { 5, "kafali22@gmail.com", "Mustafa", "Kafali", "542-366-6688" },
                    { 6, "mert@outlook.com", "Mert", "Kafali", "546-297-5518" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "ID", "AddressLine", "AddressType", "CustomerID", "District", "Province" },
                values: new object[,]
                {
                    { 1, "Yavrukus St. No:19/1", "Home", 1, "Sisli", "Istanbul" },
                    { 2, "Lalegul St. No:5", "Office", 1, "Kagithane", "Istanbul" },
                    { 3, "Ali Riza Efendi St. No:22", "Home", 2, "Kesan", "Edirne" },
                    { 4, "Seher St. No:16/60", "Home", 6, "Maltepe", "Istanbul" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerID",
                table: "Addresses",
                column: "CustomerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
