using AppWeb1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWeb1.Controllers
{
    public class LoginController : Controller
    {

      MySqlDataReader dr;
      string StrQuery;

      public ActionResult Index()
      {
         return View();
      }

      [HttpPost]
      public ActionResult Logar(Usuario usuario)
      {
         using (Conexao conexao = new Conexao())
         {
            StrQuery = "SELECT * FROM Usuarios where username = @NomeUsuario and userpass = @SenhaUsuario;";
            using (MySqlCommand comando = new MySqlCommand(StrQuery, conexao.conn))
            {
               comando.Parameters.AddWithValue("@NomeUsuario", usuario.UserName);
               comando.Parameters.AddWithValue("@SenhaUsuario", usuario.UserPass);

               dr = comando.ExecuteReader();

               if (dr.HasRows)
               {
                  ViewBag.UsuarioLogado ="Djalma";
                  Session.Add("Logado", usuario.UserName);
                  return Redirect("/Home/Index");
               }
               ViewBag.ErroLogin = "Usuario ou senha inválidos";
               return View("Index");

            }
         }

      }

   }
}