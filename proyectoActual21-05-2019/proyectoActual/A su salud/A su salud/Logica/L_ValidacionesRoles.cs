using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;

namespace Logica
{
    public class L_ValidacionesRoles
    {
        public string validacionnula(string sesion, U_DatosUser user)
        {
            string mensaje = "";
            if (sesion == null)
            {
                Int32 FORMULARIO = 9;
                Int32 Idioma = user.Sessionidioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                string mensaje1;
                mensaje1 = compIdioma["MensajeValidacionNula1"].ToString();

                mensaje = "<script type='text/javascript'>alert('" + mensaje1 + "');window.location=\"login.aspx\"</script>";
                //mensaje = "< script type = 'text/javascript' > alert('Error al ingresar'); window.location =\"login.aspx\"</script>";               
            }
            return mensaje;
        }
        public string validacionrol(U_DatosUser user)
        {
            string mensaje = "";
            if (user.Sessionidrolvalidacion != 1)
            {
                Int32 FORMULARIO = 9;
                Int32 Idioma = user.Sessionidioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                string mensaje1;
                mensaje1 = compIdioma["MensajeValidacionNula1"].ToString();

                mensaje = "<script type='text/javascript'>alert('" + mensaje1 + "');window.location=\"login.aspx\"</script>";
                //mensaje = "< script type = 'text/javascript' > alert('Error al ingresar'); window.location =\"login.aspx\"</script>";
            }

            return mensaje;
        }

        public string validacionrol2(U_DatosUser user)
        {
            string mensaje = "";
            if (user.Sessionidrolvalidacion != 2)
            {
                Int32 FORMULARIO = 9;
                Int32 Idioma = user.Sessionidioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                string mensaje1;
                mensaje1 = compIdioma["MensajeValidacionNula1"].ToString();

                mensaje = "<script type='text/javascript'>alert('" + mensaje1 + "');window.location=\"login.aspx\"</script>";
                //mensaje = "< script type = 'text/javascript' > alert('Error al ingresar'); window.location =\"login.aspx\"</script>";
            }

            return mensaje;
        }

        public void validacionnula(U_DatosUser user)
        {
            if (user.Sessionuser == null)
            {
                Int32 FORMULARIO = 9;
                Int32 Idioma = user.Sessionidioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                string mensaje;
                mensaje = compIdioma["MensajeValidacionNula"].ToString();

                user.Mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"login.aspx\"</script>";
                //user.Mensaje = "<script type='text/javascript'>alert('INICIE SESION :(');window.location=\"Login.aspx\"</script>";

            }
        }
        public void validacionroladmin(U_DatosUser user)
        {
            if (user.Sessionidrolvalidacion != 1)
            {
                Int32 FORMULARIO = 9;
                Int32 Idioma = user.Sessionidioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                string mensaje;
                mensaje = compIdioma["MensajeValidacionNula"].ToString();

                user.Mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"login.aspx\"</script>";
                //user.Mensaje = "<script type='text/javascript'>alert('INICIE SESION :(');window.location=\"Login.aspx\"</script>";
            }
        }
        public void validacionrolmedico(U_DatosUser user)
        {
            if (user.Sessionidrolvalidacion != 2)
            {
                Int32 FORMULARIO = 9;
                Int32 Idioma = user.Sessionidioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                string mensaje;
                mensaje = compIdioma["MensajeValidacionNula"].ToString();

                user.Mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"login.aspx\"</script>";
                //user.Mensaje = "<script type='text/javascript'>alert('INICIE SESION :(');window.location=\"Login.aspx\"</script>";
            }
        }
        public void validacionrolpaciente(U_DatosUser user)
        {
            if (user.Sessionidrolvalidacion != 3)
            {
                Int32 FORMULARIO = 9;
                Int32 Idioma = user.Sessionidioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                string mensaje;
                mensaje = compIdioma["MensajeValidacionNula"].ToString();

                user.Mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"login.aspx\"</script>";
                //user.Mensaje = "<script type='text/javascript'>alert('INICIE SESION :(');window.location=\"Login.aspx\"</script>";
            }
        }
        public U_DatosUser PaginaPrincipalMedico(U_DatosUser user)
        {
            if (user.Sessionuser == null)
            {
                user.Mensaje = "login.aspx";
            }
            long id = Int64.Parse(user.Sessionidrolvalidacion.ToString());
            if (id != 2)
            {
                user.Mensaje = "login.aspx";
            }
            return user;
        }
    }
}

