using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Analise.Api.Domain
{
    public class usuario
    {
        [Key]
        public int  id_usuario{ get; set; }
        public string nome { get; set; }
        public string nivel_de_acesso  { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string celular { get; set; }
        public DateTime data_nascimento { get; set; }
        public DateTime data_admissao { get; set; }
        [ForeignKey("id_filial")]
        public virtual filial filial { get; set; }

    }
}
