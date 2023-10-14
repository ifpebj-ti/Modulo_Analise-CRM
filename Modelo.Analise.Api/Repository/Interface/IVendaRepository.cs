using Modelo.Analise.Api.Domain;

namespace Modelo.Analise.Api.Repository.Interface
{
    public interface IVendaRepository
    {
        Task<List<venda>> GetVendas();
        Task<decimal> ObterFaturamentoDeVendasComparadoMesAnterior();
        Task<List<venda>> ObterTopCincoVendas();
        Task<int> ObterQtdDeVendasComparadoMesAnterior();
    }
}
