using Modelo.Analise.Api.Domain;

namespace Modelo.Analise.Api.Repository.Interface
{
    public interface IClienteRepository
    {
        Task<List<cliente>> GetCliente();
    }
}
