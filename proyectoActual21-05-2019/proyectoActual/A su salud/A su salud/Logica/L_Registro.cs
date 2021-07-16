using System;
using System.Collections.Generic;
using Utilitarios;
using Datos;
using System.Collections;

namespace Logica
{
    public class L_Registro
    {
        public void registro(U_DatosUser user)
        {
            UP_usuarios user2 = new UP_usuarios();
            user2.Identificacion = user.Numid;
            user2.Email = user.Email;

            List<UP_usuarios> aux = new DP_Medicos().validar_identificacionCorreo(user2);
            if (aux.Count == 0)
            {
                if ((user.Extension.Equals(".jpg") || user.Extension.Equals(".gif") || user.Extension.Equals(".jpge") || user.Extension.Equals(".png")))
                {
                    user.SaveLocation1 = user.SaveLocation + "\\imagenes\\" + user.NombreArchivo;
                }
                else
                {
                    Int32 FORMULARIO = 26;
                    Int32 Idioma = user.Sessionidioma;
                    Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                    string mensaje;
                    mensaje = compIdioma["MensajeArchivoInvalido"].ToString();

                    user.Mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"Registro.aspx\"</script>";
                    //user.Mensaje = "El formato del archivo es invalido";
                    return;
                }
                if (System.IO.File.Exists(user.Ruta))
                {
                    Int32 FORMULARIO = 26;
                    Int32 Idioma = user.Sessionidioma;
                    Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                    string mensaje;
                    mensaje = compIdioma["MensajeErrorRegistro"].ToString();

                    user.Mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"Registro.aspx\"</script>";
                    //user.Mensaje = "<script type='text/javascript'>alert('Ya existe un archivo en el servidor con ese nombre');window.location=\"Registro.aspx\"</script>";
                    return;
                }
                else
                {
                    user2.Apellidos = user.Apellidos;
                    user2.Nombres = user.Nombres;
                    user2.Identificacion = user.Numid;
                    user2.Email = user.Email;
                    user2.Clave = user.Clave;
                    user2.Id_rol = 3;
                    user2.Session = user.Session;
                    user2.Estado = 1;
                    user2.Last_modified = DateTime.Now;
                    user2.Foto = user.NombreArchivo;
                    user2.Url = user.SaveLocation1;
                    user2.Especialidad = "";
                    UP_Seguridad seguridad = new UP_Seguridad();
                    seguridad.Id_user = user.Numid; 
                    seguridad.Cantidad_sesiones = 3;
                    seguridad.Sesiones_activas = 0;
                    seguridad.Intentos_erroneos = 0;
                    seguridad.Maximo_intentos = 3;
                    seguridad.Estado = 1;
                    seguridad.Sesion = user.Session;
                    seguridad.Last_modified = DateTime.Now;

                    new DP_Medicos().insertar_usuario(user2,seguridad);

                    Int32 FORMULARIO = 26;
                    Int32 Idioma = user.Sessionidioma;
                    Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                    string mensaje;
                    mensaje = compIdioma["MensajeRegistroExitoso"].ToString();

                    user.Mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"Registro.aspx\"</script>";
                    //user.Mensaje = "<script type='text/javascript'>alert('Registro Exitoso');window.location=\"Registro.aspx\"</script>";
                }
            }
            else
            {
                Int32 FORMULARIO = 26;
                Int32 Idioma = user.Sessionidioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                string mensaje;
                mensaje = compIdioma["MensajeErrorYaRegistrado"].ToString();

                user.Mensaje1 = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"Registro.aspx\"</script>";
            }
        }
        public void crearusuario(U_DatosUser user)
        {
            new Datos.DAO_Usuarios().CrearUsuarios(user);
        }
    }
}

