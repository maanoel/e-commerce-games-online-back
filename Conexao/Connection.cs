using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Conexao
{
    public class Connection
    {
        /// <summary>
        /// Classe usada para se obter uma conexão com o banco de dados
        /// </summary>
        /// <returns>MySqlConnection</returns>
        public MySqlConnection getConnection()
        {
            MySqlConnection con;
            try
            {
                con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalMySqlServer"].ToString());
            }
            catch (MySqlException e){ 
                throw  e;
            }
            con.Open();
            return con;
        }
    }
}
