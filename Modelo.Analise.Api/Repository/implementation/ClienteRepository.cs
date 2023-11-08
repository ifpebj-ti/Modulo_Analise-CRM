using Microsoft.EntityFrameworkCore;
using Modelo.Analise.Api.Controllers;
using Modelo.Analise.Api.Domain;
using Modelo.Analise.Api.Model;
using Modelo.Analise.Api.Repository.Interface;
using System.Globalization;

namespace Modelo.Analise.Api.Repository.implementation
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ContextBd _context;
        private readonly ILogger<ClienteRepository> _logger;
        public ClienteRepository(ContextBd context, ILogger<ClienteRepository> logger)
        {
            _context = context;
            _logger = logger;
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
                _logger.LogError("Ocorreu uma exception :",ex.Message);
            }
        }

        public async Task<List<object>> DistribuicaoAnualCliente()
        {
            try
            {
                var dados = await _context.cliente
                    .Where(c => c.data_registro.Value.Year == DateTime.Now.Year)
                    .GroupBy(c => c.data_registro.Value.Month)
                    .Select(group => new ClientesAnual
                    {
                        Mes = group.Key,
                        Quantidade = group.Count()
                    })
                    .OrderBy(item => item.Mes)
                    .ToListAsync();
                var data = new List<object> { new List<object> { "Mes", "Quantidade" } };
                foreach (var item in dados)
                {
                    string nomeMes = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.Mes);
                    data.Add(new List<object> { nomeMes, item.Quantidade });
                }

                return data;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<object>> DistribuicaoPorGenero(string tipo)
        {
            try
            {
                if (tipo.ToUpper() == "GENERO")
                {
                    var dados = await _context.cliente
                    .GroupBy(c => c.sexo)
                    .Select(group => new
                    {
                        Sexo = group.Key,
                        Quantidade = group.Count()
                    })
                    .OrderBy(cliente => cliente.Quantidade)
                    .ToListAsync();
                    var data = new List<object> { new List<object> { "Gênero", "Quantidade" } };
                    foreach (var cliente in dados)
                    {
                        data.Add(new List<object> { cliente.Sexo, cliente.Quantidade });
                    }
                    return data;
                }
                else
                {
                    var dadosIdade = await _context.cliente
                                      .Select(c => new
                                      {
                                          Idade = DateTime.Now.Year - c.data_nascimento.Year
                                      })
                                      .ToListAsync();
                    var faixasEtarias = new List<Tuple<int, int>>
                    {
                        new Tuple<int, int>(10, 20),
                        new Tuple<int, int>(21, 29),
                        new Tuple<int, int>(30, 39),
                        new Tuple<int, int>(40, 49),
                        new Tuple<int, int>(50, 59),
                        new Tuple<int, int>(60, 69),
                        new Tuple<int, int>(70, 79),
                        new Tuple<int, int>(80, 89),
                    };

                    var dadosParaGrafico = new List<object>
                    {
                        new List<object> {"Idade", "Quantidade"}
                    };
                    foreach (var faixa in faixasEtarias)
                    {
                        int quantidade = dadosIdade.Count(c => c.Idade >= faixa.Item1 && c.Idade <= faixa.Item2);
                        if(quantidade > 0)
                        {
                            dadosParaGrafico.Add(new List<object> { $"{faixa.Item1} - {faixa.Item2}", quantidade });
                        }
                        
                    }
                    return dadosParaGrafico;
                }

    
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
                _logger.LogError("Ocorreu uma exception :", ex.Message);
            }
        }

    }
}
