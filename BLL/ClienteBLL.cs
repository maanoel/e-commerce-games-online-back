using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using DAO;
using MySql.Data.MySqlClient;

namespace BLL
{
    public class ClienteBLL
    {
        public void inserirCliente(ClienteDTO clienteDTO)
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            try
            {
                clienteDAO.inserirCliente(clienteDTO);
            }
            catch (Exception)
            {
                throw new BancoDeDadosException();
            }
        }

        public ClienteDTO buscarCliente(int userId)
        {

            ClienteDAO clienteDAO = new ClienteDAO();
            try
            {
                ClienteDTO clienteDTO = clienteDAO.buscarCliente(userId);
                return clienteDTO;
            }
            catch (Exception)
            {
                throw new BancoDeDadosException();
            }
        }

        public void alterarCliente(ClienteDTO clienteDTO)
        {

            ClienteDAO clienteDAO = new ClienteDAO();
            try
            {
                clienteDAO.alterarCliente(clienteDTO);

            }
            catch (Exception)
            {
                throw new BancoDeDadosException();
            }
        }
    }
}
