using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceForWorkingWithApartmentBuildingDatabaseMigration.Migrations
{
    public partial class Correct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeetId",
                table: "Tenant");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Poll",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "ManagementCompany",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeetId",
                table: "Building",
                maxLength: 64,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Poll");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "ManagementCompany");

            migrationBuilder.DropColumn(
                name: "MeetId",
                table: "Building");

            migrationBuilder.AddColumn<string>(
                name: "MeetId",
                table: "Tenant",
                type: "character varying(64)",
                maxLength: 64,
                nullable: true);
        }
    }
}
