using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jumper.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ınputTypesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropertyPocoType",
                table: "ProjectEntityProperties");

            migrationBuilder.DropColumn(
                name: "PropertyPocoType",
                table: "EntityPropertyDefinitions");

            migrationBuilder.AddColumn<string>(
                name: "PropertyInputTypeCode",
                table: "ProjectEntityProperties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PropertyInputTypeCode",
                table: "EntityPropertyDefinitions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PropertyInputTypeDeclarations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyInputTypeDeclarations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyInputTypeDeclarations_DeletedTime",
                table: "PropertyInputTypeDeclarations",
                column: "DeletedTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyInputTypeDeclarations");

            migrationBuilder.DropColumn(
                name: "PropertyInputTypeCode",
                table: "ProjectEntityProperties");

            migrationBuilder.DropColumn(
                name: "PropertyInputTypeCode",
                table: "EntityPropertyDefinitions");

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
    }
}
