using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppWeb1.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        public int? Qtde { get; set; }
        [Required]
        [MaxLength(20)]
        public string Tipo { get; set; }
        public decimal VrUnitario { get; set; }
        public string Unidade { get; set; }
        public string MsgPromo { get; set; }
        public string Modelo { get; set; }
    }
}