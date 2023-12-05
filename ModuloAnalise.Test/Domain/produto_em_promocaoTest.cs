using Xunit;

namespace Modelo.Analise.Api.Domain.Tests
{
  public class produto_em_promocaoTests
  {
    [Fact]
    public void testesGets()
    {
      produto_em_promocao produto_em_promocao = new produto_em_promocao { id_produto_em_promocao = 1, desconto = 1.0, produto = new produto() };

      // Act & Assert
      Assert.NotNull(produto_em_promocao.GetType().GetProperty("id_produto_em_promocao"));
      Assert.NotNull(produto_em_promocao.GetType().GetProperty("desconto"));
      Assert.NotNull(produto_em_promocao.GetType().GetProperty("produto"));
    }
  }
}