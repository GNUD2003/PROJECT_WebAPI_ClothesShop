using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Data.Migrations
{
    /// <inheritdoc />
    public partial class update_v8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "countOfProduct",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "countOfProduct",
                table: "Products");
        }
    }
}
