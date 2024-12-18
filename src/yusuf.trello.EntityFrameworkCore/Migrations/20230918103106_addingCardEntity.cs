using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace yusuf.trello.Migrations
{
    /// <inheritdoc />
    public partial class addingCardEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "Varchar", maxLength: 30, nullable: false),
                    ListId = table.Column<Guid>(type: "Uuid", nullable: false),
                    ListeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "Varchar", maxLength: 300, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppCards_AppLists_ListeId",
                        column: x => x.ListeId,
                        principalTable: "AppLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppCards_ListeId",
                table: "AppCards",
                column: "ListeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppCards");
        }
    }
}
