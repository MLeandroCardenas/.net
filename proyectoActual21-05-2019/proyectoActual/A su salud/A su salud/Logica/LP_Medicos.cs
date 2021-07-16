using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilitarios;
using Datos;
using System.Threading.Tasks;

namespace Logica
{
    public class LP_Medicos
    {
        public List<UP_usuarios> traer_usuarios(int id)
        {
            DP_Medicos dp = new DP_Medicos();
            return dp.traer_medicos(id);
        }

        public List<UP_usuarios> traer_medicos()
        {
            DP_Medicos dp = new DP_Medicos();
            return dp.traer_todos_los_medicos();
        }

        public void insertar_usuario(UP_usuarios user,UP_Seguridad segu)
        {
            DP_Medicos dp = new DP_Medicos();
            dp.insertar_usuario(user,segu);
        }
        
        public void actualizar_usuario(UP_usuarios user_actualizado)
        {
            List<UP_usuarios> lista = new List<UP_usuarios>();
            UP_usuarios obj2 = new UP_usuarios();
            lista = traer_usuarios((int)user_actualizado.Id);
            foreach (UP_usuarios ob in lista)
            {
                obj2.Id = ob.Id;
                obj2.Id_rol = ob.Id_rol;
                obj2.Session = ob.Session;
                obj2.Estado = ob.Estado;
                obj2.Last_modified = ob.Last_modified;
                obj2.Especialidad = ob.Especialidad;
                obj2.Url = ob.Url;
            }
            DP_Medicos dp = new DP_Medicos();
            DateTime fecha = new DateTime();
            fecha = DateTime.Now;
            string fechalm = fecha.ToString();
            user_actualizado.Id = obj2.Id;
            user_actualizado.Id_rol = obj2.Id_rol;
            user_actualizado.Session = obj2.Session;
            user_actualizado.Estado = obj2.Estado;
            user_actualizado.Last_modified = fecha;
            user_actualizado.Especialidad = obj2.Especialidad;
            user_actualizado.Foto = obj2.Foto;
            user_actualizado.Url = obj2.Url;
            dp.actualizar_usuario(user_actualizado);
        }

        public void eliminar_usuario(UP_usuarios user_eliminado)
        {
            DP_Medicos dp = new DP_Medicos();
            //dp.borrar_usuario(user_eliminado);
        }

        public List<U_AgendaMedico> traer_agenda(int id)
        {
            DP_Medicos dp = new DP_Medicos();
            return dp.traer_agenda_medico(id);
            
        }

        public List<U_AgendaMedico> traer_agenda_modificar(int id)
        {
            DP_Medicos dp = new DP_Medicos();
            return dp.traer_agenda_medico_modificar(id);

        }


        public UP_usuarios sacar_usuario_eliminar(List<UP_usuarios>lista)
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
                user_actualizado.Last_modified = obj2.Last_modified ;
                user_actualizado.Especialidad = obj2.Especialidad;
                user_actualizado.Foto = obj2.Foto;
                user_actualizado.Url = obj2.Url;
                DP_Medicos dp = new DP_Medicos();
                dp.borrar_usuario((int)user_actualizado.Id);
            }
            return user_actualizado;
        }

        public U_foto traer_ruta(String nombre)
        {
            U_foto archivo = new U_foto();
            //Editarproductoadmin archivo = new Editarproductoadmin();

            if (nombre.Equals(""))
            {
                archivo = null;//  e.NewValues.Insert(3, "descripcion", ((Image)row.FindControl("I_EProducto")).ImageUrl);
            }
            else
            {
                if (System.IO.Path.GetExtension(nombre).Equals(".jpg") || System.IO.Path.GetExtension(nombre).Equals(".jpeg")
                    || System.IO.Path.GetExtension(nombre).Equals(".bmp") || System.IO.Path.GetExtension(nombre).Equals(".gif")
                    || System.IO.Path.GetExtension(nombre).Equals(".png"))
                {
                    
                    archivo.Ruta = "~\\Archivos\\imagenes\\";
                    archivo.Archivo = nombre;
                    //actualizacion_previa_foto(archivo);

                }

            }

            return archivo;
        }

        public void actualizacion_previa_foto(int id,string ruta,string archivo)
        {
            DP_Medicos dp = new DP_Medicos();
            dp.actualizacion_previa(ruta,archivo,id);
        }
        public void editar_medico_perfil_no_hace_nada(int id, string apellido, string clave, string nombres)
        {

        }


        public void traer_ruta_antigua(UP_usuarios user_actualizado)
        {
            List<UP_usuarios> lista = new List<UP_usuarios>();
            UP_usuarios obj2 = new UP_usuarios();
            lista = traer_usuarios((int)user_actualizado.Id);
            foreach (UP_usuarios ob in lista)
            {
                obj2.Url = ob.Url;
            }
            DP_Medicos dp = new DP_Medicos();
            user_actualizado.Foto = obj2.Foto;
            user_actualizado.Url = obj2.Url;
            dp.actualizar_usuario(user_actualizado);
        }

        public UP_usuarios sacar_medico_eliminar(List<UP_usuarios> lista, string urlaborrar)
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

                DP_Medicos dp = new DP_Medicos();
                dp.borrar_medico((int)user_actualizado.Id, urlaborrar);
            }
            return user_actualizado;
        }  
    }
}
