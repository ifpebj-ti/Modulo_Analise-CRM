using Castle.Components.DictionaryAdapter;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace Modelo.Analise.Api.Domain
{
    public class produto
    {
        [Key]
        public int id_produto { get; set; }
        public string nome { get; set; }
        public DateTime data_validade { get; set; }
        public string fornecedor { get; set; }
        public string descricao { get; set; }
        public int quantidade_estoque { get; set; }
        public double preco_venda { get; set; }
        [ForeignKey("id_categoria")]
        public virtual categoria_produto categoria_produto { get; set; }
        [ForeignKey("id_subcategoria")]
        public virtual subcategoria_produto? subcategoria_produto { get; set; }




    }
}
