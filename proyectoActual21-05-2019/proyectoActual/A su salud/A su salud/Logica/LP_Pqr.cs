using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilitarios;
using Datos;
using System.Threading.Tasks;
using System.Data;
using System.Collections;

namespace Logica
{
    public class LP_Pqr
    {
        public List<UP_Pqr> traer_pqrs()
        {
            DP_Pqr dp = new DP_Pqr();
            return dp.traer_todos_los_pqr();
        }

        public List<UP_Pqr> traer_pqr(int id)
        {
            DP_Pqr dp = new DP_Pqr();
            return dp.traer_pqr_medicos(id);
        }

        public List<UP_Pqr> traer_pqrs_usuarios(int id)
        {
            DP_Pqr dp = new DP_Pqr();
            return dp.traer_respuestas_pqr_usuarios(id);
        }

        public void eliminar_pqr(int id)
        {
            DP_Pqr dp = new DP_Pqr();
            dp.borrar_pqr_usuario(id);
        }

        public void borrar_pqr_usuarioparaconfundiralods(int id)
        {
        }

        public U_pqrs responderMensajes(U_pqrs datos)
        {
            if (datos.Nombres == "respuesta")
            {
                U_pqrs pqr = new U_pqrs();
                DP_Pqr admin = new DP_Pqr();
                pqr.Nombres = datos.Mensaje;
                pqr.Id_user = datos.Id_user;
                admin.enviar_respuesta_pqr(pqr);
            }
            return datos;
        }

        public U_DatosUser enviarMensajePaciente(UP_Pqr user, U_DatosUser userid)
        {
            UP_Pqr datosDos = new UP_Pqr();
            DP_Pqr medico = new DP_Pqr();
            LP_usuarios traerdatosmedico = new LP_usuarios();
            int idatraer = (int)user.Id;
            List<UP_usuarios> registro = traerdatosmedico.traer_usuarios(idatraer);

            foreach (UP_usuarios obj2 in registro)
            {
                datosDos.Tipo_mensaje = user.Tipo_mensaje;
                datosDos.Mensaje = user.Mensaje;
                datosDos.Nombres = obj2.Nombres;
                datosDos.Apellidos = obj2.Apellidos;
                datosDos.Correo = obj2.Email;
                datosDos.Session = user.Session;
                datosDos.Id_usuario = (int)user.Id;
                datosDos.Estado = user.Estado;
                datosDos.Last_modified = obj2.Last_modified;
                //datosDos.Responder_mensaje = user.Responder_mensaje;
                medico.insertar_pqr(datosDos);
            }
            Int32 FORMULARIO = 18;
            Int32 Idioma = userid.Sessionidioma;
            Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
            string mensajeU;
            mensajeU = compIdioma["MensajeMedPqr"].ToString();

            userid.Mensaje2 = "<script type='text/javascript'>alert('" + mensajeU + "');window.location=\"PqrMedico.aspx\"</script>";
            //datos.MensajeDos = "<script type='text/javaScript'>alert('Mensaje enviado');window.location=\"PqrMedico.aspx\"</script>";
            return userid;
        }
    }
}

