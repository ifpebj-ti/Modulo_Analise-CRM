using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Modelo.Analise.Api.Controllers;
using Modelo.Analise.Api.Domain;
using Modelo.Analise.Api.Repository.Interface;
using Moq;
using Xunit;

namespace Modelo.Analise.Api.Tests.Controllers
{
  public class ProdutoControllerIntegrationTests
  {
    [Fact]
    public async Task Get_ReturnsOkResultWithProdutos()
    {
      // Arrange
      var produtoRepositoryMock = new Mock<IProdutoRepository>();
      var expectedProdutos = new List<produto> { /* your test data here */ };
      produtoRepositoryMock.Setup(repo => repo.GetProdutos()).ReturnsAsync(expectedProdutos);
      var controller = new ProdutoController(produtoRepositoryMock.Object);

      // Act
      var result = await controller.Get();

      // Assert
      var okResult = Assert.IsType<OkObjectResult>(result);
      var resultProdutos = Assert.IsType<List<produto>>(okResult.Value);
      Assert.Equal(expectedProdutos, resultProdutos);
    }
  }
}
