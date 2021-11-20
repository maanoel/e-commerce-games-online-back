using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class ClienteDTO
    {
        private int userId;
        private String nome;
        private String telefone;
        private DateTime dataNascimento;

        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public DateTime DataNascimento
        {
            get { return dataNascimento; }
            set { dataNascimento = value; }
        }
        public String Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
    }
}
