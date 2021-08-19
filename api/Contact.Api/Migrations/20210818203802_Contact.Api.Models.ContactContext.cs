using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Contact.Api.Migrations
{
    public partial class ContactApiModelsContactContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "DateOfBirth", "Email", "FirstName", "LastName" },
                values: new object[] { 1L, new DateTime(1979, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "pradeep@gmail.com", "Pradeep", "Dhawan" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "DateOfBirth", "Email", "FirstName", "LastName" },
                values: new object[] { 2L, new DateTime(1981, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "shilpi@gmail.com", "Shilpi", "Vohra" });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Email",
                table: "Contacts",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}