using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;

namespace Datos
{
    public class DP_Servicios
    {

        public void insertar_token_generado(string nombre, string token)
        {
            U_seguridad_cliente datos = new U_seguridad_cliente();
            using (var insertar = new Mapeo("security"))
            {
                datos = traer_token_cliente(nombre);
                datos.Token_generado = token;
                insertar.token_cliente.Attach(datos);

                var entry = insertar.Entry(datos);
                entry.State = EntityState.Modified;
                insertar.SaveChanges();
            }

        }

        public U_seguridad_cliente traer_token_cliente(string nombre_cliente)
        {
            U_seguridad_cliente datos = new U_seguridad_cliente();
            string token = "";
            using (var consultar = new Mapeo("security"))
            {
                var con = consultar.token_cliente.Where(x => x.Nombre_cliente == nombre_cliente).ToList<U_seguridad_cliente>();
                foreach (U_seguridad_cliente obj in con)
                {
                    datos.Nombre_cliente = obj.Nombre_cliente;
                    datos.Token_seguridad = obj.Token_seguridad;
                    datos.Fecha_vigencia = obj.Fecha_vigencia;
                    datos.Clave_cliente = obj.Clave_cliente;
                    datos.Token_generado = obj.Token_generado;
                    datos.Id = obj.Id;
                }
                return datos;
            }

        }
    }
}
