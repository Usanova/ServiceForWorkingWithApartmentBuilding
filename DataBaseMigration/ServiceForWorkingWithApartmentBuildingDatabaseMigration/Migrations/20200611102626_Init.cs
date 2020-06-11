using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceForWorkingWithApartmentBuildingDatabaseMigration.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManagementCompany",
                columns: table => new
                {
                    ManagementCompanyId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementCompany", x => x.ManagementCompanyId);
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
                    Avatar = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.TenatId);
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

            migrationBuilder.CreateIndex(
                name: "IX_Building_ManagementCompanyId",
                table: "Building",
                column: "ManagementCompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropTable(
                name: "Tenant");

            migrationBuilder.DropTable(
                name: "ManagementCompany");
        }
    }
}
