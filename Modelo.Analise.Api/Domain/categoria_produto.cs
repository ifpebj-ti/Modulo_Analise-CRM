using System.ComponentModel.DataAnnotations;

namespace Modelo.Analise.Api.Domain
{
    public class categoria_produto
    {
        [Key]
        public int id_categoria { get; set; }
        public string nome { get; set; }
    }
}
