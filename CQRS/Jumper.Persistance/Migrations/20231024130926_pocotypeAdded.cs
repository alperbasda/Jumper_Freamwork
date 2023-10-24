using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jumper.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class pocotypeAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PropertyPocoType",
                table: "ProjectEntityProperties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PropertyPocoType",
                table: "EntityPropertyDefinitions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropertyPocoType",
                table: "ProjectEntityProperties");

            migrationBuilder.DropColumn(
                name: "PropertyPocoType",
                table: "EntityPropertyDefinitions");
        }
    }
}
