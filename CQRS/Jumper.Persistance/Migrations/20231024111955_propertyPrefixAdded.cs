using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jumper.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class propertyPrefixAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Prefix",
                table: "ProjectEntityProperties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prefix",
                table: "ProjectEntityProperties");
        }
    }
}
