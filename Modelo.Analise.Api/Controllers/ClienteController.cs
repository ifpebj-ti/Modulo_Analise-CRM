using Microsoft.AspNetCore.Mvc;
using Modelo.Analise.Api.Domain;
using Modelo.Analise.Api.Repository.Interface;
using System.Text.Json.Serialization;
using System.Text.Json;

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


    }
}
