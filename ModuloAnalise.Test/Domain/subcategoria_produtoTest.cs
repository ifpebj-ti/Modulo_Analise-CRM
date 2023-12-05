using Xunit;

namespace Modelo.Analise.Api.Domain.Tests
{
  public class subcategoria_produtoTests
  {
    [Fact]
    public void testesGets()
    {
      subcategoria_produto subcategoria_produto = new subcategoria_produto { id_subcategoria = 1, nome_subcategoria = "nome_subcategoria" };

      // Act & Assert
      Assert.NotNull(subcategoria_produto.GetType().GetProperty("id_subcategoria"));
      Assert.NotNull(subcategoria_produto.GetType().GetProperty("nome_subcategoria"));
    }
  }
}