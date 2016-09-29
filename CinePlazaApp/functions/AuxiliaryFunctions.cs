using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CinePlazaApp.functions
{
    class AuxiliaryFunctions
    {
       
        public static bool checks_connection()
        {
            try
            {
                /*Verfica se o smartphone está conectado a internet caso
                    esteja trasnfere para a tela de pesquisa, caso não ele
                    informa o usuario que tem que estar conectado 
                */
                if (!NetworkInterface.GetIsNetworkAvailable())
                {
                    return false;
                }
                else
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
