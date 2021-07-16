using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Datos;

namespace Logica
{
    public class LP_autenticacion : System.Web.Services.Protocols.SoapHeader
    {
        /*
        public bool validacionTokenSeguridad(string token)
        {
            /*
            try
            {
                DP_Core CORE = new DP_Core();
                List<U_seguridad_cliente> lista = new List<U_seguridad_cliente>();
                lista = CORE.traer_datos_cliente(token);
                if (lista.Count() > 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            */

        

        /*
        public void insertar_token(string token,string token_autenticacion)
        {
            try
            {
                DP_Core core = new DP_Core();
                core.insertar_token_autenticacion(token,token_autenticacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        */

    }
}
