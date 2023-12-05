using Xunit;

namespace Modelo.Analise.Api.Domain.Tests
{
  public class produtoTests
  {
    [Fact]
    public void testesGets()
    {
      produto produto = new produto { id_produto = 1, nome = "Produto 1", data_validade = DateTime.Now, fornecedor = "fornecedor", descricao = "descricao", quantidade_estoque = 1, preco_venda = 1.0, categoria_produto = new categoria_produto(), subcategoria_produto = new subcategoria_produto() };

      // Act & Assert
      Assert.NotNull(produto.GetType().GetProperty("id_produto"));
      Assert.NotNull(produto.GetType().GetProperty("nome"));
      Assert.NotNull(produto.GetType().GetProperty("data_validade"));
      Assert.NotNull(produto.GetType().GetProperty("fornecedor"));
      Assert.NotNull(produto.GetType().GetProperty("descricao"));
      Assert.NotNull(produto.GetType().GetProperty("quantidade_estoque"));
      Assert.NotNull(produto.GetType().GetProperty("preco_venda"));
      Assert.NotNull(produto.GetType().GetProperty("categoria_produto"));
      Assert.NotNull(produto.GetType().GetProperty("subcategoria_produto"));
    }
  }
}