using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Analise.Api.Domain
{
    public class produto_em_promocao
    {
        [Key]
        public int id_produto_em_promocao { get; set; }
        public double desconto { get; set; }
        [ForeignKey("id_produto")]
        public virtual produto produto { get; set; }



    }
}
