using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using Conexao;
using MySql.Data.MySqlClient;

namespace DAO
{
    public class ClienteDAO
    {
        public void inserirCliente(ClienteDTO cliente)
        {
            //Pegando os dados do cliente.
            String nome = cliente.Nome, telefone = cliente.Telefone;
            int userId = cliente.UserId;
            try
            {
                DateTime dataNascimento = cliente.DataNascimento;
            }
            catch (Exception)
            {
                throw new BancoDeDadosException();
            }

            MySqlConnection con = null;

            try
            {
                con = new Connection().getConnection();
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "INSERT INTO cliente(cli_user_id, cli_data_nascimento, cli_nome, cli_telefone) VALUES(@userId, @dataNascimento, @nome, @telefone)";

                List<MySqlParameter> listaDosParamestros = new List<MySqlParameter>();
                listaDosParamestros.Add(new MySqlParameter() { ParameterName = "@userId", Value = cliente.UserId });

                listaDosParamestros.Add(new MySqlParameter() { ParameterName = "@dataNascimento", Value = cliente.DataNascimento });
                listaDosParamestros.Add(new MySqlParameter() { ParameterName = "@nome", Value = cliente.Nome });
                listaDosParamestros.Add(new MySqlParameter() { ParameterName = "@telefone", Value = cliente.Telefone });

                //Passando os parametros para o comando.
                foreach (MySqlParameter parametro in listaDosParamestros)
                {
                    comando.Parameters.Add(parametro);
                }

                //Definindo a conexão que será usada
                comando.Connection = con;
                //Executando a Query
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new BancoDeDadosException();

            }
            finally
            {
                try
                {
                    con.Close();
                }
                catch (Exception)
                {
                    throw new BancoDeDadosException();
                }
            }
        }

        public ClienteDTO buscarCliente(int userId)
        {
            MySqlConnection con = null;
            MySqlDataReader dr = null;
            try
            {
                con = new Connection().getConnection();
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = con;
                comando.CommandText = "SELECT cli_data_nascimento, cli_nome,cli_telefone FROM cliente WHERE cli_user_id = @userId";
                comando.Parameters.Add(new MySqlParameter { ParameterName = "@userId", Value = userId });

                dr = comando.ExecuteReader();
                bool existe = dr.HasRows;

                if (existe)
                {
                    dr.Read();
                    String dataNascimento = dr["cli_data_nascimento"].ToString();
                    String nome = dr["cli_nome"].ToString();
                    String telefone = dr["cli_telefone"].ToString();

                    ClienteDTO clienteDTO = new ClienteDTO()
                    {
                        DataNascimento = Convert.ToDateTime(dataNascimento),
                        Nome = nome,
                        Telefone = telefone

                    };
                    return clienteDTO;
                }
                else
                {
                    throw new BancoDeDadosException();
                }

            }
            catch (Exception)
            {
                throw new BancoDeDadosException();
            }
            finally
            {
                con.Close();
                dr.Close();
            }
        }
        public void alterarCliente(ClienteDTO cliente)
        {
            String nome = cliente.Nome, telefone = cliente.Telefone;
            DateTime dataNascimento = cliente.DataNascimento;
            int userId = cliente.UserId;

            MySqlConnection con = null;
            try
            {
                con = new Connection().getConnection();
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "UPDATE cliente set cli_data_nascimento = @dataNascimento, cli_nome = @nome, cli_telefone = @telefone WHERE cli_user_id = @userId";

                List<MySqlParameter> listaDosParamestros = new List<MySqlParameter>();
                listaDosParamestros.Add(new MySqlParameter() { ParameterName = "@userId", Value = cliente.UserId });

                listaDosParamestros.Add(new MySqlParameter() { ParameterName = "@dataNascimento", Value = cliente.DataNascimento });
                listaDosParamestros.Add(new MySqlParameter() { ParameterName = "@nome", Value = cliente.Nome });
                listaDosParamestros.Add(new MySqlParameter() { ParameterName = "@telefone", Value = cliente.Telefone });

                foreach (MySqlParameter parametro in listaDosParamestros)
                {
                    comando.Parameters.Add(parametro);
                }

                comando.Connection = con;
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new BancoDeDadosException();

            }
            finally
            {
                try
                {
                    con.Close();
                }
                catch (Exception)
                {
                    throw new BancoDeDadosException();
                }
            }
        }
    }
}
