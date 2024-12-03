using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlogNight.DataAccessLayer.Migrations
{
    public partial class mig8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AppUserID",
                table: "Articles",
                column: "AppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_AppUserID",
                table: "Articles",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_AppUserID",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_AppUserID",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Articles");
        }
    }
}
