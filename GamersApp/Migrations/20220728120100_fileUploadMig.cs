using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamersApp.Migrations
{
    public partial class fileUploadMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "File",
                table: "Profiles",
                newName: "ProfilePictureURI");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfilePictureURI",
                table: "Profiles",
                newName: "File");
        }
    }
}
