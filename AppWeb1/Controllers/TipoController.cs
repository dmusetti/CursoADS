using AppWeb1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWeb1.Controllers
{
    public class TipoController : Controller
    {

      MySqlConnection conn;
      MySqlDataReader dr;
      string StrConn;
      string StrQuery;

      public ActionResult Index()
        {

         StrConn = "Server=den1.mysql2.gear.host;Port=3306;Database=ads32021;Uid=ads32021;Pwd=Wq0a9fuhf?_A;";

         List<Tipo> lstTipos = new List<Tipo>();
         conn = new MySqlConnection(StrConn);

         StrQuery = "SELECT * FROM tipos order by descricao";
         MySqlCommand comando = new MySqlCommand(StrQuery, conn);
         conn.Open();

         dr = comando.ExecuteReader();

         while (dr.Read())
         {
            Tipo tipo = new Tipo();
            tipo.Id = Convert.ToInt32(dr["id"]);
            tipo.Descricao = Convert.ToString(dr["descricao"]);
            lstTipos.Add(tipo);
         }

         return View(lstTipos);
        }

      public ActionResult SalvarTipo()
      {

         return View();
      }
    }
}