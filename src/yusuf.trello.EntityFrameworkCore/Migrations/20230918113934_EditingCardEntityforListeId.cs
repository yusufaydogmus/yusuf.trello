using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace yusuf.trello.Migrations
{
    /// <inheritdoc />
    public partial class EditingCardEntityforListeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ListId",
                table: "AppCards");

            migrationBuilder.AlterColumn<Guid>(
                name: "ListeId",
                table: "AppCards",
                type: "Uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ListeId",
                table: "AppCards",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "Uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "ListId",
                table: "AppCards",
                type: "Uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
