using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_one.Migrations
{
    /// <inheritdoc />
    public partial class v22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "number",
                table: "Customer",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Customer",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Customer",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "adress",
                table: "Customer",
                newName: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Customer",
                newName: "number");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Customer",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Customer",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Customer",
                newName: "adress");
        }
    }
}
