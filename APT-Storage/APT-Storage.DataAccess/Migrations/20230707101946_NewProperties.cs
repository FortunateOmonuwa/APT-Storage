using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APT_Storage.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NewProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FolderPath",
                table: "Folders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Folders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Folders_UserId",
                table: "Folders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_Users_UserId",
                table: "Folders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folders_Users_UserId",
                table: "Folders");

            migrationBuilder.DropIndex(
                name: "IX_Folders_UserId",
                table: "Folders");

            migrationBuilder.DropColumn(
                name: "FolderPath",
                table: "Folders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Folders");
        }
    }
}
