using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Analise.Api.Domain
{
    public class subcategoria_produto
    {
        [Key]
        public int id_subcategoria { get; set; }
        public string nome_subcategoria { get; set; }
    }
}
