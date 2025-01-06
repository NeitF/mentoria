using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Core.Migrations
{
    /// <inheritdoc />
    public partial class setupinicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    NOME = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Editora",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    NOME = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editora", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
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
                    table.PrimaryKey("PK_Livro", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Livro_Autor_AUTOR_ID",
                        column: x => x.AUTOR_ID,
                        principalTable: "Autor",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Livro_Editora_EDITORA_ID",
                        column: x => x.EDITORA_ID,
                        principalTable: "Editora",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livro_AUTOR_ID",
                table: "Livro",
                column: "AUTOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_EDITORA_ID",
                table: "Livro",
                column: "EDITORA_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livro");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Editora");
        }
    }
}
