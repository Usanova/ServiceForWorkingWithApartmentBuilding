using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceForWorkingWithApartmentBuildingDatabaseMigration.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Announcement",
                columns: table => new
                {
                    AnnouncementId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 64, nullable: true),
                    Content = table.Column<string>(maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcement", x => x.AnnouncementId);
                });

            migrationBuilder.CreateTable(
                name: "ManagementCompany",
                columns: table => new
                {
                    ManagementCompanyId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: true),
                    Info = table.Column<string>(nullable: true),
                    Avatar = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementCompany", x => x.ManagementCompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Meeting",
                columns: table => new
                {
                    MeetingId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: true),
                    OwnerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting", x => x.MeetingId);
                });

            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    BuildingId = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(maxLength: 64, nullable: true),
                    ManagementCompanyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.BuildingId);
                    table.ForeignKey(
                        name: "FK_Building_ManagementCompany_ManagementCompanyId",
                        column: x => x.ManagementCompanyId,
                        principalTable: "ManagementCompany",
                        principalColumn: "ManagementCompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    TenatId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: true),
                    Surname = table.Column<string>(maxLength: 32, nullable: true),
                    Password = table.Column<string>(maxLength: 64, nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    BuildingId = table.Column<Guid>(nullable: false),
                    EntranceNumber = table.Column<int>(nullable: false),
                    FlatNumber = table.Column<int>(nullable: false),
                    Avatar = table.Column<byte[]>(nullable: true),
                    MeetingId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.TenatId);
                    table.ForeignKey(
                        name: "FK_Tenant_Meeting_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meeting",
                        principalColumn: "MeetingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementTenant",
                columns: table => new
                {
                    AnnouncementId = table.Column<Guid>(nullable: false),
                    TenatId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementTenant", x => new { x.TenatId, x.AnnouncementId });
                    table.ForeignKey(
                        name: "FK_AnnouncementTenant_Announcement_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalTable: "Announcement",
                        principalColumn: "AnnouncementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnnouncementTenant_Tenant_TenatId",
                        column: x => x.TenatId,
                        principalTable: "Tenant",
                        principalColumn: "TenatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementTenant_AnnouncementId",
                table: "AnnouncementTenant",
                column: "AnnouncementId");

            migrationBuilder.CreateIndex(
                name: "IX_Building_ManagementCompanyId",
                table: "Building",
                column: "ManagementCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_MeetingId",
                table: "Tenant",
                column: "MeetingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnouncementTenant");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropTable(
                name: "Announcement");

            migrationBuilder.DropTable(
                name: "Tenant");

            migrationBuilder.DropTable(
                name: "ManagementCompany");

            migrationBuilder.DropTable(
                name: "Meeting");
        }
    }
}
