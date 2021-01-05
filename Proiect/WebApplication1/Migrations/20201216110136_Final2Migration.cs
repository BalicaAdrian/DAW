using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class Final2Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ModelsRelations",
                table: "ModelsRelations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModelsRelations",
                table: "ModelsRelations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ModelsRelations_ChannelId",
                table: "ModelsRelations",
                column: "ChannelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ModelsRelations",
                table: "ModelsRelations");

            migrationBuilder.DropIndex(
                name: "IX_ModelsRelations_ChannelId",
                table: "ModelsRelations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModelsRelations",
                table: "ModelsRelations",
                columns: new[] { "ChannelId", "SubscriptionId" });
        }
    }
}
