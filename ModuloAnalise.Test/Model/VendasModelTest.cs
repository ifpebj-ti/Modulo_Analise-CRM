using Xunit;

namespace Modelo.Analise.Api.Model.Tests
{
  public class VendaModelTests
  {
    [Fact]
    public void VendaModel_PropertiesInitializedCorrectly()
    {
      // Arrange
      var vendaModel = new VendaModel();

      // Act & Assert
      Assert.Null(vendaModel.NomeClienteCompleto);
      Assert.Equal(0, vendaModel.ValorVenda);
      Assert.Equal(0, vendaModel.FrequenciaVenda);
    }

    [Fact]
    public void VendaModel_SetProperties()
    {
      // Arrange
      var vendaModel = new VendaModel();

      // Act
      vendaModel.NomeClienteCompleto = "John Doe";
      vendaModel.ValorVenda = 100.50M;
      vendaModel.FrequenciaVenda = 5;

      // Assert
      Assert.Equal("John Doe", vendaModel.NomeClienteCompleto);
      Assert.Equal(100.50M, vendaModel.ValorVenda);
      Assert.Equal(5, vendaModel.FrequenciaVenda);
    }
  }
}
