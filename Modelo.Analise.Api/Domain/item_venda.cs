using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Analise.Api.Domain
{
    public class item_venda
    {
        [Key]
        public int id_item_venda { get; set; }
        public double preco_unitario { get; set; }
        public int quantidade_vendida { get; set; }
        [ForeignKey("id_produto")]
        public virtual produto produto { get; set; }
        [ForeignKey("id_venda")]
        public virtual venda venda { get; set; }

    }
}
