using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetMVC.Migrations
{
    /// <inheritdoc />
    public partial class UpdateContactProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ativo",
                table: "Contacts",
                newName: "Active");

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Contacts",
                newName: "Ativo");
        }
    }
}
