using AppWeb1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWeb1.Controllers
{
   public class ProdutoController : Controller
   {
        // GET: Produto
        BuscasController buscas = new BuscasController();
      public ActionResult Index()
      {
         ViewBag.ListaTipos =  buscas.GetTiposProdutos();
         return View();
      }


   }
}