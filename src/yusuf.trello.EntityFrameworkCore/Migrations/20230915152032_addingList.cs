using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace yusuf.trello.Migrations
{
    /// <inheritdoc />
    public partial class addingList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "AppBoards",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "AppBoards",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "Varchar", maxLength: 30, nullable: false),
                    Position = table.Column<int>(type: "Integer", nullable: false),
                    BoardId = table.Column<Guid>(type: "Uuid", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppLists_AppBoards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "AppBoards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppLists_BoardId",
                table: "AppLists",
                column: "BoardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppLists");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "AppBoards");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "AppBoards");
        }
    }
}
