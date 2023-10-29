using Microsoft.AspNetCore.Mvc;
using Modelo.Analise.Api.Domain;
using Modelo.Analise.Api.Repository.Interface;
using System.Text.Json.Serialization;
using System.Text.Json;
using Modelo.Analise.Api.Repository.implementation;

namespace Modelo.Analise.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository; 
        }
        [HttpGet(Name = "GetCliente")]
        public async Task<IActionResult> Get()
        {
            List<cliente> clientes = await _clienteRepository.GetCliente();
            
            return Ok(clientes);
        }

        [HttpGet]
        [Route("ObterQtdClientesComparadoMesAnterior")]
        public async Task<IActionResult> ObterQtdClientesComparadoMesAnterior()
        {
            var qtd = await _clienteRepository.ObterQuantidadeDeClientesComparadoMesAnterior();

            return Ok(qtd);
        }
        [HttpGet]
        [Route("ObterQtdClientesAnual")]
        public async Task<IActionResult> ObterQtdClientesAnual()
        {
            var qtd = await _clienteRepository.DistribuicaoAnualCliente();

            return Ok(qtd);
        }
        [HttpGet]
        [Route("ObterClientesPorGeneroIdade")]
        public async Task<IActionResult> ObterClientesPorGeneroIdade(string tipo)
        {
            var qtd = await _clienteRepository.DistribuicaoPorGenero(tipo);

            return Ok(qtd);
        }
    }
}
