using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IdentityServer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiResources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApiSecret = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ApiSecretSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiResources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    LanguageCode = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientSecret = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ClientSecretSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ClientUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoginRedirectUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoutRedirectUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApiResourceScopes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Scope = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiResourceScopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiResourceScopes_ApiResources_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "ApiResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientApiResources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApiResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientApiResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientApiResources_ApiResources_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalTable: "ApiResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientApiResources_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientScopes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Scope = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientScopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientScopes_Clients_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserPasswords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserPasswords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityUserPasswords_IdentityUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "IdentityUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserRefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityUserRefreshTokens_IdentityUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "IdentityUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserScopes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Scope = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserScopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityUserScopes_IdentityUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "IdentityUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentityUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityUserRoles_IdentityUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "IdentityUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentityUserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleScopes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Scope = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleScopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleScopes_Roles_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AuthMessages",
                columns: new[] { "Id", "Code", "CreateTime", "LanguageCode", "Message", "Type", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("1cc4e354-81b7-47da-a2df-40b81f5f2433"), 4, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7708), 0, "Şifreniz En Az 1 Küçük, 1 Büyük, 1 Rakam ve 1 özel karakter içermelidir !!!", 1, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7708) },
                    { new Guid("266d46cf-8f55-4cc3-ac18-f0c1d3143a39"), 4, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7707), 1, "Your password must contain at least 1 lowercase, 1 uppercase, 1 digit and 1 special character. !!!", 1, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7707) },
                    { new Guid("274289fa-fa69-42b3-9aa6-11e875e8bbbb"), 0, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7720), 1, "Data Not Found !!!", 0, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7720) },
                    { new Guid("2c2803e7-78de-4d12-ac53-608ef50d08a0"), 2, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7699), 1, "This Field Is Required !!! This Field Can Not Contains Space !!!", 1, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7699) },
                    { new Guid("2de974f2-2590-4db3-ba40-cbc744e0ac12"), 6, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7711), 1, "Invalid Phone Number !!!", 1, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7712) },
                    { new Guid("3dfc5c58-ba4e-4752-a304-b45d5ee86968"), 2, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7689), 0, "Bu Alan Bosluk Içeremez ve Bos Olamaz !!!", 1, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7697) },
                    { new Guid("4aee96a7-4e02-4baf-a909-49cf144cb83e"), 7, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7724), 1, "Verification Code has been sent !!!", 0, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7725) },
                    { new Guid("616c2e26-e46a-4ac9-85a0-8465b89ed2cc"), 6, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7727), 1, "Old Password Is Incorrect !!!", 0, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7728) },
                    { new Guid("679cb5fe-401d-411b-83b6-ea0fac56fd14"), 1, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7742), 1, "Success !!!", 0, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7742) },
                    { new Guid("735aca87-a458-4b52-a418-59d8ce126119"), 2, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7733), 0, "Sunucu Içi Hata !!!", 0, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7733) },
                    { new Guid("73a16a1d-6bd7-4494-b67e-a5cf0a5c4495"), 0, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7702), 0, "Alan Bos Geçilemez !!!", 1, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7703) },
                    { new Guid("76de7aaf-4cf3-4454-9de5-16f5627af291"), 5, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7739), 1, "Phone Number Already Taken !!!", 0, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7739) },
                    { new Guid("860005b5-3ea8-4821-afee-259a773d1dc8"), 3, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7745), 1, "User Name Already Taken !!!", 0, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7745) },
                    { new Guid("893a19c3-e7d0-421f-b72a-b6c7610f9f3d"), 1, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7743), 0, "Başarılı !!!", 0, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7744) },
                    { new Guid("8c302663-913c-45cf-be1d-40194b51961e"), 0, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7722), 0, "Veri Bulunamadı !!!", 0, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7722) },
                    { new Guid("9224643e-b389-4927-887e-e0722f6771a6"), 4, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7735), 1, "Mail Address Already Taken !!!", 0, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7735) },
                    { new Guid("9e474ddb-7957-4cdc-9a4b-ce808b32db76"), 7, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7726), 0, "Doğrulama Kodu Gönderildi !!!", 0, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7726) },
                    { new Guid("a02d4be9-c4e0-497f-8f23-0be069d6b49b"), 1, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7719), 0, "Bu Alan Bosluk Içeremez !!!", 1, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7719) },
                    { new Guid("a71a167e-bfa4-4852-8d07-74bddeaeff1c"), 3, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7746), 0, "Kullanıcı Adı Daha Onceden Alınmış !!!", 0, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7747) },
                    { new Guid("b2e72eb3-95ff-4ed1-b790-4e5d94c0dabb"), 0, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7701), 1, "This Field Is Required !!!", 1, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7701) },
                    { new Guid("b470d9f3-a9f1-4248-9185-4bbe56f9e63a"), 1, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7717), 1, "This Field Can Not Contains Space !!!", 1, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7718) },
                    { new Guid("bba095bc-9043-493e-97b3-ad89f5c34486"), 3, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7716), 0, "Şifreler Eşleşmiyor !!!", 1, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7716) },
                    { new Guid("d02ad221-a522-4059-907e-0f0992e99c39"), 5, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7704), 1, "Invalid Email !!!", 1, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7704) },
                    { new Guid("e2436d3d-7175-4bcf-ba39-993da27db662"), 5, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7740), 0, "Telefon Numarası Daha Onceden Alınmış !!!", 0, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7740) },
                    { new Guid("e81c0e16-e387-47f3-b2d1-cd4c64fbef6f"), 2, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7731), 1, "Interval Error !!!", 0, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7732) },
                    { new Guid("ea32fd1f-bc5a-46a3-b4e7-ee90c5bd17d3"), 4, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7736), 0, "E-Posta Daha Once Kayıt Edilmiş !!!", 0, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7736) },
                    { new Guid("efe795ad-2373-43f4-9149-afcb40754c6e"), 5, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7705), 0, "Geçersiz E-posta Adresi !!!", 1, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7705) },
                    { new Guid("f4a80a45-6a75-4f10-8ba5-632a55a4cf67"), 3, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7714), 1, "Passwords Are Not Same !!!", 1, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7714) },
                    { new Guid("fc8065d8-ab03-4a64-a547-3090c557b158"), 6, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7713), 0, "Geçersiz Telefon Numarası !!!", 1, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7713) },
                    { new Guid("fd97bdcb-8009-46c8-a42b-06e7c8d161b8"), 6, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7730), 0, "Eski Şifre Hatalı !!!", 0, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7730) }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "ClientId", "ClientSecret", "ClientSecretSalt", "ClientUrl", "CreateTime", "LoginRedirectUrl", "LogoUrl", "LogoutRedirectUrl", "Name", "Status", "UpdateTime" },
                values: new object[] { new Guid("8214773a-de51-49f6-82fa-821f780844f7"), "jumper", new byte[] { 130, 162, 123, 243, 194, 177, 126, 70, 174, 168, 239, 45, 253, 190, 208, 195, 167, 126, 110, 19, 210, 248, 31, 138, 73, 27, 32, 10, 170, 173, 125, 230, 174, 131, 62, 20, 217, 157, 188, 45, 72, 125, 148, 123, 31, 15, 64, 179, 216, 102, 49, 231, 71, 221, 53, 98, 77, 225, 101, 16, 236, 23, 95, 167 }, new byte[] { 22, 246, 197, 30, 41, 39, 61, 34, 211, 151, 157, 214, 224, 118, 83, 135, 152, 220, 47, 124, 82, 61, 92, 215, 106, 64, 92, 178, 149, 143, 130, 154, 62, 97, 246, 3, 237, 96, 70, 189, 212, 116, 170, 78, 35, 61, 240, 163, 238, 89, 119, 2, 148, 38, 48, 142, 171, 50, 86, 127, 221, 73, 44, 96, 31, 31, 177, 94, 28, 92, 159, 37, 233, 33, 23, 148, 162, 19, 141, 207, 9, 55, 134, 90, 18, 119, 9, 116, 12, 156, 91, 0, 180, 172, 196, 82, 127, 83, 180, 211, 130, 158, 80, 72, 246, 136, 65, 44, 102, 170, 135, 172, 43, 180, 163, 59, 154, 45, 229, 200, 118, 104, 221, 157, 244, 206, 22, 30 }, "", new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7998), "/home", "", "/login", "DemoSite", 200, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(7998) });

            migrationBuilder.InsertData(
                table: "IdentityUsers",
                columns: new[] { "Id", "ClientId", "CreateTime", "Email", "Name", "NormalizedEmail", "NormalizedUserName", "PhoneNumber", "Status", "Surname", "UpdateTime", "UserName" },
                values: new object[] { new Guid("763a89cc-c679-4dd4-967e-7509d24ca75a"), "jumper", new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(8060), "admin@admin.com", "Alper", "admin@admin.com", "admin", "5555555555", 200, "Başda", new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(8060), "admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreateTime", "Name", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("34215d8e-1c9b-49f4-8dce-f257185cf989"), new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(8027), "Personnel", new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(8028) },
                    { new Guid("35215d8e-1c9b-49f4-8dce-f257185cf989"), new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(8029), "User", new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(8030) },
                    { new Guid("36215d8e-1c9b-49f4-8dce-f257185cf989"), new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(8026), "Manager", new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(8027) },
                    { new Guid("37215d8e-1c9b-49f4-8dce-f257185cf989"), new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(8028), "Admin", new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(8029) }
                });

            migrationBuilder.InsertData(
                table: "ClientScopes",
                columns: new[] { "Id", "CreateTime", "ExpiredDate", "OwnerId", "Scope", "UpdateTime" },
                values: new object[] { new Guid("85a5e416-3da0-478e-8f69-a69cc5b14bee"), new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(8011), null, new Guid("8214773a-de51-49f6-82fa-821f780844f7"), "site_client_scope", new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(8011) });

            migrationBuilder.InsertData(
                table: "IdentityUserPasswords",
                columns: new[] { "Id", "CreateTime", "OwnerId", "PasswordHash", "PasswordSalt", "UpdateTime" },
                values: new object[] { new Guid("6052badd-7876-48be-9e50-744f8f170359"), new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(8091), new Guid("763a89cc-c679-4dd4-967e-7509d24ca75a"), new byte[] { 219, 184, 223, 88, 64, 57, 202, 105, 40, 165, 197, 163, 161, 104, 58, 254, 29, 128, 184, 150, 76, 75, 86, 164, 132, 186, 213, 89, 213, 100, 82, 191, 20, 69, 123, 174, 79, 171, 39, 227, 101, 167, 94, 116, 101, 193, 219, 180, 189, 106, 176, 33, 35, 245, 152, 25, 121, 1, 74, 60, 100, 180, 207, 130 }, new byte[] { 166, 99, 125, 110, 172, 211, 23, 127, 13, 239, 175, 160, 73, 204, 149, 250, 141, 99, 56, 155, 95, 186, 85, 203, 234, 182, 147, 90, 190, 234, 63, 47, 41, 30, 57, 192, 7, 231, 206, 57, 227, 247, 225, 4, 70, 204, 42, 25, 63, 49, 32, 182, 233, 23, 3, 13, 209, 141, 81, 26, 173, 113, 250, 3, 25, 99, 65, 176, 109, 113, 6, 15, 31, 35, 232, 9, 35, 174, 139, 80, 91, 182, 139, 32, 135, 129, 45, 42, 219, 211, 87, 0, 1, 10, 54, 254, 132, 60, 224, 85, 24, 20, 78, 176, 11, 9, 131, 68, 209, 127, 200, 215, 227, 170, 156, 205, 32, 145, 162, 227, 52, 128, 34, 154, 166, 107, 170, 137 }, new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(8091) });

            migrationBuilder.InsertData(
                table: "IdentityUserRoles",
                columns: new[] { "Id", "CreateTime", "ExpiredDate", "IdentityUserId", "RoleId", "UpdateTime" },
                values: new object[] { new Guid("d22870fd-d13e-499f-b0e1-8a340c832c5c"), new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(8102), null, new Guid("763a89cc-c679-4dd4-967e-7509d24ca75a"), new Guid("37215d8e-1c9b-49f4-8dce-f257185cf989"), new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(8102) });

            migrationBuilder.InsertData(
                table: "RoleScopes",
                columns: new[] { "Id", "CreateTime", "ExpiredDate", "OwnerId", "Scope", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("6aa5971c-b4bc-49b8-81b2-382b5ddae597"), new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(8049), null, new Guid("34215d8e-1c9b-49f4-8dce-f257185cf989"), "personnel_role_scope", new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(8049) },
                    { new Guid("93badf40-ae89-445e-933c-ab496dcffce5"), new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(8041), null, new Guid("37215d8e-1c9b-49f4-8dce-f257185cf989"), "admin_user_scope", new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(8041) },
                    { new Guid("a57d879c-fae1-41c7-bf27-bc80808b0fe0"), new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(8046), null, new Guid("36215d8e-1c9b-49f4-8dce-f257185cf989"), "manager_role_scope", new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(8046) },
                    { new Guid("b44a87d5-4897-4bbf-bc1b-936d7dda35fe"), new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(8044), null, new Guid("35215d8e-1c9b-49f4-8dce-f257185cf989"), "user_role_scope", new DateTime(2023, 9, 27, 19, 28, 17, 755, DateTimeKind.Local).AddTicks(8044) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApiResourceScopes_OwnerId",
                table: "ApiResourceScopes",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientApiResources_ApiResourceId",
                table: "ClientApiResources",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientApiResources_ClientId",
                table: "ClientApiResources",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientScopes_OwnerId",
                table: "ClientScopes",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserPasswords_OwnerId",
                table: "IdentityUserPasswords",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserRefreshTokens_OwnerId",
                table: "IdentityUserRefreshTokens",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserRoles_IdentityUserId",
                table: "IdentityUserRoles",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserRoles_RoleId",
                table: "IdentityUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUsers_ClientId",
                table: "IdentityUsers",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUsers_NormalizedEmail",
                table: "IdentityUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUsers_NormalizedUserName",
                table: "IdentityUsers",
                column: "NormalizedUserName");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserScopes_OwnerId",
                table: "IdentityUserScopes",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleScopes_OwnerId",
                table: "RoleScopes",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiResourceScopes");

            migrationBuilder.DropTable(
                name: "AuthMessages");

            migrationBuilder.DropTable(
                name: "ClientApiResources");

            migrationBuilder.DropTable(
                name: "ClientScopes");

            migrationBuilder.DropTable(
                name: "IdentityUserPasswords");

            migrationBuilder.DropTable(
                name: "IdentityUserRefreshTokens");

            migrationBuilder.DropTable(
                name: "IdentityUserRoles");

            migrationBuilder.DropTable(
                name: "IdentityUserScopes");

            migrationBuilder.DropTable(
                name: "RoleScopes");

            migrationBuilder.DropTable(
                name: "ApiResources");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "IdentityUsers");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
