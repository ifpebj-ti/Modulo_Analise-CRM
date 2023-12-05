using Xunit;

namespace Modelo.Analise.Api.Domain.Tests
{
  public class usuarioTests
  {
    [Fact]
    public void testesGets()
    {
      usuario usuario = new usuario { id_usuario = 1, nome = "nome", nivel_de_acesso = "1", email = "email", celular = "celular", data_nascimento = new System.DateTime(), data_admissao = new System.DateTime(), filial = new filial() };

      // Act & Assert
      Assert.NotNull(usuario.GetType().GetProperty("id_usuario"));
      Assert.NotNull(usuario.GetType().GetProperty("nome"));
      Assert.NotNull(usuario.GetType().GetProperty("nivel_de_acesso"));
      Assert.NotNull(usuario.GetType().GetProperty("email"));
      Assert.NotNull(usuario.GetType().GetProperty("celular"));
      Assert.NotNull(usuario.GetType().GetProperty("data_nascimento"));
      Assert.NotNull(usuario.GetType().GetProperty("data_admissao"));
      Assert.NotNull(usuario.GetType().GetProperty("filial"));
    }
  }
}