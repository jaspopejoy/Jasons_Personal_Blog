using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jasons_Personal_Blog.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixedshortdescriptionerror : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "BlogPosts",
                newName: "ShortDescription");

            migrationBuilder.AlterColumn<bool>(
                name: "Visible",
                table: "BlogPosts",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShortDescription",
                table: "BlogPosts",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "Visible",
                table: "BlogPosts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
