using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Datos;

namespace Logica
{
    public class L_SERVICIOS
    {
        //----------------SCA-----------------------------------//

        public U_SCA_SEDES traer_sede(int id_sede, List<U_SCA_SEDES> lista)
        {
            U_SCA_SEDES dato = new U_SCA_SEDES();
            foreach (U_SCA_SEDES obj in lista)
            {
                if (obj.IdSede == id_sede)
                {
                    dato.IdSede = obj.IdSede;
                    dato.nombresede = obj.nombresede;
                    dato.ciudad = obj.ciudad;
                    dato.direccion = obj.direccion;
                    dato.estado = obj.estado;
                }

            }
            return dato;

        }





        //----------------SCA-------------------------------------//

        public void insertar_token(string nombre, string token)
        {
            DP_Servicios dp = new DP_Servicios();
            dp.insertar_token_generado(nombre, token);
        }

        public U_seguridad_cliente traer_token_cliente(string nombre)
        {
            DP_Servicios datos = new DP_Servicios();
            return datos.traer_token_cliente(nombre);
        }
    }
}
