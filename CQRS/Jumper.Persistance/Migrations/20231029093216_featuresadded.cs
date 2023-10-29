using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jumper.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class featuresadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntityFeatureDefinitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Template = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Namespace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityFeatureDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntityPropertyFeatureDefinitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Template = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Namespace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityPropertyFeatureDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntityFeatureDefinitionProjectEntityRelations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityFeatureDefinitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityFeatureDefinitionProjectEntityRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityFeatureDefinitionProjectEntityRelations_EntityFeatureDefinitions_EntityFeatureDefinitionId",
                        column: x => x.EntityFeatureDefinitionId,
                        principalTable: "EntityFeatureDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityFeatureDefinitionProjectEntityRelations_ProjectEntities_ProjectEntityId",
                        column: x => x.ProjectEntityId,
                        principalTable: "ProjectEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityPropertyFeatureDefinitionProjectEntityPropertyRelations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityPropertyFeatureDefinitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectEntityPropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityPropertyFeatureDefinitionProjectEntityPropertyRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityPropertyFeatureDefinitionProjectEntityPropertyRelations_EntityPropertyFeatureDefinitions_EntityPropertyFeatureDefiniti~",
                        column: x => x.EntityPropertyFeatureDefinitionId,
                        principalTable: "EntityPropertyFeatureDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityPropertyFeatureDefinitionProjectEntityPropertyRelations_ProjectEntityProperties_ProjectEntityPropertyId",
                        column: x => x.ProjectEntityPropertyId,
                        principalTable: "ProjectEntityProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntityFeatureDefinitionProjectEntityRelations_EntityFeatureDefinitionId",
                table: "EntityFeatureDefinitionProjectEntityRelations",
                column: "EntityFeatureDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFeatureDefinitionProjectEntityRelations_ProjectEntityId",
                table: "EntityFeatureDefinitionProjectEntityRelations",
                column: "ProjectEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityPropertyFeatureDefinitionProjectEntityPropertyRelations_EntityPropertyFeatureDefinitionId",
                table: "EntityPropertyFeatureDefinitionProjectEntityPropertyRelations",
                column: "EntityPropertyFeatureDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityPropertyFeatureDefinitionProjectEntityPropertyRelations_ProjectEntityPropertyId",
                table: "EntityPropertyFeatureDefinitionProjectEntityPropertyRelations",
                column: "ProjectEntityPropertyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityFeatureDefinitionProjectEntityRelations");

            migrationBuilder.DropTable(
                name: "EntityPropertyFeatureDefinitionProjectEntityPropertyRelations");

            migrationBuilder.DropTable(
                name: "EntityFeatureDefinitions");

            migrationBuilder.DropTable(
                name: "EntityPropertyFeatureDefinitions");
        }
    }
}
