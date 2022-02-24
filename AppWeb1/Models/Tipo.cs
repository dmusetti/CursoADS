using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppWeb1.Models
{
   public class Tipo
   {
      public int Id { get; set; }
      [Required]
      public string Descricao { get; set; }
   }
}