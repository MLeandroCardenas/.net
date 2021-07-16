using System;
using System.Collections.Generic;
using System.Linq;
using Utilitarios;
using System.Data.Entity;
using Datos;

namespace Datos
{
    public class DP_Medicos
    {
        public List<UP_usuarios> traer_medicos(int id)
        {
            using (var db = new Mapeo("usuarios"))
            {
                var medicos = db.usuario_medico.Where(x => x.Id == id).ToList<UP_usuarios>();
                return medicos.ToList<UP_usuarios>();
            }
        }

        public List<UP_usuarios>traer_todos_los_medicos()
        {
            using (var db = new Mapeo("usuarios"))
            {
                var medicos = db.usuario_medico.Where(x => x.Id_rol == 2).ToList<UP_usuarios>();
                return medicos.ToList<UP_usuarios>();
            }
        }

        public List<UP_Especialidades> obtenerEspecialidades2()
        {
            using (var db = new Mapeo("medico"))
            {
                var especialidades = db.especialidad.ToList<UP_Especialidades>();
                return especialidades.ToList<UP_Especialidades>();
            }
        }

        public void enviarMensajes(UP_Pqr datos)
        {
            using (var db = new Mapeo("administrador"))
            {
                db.pqr.Add(datos);
            }
        }

        public void actualizar_usuario(UP_usuarios datos_actualizar)
        {
            using (var db = new Mapeo("usuarios"))
            {
                db.usuario_medico.Attach(datos_actualizar);

                var entry = db.Entry(datos_actualizar);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void borrar_usuario(int id)
        {
            
            using (var db = new Mapeo("usuarios"))
            {
                var usuario = db.usuario_medico.Where(x => x.Id == id).FirstOrDefault();
                db.usuario_medico.Remove(usuario);
                db.SaveChanges();
            }
        }

        public void borrar_Especialidades(UP_Especialidades ESPE)
        {

            using (var db = new Mapeo("medico"))
            {
              UP_Especialidades especial = db.especialidad.Find(ESPE.Id);
                db.especialidad.Remove(especial);
                db.SaveChanges();
            }
        }



        public List<U_AgendaMedico> traer_agenda_medico(int id)
        {
            DateTime fecha = new DateTime();
            fecha = DateTime.Now;
            using (var db = new Mapeo("medico"))
            {
                var agenda = db.agenda.Where(x => x.Medico_id == id).ToList<U_AgendaMedico>();
                return agenda.ToList<U_AgendaMedico>();
            }
        }

        public List<U_AgendaMedico> traer_agenda_medico_modificar(int id)
        {
            DateTime fecha = new DateTime();
            fecha = DateTime.Now;
            using (var db = new Mapeo("medico"))
            {
                var agenda = db.agenda.Where(x => x.Medico_id == id && x.Fecha_inicio>DateTime.Now).ToList<U_AgendaMedico>();
                return agenda.ToList<U_AgendaMedico>();
            }
        }

        public void actualizacion_previa(String ruta,string nombre,int id)
        {
            DP_Auditoria auditoria = new DP_Auditoria();
            UP_Acceso acceso = new UP_Acceso();
            UP_usuarios ob = new UP_usuarios();
            List<UP_usuarios> lista = new List<UP_usuarios>();
            lista=traer_medicos(id);
            foreach (UP_usuarios obj in lista)
            {
                ob.Id = obj.Id;
                ob.Apellidos = obj.Apellidos;
                ob.Nombres = obj.Nombres;
                ob.Identificacion = obj.Identificacion;
                ob.Email = obj.Email;
                ob.Clave = obj.Clave;
                ob.Id_rol = obj.Id_rol;
                ob.Session = obj.Session;
                ob.Estado = obj.Estado;
                ob.Last_modified = obj.Last_modified;
                ob.Especialidad = obj.Especialidad;
                ob.Foto = obj.Foto;
                ob.Url = obj.Url;
            }
            //auditoria
            UP_usuarios new_obj = new UP_usuarios();
            new_obj.Id = ob.Id;
            new_obj.Apellidos = ob.Apellidos;
            new_obj.Nombres = ob.Nombres;
            new_obj.Identificacion = ob.Identificacion;
            new_obj.Email = ob.Email;
            new_obj.Clave = ob.Clave;
            new_obj.Id_rol = ob.Id_rol;
            new_obj.Session = ob.Session;
            new_obj.Estado = ob.Estado;
            new_obj.Last_modified = ob.Last_modified;
            new_obj.Especialidad = ob.Especialidad;
            new_obj.Foto = nombre;
            new_obj.Url = ruta + nombre;

            //acceso
            acceso.Id = Convert.ToInt32(new_obj.Id);
            acceso.Session = new_obj.Session;
            using (var db = new Mapeo("usuarios"))
            {
                db.usuario_medico.Attach(new_obj);

                var entry = db.Entry(new_obj);
                entry.State = EntityState.Modified;
                db.SaveChanges();
                auditoria.update(new_obj, ob, acceso,"usuarios","usuarios");

            }
        }

        public List<UP_Especialidades> validarEspecialidad(UP_Especialidades especialidad)
        {
            using (var db = new Mapeo("medico"))
            {
                var validacion = db.especialidad.Where(x => x.Nombre == especialidad.Nombre).ToList<UP_Especialidades>();
                return validacion.ToList<UP_Especialidades>();
            }
        }


        public void insertar_Especialidad(UP_Especialidades datos)
        {
            using (var db = new Mapeo("medico"))
            {
                DP_Auditoria auditoria = new DP_Auditoria();
                UP_Acceso acceso = new UP_Acceso();
                db.especialidad.Add(datos);
                acceso.Id = datos.Id;
                acceso.Session = datos.Session;
                auditoria.insert(datos,acceso, "medico", "especialidades");
                db.SaveChanges();
            }
        }

        public List<UP_usuarios> validar_identificacionCorreo(UP_usuarios usuario)
        {
            using (var db = new Mapeo("usuarios"))
            {
                var iden_correo = db.usuario_medico.Where(x => x.Identificacion == usuario.Identificacion || x.Email == usuario.Email).ToList<UP_usuarios>();
                return iden_correo.ToList<UP_usuarios>();
            }
        }

        public void insertar_usuario(UP_usuarios datos,UP_Seguridad segu)
        {
            using (var db = new Mapeo("usuarios"))
            {
                DP_Auditoria auditoria = new DP_Auditoria();
                UP_Acceso acceso = new UP_Acceso();
                acceso.Id = Convert.ToInt16(datos.Id);
                acceso.Session = datos.Session;
                db.usuario_medico.Add(datos);
                db.SaveChanges();
                db.seguridad.Add(segu);
                db.SaveChanges();
                auditoria.insert(datos,acceso,"usuarios","usuarios");
            }
        }        
        public void borrar_medico(int id, string urlaborrar)
        {
            using (var db = new Mapeo("usuarios"))
            {
                DP_Auditoria auditoria = new DP_Auditoria();
                UP_Acceso acceso = new UP_Acceso();
                UP_usuarios usuario = new UP_usuarios();
                new DP_admin().borrar_medico(id);

                /*var medico = db.usuario_medico.Where(x => x.Id == id).FirstOrDefault();
                List<UP_usuarios> e = new List<UP_usuarios>();
                e = traer_medicos(id);
                foreach (UP_usuarios obj in e)
                {
                    usuario.Id = obj.Id;
                    usuario.Session = obj.Session;
                }
                acceso.Id = Convert.ToInt16(usuario.Id);
                acceso.Session = usuario.Session;
                auditoria.delete(medico,acceso,"usuarios","usuarios");
                db.usuario_medico.Remove(medico);
                db.SaveChanges();*/                
            }
        }
        public List<U_ControlesIdiomas> obtenerControles(int id)
        {
            using (var db = new Mapeo("idioma"))
            {
                var medicos = db.controles.Where(x => x.Id == id).ToList<U_ControlesIdiomas>();
                return medicos.ToList<U_ControlesIdiomas>();
            }
        }

        public List<U_ControlesIdiomas> ValidarControl(U_ControlesIdiomas aux)
        {
            using (var db = new Mapeo("idioma"))
            {
                var medicos = db.controles.Where(x => x.Control.Contains(aux.Control) && x.Idioma_id == aux.Idioma_id).ToList<U_ControlesIdiomas>();
                return medicos.ToList<U_ControlesIdiomas>();
            }
        }

        public List<U_CitasMedicas> reportePaciente(int id)
        {
            using (var db = new Mapeo("medico"))
            {
                U_CitasMedicas citas = new U_CitasMedicas();
                var agenda = db.citas.Where(x => x.Id_medico == id).ToList<U_CitasMedicas>();
                foreach (U_CitasMedicas obj in agenda)
                {
                    citas.Nombre_paciente = obj.Nombre_paciente;
                    citas.Apellido_paciente = obj.Apellido_paciente;
                    citas.Documento = obj.Documento;
                }
                return agenda.ToList<U_CitasMedicas>();
            }
        }
    }
}
