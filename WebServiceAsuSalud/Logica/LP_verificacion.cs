using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Utilitarios;

namespace Logica
{
    public class LP_verificacion : System.Web.Services.Protocols.SoapHeader
    {


        public bool validacionUsuario(string nombre_cliente, string clave_cliente)
        {
            try
            {
                DP_Core CORE = new DP_Core();
                U_seguridad_cliente datos = new U_seguridad_cliente();
                List<U_seguridad_cliente> lista = new List<U_seguridad_cliente>();
                lista = CORE.traer_cliente(nombre_cliente, clave_cliente);
                if (lista.Count() > 0)
                {
                    foreach (U_seguridad_cliente obj in lista)
                    {
                        datos.Id = obj.Id;
                        datos.Nombre_cliente = obj.Nombre_cliente;
                        datos.Clave_cliente = obj.Clave_cliente;
                        datos.Token_seguridad = obj.Token_seguridad;
                        datos.Fecha_vigencia = obj.Fecha_vigencia;
                    }
                    if (datos.Token_seguridad != null && datos.Fecha_vigencia < DateTime.Now)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public void insertar_token(string token,string token_antiguio)
        {
            try
            {
                DP_Core core = new DP_Core();
                core.insertar_token(token,token_antiguio);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
