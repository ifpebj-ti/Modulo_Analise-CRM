using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Analise.Api.Domain
{
    public class categoria_produto
    {
        [Key]
        public int id_categoria { get; set; }
        public string nome { get; set; }
    }
}
