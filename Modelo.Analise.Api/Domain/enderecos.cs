using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Analise.Api.Domain
{
    public class enderecos
    {
        [Key]
        public int id_endereco { get; set; }
        public string pais { get; set; }
        public string estado { get; set; }
        public string cidade { get; set; }
        public string bairro { get; set; }
        public string rua { get; set; }
        public string numero { get; set; }
        //public virtual List<cliente> clientes { get; set; }


    }
}