using MySql.Data.MySqlClient;
using System;

namespace AppWeb1.Models
{
   public class Conexao : IDisposable
   {
      public MySqlConnection conn;
      private readonly string host = "localhost";
      private readonly string port = "3307";
      private readonly string db = "loja";
      private readonly string user = "djalma";
      private readonly string pass = "djalma";

      public Conexao()
      {
         Conectar();
      }

      private void Conectar()
      {
         string StrConn = "";
         StrConn = "Server=" + host + ";Port=" + port + ";Database=" + db + ";Uid=" + user + ";Pwd=" + pass + ";";
         conn = new MySqlConnection(StrConn);
         try
         {
            conn.Open();
         }
         catch (Exception)
         {
            throw;
         }
      }

      public void Dispose()
      {
         conn.Close();
         conn.Dispose();
      }

      public void FecharConexao()
      {
         conn.Close();
         conn.Dispose();
      }

   }
}