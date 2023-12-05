using Xunit;

namespace Modelo.Analise.Api.Domain.Tests
{
  public class CategoriaProdutoTests
  {
    [Fact]
    public void testesGets()
    {
      categoria_produto categoria_produto = new categoria_produto { id_categoria = 1, nome = "Teste" };

      // Act & Assert
      Assert.NotNull(categoria_produto.GetType().GetProperty("id_categoria"));
      Assert.NotNull(categoria_produto.GetType().GetProperty("nome"));
    }
  }
}
