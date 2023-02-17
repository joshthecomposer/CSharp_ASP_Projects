using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingPlanner.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RSVPList_Users_UserId",
                table: "RSVPList");

            migrationBuilder.DropForeignKey(
                name: "FK_RSVPList_Wedding_WeddingId",
                table: "RSVPList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wedding",
                table: "Wedding");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RSVPList",
                table: "RSVPList");

            migrationBuilder.RenameTable(
                name: "Wedding",
                newName: "Weddings");

            migrationBuilder.RenameTable(
                name: "RSVPList",
                newName: "RSVPLists");

            migrationBuilder.RenameIndex(
                name: "IX_RSVPList_WeddingId",
                table: "RSVPLists",
                newName: "IX_RSVPLists_WeddingId");

            migrationBuilder.RenameIndex(
                name: "IX_RSVPList_UserId",
                table: "RSVPLists",
                newName: "IX_RSVPLists_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weddings",
                table: "Weddings",
                column: "WeddingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RSVPLists",
                table: "RSVPLists",
                column: "RSVPListId");

            migrationBuilder.AddForeignKey(
                name: "FK_RSVPLists_Users_UserId",
                table: "RSVPLists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RSVPLists_Weddings_WeddingId",
                table: "RSVPLists",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "WeddingId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RSVPLists_Users_UserId",
                table: "RSVPLists");

            migrationBuilder.DropForeignKey(
                name: "FK_RSVPLists_Weddings_WeddingId",
                table: "RSVPLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weddings",
                table: "Weddings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RSVPLists",
                table: "RSVPLists");

            migrationBuilder.RenameTable(
                name: "Weddings",
                newName: "Wedding");

            migrationBuilder.RenameTable(
                name: "RSVPLists",
                newName: "RSVPList");

            migrationBuilder.RenameIndex(
                name: "IX_RSVPLists_WeddingId",
                table: "RSVPList",
                newName: "IX_RSVPList_WeddingId");

            migrationBuilder.RenameIndex(
                name: "IX_RSVPLists_UserId",
                table: "RSVPList",
                newName: "IX_RSVPList_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wedding",
                table: "Wedding",
                column: "WeddingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RSVPList",
                table: "RSVPList",
                column: "RSVPListId");

            migrationBuilder.AddForeignKey(
                name: "FK_RSVPList_Users_UserId",
                table: "RSVPList",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RSVPList_Wedding_WeddingId",
                table: "RSVPList",
                column: "WeddingId",
                principalTable: "Wedding",
                principalColumn: "WeddingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
