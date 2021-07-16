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
    public class L_CrearMedicos
    {
        public void crearespecialidad(U_DatosUser especialidad)
        {
            UP_Especialidades aux = new UP_Especialidades();
            aux.Nombre = especialidad.Nombres;
            List<UP_Especialidades> resul = new DP_Medicos().validarEspecialidad(aux);

            if (resul.Count == 0)
            {
                aux.Nombre = especialidad.Espe;
                aux.Session = especialidad.Session;
                aux.Last_modified = DateTime.Now;

                new DP_Medicos().insertar_Especialidad(aux);
                //new Datos.DAO_Admin().CrearEspecialidad(especialidad);

                Int32 FORMULARIO = 7;
                Int32 Idioma = especialidad.Sessionidioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                string mensaje;
                mensaje = compIdioma["MensajeCrearEspe"].ToString();

                especialidad.Mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"CrearMedicos.aspx\"</script>";
            }
            else
            {
                Int32 FORMULARIO = 7;
                Int32 Idioma = especialidad.Sessionidioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                string mensaje;
                mensaje = compIdioma["MensajeEspYaExis"].ToString();

                especialidad.Mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"CrearMedicos.aspx\"</script>";
            }
        }

        public List<UP_Especialidades> obtenerEspecialidades2()
        {
                DP_Medicos medico = new DP_Medicos();
               return medico.obtenerEspecialidades2();
        }

        public void eliminarEspecialidades(UP_Especialidades ESPECIA)
        {
            DP_Medicos espe = new DP_Medicos();
            espe.borrar_Especialidades(ESPECIA);
        }


        public void crearMedico(U_DatosUser medico)
        {
            UP_usuarios user_medico = new UP_usuarios();
            user_medico.Identificacion = medico.Numid;
            user_medico.Email = medico.Email;
            List<UP_usuarios> resul = new DP_Medicos().validar_identificacionCorreo(user_medico);

            if (resul.Count == 0)
            {
                if ((medico.Extension.Equals(".jpg") || medico.Extension.Equals(".gif") || medico.Extension.Equals(".jpge") || medico.Extension.Equals(".png")))
                {
                    medico.SaveLocation1 = medico.SaveLocation + "\\imagenes\\" + medico.NombreArchivo;
                }
                else
                {
                    Int32 FORMULARIO = 7;
                    Int32 Idioma = medico.Sessionidioma;
                    Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                    string mensaje;
                    mensaje = compIdioma["MensajeCrearMedicoArchivoInv"].ToString();

                    medico.Mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"CrearMedicos.aspx\"</script>";

                    return;
                }
                if (System.IO.File.Exists(medico.Ruta))
                {
                    Int32 FORMULARIO = 7;
                    Int32 Idioma = medico.Sessionidioma;
                    Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                    string mensaje;
                    mensaje = compIdioma["MensajeCrearMedicoArchivoYaExiste"].ToString();

                    medico.Mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"CrearMedicos.aspx\"</script>";
                    return;
                }
                else
                {

                    U_DatosUser insertaruser = new U_DatosUser();
                    insertaruser.Foto = medico.NombreArchivo;
                    insertaruser.Url = medico.SaveLocation1;
                    insertaruser.Nombres = medico.Nombres;
                    insertaruser.Clave = medico.Clave;
                    insertaruser.Email = medico.Email;
                    insertaruser.Apellidos = medico.Apellidos;
                    insertaruser.Numid = medico.Numid;
                    insertaruser.Session = medico.Session;
                    insertaruser.Especializacion1 = medico.Especializacion1;
                    insertaruser.Rol = 2;
                    insertaruser.Horas = medico.Horas;
                    insertaruser.Session = medico.Session;
                    insertaruser.Estado = 1;
                    /************************************************/
                    user_medico.Apellidos = medico.Apellidos;
                    user_medico.Nombres = medico.Nombres;
                    user_medico.Identificacion = medico.Numid;
                    user_medico.Email = medico.Email;
                    user_medico.Clave = medico.Clave;
                    user_medico.Id_rol = 2;
                    user_medico.Estado = 1;
                    user_medico.Last_modified = DateTime.Now;
                    user_medico.Session = medico.Session;
                    user_medico.Especialidad = medico.Especializacion1;
                    user_medico.Foto = medico.NombreArchivo;
                    user_medico.Url = medico.SaveLocation1;
                    UP_Seguridad seguridad = new UP_Seguridad();
                    seguridad.Id_user = medico.Numid;
                    seguridad.Cantidad_sesiones = 3;
                    seguridad.Sesiones_activas = 0;
                    seguridad.Intentos_erroneos = 0;
                    seguridad.Maximo_intentos = 3;
                    seguridad.Estado = 1;
                    seguridad.Sesion = medico.Session;
                    seguridad.Last_modified = DateTime.Now;

                  estados_medicos estado = new estados_medicos();

                    estado.id_medico = Convert.ToInt32(user_medico.Identificacion);
                    estado.nombre_medico = user_medico.Nombres;
                    estado.apellido_medico = user_medico.Apellidos;
                    estado.estado_agenda = 1;
                    estado.estado_horario = 1;
                    estado.especialidad = user_medico.Especialidad;
                    estado.horas_semana = insertaruser.Horas;
                   
                    new DP_Medicos().insertar_usuario(user_medico,seguridad);
                    new DP_admin().SP_GenerarEstadoMedico(estado);

                    Int32 FORMULARIO = 7;
                    Int32 Idioma = medico.Sessionidioma;
                    Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                    string mensaje;
                    mensaje = compIdioma["MensajeCrearMedicoRegExi"].ToString();

                    medico.Mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"CrearMedicos.aspx\"</script>";
                    //medico.Mensaje = "<script type='text/javascript'>alert('MEDICO REGISTRADO EXITOSAMENTE');window.location=\"CrearMedicos.aspx\"</script>";
                }
            }
            else
            {
                Int32 FORMULARIO = 7;
                Int32 Idioma = medico.Sessionidioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                string mensaje;
                mensaje = compIdioma["MensajeCrearMedicoYaReg"].ToString();

                medico.Mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"CrearMedicos.aspx\"</script>";
                //medico.Mensaje = "<script type='text/javascript'>alert('IDENTIFICACIÓN O EMAIL YA ESTAN REGISTRADOS EN EL SISTEMA INGRESE OTRO POR FAVOR');window.location=\"CrearMedicos.aspx\"</script>";
            }
        }
    }
}