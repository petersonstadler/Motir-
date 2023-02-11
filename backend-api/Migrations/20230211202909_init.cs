using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backendapi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patrocinadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    Resposta = table.Column<string>(type: "TEXT", nullable: false),
                    FormaDeContato = table.Column<string>(type: "TEXT", nullable: false),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    Observacoes = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Responsavel = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patrocinadores", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Patrocinadores",
                columns: new[] { "Id", "FormaDeContato", "Nome", "Observacoes", "Responsavel", "Resposta", "Status", "Valor" },
                values: new object[] { 1, "Pessoalmente", "Peterson", "Teste", "Peter", "Sim", "Pendente", 100m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patrocinadores");
        }
    }
}
