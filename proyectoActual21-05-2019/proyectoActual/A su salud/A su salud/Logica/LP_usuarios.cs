using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Datos;
using System.Collections;
using System.IO;
using System.Data;

namespace Logica
{
    public class LP_usuarios
    {
        public List<UP_usuarios> traer_usuarios(int id)
        {
            DP_usuarios dp = new DP_usuarios();
            return dp.obtener_usuarios(id);
        }

        public List<UP_Seguridad> traeruser()
        {
           return  new DP_Seguridad().traerUsuarios();
        }


        public List<UP_usuarios>traer_todos_usuarios()
        {
            DP_usuarios dp = new DP_usuarios();
            return dp.obtener_pacientes();
        }

        public void actualizar_usuario(UP_usuarios user_actualizado)
        {
            DateTime fecha = new DateTime();
            List<UP_usuarios> lista = new List<UP_usuarios>();
            UP_usuarios obj_old = new UP_usuarios();
            lista = traer_usuarios((int)user_actualizado.Id);
            foreach (UP_usuarios ob in lista)
            {
                obj_old.Id = ob.Id;
                obj_old.Apellidos = ob.Apellidos;
                obj_old.Nombres = ob.Nombres;
                obj_old.Identificacion = ob.Identificacion;
                obj_old.Email = ob.Email;
                obj_old.Clave = ob.Clave;
                obj_old.Id_rol = ob.Id_rol;
                obj_old.Session = ob.Session;
                obj_old.Estado = ob.Estado;
                obj_old.Last_modified = ob.Last_modified;
                obj_old.Especialidad = ob.Especialidad;
                obj_old.Url = ob.Url;
                obj_old.Foto = ob.Foto;
            }
            DP_usuarios dp = new DP_usuarios();
            UP_usuarios obj_new = new UP_usuarios();
            obj_new.Id = obj_old.Id;
            obj_new.Apellidos = user_actualizado.Apellidos;
            obj_new.Nombres = user_actualizado.Nombres;
            obj_new.Identificacion = obj_old.Identificacion;
            obj_new.Email = user_actualizado.Email;
            obj_new.Clave = user_actualizado.Clave;
            obj_new.Id_rol = obj_old.Id_rol;
            obj_new.Session = obj_old.Session;
            obj_new.Estado = obj_old.Estado;
            obj_new.Last_modified = DateTime.Now;
            obj_new.Especialidad = obj_old.Especialidad;
            obj_new.Url = obj_old.Url;
            obj_new.Foto = obj_old.Foto;
            //            
            if (obj_old.Especialidad == null)
            {
                obj_old.Especialidad = "";
                obj_new.Especialidad = "";
            }
            dp.actualizar_usuario(obj_new, obj_old);
        }
        public List<UP_Historia_Clinica> traer_historia_usuario(int id)
        {
            DP_usuarios dp = new DP_usuarios();
            return dp.obtener_historia_usuario(id);
        }

        public void insertar_usuario(UP_usuarios user)
        {
            DP_usuarios dp = new DP_usuarios();
            dp.insertar_usuario(user);
        }
        public void editar_usuario_perfil_no_hace_nada(UP_usuarios user_actualizado)
        {

        }

        public void actualizar_sesion(UP_Seguridad user_actualizado)
        {
            DP_Seguridad seg = new DP_Seguridad();
            seg.editarSesion(user_actualizado);
        }

        public int obtener_id_user()
        {
            int id_user = 0;
            DP_usuarios user = new DP_usuarios();
            List<UP_usuarios> id = user.obtener_iduser();
            if (id.Count > 0)
            {
                foreach (UP_usuarios ob in id)
                {
                    id_user = (int)ob.Id;
                }
            }
            return id_user;
        }

        public void eliminar_usuario(UP_usuarios user_eliminado)
        {
            DP_usuarios dp = new DP_usuarios();
            //dp.borrar_usuario(user_eliminado);
        }

        public UP_usuarios sacar_usuario_eliminar(List<UP_usuarios> lista)
        {
            UP_usuarios user_actualizado = new UP_usuarios();

            DP_usuarios dp = new DP_usuarios();
            foreach (UP_usuarios obj2 in lista)
            {
                user_actualizado.Id = obj2.Id;
                user_actualizado.Apellidos = obj2.Apellidos;
                user_actualizado.Nombres = obj2.Nombres;
                user_actualizado.Identificacion = obj2.Identificacion;
                user_actualizado.Email = obj2.Email;
                user_actualizado.Clave = obj2.Clave;
                user_actualizado.Id_rol = obj2.Id_rol;
                user_actualizado.Session = obj2.Session;
                user_actualizado.Estado = obj2.Estado;
                user_actualizado.Last_modified = obj2.Last_modified;
                user_actualizado.Especialidad = obj2.Especialidad;
                user_actualizado.Foto = obj2.Foto;
                user_actualizado.Url = obj2.Url;
            }
            if (user_actualizado.Especialidad == null)
            {
                user_actualizado.Especialidad = "no hay";
            }
            dp.borrar_usuario((int)user_actualizado.Id, user_actualizado.Identificacion, user_actualizado);
            return user_actualizado;
        } 
        
        public void eliminar_foto_carpeta(string rutaprueba)
        {

        }
        
        public UP_usuarios sacar_usuario_eliminar(List<UP_usuarios> lista, string urlaborrar)
        {
            UP_usuarios user_actualizado = new UP_usuarios();
            foreach (UP_usuarios obj2 in lista)
            {
                user_actualizado.Id = obj2.Id;
                user_actualizado.Apellidos = obj2.Apellidos;
                user_actualizado.Nombres = obj2.Nombres;
                user_actualizado.Identificacion = obj2.Identificacion;
                user_actualizado.Email = obj2.Email;
                user_actualizado.Clave = obj2.Clave;
                user_actualizado.Id_rol = obj2.Id_rol;
                user_actualizado.Session = obj2.Session;
                user_actualizado.Estado = obj2.Estado;
                user_actualizado.Last_modified = obj2.Last_modified;
                user_actualizado.Especialidad = obj2.Especialidad;
                user_actualizado.Foto = obj2.Foto;
                user_actualizado.Url = obj2.Url;

                DP_usuarios dp = new DP_usuarios();
                dp.borrar_usuario((int)user_actualizado.Id, urlaborrar);
            }
            return user_actualizado;
        }

        public void actualizar_foto_perfil(string ruta_a_buscar, string ruta, int id_user, U_foto foto, U_DatosUser actu, string ruta_antiguafoto, string nombre, int id_rol)
        {
            LP_Medicos lp = new LP_Medicos();
            if (System.IO.File.Exists(ruta_a_buscar))
            {
                switch (id_rol)
                {
                    case 1:
                        Int32 FORMULARIO = 26;
                        Int32 Idioma = actu.Sessionidioma;
                        Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                        string mensaje;
                        mensaje = compIdioma["MensajeErrorRegistro"].ToString();

                        actu.Mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"PrincipalAdmin.aspx\"</script>";
                        break;
                    case 2:
                        Int32 FORMULARIO1 = 26;
                        Int32 Idioma1 = actu.Sessionidioma;
                        Hashtable compIdioma1 = new L_Idioma().obtenerIdioma(FORMULARIO1, Idioma1);
                        string mensaje1;
                        mensaje1 = compIdioma1["MensajeErrorRegistro"].ToString();

                        actu.Mensaje = "<script type='text/javascript'>alert('" + mensaje1 + "');window.location=\"PrincipalMedico.aspx\"</script>";
                        break;
                    case 3:
                        Int32 FORMULARIO2 = 26;
                        Int32 Idioma2 = actu.Sessionidioma;
                        Hashtable compIdioma2 = new L_Idioma().obtenerIdioma(FORMULARIO2, Idioma2);
                        string mensaje2;
                        mensaje2 = compIdioma2["MensajeErrorRegistro"].ToString();

                        actu.Mensaje = "<script type='text/javascript'>alert('" + mensaje2 + "');window.location=\"PrincipalPaciente.aspx\"</script>";
                        break;
                    default:
                        //No haga nada
                        break;
                }
            }
            else
            {
                actu.Ruta = ruta;
                string rutaa = foto.Ruta;
                string archivoo = foto.Archivo;
                lp.actualizacion_previa_foto(id_user, foto.Ruta, foto.Archivo);
                File.Delete(ruta_antiguafoto);
                switch (id_rol)
                {
                    case 1:
                        Int32 FORMULARIO = 26;
                        Int32 Idioma = actu.Sessionidioma;
                        Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                        string mensaje;
                        mensaje = compIdioma["MensajeRegistroExitoso"].ToString();

                        actu.Mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"PrincipalAdmin.aspx\"</script>";
                        break;
                    case 2:
                        Int32 FORMULARIO1 = 26;
                        Int32 Idioma1 = actu.Sessionidioma;
                        Hashtable compIdioma1 = new L_Idioma().obtenerIdioma(FORMULARIO1, Idioma1);
                        string mensaje1;
                        mensaje1 = compIdioma1["MensajeRegistroExitoso"].ToString();

                        actu.Mensaje = "<script type='text/javascript'>alert('" + mensaje1 + "');window.location=\"PrincipalMedico.aspx\"</script>";
                        break;
                    case 3:
                        Int32 FORMULARIO2 = 26;
                        Int32 Idioma2 = actu.Sessionidioma;
                        Hashtable compIdioma2 = new L_Idioma().obtenerIdioma(FORMULARIO2, Idioma2);
                        string mensaje2;
                        mensaje2 = compIdioma2["MensajeRegistroExitoso"].ToString();
                        actu.Mensaje = "<script type='text/javascript'>alert('" + mensaje2 + "');window.location=\"PrincipalPaciente.aspx\"</script>";
                        break;
                    default:
                        //No haga nada
                        break;
                }
            }
        }
    }
}
