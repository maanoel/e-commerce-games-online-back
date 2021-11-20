using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class VendaRagarok
    {
        /// <summary>
        /// Verifica se a quantidade é maior do que o valor mínimo de compra.
        /// </summary>
        /// <param name="servidor"></param>
        /// <param name="quantidade"></param>
        /// <returns></returns>
        public bool checarValorMaximo(String servidor, int quantidade)
        {
            if (servidor.Equals("Asgard") && quantidade > 300)
            {
                return false;
            }
            else if ((servidor.Equals("Thor") || servidor.Equals("Odin")) && quantidade > 4000) {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Calculo o valor da compra para o servidor Asgard.
        /// </summary>
        /// <param name="quantidade"></param>
        /// <returns>decimal valor</returns>
        public decimal calcularPrecoAsgard(int quantidade)
        {
            return quantidade * (decimal)10.00;
        }

        /// <summary>
        /// Calculo o valor da compra para o servidor Thor.
        /// </summary>
        /// <param name="quantidade"></param>
        /// <returns>decimal valor</returns>

        public decimal calcularPrecoThor(int quantidade)
        {
            decimal valorDoKk= 0 ;
            if (quantidade >= 1 && quantidade <= 99)
            {
                valorDoKk = (decimal) 0.59;
            }
            else if (quantidade >= 100 && quantidade <= 499)
            {
                valorDoKk = (decimal)0.58;
            }
            else if (quantidade >= 500 && quantidade <= 999)
            {
                valorDoKk = (decimal)0.57;
            }
            else if (quantidade >= 1000)
            {
                valorDoKk = (decimal)0.55;
            }
            return quantidade * valorDoKk;
        }

        /// <summary>
        /// Calcula o valor da compra para o servidor Odin.
        /// </summary>
        /// <param name="quantidade"></param>
        /// <returns></returns>
        public decimal calcularPrecoOdin(int quantidade)
        {
            decimal valorDoKk = 0;
            if (quantidade >= 1 && quantidade <= 99)
            {
                valorDoKk = (decimal)0.59;
            }
            else if (quantidade >= 100 && quantidade <= 499)
            {
                valorDoKk = (decimal)0.58;
            }
            else if (quantidade >= 500 && quantidade <= 999)
            {
                valorDoKk = (decimal)0.57;
            }
            else if (quantidade >= 1000)
            {
                valorDoKk = (decimal)0.55;
            }
            return quantidade * valorDoKk;
        }
    }
}
