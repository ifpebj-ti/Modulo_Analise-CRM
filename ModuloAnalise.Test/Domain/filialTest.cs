using Xunit;

namespace Modelo.Analise.Api.Domain.Tests
{
  public class filialTests
  {
    [Fact]
    public void testesGets()
    {
      filial filial = new filial { id_filial = 1, nome = "Filial 1", email = "email", celular = "celular", telefone_fixo = "telefone_fixo", cnpj = "cnpj" };

      // Act & Assert
      Assert.NotNull(filial.GetType().GetProperty("id_filial"));
      Assert.NotNull(filial.GetType().GetProperty("nome"));
      Assert.NotNull(filial.GetType().GetProperty("email"));
      Assert.NotNull(filial.GetType().GetProperty("celular"));
      Assert.NotNull(filial.GetType().GetProperty("telefone_fixo"));
      Assert.NotNull(filial.GetType().GetProperty("cnpj"));
    }
  }
}