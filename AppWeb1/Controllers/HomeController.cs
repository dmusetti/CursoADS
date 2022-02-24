using AppWeb1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWeb1.Controllers
{
   public class HomeController : Controller
   {
      MySqlDataReader dr;
      string StrQuery;


      // GET: Home
      public ActionResult Index()
      {
         if (Session["Logado"] == null)
         {
            return RedirectToAction("Index", "Login");
         }

         using (Conexao conexao = new Conexao())
         {
            StrQuery = "SELECT * FROM Produtos where exibirInicio = 1 order by descricao limit 3";
            using (MySqlCommand comando = new MySqlCommand(StrQuery, conexao.conn))
            {
               using (dr = comando.ExecuteReader())
               {
                  List<Produto> lstProdutos = new List<Produto>();
                  while (dr.Read())
                  {
                     Produto produto = new Produto
                     {
                        Id = Convert.ToInt32(dr["id"]),
                        Descricao = Convert.ToString(dr["descricao"]),
                        MsgPromo = Convert.ToString(dr["msgPromo"])
                     };
                     lstProdutos.Add(produto);
                  }
                  return View(lstProdutos);
               }

            }
         }
      }

     

      public ActionResult NovoProduto()
      {

         Conexao conexao = new Conexao();

         StrQuery = "SELECT * FROM Tipos order by descricao";
         MySqlCommand comando = new MySqlCommand(StrQuery, conexao.conn);
         dr = comando.ExecuteReader();

         List<Tipo> lstTipos = new List<Tipo>();

         while (dr.Read())

         {
            Tipo tipo = new Tipo
            {
               Id = Convert.ToInt32(dr["id"]),
               Descricao = Convert.ToString(dr["descricao"])
            };
            lstTipos.Add(tipo);
         }

         dr.Close();

         StrQuery = "SELECT * FROM unidades order by descricao";
         MySqlCommand comando2 = new MySqlCommand(StrQuery, conexao.conn);
         dr = comando2.ExecuteReader();

         List<Unidade> lstUnidades = new List<Unidade>();
         while (dr.Read())

         {
            Unidade unidade = new Unidade
            {
               Id = Convert.ToInt32(dr["id"]),
               Descricao = Convert.ToString(dr["descricao"])
            };
            lstUnidades.Add(unidade);
         }
         conexao.FecharConexao();

         ViewBag.TipoLista = lstTipos.ToList();
         ViewBag.UnidadesLista = lstUnidades.ToList();

         return View();
      }

      public ActionResult SalvarProduto(Produto produto)
      {

         if (ModelState.IsValid)
         {

            using (Conexao conexao = new Conexao())
            {
               var StrQuery = "INSERT INTO produtos(descricao, unidade, tipo, qtde) values (@Descricao, @Unidade, @Tipo, @Qtde)";
               MySqlCommand comando = new MySqlCommand(StrQuery, conexao.conn);
               comando.Parameters.AddWithValue("@Descricao", produto.Descricao);
               comando.Parameters.AddWithValue("@Unidade", produto.Unidade);
               comando.Parameters.AddWithValue("@Tipo", produto.Tipo);
               comando.Parameters.AddWithValue("@Qtde", produto.Qtde);

               comando.ExecuteNonQuery();
               return RedirectToAction("Index");
            }

         }
         return View(produto);
      }
   }
}