using Microsoft.EntityFrameworkCore;
using Modelo.Analise.Api.Domain;
using Modelo.Analise.Api.Repository.Interface;

namespace Modelo.Analise.Api.Repository.implementation
{
    public class VendaRepository : IVendaRepository
    {
        private readonly ContextBd _context;
        public VendaRepository(ContextBd context)
        {
            _context = context;
        }
        public async Task<List<venda>> GetVendas()
        {
            List<venda> vendas = await _context.venda.Take(100)
                .ToListAsync();
            return vendas;
        }
        public async Task<int> ObterQuantidadeDeVendasComparadoMesAnterior()
        {
            try
            {
                var MesAnterior = await _context.venda.Where(v => v.data.Month == DateTime.Now.Month - 1).ToListAsync();
                var qtdMesAnterior = MesAnterior.Sum(s => s.total_venda);
                var MesAtual = await _context.venda.Where(v => v.data.Month == DateTime.Now.Month).ToListAsync();
                var qtdMesAtual = MesAtual.Sum(s => s.total_venda);
                var qtdComparado = qtdMesAtual - qtdMesAnterior;
                return qtdComparado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
