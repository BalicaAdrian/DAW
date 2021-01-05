using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class FinalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "ModelsRelations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "ModelsRelations",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ModelsRelations",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ModelsRelations",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ModelsRelations");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "ModelsRelations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ModelsRelations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ModelsRelations");
        }
    }
}
