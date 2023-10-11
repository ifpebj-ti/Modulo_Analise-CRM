using Modelo.Analise.Api.Domain;

namespace Modelo.Analise.Api.Repository.Interface
{
    public interface IVendaRepository
    {
        Task<List<venda>> GetVendas();
        Task<decimal> ObterQuantidadeDeVendasComparadoMesAnterior();
        Task<List<venda>> ObterTopCincoVendas();
    }
}
