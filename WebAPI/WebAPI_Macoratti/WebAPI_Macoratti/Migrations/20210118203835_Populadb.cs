using Microsoft.EntityFrameworkCore.Migrations;

namespace APICatalogo.Migrations
{
    public partial class Populadb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Categorias
            migrationBuilder.Sql("Insert into Categorias(Nome, ImagemUrl) values('Bebidas', " +
                "'http://www.macorati.net/imagens/1.jpg')");
            migrationBuilder.Sql("Insert into Categorias(Nome, ImagemUrl) values('Lanches', " +
                "'http://www.macorati.net/imagens/2.jpg')");
            migrationBuilder.Sql("Insert into Categorias(Nome, ImagemUrl) values('Sobremesas', " +
                "'http://www.macorati.net/imagens/3.jpg')");

            //Produtos
            migrationBuilder.Sql("Insert into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) values ('Coca-Cola Diet', 'Refrigerante de Cola 350ml', 5.45, " +
                "'http://www.macorati.net/Imagens/coca.jpg', 50, now(), (Select CategoriaId from Categorias where Nome = 'Bebidas'))");
            migrationBuilder.Sql("Insert into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) values ('Lanche de Atum', 'Lanche de Atum com maionese', 8.50, " +
                "'http://www.macorati.net/Imagens/atum.jpg', 10, now(), (Select CategoriaId from Categorias where Nome = 'Lanches'))");
            migrationBuilder.Sql("Insert into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) values ('Pudim 100g', 'Pudim de leite condensado 100g', 6.75, " +
                "'http://www.macorati.net/Imagens/pudim.jpg', 20, now(), (Select CategoriaId from Categorias where Nome = 'Sobremesas'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Categorias");
            migrationBuilder.Sql("Delete from Produtos");
        }
    }
}
