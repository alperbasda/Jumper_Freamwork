using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jumper.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntityDefinitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectDeclarationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatabaseType = table.Column<int>(type: "int", nullable: false),
                    IsConstant = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyTypeDeclarations",
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
                    table.PrimaryKey("PK_PropertyTypeDeclarations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntityPropertyDefinitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityDefinitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertyTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasIndex = table.Column<bool>(type: "bit", nullable: false),
                    IsUnique = table.Column<bool>(type: "bit", nullable: false),
                    IsConstant = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityPropertyDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityPropertyDefinitions_EntityDefinitions_EntityDefinitionId",
                        column: x => x.EntityDefinitionId,
                        principalTable: "EntityDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectEntityActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CacheEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LogEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsConstant = table.Column<bool>(type: "bit", nullable: false),
                    EntityAction = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEntityActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectEntityActions_ProjectEntities_ProjectEntityId",
                        column: x => x.ProjectEntityId,
                        principalTable: "ProjectEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectEntityDependencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectDeclarationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DependsOnId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DependedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EntityDependencyType = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEntityDependencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectEntityDependencies_ProjectEntities_DependedId",
                        column: x => x.DependedId,
                        principalTable: "ProjectEntities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectEntityDependencies_ProjectEntities_DependsOnId",
                        column: x => x.DependsOnId,
                        principalTable: "ProjectEntities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectEntityProperties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertyTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasIndex = table.Column<bool>(type: "bit", nullable: false),
                    IsUnique = table.Column<bool>(type: "bit", nullable: false),
                    IsConstant = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEntityProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectEntityProperties_ProjectEntities_ProjectEntityId",
                        column: x => x.ProjectEntityId,
                        principalTable: "ProjectEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectEntityActionProperties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectEntityActionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectEntityPropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionPropertyType = table.Column<int>(type: "int", nullable: false),
                    IsConstant = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEntityActionProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectEntityActionProperties_ProjectEntityActions_ProjectEntityActionId",
                        column: x => x.ProjectEntityActionId,
                        principalTable: "ProjectEntityActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectEntityActionProperties_ProjectEntityProperties_ProjectEntityPropertyId",
                        column: x => x.ProjectEntityPropertyId,
                        principalTable: "ProjectEntityProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntityDefinitions_DeletedTime",
                table: "EntityDefinitions",
                column: "DeletedTime");

            migrationBuilder.CreateIndex(
                name: "IX_EntityDefinitions_UserId",
                table: "EntityDefinitions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityPropertyDefinitions_DeletedTime",
                table: "EntityPropertyDefinitions",
                column: "DeletedTime");

            migrationBuilder.CreateIndex(
                name: "IX_EntityPropertyDefinitions_EntityDefinitionId",
                table: "EntityPropertyDefinitions",
                column: "EntityDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEntities_DeletedTime",
                table: "ProjectEntities",
                column: "DeletedTime");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEntities_ProjectDeclarationId",
                table: "ProjectEntities",
                column: "ProjectDeclarationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEntities_UserId",
                table: "ProjectEntities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEntityActionProperties_DeletedTime",
                table: "ProjectEntityActionProperties",
                column: "DeletedTime");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEntityActionProperties_ProjectEntityActionId",
                table: "ProjectEntityActionProperties",
                column: "ProjectEntityActionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEntityActionProperties_ProjectEntityPropertyId",
                table: "ProjectEntityActionProperties",
                column: "ProjectEntityPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEntityActions_DeletedTime",
                table: "ProjectEntityActions",
                column: "DeletedTime");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEntityActions_ProjectEntityId",
                table: "ProjectEntityActions",
                column: "ProjectEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEntityDependencies_DependedId",
                table: "ProjectEntityDependencies",
                column: "DependedId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEntityDependencies_DependsOnId",
                table: "ProjectEntityDependencies",
                column: "DependsOnId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEntityDependencies_ProjectDeclarationId",
                table: "ProjectEntityDependencies",
                column: "ProjectDeclarationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEntityProperties_DeletedTime",
                table: "ProjectEntityProperties",
                column: "DeletedTime");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEntityProperties_ProjectEntityId",
                table: "ProjectEntityProperties",
                column: "ProjectEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTypeDeclarations_DeletedTime",
                table: "PropertyTypeDeclarations",
                column: "DeletedTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityPropertyDefinitions");

            migrationBuilder.DropTable(
                name: "ProjectEntityActionProperties");

            migrationBuilder.DropTable(
                name: "ProjectEntityDependencies");

            migrationBuilder.DropTable(
                name: "PropertyTypeDeclarations");

            migrationBuilder.DropTable(
                name: "EntityDefinitions");

            migrationBuilder.DropTable(
                name: "ProjectEntityActions");

            migrationBuilder.DropTable(
                name: "ProjectEntityProperties");

            migrationBuilder.DropTable(
                name: "ProjectEntities");
        }
    }
}
