using Microsoft.AspNetCore.Mvc;
using Modelo.Analise.Api.Domain;
using Modelo.Analise.Api.Repository.Interface;

namespace Modelo.Analise.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        [Route("ObterQtdComparadoMesAnterior")]
        public async Task<IActionResult> ObterQtdVendasComparadoMesAnterior()
        {
            int qtd = await _vendaRepository.ObterQuantidadeDeVendasComparadoMesAnterior();

            return Ok(qtd);
        }
        [HttpGet]
        [Route("ObterTopCincoVendas")]
        public async Task<IActionResult> ObterTopCincoVendas()
        {
            var top = await _vendaRepository.ObterTopCincoVendas();

            return Ok(top);
        }
    }
}
