using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Datos;
using System.Web;

namespace Logica
{
    public class LP_seguridad : System.Web.Services.Protocols.SoapHeader
    {
        public string StToken { get; set; }
        public string AutenticacionToken { get; set; }

        public bool blCredencialesValidas(string stToken)
        {
            try
            {
                if (stToken == DateTime.Now.ToString("yyyyMMdd")) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool blCredencialesValidas(LP_seguridad SoapHeader)
        {
            try
            {
                if (SoapHeader == null) return false;
                if (!string.IsNullOrEmpty(SoapHeader.AutenticacionToken))
                    return (HttpRuntime.Cache[SoapHeader.AutenticacionToken] != null);

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
