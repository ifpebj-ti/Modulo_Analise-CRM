using Castle.Components.DictionaryAdapter;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace Modelo.Analise.Api.Domain
{
    public class cliente
    {

        [Key]
        public int id_cliente { get; set; }
        public string cpf { get; set; }
        public string nome_completo { get; set; }
        public DateTime data_nascimento { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public char sexo { get; set; }
        public Nullable<System.DateTime> data_registro { get; set; }
        [ForeignKey("id_endereco")]
        public  virtual enderecos enderecos { get; set; }

    }
}
