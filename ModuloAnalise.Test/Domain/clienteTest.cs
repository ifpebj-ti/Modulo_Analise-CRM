using Xunit;

namespace Modelo.Analise.Api.Domain.Tests
{
  public class clienteTests
  {
    [Fact]
    public void testesGets()
    {
      cliente cliente = new cliente { id_cliente = 1, cpf = "12345678901", nome_completo = "Teste", data_nascimento = DateTime.Now, telefone = "12345678901", email = "email", sexo = 'M', data_registro = DateTime.Now, enderecos = new enderecos() };

      // Act & Assert
      Assert.NotNull(cliente.GetType().GetProperty("id_cliente"));
      Assert.NotNull(cliente.GetType().GetProperty("cpf"));
      Assert.NotNull(cliente.GetType().GetProperty("nome_completo"));
      Assert.NotNull(cliente.GetType().GetProperty("data_nascimento"));
      Assert.NotNull(cliente.GetType().GetProperty("telefone"));
      Assert.NotNull(cliente.GetType().GetProperty("email"));
      Assert.NotNull(cliente.GetType().GetProperty("sexo"));
      Assert.NotNull(cliente.GetType().GetProperty("data_registro"));
      Assert.NotNull(cliente.GetType().GetProperty("enderecos"));
    }
  }
}