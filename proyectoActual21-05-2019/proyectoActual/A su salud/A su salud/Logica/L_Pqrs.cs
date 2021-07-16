using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Datos;
using System.Data;
using System.Collections;

namespace Logica
{
    public class L_Pqrs
    {

        public U_DatosUser inicioRolMedico(U_DatosUser usuario)
        {
            if (usuario.Sessionuser == null)
            {
                usuario.Mensaje = "login.aspx";
            }
            long id = Int64.Parse(usuario.Sessionidrolvalidacion.ToString());
            if (id != 2)
            {
                usuario.Mensaje = "login.aspx";
            }
            return usuario;
        }
        //"<script type='text/javaScript'>alert('Las contraseñas no coinciden');window.location=\"RecuperarContraseña2.aspx\"</script>";
        public UP_Pqr enviarMensajeMedico(UP_Pqr datos, U_DatosUser user)
        {
            UP_Pqr datosDos = new UP_Pqr();
            D_medicos medico1 = new D_medicos();
            LP_usuarios medico = new LP_usuarios();
            List<UP_usuarios> registro = medico.traer_usuarios((int)datos.Id);
            UP_Pqr pqr = new UP_Pqr();
            foreach (UP_usuarios pqr_envio in registro)
            {
                pqr.Tipo_mensaje = datos.Tipo_mensaje;
                pqr.Mensaje = datos.Mensaje;
                pqr.Nombres = pqr_envio.Nombres;
                pqr.Apellidos = pqr_envio.Apellidos;
                pqr.Correo = pqr_envio.Email;
                pqr.Session = datos.Session;
                pqr.Id_usuario = (int)pqr_envio.Id;
                pqr.Estado = datos.Estado;
            }
            // medico1.enviarPqrUsuarios(pqr);
            new DP_admin().EnviarPqrUser(pqr);
            Int32 FORMULARIO = 18;
            Int32 Idioma = user.Sessionidioma;
            Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
            string mensajeU;
            mensajeU = compIdioma["MensajeMedPqr"].ToString();

            datos.Mensaje = "<script type='text/javascript'>alert('" + mensajeU + "');window.location=\"PqrMedico.aspx\"</script>";

            //datos.MensajeDos = "<script type='text/javaScript'>alert('Mensaje enviado');window.location=\"PqrMedico.aspx\"</script>";
            return datos;
        }

        public U_DatosUser inicioRolPaciente(U_DatosUser usuario)
        {
            if (usuario.Sessionuser == null)
            {
                usuario.Mensaje = "Login.aspx";
            }
            long id = Int64.Parse(usuario.Sessionidrolvalidacion.ToString());
            if (id != 3)
            {
                usuario.Mensaje = "Login.aspx";
            }
            return usuario;
        }

        public UP_Pqr enviarMensajeUsuario(UP_Pqr datos, U_DatosUser user)
        {
            UP_Pqr datosDos = new UP_Pqr();
            D_medicos medico1 = new D_medicos();
            LP_usuarios medico = new LP_usuarios();
            List<UP_usuarios> registro = medico.traer_usuarios((int)datos.Id);
            UP_Pqr pqr = new UP_Pqr();
            foreach (UP_usuarios pqr_envio in registro)
            {
                pqr.Tipo_mensaje = datos.Tipo_mensaje;
                pqr.Mensaje = datos.Mensaje;
                pqr.Nombres = pqr_envio.Nombres;
                pqr.Apellidos = pqr_envio.Apellidos;
                pqr.Correo = pqr_envio.Email;
                pqr.Session = datos.Session;
                pqr.Id_usuario = (int)pqr_envio.Id;
                pqr.Estado = datos.Estado;
            }
            //medico1.enviarPqrUsuarios(pqr);
            new DP_admin().EnviarPqrUser(pqr);
            Int32 FORMULARIO = 19;
            Int32 Idioma = user.Sessionidioma;
            Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
            string mensajeU;
            mensajeU = compIdioma["MensajePacPqr"].ToString();

            datos.Mensaje = "<script type='text/javascript'>alert('" + mensajeU + "');window.location=\"PqrPaciente.aspx\"</script>";
            //datos.MensajeDos = "<script type='text/javaScript'>alert('Mensaje enviado');window.location=\"PqrPaciente.aspx\"</script>"; ;
            return datos;
        }

        /*public U_pqrs responderMensajes(U_pqrs datos)
        {

            if (datos.Nombres == "respuesta")
            {
                U_pqrs pqr = new U_pqrs();
                D_Admin admin = new D_Admin();

                pqr.Nombres = datos.Mensaje;

                pqr.Id_user = datos.Id_user;

                admin.responderpqr(pqr);
            }
            return datos;
        }*/
        public U_DatosUser inicioRolAdministrador(U_DatosUser usuario)
        {
            if (usuario.Sessionuser == null)
            {
                usuario.Mensaje = "login.aspx";
            }
            long id = Int64.Parse(usuario.Sessionidrolvalidacion.ToString());
            if (id != 1)
            {
                usuario.Mensaje = "L}login.aspx";
            }
            return usuario;
        }






    }
}
