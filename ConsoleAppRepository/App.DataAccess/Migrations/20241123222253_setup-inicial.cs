using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class setupinicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AUTOR",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    NOME = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUTOR", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EDITORA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    NOME = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDITORA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LIVRO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    TITULO = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ANO_PUBLICACAO = table.Column<int>(type: "INTEGER", nullable: false),
                    AUTOR_ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    EDITORA_ID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LIVRO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LIVRO_AUTOR_AUTOR_ID",
                        column: x => x.AUTOR_ID,
                        principalTable: "AUTOR",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_LIVRO_EDITORA_EDITORA_ID",
                        column: x => x.EDITORA_ID,
                        principalTable: "EDITORA",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LIVRO_AUTOR_ID",
                table: "LIVRO",
                column: "AUTOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LIVRO_EDITORA_ID",
                table: "LIVRO",
                column: "EDITORA_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LIVRO");

            migrationBuilder.DropTable(
                name: "AUTOR");

            migrationBuilder.DropTable(
                name: "EDITORA");
        }
    }
}
