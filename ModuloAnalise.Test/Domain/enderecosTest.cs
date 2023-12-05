using Xunit;

namespace Modelo.Analise.Api.Domain.Tests
{
  public class enderecosTests
  {
    [Fact]
    public void testesGets()
    {
      enderecos enderecos = new enderecos { id_endereco = 1, pais = "Brasil", estado = "São Paulo", cidade = "São Paulo", bairro = "Vila Mariana", rua = "Rua Vergueiro", numero = "123" };

      // Act & Assert
      Assert.NotNull(enderecos.GetType().GetProperty("id_endereco"));
      Assert.NotNull(enderecos.GetType().GetProperty("pais"));
      Assert.NotNull(enderecos.GetType().GetProperty("estado"));
      Assert.NotNull(enderecos.GetType().GetProperty("cidade"));
      Assert.NotNull(enderecos.GetType().GetProperty("bairro"));
      Assert.NotNull(enderecos.GetType().GetProperty("rua"));
      Assert.NotNull(enderecos.GetType().GetProperty("numero"));
    }
  }
}