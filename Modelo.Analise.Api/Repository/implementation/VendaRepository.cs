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
        public async Task<ResultadoModel> ObterFaturamentoDeVendasComparadoMesAnterior()
        {
            try
            {
                var resultado = new ResultadoModel();
                var MesAnterior = await _context.venda.Where(v => v.data.Month == DateTime.Now.Month - 1).SumAsync(s => s.total_venda);
                var MesAtual = await _context.venda.Where(v => v.data.Month == DateTime.Now.Month).SumAsync(s => s.total_venda);
  
                if (MesAtual != 0 && MesAnterior != 0)
                {
                    var qtdComparado = MesAtual - MesAnterior;
                    decimal porcentagemAumento = ((decimal)qtdComparado / MesAnterior) * 100;


                    resultado.FaturamentoComparado = MesAtual;
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
        public async Task<ResultadoModel> ObterQtdDeVendasComparadoMesAnterior()
        {
            try
            {
                var resultado = new ResultadoModel();
                var MesAnterior = await _context.venda.Where(v => v.data.Month == DateTime.Now.Month - 1).CountAsync();
                var MesAtual = await _context.venda.Where(v => v.data.Month == DateTime.Now.Month).CountAsync();
                if (MesAtual != 0 && MesAnterior != 0)
                {
                    var qtdComparado = MesAtual - MesAnterior;
                    decimal porcentagemAumento = ((decimal)qtdComparado / MesAnterior) * 100;


                    resultado.QuantidadeComparado = MesAtual;
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
        public async Task<List<VendaModel>> ObterDadosGraficoFrequencia(string filial)
        {
            List<VendaModel> dados = new List<VendaModel>();
            dados = await _context.venda
                        .Where(f => (string.IsNullOrEmpty(filial) || filial == "Nenhum selecionado") || f.filial.nome == filial.ToUpper())
                        .GroupBy(c => c.cliente)
                        .Select(g => new VendaModel
                        {
                            NomeClienteCompleto = g.Key.nome_completo != null ? g.Key.nome_completo : "Não informado",
                            FrequenciaVenda = g.Count(),
                            ValorVenda = g.Sum(v => v.total_venda)
                        })
                        .OrderByDescending(g => g.ValorVenda)
                        .ToListAsync();
            //pegar maior velor venda e frequencia

            //var maxValorVenda = dados.Max(d => d.ValorVenda);
            //var maxFrequencia = dados.Max(d => d.FrequenciaVenda);

            //var mediaQuadranteValor = maxValorVenda / 2;
            //var mediaFrequenciaValor = maxFrequencia / 2;
            //List<Dictionary<string, object>> resultado = dados.Select(cliente => new Dictionary<string, object> { { "venda", (decimal)cliente.ValorVenda }, { "frequencia", cliente.FrequenciaVenda } }).ToList();

            //var quadrante1 = dados.Where(d => d.ValorVenda > mediaQuadranteValor && d.FrequenciaVenda > mediaFrequenciaValor).ToList();
            //var quadrante2 = dados.Where(d => d.ValorVenda < mediaQuadranteValor && d.FrequenciaVenda > mediaFrequenciaValor).ToList();
            //var quadrante3 = dados.Where(d => d.ValorVenda < mediaQuadranteValor && d.FrequenciaVenda < mediaFrequenciaValor).ToList();
            //var quadrante4 = dados.Where(d => d.ValorVenda > mediaQuadranteValor && d.FrequenciaVenda < mediaFrequenciaValor).ToList();
            //var resultado = new ResultadoQuadranteModel
            //{
            //    Quadrante1 = quadrante1,
            //    Quadrante2 = quadrante2,
            //    Quadrante3 = quadrante3,
            //    Quadrante4 = quadrante4
            //};
            return dados;
        }
    }
}
