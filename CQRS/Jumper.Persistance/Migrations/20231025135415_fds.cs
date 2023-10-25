using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jumper.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class fds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsShowOnRelation",
                table: "ProjectEntityProperties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "ProjectEntityProperties",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShowOnRelation",
                table: "ProjectEntityProperties");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "ProjectEntityProperties");
        }
    }
}
