using Xunit;

namespace Modelo.Analise.Api.Model.Tests
{
    public class ResultadoModelTests
    {
        [Fact]
        public void ResultadoModel_PropertiesInitializedCorrectly()
        {
            // Arrange
            var resultadoModel = new ResultadoModel();

            // Act & Assert
            Assert.Equal(0, resultadoModel.QuantidadeComparado);
            Assert.Equal(0M, resultadoModel.FaturamentoComparado);
            Assert.Equal(0M, resultadoModel.PorcentagemAumento);
        }

        [Fact]
        public void ResultadoModel_SetProperties()
        {
            // Arrange
            var resultadoModel = new ResultadoModel();

            // Act
            resultadoModel.QuantidadeComparado = 100;
            resultadoModel.FaturamentoComparado = 500.75M;
            resultadoModel.PorcentagemAumento = 10.5M;

            // Assert
            Assert.Equal(100, resultadoModel.QuantidadeComparado);
            Assert.Equal(500.75M, resultadoModel.FaturamentoComparado);
            Assert.Equal(10.5M, resultadoModel.PorcentagemAumento);
        }
    }
}
