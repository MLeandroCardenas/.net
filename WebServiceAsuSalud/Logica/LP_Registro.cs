using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Datos;

namespace Logica
{
    public class LP_Registro : System.Web.Services.Protocols.SoapHeader
    {

        public string Registro_Paciente(string nombres, string apellidos, long identificacion, string email, string clave, string session, string foto, string url)
        {
            string mensaje;
            UP_usuarios user = new UP_usuarios();
            UP_Seguridad segu = new UP_Seguridad();
            user.Nombres = nombres;
            user.Apellidos = apellidos;
            user.Identificacion = identificacion;
            user.Email = email;
            user.Clave = clave;
            user.Session = session;
            user.Foto = foto;
            user.Url = url;
            user.Id_rol = 3;
            user.Especialidad = null;
            user.Estado = 1;
            user.Last_modified = DateTime.Now;
            List<UP_usuarios> lista = new List<UP_usuarios>();
            lista = validacion_usuario(identificacion);
            segu.Id_user = identificacion;
            segu.Intentos_erroneos = 0;
            segu.Last_modified = DateTime.Now;
            segu.Maximo_intentos = 3;
            segu.Sesion = session;
            segu.Sesiones_activas = 0;
            segu.Cantidad_sesiones = 3;
            segu.Estado = 1;
            segu.Fecha_bloqueo = null;

            if (lista.Count() > 0)
            {

                mensaje = "Un usuario con este numero de identificacion :" + identificacion + " ya se encuentra registrado";
                return mensaje;
            }
            else
            {
                DP_Registro dp = new DP_Registro();
                dp.insertar_usuario(user, segu);

                mensaje = "Registro Exitoso";
                return mensaje;
            }


        }


        public List<UP_usuarios> validacion_usuario(long identificacion)
        {
            List<UP_usuarios> lista = new List<UP_usuarios>();
            DP_Registro dp = new DP_Registro();
            lista = dp.traer_usuario(identificacion);

            return lista;
        }
    }
}