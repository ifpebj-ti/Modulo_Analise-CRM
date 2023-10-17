using Microsoft.EntityFrameworkCore;
using Modelo.Analise.Api.Domain;
using Modelo.Analise.Api.Model;
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

        public async Task<ResultadoModel> ObterQuantidadeDeClientesComparadoMesAnterior()
        {
            try
            {
                var resultado = new ResultadoModel();
                var MesAnterior = await _context.cliente.Where(c => c.data_registro.Value.Month == DateTime.Now.Month - 1).CountAsync();

                var MesAtual = await _context.cliente.Where(c => c.data_registro.Value.Month == DateTime.Now.Month).CountAsync();
                if (MesAtual != 0 && MesAnterior != 0)
                {
                    var qtdComparado = MesAtual - MesAnterior;
                    decimal porcentagemAumento = ((decimal)qtdComparado / MesAnterior) * 100;


                    resultado.QuantidadeComparado = qtdComparado;
                    resultado.PorcentagemAumento = Math.Round(porcentagemAumento, 2);
                    
                    return resultado;
                }
                else
                {
                    resultado.QuantidadeComparado = 0;
                    resultado.PorcentagemAumento = 0;
                    return resultado;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
