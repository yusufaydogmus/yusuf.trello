using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace yusuf.trello.Migrations
{
    /// <inheritdoc />
    public partial class addingPositionPropertyToCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "AppCards",
                type: "Integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "AppCards");
        }
    }
}
