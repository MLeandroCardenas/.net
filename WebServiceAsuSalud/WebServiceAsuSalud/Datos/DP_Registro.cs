using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;

namespace Datos
{
    public class DP_Registro
    {

        public string insertar_usuario(UP_usuarios datos, UP_Seguridad segu)
        {
            string mensaje = "";
            try
            {
                using (var db = new Mapeo("usuarios"))
                {
                    db.usuario.Add(datos);
                    db.SaveChanges();
                    db.seguridad.Add(segu);
                    db.SaveChanges();
                    mensaje = "Registro Exitoso";
                    return mensaje;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UP_usuarios> traer_usuario(long identificacion)
        {
            using (var consulta = new Mapeo("usuarios"))
            {
                var lista = consulta.usuario.Where(x => x.Identificacion == identificacion).ToList<UP_usuarios>();
                return lista;
            }
        }

    }
}