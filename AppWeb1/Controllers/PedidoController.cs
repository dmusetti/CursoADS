using AppWeb1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWeb1.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido

        BuscasController buscas = new BuscasController();

        public ActionResult Index()
        {
            buscas.BuscarProduto(1);
            return View();
        }

        public ActionResult Pedido()
        {

            return View();

        }


        public JsonResult SalvarPedido(int? Id, string NomeCliente)
        {
            int ultimoId;
            using (Conexao conexao = new Conexao())
            {
                var StrQuery = "INSERT INTO pedidos(idCliente, nomeCliente) " +
                   "values (@idCliente, @nomeCliente)";

                MySqlCommand comando = new MySqlCommand(StrQuery, conexao.conn);

                comando.Parameters.AddWithValue("@idCliente", Id);
                comando.Parameters.AddWithValue("@nomeCliente", NomeCliente.ToUpper());
                comando.ExecuteNonQuery();

                try
                {
                    if (comando.LastInsertedId != 0) comando.Parameters.Add(new MySqlParameter("ultimoId", comando.LastInsertedId));
                    ultimoId = Convert.ToInt32(comando.Parameters["@ultimoId"].Value);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return new JsonResult { Data = ultimoId, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}