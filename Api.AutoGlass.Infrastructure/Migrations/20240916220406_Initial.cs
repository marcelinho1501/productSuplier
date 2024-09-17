using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.AutoGlass.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    cd_produto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ds_produto = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    tp_situacao = table.Column<int>(type: "integer", nullable: false),
                    dt_fabricacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    dt_validade = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    cd_fornecedor = table.Column<int>(type: "integer", nullable: true),
                    ds_fornecedor = table.Column<string>(type: "text", nullable: true),
                    ds_cnpj = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.cd_produto);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product");
        }
    }
}
