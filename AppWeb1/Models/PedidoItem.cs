using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWeb1.Models
{
   public class PedidoItem
   {
      public int id { get; set; }
      public int idPedido { get; set; }
      public int idProduto { get; set; }
      public string descricao { get; set; }
      public int qtde { get; set; }
      public decimal valor  { get; set; }
      public decimal total { get; set; }
   }
}