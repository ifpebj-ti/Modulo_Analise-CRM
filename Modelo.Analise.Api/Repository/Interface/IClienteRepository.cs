using Modelo.Analise.Api.Domain;
using Modelo.Analise.Api.Model;

namespace Modelo.Analise.Api.Repository.Interface
{
    public interface IClienteRepository
    {
        Task<List<cliente>> GetCliente();
        Task<ResultadoModel> ObterQuantidadeDeClientesComparadoMesAnterior();
    }
}
