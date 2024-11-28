using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Data.Migrations
{
    /// <inheritdoc />
    public partial class update_v9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "img_product",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "img_product",
                table: "Products");
        }
    }
}
