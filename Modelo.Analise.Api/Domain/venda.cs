using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Analise.Api.Domain
{
    public class venda
    {
        [Key]
        public int id_venda { get; set; }
        public string nome_vendedor { get; set; }
        public DateTime data { get; set; }
        public string forma_de_pagamento { get; set; }
        public int total_venda { get; set; }

        [ForeignKey("id_filial")]
        public virtual filial filial { get; set; }
    }
}
