using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Modelo.Analise.Api.Controllers;
using Modelo.Analise.Api.Domain;
using Modelo.Analise.Api.Model;
using Modelo.Analise.Api.Repository.Interface;
using Moq;
using Xunit;

namespace Modelo.Analise.Api.Tests
{
  public class ClienteControllerIntegrationTests
  {
    [Fact]
    public async Task Get_ReturnsOkResultWithClientes()
    {
      // Arrange
      var clienteRepositoryMock = new Mock<IClienteRepository>();
      var loggerMock = new Mock<ILogger<ClienteController>>();
      var expectedClientes = new List<cliente> { /* your test data here */ };
      clienteRepositoryMock.Setup(repo => repo.GetCliente()).ReturnsAsync(expectedClientes);
      var controller = new ClienteController(clienteRepositoryMock.Object, loggerMock.Object);

      // Act
      var result = await controller.Get();

      // Assert
      var okResult = Assert.IsType<OkObjectResult>(result);
      var resultClientes = Assert.IsType<List<cliente>>(okResult.Value);
      Assert.Equal(expectedClientes, resultClientes);
    }

    // Add similar tests for other actions (ObterQtdClientesComparadoMesAnterior, ObterQtdClientesAnual, ObterClientesPorGeneroIdade)
    // ...

    // Sample test for ObterQtdClientesComparadoMesAnterior
    [Fact]
    public async Task ObterQtdClientesComparadoMesAnterior_ReturnsOkResultWithQuantity()
    {
      // Arrange
      var clienteRepositoryMock = new Mock<IClienteRepository>();
      var loggerMock = new Mock<ILogger<ClienteController>>();
      var expectedResult = new ResultadoModel { QuantidadeComparado = 10 }; // or whatever your ResultadoModel looks like
      clienteRepositoryMock.Setup(repo => repo.ObterQuantidadeDeClientesComparadoMesAnterior()).ReturnsAsync(expectedResult);
      var controller = new ClienteController(clienteRepositoryMock.Object, loggerMock.Object);

      // Act
      var result = await controller.ObterQtdClientesComparadoMesAnterior();

      // Assert
      var okResult = Assert.IsType<OkObjectResult>(result);
      var resultModel = Assert.IsType<ResultadoModel>(okResult.Value);
      Assert.Equal(expectedResult.QuantidadeComparado, resultModel.QuantidadeComparado);
    }

  }
}
