using Xunit;

namespace Modelo.Analise.Api.Domain.Tests
{
  public class vendaTests
  {
    [Fact]
    public void testesGets()
    {
      venda venda = new venda { id_venda = 1, nome_vendedor = "nome_vendedor", data = DateTime.Now, forma_de_pagamento = "forma_de_pagamento", total_venda = 10, cliente = new cliente(), filial = new filial() };

      // Act & Assert
      Assert.NotNull(venda.GetType().GetProperty("id_venda"));
      Assert.NotNull(venda.GetType().GetProperty("nome_vendedor"));
      Assert.NotNull(venda.GetType().GetProperty("data"));
      Assert.NotNull(venda.GetType().GetProperty("forma_de_pagamento"));
      Assert.NotNull(venda.GetType().GetProperty("total_venda"));
      Assert.NotNull(venda.GetType().GetProperty("cliente"));
      Assert.NotNull(venda.GetType().GetProperty("filial"));
    }
  }
}