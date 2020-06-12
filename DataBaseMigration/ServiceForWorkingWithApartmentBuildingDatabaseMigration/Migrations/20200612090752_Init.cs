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
                    Content = table.Column<string>(maxLength: 1024, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
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
                name: "Poll",
                columns: table => new
                {
                    PollId = table.Column<Guid>(nullable: false),
                    Question = table.Column<string>(maxLength: 64, nullable: true),
                    OwnerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poll", x => x.PollId);
                });

            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    TenantId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: true),
                    Surname = table.Column<string>(maxLength: 32, nullable: true),
                    Password = table.Column<string>(maxLength: 64, nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    BuildingId = table.Column<Guid>(nullable: false),
                    EntranceNumber = table.Column<int>(nullable: false),
                    FlatNumber = table.Column<int>(nullable: false),
                    Avatar = table.Column<byte[]>(nullable: true),
                    MeetId = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.TenantId);
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
                name: "AnswerOption",
                columns: table => new
                {
                    AnswerOptionId = table.Column<Guid>(nullable: false),
                    PollId = table.Column<Guid>(nullable: false),
                    Answer = table.Column<string>(nullable: true),
                    VotersNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerOption", x => x.AnswerOptionId);
                    table.ForeignKey(
                        name: "FK_AnswerOption_Poll_PollId",
                        column: x => x.PollId,
                        principalTable: "Poll",
                        principalColumn: "PollId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementTenant",
                columns: table => new
                {
                    AnnouncementTenantId = table.Column<Guid>(nullable: false),
                    AnnouncementId = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementTenant", x => x.AnnouncementTenantId);
                    table.ForeignKey(
                        name: "FK_AnnouncementTenant_Announcement_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalTable: "Announcement",
                        principalColumn: "AnnouncementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnnouncementTenant_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "TenantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PollTenant",
                columns: table => new
                {
                    PollTenantId = table.Column<Guid>(nullable: false),
                    PollId = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollTenant", x => x.PollTenantId);
                    table.ForeignKey(
                        name: "FK_PollTenant_Poll_PollId",
                        column: x => x.PollId,
                        principalTable: "Poll",
                        principalColumn: "PollId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PollTenant_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "TenantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementTenant_AnnouncementId",
                table: "AnnouncementTenant",
                column: "AnnouncementId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementTenant_TenantId",
                table: "AnnouncementTenant",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerOption_PollId",
                table: "AnswerOption",
                column: "PollId");

            migrationBuilder.CreateIndex(
                name: "IX_Building_ManagementCompanyId",
                table: "Building",
                column: "ManagementCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PollTenant_PollId",
                table: "PollTenant",
                column: "PollId");

            migrationBuilder.CreateIndex(
                name: "IX_PollTenant_TenantId",
                table: "PollTenant",
                column: "TenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnouncementTenant");

            migrationBuilder.DropTable(
                name: "AnswerOption");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropTable(
                name: "Meeting");

            migrationBuilder.DropTable(
                name: "PollTenant");

            migrationBuilder.DropTable(
                name: "Announcement");

            migrationBuilder.DropTable(
                name: "ManagementCompany");

            migrationBuilder.DropTable(
                name: "Poll");

            migrationBuilder.DropTable(
                name: "Tenant");
        }
    }
}
