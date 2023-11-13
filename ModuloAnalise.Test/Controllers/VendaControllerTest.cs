using Microsoft.AspNetCore.Mvc;
using Modelo.Analise.Api.Controllers;
using Modelo.Analise.Api.Domain;
using Modelo.Analise.Api.Model;
using Modelo.Analise.Api.Repository.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloAnalise.Test.Controllers
{
    public class VendaControllerTest
    {
        [Fact]
        public async Task GetVendaObterFaturamentoComparadoMesAnteriorTest()
        {
            // Arrange
            var vendaRepositoryMock = new Mock<IVendaRepository>();
            var tes = new ResultadoModel();
            //tes.FaturamentoComparado = 0;
            //tes.PorcentagemAumento = 0;
            //tes.QuantidadeComparado = 0;
            vendaRepositoryMock.Setup(repo => repo.ObterFaturamentoDeVendasComparadoMesAnterior())
                .ReturnsAsync(tes); // Substitua o valor de retorno pelo valor esperado.

            var controller = new VendaController(vendaRepositoryMock.Object);

            // Act
            var result = await controller.ObterFaturamentoComparadoMesAnterior() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode); // Verifique se o status code é Ok (200).
            
            Assert.Equal(tes, result.Value);

        }
        [Fact]
        public async Task ObterTopCincoVendasTest()
        {
            // Arrange
            var vendaRepositoryMock = new Mock<IVendaRepository>();
            List<venda> tes = new List<venda>();
            vendaRepositoryMock.Setup(repo => repo.ObterTopCincoVendas())
                .ReturnsAsync(tes); // Substitua o valor de retorno pelo valor esperado.

            var controller = new VendaController(vendaRepositoryMock.Object);

            // Act
            var result = await controller.ObterTopCincoVendas() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode); // Verifique se o status code é Ok (200).

            Assert.Equal(tes, result.Value);

        }
    }

}
