using Microsoft.EntityFrameworkCore;
using Modelo.Analise.Api.Domain;
using Modelo.Analise.Api.Model;
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
        public async Task<decimal> ObterFaturamentoDeVendasComparadoMesAnterior()
        {
            try
            {
                var MesAnterior = await _context.venda.Where(v => v.data.Month == DateTime.Now.Month - 1).SumAsync(s => s.total_venda);
                var MesAtual = await _context.venda.Where(v => v.data.Month == DateTime.Now.Month).SumAsync(s => s.total_venda);
                var qtdComparado = MesAtual - MesAnterior;
                return qtdComparado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<venda>> ObterTopCincoVendas()
        {
            var top = await _context.venda
                       .Where(v => v.data.Month == DateTime.Now.Month)
                       .GroupBy(c => c.cliente)
                       .Select(g => new venda
                       {
                           cliente = g.Key,
                           total_venda = g.Sum(v => v.total_venda)
                       })
                       .OrderByDescending(g => g.total_venda)
                       .Take(5)
                       .ToListAsync();



            return top;
        }
        public async Task<int> ObterQtdDeVendasComparadoMesAnterior()
        {
            try
            {
                var MesAnterior = await _context.venda.Where(v => v.data.Month == DateTime.Now.Month - 1).CountAsync();
                var MesAtual = await _context.venda.Where(v => v.data.Month == DateTime.Now.Month).CountAsync();
                var qtdComparado = MesAtual - MesAnterior;
                return qtdComparado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<List<VendaModel>> ObterDadosGraficoFrequencia()
        {
            var dados = await _context.venda
                        .GroupBy(c => c.cliente)
                        .Select(g => new VendaModel
                        {
                            NomeClienteCompleto = g.Key.nome_completo != null ? g.Key.nome_completo : "Não informado",
                            FrequenciaVenda = g.Count(),
                            ValorVenda = g.Sum(v => v.total_venda)
                        })
                        .OrderByDescending(g => g.ValorVenda)
                        .ToListAsync();
            return dados;
        }
    }
}
