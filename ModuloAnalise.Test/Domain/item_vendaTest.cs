using Xunit;

namespace Modelo.Analise.Api.Domain.Tests
{
  public class item_vendaTests
  {
    [Fact]
    public void testesGets()
    {
      item_venda item_venda = new item_venda { id_item_venda = 1, preco_unitario = 1, quantidade_vendida = 1, produto = new produto(), venda = new venda() };

      // Act & Assert
      Assert.NotNull(item_venda.GetType().GetProperty("id_item_venda"));
      Assert.NotNull(item_venda.GetType().GetProperty("preco_unitario"));
      Assert.NotNull(item_venda.GetType().GetProperty("quantidade_vendida"));
      Assert.NotNull(item_venda.GetType().GetProperty("produto"));
      Assert.NotNull(item_venda.GetType().GetProperty("venda"));
    }
  }
}