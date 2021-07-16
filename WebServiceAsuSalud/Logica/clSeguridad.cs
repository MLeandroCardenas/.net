using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Datos;
using Utilitarios;

namespace Logica
{
    public class clSeguridad : System.Web.Services.Protocols.SoapHeader
    {

        public string stToken { get; set; }
        public string AutenticacionToken { get; set; }
        public string user { get; set; }
        public string clave { get; set; }

        public string blCredencialesValidas(string token)
        {
            try
            {
                string mensaje="";
                U_seguridad_cliente usuario = new U_seguridad_cliente();
                List<U_seguridad_cliente> datos = new List<U_seguridad_cliente>();
                DP_Core dp = new DP_Core();
                datos=dp.traer_datos_cliente(token);
                if (datos.Count > 0)
                {
                    
                    foreach (U_seguridad_cliente obj in datos)
                    {
                        usuario.Token_seguridad = obj.Token_seguridad;
                        usuario.Fecha_vigencia = obj.Fecha_vigencia;
                    }
                    if (usuario.Token_seguridad != null && usuario.Fecha_vigencia>DateTime.Now)
                    {
                        return "1";
                    }
                    else
                    {
                        return "2";
                    }
                }
                else return "-1";
                //if (stToken == "a070d88f-70b5-402c-9bbb-c367f8d51918") return true;
                //else return false;


            }
            catch (Exception ex) { throw ex; }
        }

        public bool blCredencialesValidas(clSeguridad SoapHeader)
        {
            try
            {
                if (SoapHeader == null) return false;
                if (!string.IsNullOrEmpty(SoapHeader.AutenticacionToken))
                    return (HttpRuntime.Cache[SoapHeader.AutenticacionToken] != null);

                return false;
            }
            catch (Exception ex) { throw ex; }
        }

        public string traer_token(string user, string clave)
        {
            try
            {
                string mensaje = "";
                U_seguridad_cliente usuario = new U_seguridad_cliente();
                List<U_seguridad_cliente> datos = new List<U_seguridad_cliente>();
                DP_Core dp = new DP_Core();
                datos = dp.traer_cliente(user, clave);
                foreach (U_seguridad_cliente obj in datos)
                {
                    mensaje = obj.Token_seguridad;
                }
                return mensaje;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}