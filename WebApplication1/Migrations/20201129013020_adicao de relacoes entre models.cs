using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class adicaoderelacoesentremodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuadrinhoIdQuadrinho",
                table: "Compra",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusCompraIdStatus",
                table: "Compra",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compra_QuadrinhoIdQuadrinho",
                table: "Compra",
                column: "QuadrinhoIdQuadrinho");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_StatusCompraIdStatus",
                table: "Compra",
                column: "StatusCompraIdStatus");

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Quadrinho_QuadrinhoIdQuadrinho",
                table: "Compra",
                column: "QuadrinhoIdQuadrinho",
                principalTable: "Quadrinho",
                principalColumn: "IdQuadrinho",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_StatusCompra_StatusCompraIdStatus",
                table: "Compra",
                column: "StatusCompraIdStatus",
                principalTable: "StatusCompra",
                principalColumn: "IdStatus",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Quadrinho_QuadrinhoIdQuadrinho",
                table: "Compra");

            migrationBuilder.DropForeignKey(
                name: "FK_Compra_StatusCompra_StatusCompraIdStatus",
                table: "Compra");

            migrationBuilder.DropIndex(
                name: "IX_Compra_QuadrinhoIdQuadrinho",
                table: "Compra");

            migrationBuilder.DropIndex(
                name: "IX_Compra_StatusCompraIdStatus",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "QuadrinhoIdQuadrinho",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "StatusCompraIdStatus",
                table: "Compra");
        }
    }
}
