using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;


namespace Datos
{
    public class DP_Core
    {
        public List<U_seguridad_cliente> traer_datos_cliente(string token)
        {
            using (var consulta = new Mapeo("servicios_seguridad"))
            {
                var datos = consulta.clientes.Where(x => x.Token_seguridad==token).ToList<U_seguridad_cliente>();
                return datos.ToList<U_seguridad_cliente>();
            }
        }
        
        public List<U_seguridad_cliente> traer_cliente(string nombre,string clave)
        {
            using (var consulta = new Mapeo("security"))
            {
                var datos = consulta.clientes.Where(x => x.Nombre_cliente == nombre && x.Clave_cliente == clave).ToList<U_seguridad_cliente>();
                return datos.ToList<U_seguridad_cliente>();
            }
        }
        
        public void insertar_token(string token_seguridad,string token_antiguo)
        {
            using (var conexion = new Mapeo("security"))
            {
                List<U_seguridad_cliente> lista = new List<U_seguridad_cliente>();
                U_seguridad_cliente datos = new U_seguridad_cliente();
                lista = traer_datos_cliente(token_antiguo);
                foreach (U_seguridad_cliente obj in lista)
                {
                    datos.Nombre_cliente = obj.Nombre_cliente;
                    datos.Clave_cliente = obj.Clave_cliente;
                    datos.Id = obj.Id;
                    datos.Fecha_vigencia = DateTime.Now.AddDays(30);
                    datos.Token_seguridad = token_seguridad;
                }
                conexion.clientes.Attach(datos);

                var ejecucion = conexion.Entry(datos);
                ejecucion.State = EntityState.Modified;
                conexion.SaveChanges();
            }
        }

    }
}
