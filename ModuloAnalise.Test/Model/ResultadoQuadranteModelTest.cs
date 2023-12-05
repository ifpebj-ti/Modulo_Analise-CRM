using System;
using System.Collections.Generic;
using Xunit;

namespace Modelo.Analise.Api.Model.Tests
{
  public class ResultadoQuadranteModelTests
  {
    [Fact]
    public void Constructor_InitializesLists()
    {
      // Arrange & Act
      ResultadoQuadranteModel resultadoQuadranteModel = new ResultadoQuadranteModel
      {
        Quadrante1 = new List<VendaModel>(),
        Quadrante2 = new List<VendaModel>(),
        Quadrante3 = new List<VendaModel>(),
        Quadrante4 = new List<VendaModel>()
      };

      // Assert
      Assert.NotNull(resultadoQuadranteModel.Quadrante1);
      Assert.NotNull(resultadoQuadranteModel.Quadrante2);
      Assert.NotNull(resultadoQuadranteModel.Quadrante3);
      Assert.NotNull(resultadoQuadranteModel.Quadrante4);
    }

    [Fact]
    public void QuadranteProperties_AreNotNull()
    {
      // Arrange
      ResultadoQuadranteModel resultadoQuadranteModel = new ResultadoQuadranteModel
      {
        Quadrante1 = new List<VendaModel>(),
        Quadrante2 = new List<VendaModel>(),
        Quadrante3 = new List<VendaModel>(),
        Quadrante4 = new List<VendaModel>()
      };

      // Assert
      Assert.NotNull(resultadoQuadranteModel.Quadrante1);
      Assert.NotNull(resultadoQuadranteModel.Quadrante2);
      Assert.NotNull(resultadoQuadranteModel.Quadrante3);
      Assert.NotNull(resultadoQuadranteModel.Quadrante4);
    }

    [Fact]
    public void QuadranteProperties_CanBeModified()
    {
      // Arrange
      var resultadoQuadranteModel = new ResultadoQuadranteModel();

      // Act
      resultadoQuadranteModel.Quadrante1 = new List<VendaModel> { new VendaModel() };

      // Assert
      Assert.Single(resultadoQuadranteModel.Quadrante1);
    }
  }
}
