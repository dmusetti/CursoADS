using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWeb1.Models
{
   public class Pedido
   {
      public int id { get; set; }
      public int idCliente { get; set; }
      public string nomeCliente { get; set; }
   }
}