using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Analise.Api.Domain
{
    public class filial
    {
        [Key]
        public int id_filial { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string celular { get; set; }
        public string telefone_fixo { get; set; }
        public string cnpj { get; set; }
        [ForeignKey("id_endereco")]
        public virtual enderecos enderecos { get; set; }
    }
}
