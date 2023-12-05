using Modelo.Analise.Api.Model;
using Xunit;

namespace Modelo.Analise.Api.Tests
{
  public class ClientesAnualTests
  {
    [Fact]
    public void ClientesAnual_CriaInstancia_Corretamente()
    {
      // Arrange
      int mes = 1;
      int quantidade = 10;

      // Act
      var clientesAnual = new ClientesAnual { Mes = mes, Quantidade = quantidade };

      // Assert
      Assert.NotNull(clientesAnual);
      Assert.Equal(mes, clientesAnual.Mes);
      Assert.Equal(quantidade, clientesAnual.Quantidade);
    }

    [Fact]
    public void ClientesAnual_DevePermitirAtualizarValores()
    {
      // Arrange
      var clientesAnual = new ClientesAnual
      {
        Mes = 7,
        Quantidade = 20
      };

      // Act
      clientesAnual.Mes = 8;
      clientesAnual.Quantidade = 30;

      // Assert
      Assert.Equal(8, clientesAnual.Mes);
      Assert.Equal(30, clientesAnual.Quantidade);
    }
  }
}