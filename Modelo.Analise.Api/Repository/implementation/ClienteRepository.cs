using Microsoft.EntityFrameworkCore;
using Modelo.Analise.Api.Domain;
using Modelo.Analise.Api.Model;
using Modelo.Analise.Api.Repository.Interface;
using System.Globalization;

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

    }
}
