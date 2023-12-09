using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modelo.Analise.Api.Domain;
using Modelo.Analise.Api.Model;
using Modelo.Analise.Api.Repository.Interface;

namespace Modelo.Analise.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class VendaController : ControllerBase
    {
        private readonly IVendaRepository _vendaRepository;
        public VendaController(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }
        [HttpGet(Name = "GetVenda")]
        public async Task<IActionResult> Get()
        {
            List<venda> vendas = await _vendaRepository.GetVendas();

            return Ok(vendas);
        }
        [HttpGet]
        [Route("ObterFaturamentoComparadoMesAnterior")]
        public async Task<IActionResult> ObterFaturamentoComparadoMesAnterior()
        {
            var qtd = await _vendaRepository.ObterFaturamentoDeVendasComparadoMesAnterior();

            return Ok(qtd);
        }
        [HttpGet]
        [Route("ObterTopCincoVendas")]
        public async Task<IActionResult> ObterTopCincoVendas()
        {
            var top = await _vendaRepository.ObterTopCincoVendas();
            var lista = top.Select(venda => new VendaModel()
            {
                NomeClienteCompleto = venda.cliente?.nome_completo != null ? venda.cliente.nome_completo : "Não informado",
                ValorVenda = venda.total_venda
            });


            return Ok(lista.ToList());
        }
        [HttpGet]
        [Route("ObterQtdVendasComparadoMesAnterior")]
        public async Task<IActionResult> ObterQtdVendasComparadoMesAnterior()
        {
            var qtd = await _vendaRepository.ObterQtdDeVendasComparadoMesAnterior();
            return Ok(qtd);
        }
        [HttpGet]
        [Route("ObterFrequenciaVendas")]
        public async Task<IActionResult> ObterFrequenciaVendas(string? filial)
        {
            var dadosFrequencia = await _vendaRepository.ObterDadosGraficoFrequencia(filial);
            return Ok(dadosFrequencia);
        }
    }
}
