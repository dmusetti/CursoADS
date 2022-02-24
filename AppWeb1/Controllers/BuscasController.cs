using AppWeb1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWeb1.Controllers
{
    public class BuscasController : Controller
    {
        public JsonResult BuscarProduto(int Id)
        {
            using (Conexao conexao = new Conexao())
            {
                var StrQuery = "SELECT * FROM produtos where id = @Id;";
                using (MySqlCommand comando = new MySqlCommand(StrQuery, conexao.conn))
                {
                    comando.Parameters.AddWithValue("Id", Id);

                    MySqlDataReader dr = comando.ExecuteReader();
                    _ = dr.Read();
                    if (dr.HasRows)
                    {
                        Produto produto = new Produto
                        {
                            Id = Convert.ToInt32(dr["id"]),
                            Descricao = Convert.ToString(dr["descricao"]),
                            VrUnitario = Convert.ToDecimal(dr["vrUnitario"])
                        };
                        return new JsonResult { Data = produto, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    }
                }
            }
            return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetModelos(string Tipo)
        {
            using (Conexao conexao = new Conexao())
            {
                var StrQuery = "SELECT Descricao FROM modelos where tipo = '" + Tipo + "' order by descricao;";

                List<Modelo> listModelo = new List<Modelo>();
                using (MySqlCommand comando = new MySqlCommand(StrQuery, conexao.conn))
                {
                    MySqlDataReader dr = comando.ExecuteReader();
                    while (dr.Read())
                    {
                        Modelo modelo = new Modelo
                        {
                            Descricao = Convert.ToString(dr["descricao"])
                        };
                        listModelo.Add(modelo);
                    }
                }
                return new JsonResult { Data = listModelo, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        public List<Tipo> GetTiposProdutos()
        {
            using (Conexao conexao = new Conexao())
            {
                var StrQuery = "SELECT * FROM tipos order by descricao";
                List<Tipo> tiposList = new List<Tipo>();
                using (MySqlCommand comando = new MySqlCommand(StrQuery, conexao.conn))
                {
                    MySqlDataReader dr = comando.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Tipo tipo = new Tipo
                            {
                                Id = Convert.ToInt32(dr["id"]),
                                Descricao = Convert.ToString(dr["descricao"])
                            };
                            tiposList.Add(tipo);
                        }
                    }
                }
                return tiposList;
            }
        }
    }
}