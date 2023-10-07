using Microsoft.EntityFrameworkCore;
using Modelo.Analise.Api.Domain;
using Modelo.Analise.Api.Repository.Interface;

namespace Modelo.Analise.Api.Repository.implementation
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ContextBd _context;
        public ClienteRepository(ContextBd context)
        {
            _context = context;
        }
        public async Task<List<cliente>> GetCliente()
        {
            List<cliente> clientes = await _context.cliente
                .ToListAsync();

            return clientes;
        }

        public async Task<int> ObterQuantidadeDeClientesComparadoMesAnterior()
        {
            try
            {
                var MesAnterior = await _context.cliente.Where(c => c.data_registro.Month == DateTime.Now.Month - 1).CountAsync();

                var MesAtual = await _context.cliente.Where(c => c.data_registro.Month == DateTime.Now.Month).CountAsync();
              
                var qtdComparado = MesAtual - MesAnterior;
                return qtdComparado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
