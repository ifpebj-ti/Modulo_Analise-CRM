using Microsoft.EntityFrameworkCore;
using Modelo.Analise.Api.Domain;
using Modelo.Analise.Api.Repository.Interface;

namespace Modelo.Analise.Api.Repository.implementation
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ContextBd _context;

        public ProdutoRepository(ContextBd context)
        {
            _context = context;
        }
        public async Task<List<produto>> GetProdutos()
        {
            List<produto> produtos = await _context.produto.ToListAsync();
            return produtos;
        }
    }
}
