using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldAPI.Migrations
{
    /// <inheritdoc />
    public partial class stateUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Population",
                table: "states",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Population",
                table: "states");
        }
    }
}
