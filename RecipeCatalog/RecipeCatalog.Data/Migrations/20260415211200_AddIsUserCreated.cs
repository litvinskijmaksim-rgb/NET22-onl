using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeCatalog.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIsUserCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUserCreated",
                table: "Recipes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUserCreated",
                table: "Recipes");
        }
    }
}
