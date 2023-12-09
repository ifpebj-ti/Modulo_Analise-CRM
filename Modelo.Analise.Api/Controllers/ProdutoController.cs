using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modelo.Analise.Api.Domain;
using Modelo.Analise.Api.Repository.Interface;

namespace Modelo.Analise.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        [HttpGet(Name = "GetProduto")]
        public async Task<IActionResult> Get()
        {
            List<produto> produtos = await _produtoRepository.GetProdutos();

            return Ok(produtos);
        }
    }
}
