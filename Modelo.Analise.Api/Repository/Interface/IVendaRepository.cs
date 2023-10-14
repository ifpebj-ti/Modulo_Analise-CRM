using Modelo.Analise.Api.Domain;
using Modelo.Analise.Api.Model;

namespace Modelo.Analise.Api.Repository.Interface
{
    public interface IVendaRepository
    {
        Task<List<venda>> GetVendas();
        Task<decimal> ObterFaturamentoDeVendasComparadoMesAnterior();
        Task<List<venda>> ObterTopCincoVendas();
        Task<int> ObterQtdDeVendasComparadoMesAnterior();
        Task<List<VendaModel>> ObterDadosGraficoFrequencia();
    }
}
