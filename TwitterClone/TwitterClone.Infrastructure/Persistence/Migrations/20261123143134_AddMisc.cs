using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TwitterClone.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddMisc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("3150d14e-1881-4b28-a637-85b070c77f07"), new DateTime(2026, 11, 23, 14, 31, 34, 6, DateTimeKind.Utc).AddTicks(3436), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "users.delete" },
                    { new Guid("3f4a3310-b7e6-4680-94da-9f37833b4113"), new DateTime(2026, 11, 23, 14, 31, 34, 6, DateTimeKind.Utc).AddTicks(3437), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "roles.manage" },
                    { new Guid("9f073bd3-26f4-45a7-92bc-3acac0bfe715"), new DateTime(2026, 11, 23, 14, 31, 34, 6, DateTimeKind.Utc).AddTicks(3432), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "users.read" }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("0985ea89-e859-421c-ac32-d25ae956464e"), new DateTime(2026, 11, 23, 14, 31, 34, 7, DateTimeKind.Utc).AddTicks(3186), new Guid("00000000-0000-0000-0000-000000000000"), null, null, new Guid("b28c66e9-370b-40c0-8bee-a43fcf5cad10"), new Guid("b9c3c1c2-1fe9-4385-80b8-3602519c70c2") },
                    { new Guid("1401901b-3fe6-4e3f-9854-9c31338de432"), new DateTime(2026, 11, 23, 14, 31, 34, 7, DateTimeKind.Utc).AddTicks(3190), new Guid("00000000-0000-0000-0000-000000000000"), null, null, new Guid("a007cd34-8644-471c-8aaf-0cf221cccdcf"), new Guid("9b0cf57f-f06c-4f38-a64c-626e286ae1e6") },
                    { new Guid("3850ecbd-8ed0-4f76-a437-e566fd5ed490"), new DateTime(2026, 11, 23, 14, 31, 34, 7, DateTimeKind.Utc).AddTicks(3207), new Guid("00000000-0000-0000-0000-000000000000"), null, null, new Guid("084dfdbe-909e-4423-adec-027692690573"), new Guid("aeb89635-4a54-44e1-b0a5-90ddc6b7b469") },
                    { new Guid("9f09f2e7-1255-4c97-8a05-3369f1b6290f"), new DateTime(2026, 11, 23, 14, 31, 34, 7, DateTimeKind.Utc).AddTicks(3210), new Guid("00000000-0000-0000-0000-000000000000"), null, null, new Guid("c4644d27-fa19-4707-af85-16dba948937d"), new Guid("9551b8e4-082b-4c00-9bc6-b0d8a182a9cc") },
                    { new Guid("dbf270d8-faf9-4f66-a180-72f543824190"), new DateTime(2026, 11, 23, 14, 31, 34, 7, DateTimeKind.Utc).AddTicks(3205), new Guid("00000000-0000-0000-0000-000000000000"), null, null, new Guid("7f56f21c-81b1-4706-b947-b4d825552cc2"), new Guid("d6aa296d-cb5f-4c14-be5b-023b04e343ed") }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("784c2c7c-f2a0-4050-b3f7-0b20e21d46e3"), new DateTime(2026, 11, 23, 14, 31, 34, 6, DateTimeKind.Utc).AddTicks(7253), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "Moderator" },
                    { new Guid("b6bbbcd6-0705-4373-bd09-d7df25cca2df"), new DateTime(2026, 11, 23, 14, 31, 34, 6, DateTimeKind.Utc).AddTicks(7254), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "User" },
                    { new Guid("dc85b434-de09-44e5-9ed1-5886e21421ae"), new DateTime(2026, 11, 23, 14, 31, 34, 6, DateTimeKind.Utc).AddTicks(7249), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_Name",
                table: "Permissions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId",
                table: "RolePermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
