using Modelo.Analise.Api.Domain;

namespace Modelo.Analise.Api.Repository.Interface
{
    public interface IProdutoRepository
    {
        Task<List<produto>> GetProdutos();
    }
}
