using System;
using System.Text;
using Utilitarios;
using Datos;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Collections;

namespace Logica
{
    public class L_Login
    {
        public static Int64 id;

        public U_Usuario autenticarUser(U_Usuario useer, bool nobotaux)
        {
            int? cantidadsesiones = 0;
            UP_usuarios useraux = new UP_usuarios();
            DP_Seguridad segur = new DP_Seguridad();
            useraux.Identificacion = useer.Identificacion;
            id = useraux.Identificacion;
            useraux.Clave = useer.Clave;
            useraux.Estado = new DP_usuarios().ObtenerEstadoUsuario(useer.Identificacion);

            UP_Seguridad seguridad2 = new UP_Seguridad();
            seguridad2.Id_user = id;

            List<UP_usuarios> lista = new List<UP_usuarios>();

            lista = new DP_usuarios().loggin(useraux);

            new DP_usuarios().SP_DesbloquearUsuario(useraux.Identificacion);

            List<UP_Seguridad> query2 = new DP_Seguridad().traerSesiones(seguridad2);
            DateTime? fechaactual = new DateTime();
            foreach (UP_Seguridad obj in query2)
            {
                seguridad2.Fecha_bloqueo = obj.Fecha_bloqueo;
            }
            fechaactual = seguridad2.Fecha_bloqueo;

            if (fechaactual == null)

                new DP_Seguridad().actualizarEstado(id);

            D_usuarios D_Datos = new D_usuarios();
            UP_Seguridad fechaaux = new UP_Seguridad();

            fechaaux.Id_user = id;
            List<UP_Seguridad> fecha = segur.traerSesiones(fechaaux);
            foreach (UP_Seguridad objfecha in fecha)
            {
                fechaaux.Fecha_bloqueo = objfecha.Fecha_bloqueo;
            }
            DateTime? fechaquery = fechaaux.Fecha_bloqueo;
            if (fechaquery != null)
            {
                Int32 FORMULARIO1 = 9;
                Int32 Idioma1 = useer.Session_idioma;
                Hashtable compIdioma1 = new L_Idioma().obtenerIdioma(FORMULARIO1, Idioma1);
                string mensajeU;
                mensajeU = compIdioma1["MensajeEstBloq"].ToString();

                useer.Mensaje = "<script type='text/javascript'>alert('" + mensajeU + "');window.location=\"login.aspx\"</script>";
                //useer.Mensaje = "<script type='text/javaScript'>alert('Esta bloqueado');window.location=\"login.aspx\"</script>";
                return useer;
            }
            else
            {
                if (nobotaux == true)
                {
                    if (lista.Count > 0)
                    {
                        UP_Seguridad segu = new UP_Seguridad();
                        segu.Id_user = useraux.Identificacion;
                        segu.Intentos_erroneos = 0;
                        new DP_Seguridad().actualizarIntentos(segu);

                        List<UP_Seguridad> lista2 = segur.traerSesiones(segu);
                        foreach (UP_Seguridad obj in lista2)
                        {
                            cantidadsesiones = obj.Cantidad_sesiones;
                        }

                        int? contador = 0;
                        int? auxsesion = 0;
                        int? cant_sesiones = cantidadsesiones;
                        List<UP_Seguridad> lista3 = segur.obtenersesionesactivas(segu);
                        foreach (UP_Seguridad obj2 in lista3)
                        {
                            auxsesion = obj2.Sesiones_activas;
                        }
                        contador = auxsesion;

                        if (cant_sesiones == 0)
                        {
                            Int32 FORMULARIO1 = 9;
                            Int32 Idioma1 = useer.Session_idioma;
                            Hashtable compIdioma1 = new L_Idioma().obtenerIdioma(FORMULARIO1, Idioma1);
                            string mensajeU;
                            mensajeU = compIdioma1["MensajeNoPerEntrar"].ToString();

                            useer.Mensaje = "<script type='text/javascript'>alert('" + mensajeU + "');window.location=\"login.aspx\"</script>";
                            //useer.Mensaje = "<script type='text/javaScript'>alert('No tiene permitido entrar contacte con el admin');window.location=\"login.aspx\"</script>";
                        }
                        if (cant_sesiones >= contador)
                        {
                            contador++;
                            segu.Sesiones_activas = contador;
                            new DP_Seguridad().actualizarSesionesActivas(segu);
                        }

                        if (contador > cant_sesiones)
                        {
                            Int32 FORMULARIO1 = 9;
                            Int32 Idioma1 = useer.Session_idioma;
                            Hashtable compIdioma1 = new L_Idioma().obtenerIdioma(FORMULARIO1, Idioma1);
                            string mensajeU;
                            mensajeU = compIdioma1["MensajeLimSesActivas"].ToString();

                            useer.Mensaje = "<script type='text/javascript'>alert('" + mensajeU + "');window.location=\"login.aspx\"</script>";
                            //useer.Mensaje = "<script type='text/javaScript'>alert('Alcanzo el limite de sesiones activas cierre las sesiones');window.location=\"login.aspx\"</script>";
                            return useer;
                        }
                        foreach (UP_usuarios x in lista)
                        {
                            useer.Identificacion = x.Identificacion;
                            useer.UserId = (int)x.Id;
                            useer.Identificacion = x.Id;
                            useer.Nombres = x.Nombres;
                            useer.Apellidos = x.Apellidos;
                            useer.RolId = x.Id_rol;
                            useer.Ruta_foto_perfil1 = x.Url;
                        }
                        U_Usuario datosUsuario = new U_Usuario();
                        MAC datosConexion = new MAC();
                        datosUsuario.UserId = useer.UserId;
                        datosUsuario.Ip = datosConexion.ip();
                        datosUsuario.Mac = datosConexion.mac();
                        datosUsuario.Session = useer.Session;
                        /**************************************************************/
                        UP_Autenticacion aux = new UP_Autenticacion();
                        aux.User_id = (int)datosUsuario.UserId;
                        aux.Ip = datosUsuario.Ip;
                        aux.Mac = datosUsuario.Mac;
                        aux.Fecha_inicio = DateTime.Now;
                        aux.Session = datosUsuario.Session;
                        new DP_usuarios().guardar_Sesion(aux);

                        switch (useer.RolId)
                        {
                            case 1:
                                Int32 FORMULARIO = 9;
                                Int32 Idioma = useer.Session_idioma;
                                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                                string mensaje;
                                mensaje = compIdioma["MensajeBienvenidoAdmin"].ToString();

                                useer.Mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"PrincipalAdmin.aspx\"</script>";
                                //useer.Mensaje = "<script type='text/javaScript'>alert('Bienvenido administrador');window.location=\"PrincipalAdmin.aspx\"</script>";
                                break;
                            case 2:
                                Int32 FORMULARIO1 = 9;
                                Int32 Idioma1 = useer.Session_idioma;
                                Hashtable compIdioma1 = new L_Idioma().obtenerIdioma(FORMULARIO1, Idioma1);
                                string mensaje1;
                                mensaje1 = compIdioma1["MensajeBienvenidoMedico"].ToString();

                                useer.Mensaje = "<script type='text/javascript'>alert('" + mensaje1 + "');window.location=\"PrincipalMedico.aspx\"</script>";
                                break;
                            case 3:
                                Int32 FORMULARIO2 = 9;
                                Int32 Idioma2 = useer.Session_idioma;
                                Hashtable compIdioma2 = new L_Idioma().obtenerIdioma(FORMULARIO2, Idioma2);
                                string mensaje2;
                                mensaje2 = compIdioma2["MensajeBienvenidoPaciente"].ToString();

                                useer.Mensaje = "<script type='text/javascript'>alert('" + mensaje2 + "');window.location=\"PrincipalPaciente.aspx\"</script>";
                                break;
                            case 4:
                                Int32 FORMULARIO3 = 9;
                                Int32 Idioma3 = useer.Session_idioma;
                                Hashtable compIdioma3 = new L_Idioma().obtenerIdioma(FORMULARIO3, Idioma3);
                                string mensaje3;
                                mensaje3 = compIdioma3["MensajeBienvenidoVentanilla"].ToString();

                                useer.Mensaje = "<script type='text/javascript'>alert('" + mensaje3 + "');window.location=\"BuscarPacienteVentanilla.aspx\"</script>";
                                break;
                            default:
                                Int32 FORMULARIO4 = 9;
                                Int32 Idioma4 = useer.Session_idioma;
                                Hashtable compIdioma4 = new L_Idioma().obtenerIdioma(FORMULARIO4, Idioma4);
                                string mensaje4;
                                mensaje4 = compIdioma4["MensajeNoExiste"].ToString();

                                useer.Mensaje = "<script type='text/javascript'>alert('" + mensaje4 + "');window.location=\"login.aspx\"</script>";
                                break;
                        }
                    }
                    else
                    {
                        Int32 FORMULARIO = 9;
                        Int32 Idioma = useer.Session_idioma;
                        Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                        string mensaje;

                        mensaje = compIdioma["MensajeDatosIncorrectos"].ToString();

                        useer.Mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"login.aspx\"</script>";
                        int? intentos = 0;
                        UP_Seguridad seguridad = new UP_Seguridad();

                        seguridad.Id_user = id;
                        List<UP_Seguridad> query = new DP_Seguridad().traerSesiones(seguridad);
                        foreach (UP_Seguridad x in query)
                        {
                            seguridad.Intentos_erroneos = x.Intentos_erroneos;
                        }
                        intentos = seguridad.Intentos_erroneos;
                        if (intentos != 3)
                        {
                            intentos++;
                            seguridad.Intentos_erroneos = intentos;
                            new DP_Seguridad().actualizarIntentos(seguridad);
                        }
                        if (intentos == 3)
                        {
                            seguridad.Fecha_bloqueo = DateTime.Now.AddMinutes(2);
                            new DP_Seguridad().actualizarFechaBloqueo(seguridad);

                            Int32 FORMULARIO1 = 9;
                            Int32 Idioma1 = useer.Session_idioma;
                            Hashtable compIdioma1 = new L_Idioma().obtenerIdioma(FORMULARIO1, Idioma1);
                            string mensajeU;
                            mensajeU = compIdioma1["MensajeBloqueado2Min"].ToString();

                            useer.Mensaje = "<script type='text/javascript'>alert('" + mensajeU + "');window.location=\"login.aspx\"</script>";
                            //useer.Mensaje = "<script type='text/javaScript'>alert('HA SIDO BLOQUEADO POR 2 MINUTOS');window.location=\"login.aspx\"</script>";
                            return useer;
                        }
                        useer.Session = null;
                    }
                }
            }
            return useer;
        }



        public U_Usuario enviarRecuperacionClave(U_Usuario usuario)
        {
            D_usuarios dao = new D_usuarios();
            DP_usuarios dp = new DP_usuarios();

            long aux = dp.Validar_usuario(long.Parse(usuario.CajaTexto));
            long identity = long.Parse(usuario.CajaTexto);

            if (aux > 0)
            {
                UP_Seguridad up = new UP_Seguridad();
                up.Id_user = Int64.Parse(usuario.CajaTexto);
                List<UP_Seguridad> lista = new DP_Seguridad().traerSesiones(up);
                int? intentos = 0;
                foreach (UP_Seguridad obj in lista)
                {
                    up.Intentos_erroneos = obj.Intentos_erroneos;
                }
                intentos = up.Intentos_erroneos;

                if (intentos == 3)
                {
                    Int32 FORMULARIO = 9;
                    Int32 Idioma = usuario.Session_idioma;
                    Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                    string mensajeU;
                    mensajeU = compIdioma["MensajeEstaBloqueadoRC"].ToString();

                    usuario.Mensaje = "<script type='text/javascript'>alert('" + mensajeU + "');window.location=\"RecuperacionContraseña.aspx\"</script>";
                    //usuario.Mensaje = "<script type='text/javaScript'>alert('Esta bloqueado intente mas tarde');window.location=\"RecuperacionContraseña.aspx\"</script>";
                    return usuario;
                }
                else
                {
                    List<UP_usuarios> auxuser = new DP_usuarios().obtener_usuarios(identity);
                    UP_usuarios usu = new UP_usuarios();
                    foreach (var x in auxuser)
                    {
                        usu.Id = x.Id;
                        usu.Estado = x.Estado;
                        usu.Email = x.Email;
                    }
                    long idaux = usu.Id;
                    int estadoaux = usu.Estado;
                    string mailaux = usu.Email;
                    U_Usuario token = new U_Usuario();
                    token.UserId = (int)idaux;
                    token.Estado = estadoaux;
                    token.Correo = mailaux;
                    token.Fecha = DateTime.Now.ToFileTimeUtc();

                    String userToken = encriptar(JsonConvert.SerializeObject(token));
                    UP_TokenRecuperacion token2 = new UP_TokenRecuperacion();

                    token2.User_id = token.UserId;
                    token2.Token = userToken;
                    token2.Fecha_creado = DateTime.Now;
                    token2.Fecha_vigencia = DateTime.Now.AddHours(6);
                    new DP_usuarios().almacenarToken(token2);

                    Correo correo = new Correo();

                    String mensaje = "su link de acceso es: " + "http://localhost:58477/View/RecuperarContraseña2.aspx?" + userToken;
                    correo.enviarCorreo(token.Correo, userToken, mensaje);
                    /**/
                    Int32 FORMULARIO = 24;
                    Int32 Idioma = usuario.Session_idioma;
                    Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                    string mensajeU;
                    mensajeU = compIdioma["MensajeRecConEnviada"].ToString();
                    usuario.Mensaje = "<script type='text/javascript'>alert('" + mensajeU + "');window.location=\"RecuperacionContraseña.aspx\"</script>";
                    //usuario.Mensaje = "<script type='text/javaScript'>alert('Su nueva contraseña ha sido enviado por correo');window.location=\"RecuperacionContraseña.aspx\"</script>";
                    usuario.CajaTexto = "";
                    /*  Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Su nueva contraseña ha sido enviada por correo');", true);
                      TB_Recuperacion.Text = "";*/
                }
            }
            else if (aux == -2)
            {
                Int32 FORMULARIO = 24;
                Int32 Idioma = usuario.Session_idioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                string mensajeU;
                mensajeU = compIdioma["MensajeYaExiToken"].ToString();
                usuario.Mensaje = "<script type='text/javascript'>alert('" + mensajeU + "');window.location=\"RecuperacionContraseña.aspx\"</script>";

                //usuario.Mensaje = "<script type='text/javaScript'>alert('Ya existe un token por favor verifique su correo');window.location=\"RecuperacionContraseña.aspx\"</script>";
                usuario.CajaTexto = "";
            }

            else
            {
                Int32 FORMULARIO = 24;
                Int32 Idioma = usuario.Session_idioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                string mensajeU;
                mensajeU = compIdioma["MensajeNoExis"].ToString();
                usuario.Mensaje = "<script type='text/javascript'>alert('" + mensajeU + "');window.location=\"RecuperacionContraseña.aspx\"</script>";
                //usuario.Mensaje = "<script type='text/javaScript'>alert('El usuario digitado no existe');window.location=\"RecuperacionContraseña.aspx\"</script>";
                usuario.CajaTexto = "";
            }
            return usuario;
        }

        private string encriptar(string input)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = provider.ComputeHash(inputBytes);

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                output.Append(hashedBytes[i].ToString("x2").ToLower());

            return output.ToString();
        }

        public U_Usuario validacion(U_Usuario usuario)
        {
            if (usuario.Peticion > 0)
            {
                D_usuarios user = new D_usuarios();

                int resultado = new DP_usuarios().ObtenerUsuarioToken(usuario.PeticionDos);

                if (resultado == -1)
                {
                    Int32 FORMULARIO = 24;
                    Int32 Idioma = usuario.Session_idioma;
                    Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                    string mensajeU;
                    mensajeU = compIdioma["MensajeGenereTokenNuevo"].ToString();
                    usuario.Mensaje = "<script type='text/javascript'>alert('" + mensajeU + "');window.location=\"login.aspx\"</script>";
                    //usuario.Mensaje = "<script type='text/javaScript'>alert('El token es invalido genere uno nuevo');window.location=\"login.aspx\"</script>";
                    //this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('El Token es invalido. Genere uno nuevo');window.location=\"login.aspx\"</script>");
                }
                else if (resultado == -2)
                {
                    Int32 FORMULARIO = 24;
                    Int32 Idioma = usuario.Session_idioma;
                    Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                    string mensajeU;
                    mensajeU = compIdioma["MensajeGenereTokenVencido"].ToString();
                    usuario.Mensaje = "<script type='text/javascript'>alert('" + mensajeU + "');window.location=\"login.aspx\"</script>";
                    //usuario.Mensaje = "<script type='text/javaScript'>alert('El token esta vencido genere uno nuevo');window.location=\"login.aspx\"</script>";
                    // this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('El Token esta vencido. Genere uno nuevo');window.location=\"login.aspx\"</script>");
                }
                else
                {
                    List<UP_TokenRecuperacion> id = new DP_usuarios().ObtenerUserId(usuario.PeticionDos);
                    UP_TokenRecuperacion tokeni = new UP_TokenRecuperacion();
                    foreach(var obj in id)
                    {
                        tokeni.User_id = obj.User_id;
                    }
                    int aux1 = (int)tokeni.User_id;
                    usuario.UserId = aux1;
                }
            }
            else
            {
                Int32 FORMULARIO = 24;
                Int32 Idioma = usuario.Session_idioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                string mensajeU;
                mensajeU = compIdioma["MensajeInicio"].ToString();
                usuario.Mensaje = "<script type='text/javascript'>alert('" + mensajeU + "');window.location=\"login.aspx\"</script>";
                //usuario.Mensaje = "<script type='text/javaScript'>alert('inicio');window.location=\"login.aspx\"</script>";
                //Response.Redirect("login.aspx");
            }
            return usuario;
        }

        public U_Usuario guardarNuevaContraseña(U_Usuario user)
        {
            if (user.Clave == user.ClaveDos)
            {
                D_usuarios usuario = new D_usuarios();
                UP_usuarios user2 = new UP_usuarios();
                UP_TokenRecuperacion token2 = new UP_TokenRecuperacion();
                user2.Clave = user.Clave;
                user2.Id = user.UserId;
                user2.Estado = 1;

                new DP_usuarios().actualizarContraseña(user2);
                // usuario.actualizarContrasena(user.UserId, user.Clave);

                Int32 FORMULARIO = 24;
                Int32 Idioma = user.Session_idioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                string mensajeU;
                mensajeU = compIdioma["MensajeContraActu"].ToString();
                user.Mensaje = "<script type='text/javascript'>alert('" + mensajeU + "');window.location=\"login.aspx\"</script>";
                //user.Mensaje = "<script type='text/javaScript'>alert('Su contraseña ha sido actualizada');window.location=\"login.aspx\"</script>";
                //this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Su Contraseña ha sido actualizada.');window.location=\"login.aspx\"</script>");
                user.Clave = "";
                user.ClaveDos = "";
            }
            else
            {
                Int32 FORMULARIO = 24;
                Int32 Idioma = user.Session_idioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                string mensajeU;
                mensajeU = compIdioma["MensajeContraNoCoin"].ToString();
                user.Mensaje = "<script type='text/javascript'>alert('" + mensajeU + "');window.location=\"RecuperarContraseña2.aspx\"</script>";
                //user.Mensaje = "<script type='text/javaScript'>alert('Las contraseñas no coinciden');window.location=\"RecuperarContraseña2.aspx\"</script>";
                //Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Las contraseñas no coinciden');", true);
                user.Clave = "";
                user.ClaveDos = "";
            }
            return user;
        }

        public U_Usuario cerrarSesion(U_Usuario user)
        {
            UP_Autenticacion auten = new UP_Autenticacion();
            auten.Session = user.Session;
            new DP_usuarios().cerrarSesion(auten);
            UP_Seguridad seguridad = new UP_Seguridad();
            seguridad.Id_user = id;
            int? contador = 0;
            int? sesiones = 0;
            List<UP_Seguridad> lista = new DP_Seguridad().obtenersesionesactivas(seguridad);
            List<UP_Seguridad> lista2 = new DP_Seguridad().traerSesiones(seguridad);
            foreach (UP_Seguridad obj in lista)
            {
                contador = obj.Sesiones_activas;
            }
            foreach (UP_Seguridad obj2 in lista2)
            {
                sesiones = obj2.Cantidad_sesiones;
            }

            if (contador != 0)
            {
                contador--;
                seguridad.Sesiones_activas = contador;
                new DP_Seguridad().actualizarSesionesActivas(seguridad);
            }
            if (contador == 0)
                return user;
            return user;
        }
    }
}


