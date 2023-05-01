using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Minerais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Caracteristica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Minerais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cargueiros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Classe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacidade = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tipo_Mineral = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargueiros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cargueiros_Minerais_Tipo_Mineral",
                        column: x => x.Tipo_Mineral,
                        principalTable: "Minerais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cargueiros_Tipo_Mineral",
                table: "Cargueiros",
                column: "Tipo_Mineral");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cargueiros");

            migrationBuilder.DropTable(
                name: "Minerais");
        }
    }
}
