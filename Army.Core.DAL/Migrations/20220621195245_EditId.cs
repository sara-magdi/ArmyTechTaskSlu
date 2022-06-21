using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Army.Core.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EditId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardProductId",
                table: "CartProducts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CardProductId",
                table: "CartProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
