using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Linq;
using Utilitarios;

namespace Datos
{
    public class DP_usuarios
    {
        public void almacenarToken(UP_TokenRecuperacion token)
        {
            using (var db = new Mapeo("usuarios"))
            {
                db.token.Add(token);
                db.SaveChanges();
            }
        }

        public List<UP_usuarios> obtener_usuarios(int id)
        {
            using (var db = new Mapeo("usuarios"))
            {
                var usuario = db.usuario_medico.Where(x => x.Id == id).ToList<UP_usuarios>();
                return usuario.ToList<UP_usuarios>();
            }
        }

        public List<UP_usuarios> obtener_usuarios(long identificacion)
        {
            using (var db = new Mapeo("usuarios"))
            {
                var usuario = db.usuario_medico.Where(x => x.Identificacion == identificacion).ToList<UP_usuarios>();
                return usuario.ToList<UP_usuarios>();
            }
        }

        public List<UP_usuarios> obtener_iduser()
        {
            using (var db = new Mapeo("usuarios"))
            {
                var usuario = db.usuario_medico.Where(x => x.Estado == 2).ToList<UP_usuarios>();
                return usuario.ToList<UP_usuarios>();
            }
        }

        public List<UP_Historia_Clinica> obtener_historia_usuario(int id)
        {
            using (var db = new Mapeo("medico"))
            {
                var usuario = db.historia.Where(x => x.Documento_paciente == id).ToList<UP_Historia_Clinica>();
                return usuario.ToList<UP_Historia_Clinica>();
            }
        }

        public List<UP_usuarios> obtener_pacientes()
        {
            using (var db = new Mapeo("usuarios"))
            {
                var pacientes = db.usuario_medico.Where(x => x.Id_rol == 3).ToList<UP_usuarios>();
                return pacientes.ToList<UP_usuarios>();
            }
        }
        

        public void insertar_usuario(UP_usuarios datos)
        {
            using (var db = new Mapeo("usuarios"))
            {
                db.usuario_medico.Add(datos);
                db.SaveChanges();
            }
        }

        public void actualizar_usuario(UP_usuarios datos_actualizar, UP_usuarios old)
        {
            using (var db = new Mapeo("usuarios"))
            {
                DP_Auditoria auditoria = new DP_Auditoria();
                UP_Acceso acceso = new UP_Acceso();
                acceso.Id = Convert.ToInt16(datos_actualizar.Id);
                acceso.Session = datos_actualizar.Session;
                db.usuario_medico.Attach(datos_actualizar);

                var entry = db.Entry(datos_actualizar);
                entry.State = EntityState.Modified;
                auditoria.update(datos_actualizar,old,acceso,"usuarios","usuarios");
                db.SaveChanges();
            }
        }

        public void borrar_usuario(int id, long identificacion, UP_usuarios user)
        {
            using (var db = new Mapeo("usuarios"))
            {
                DP_Auditoria auditoria = new DP_Auditoria();
                UP_Acceso acceso = new UP_Acceso();
                var usuario = db.usuario_medico.Where(x => x.Id == id).FirstOrDefault();
                var seguridad = db.seguridad.Where(x => x.Id_user == identificacion).FirstOrDefault();
                var estados_pacientes = db.estados_pacientes.Where(x => x.Id_usuario == id).FirstOrDefault();
                eliminar_datos_citas_medico(id);
                acceso.Id = Convert.ToInt32(user.Id);
                acceso.Session = user.Session;
                db.usuario_medico.Remove(usuario);
                db.seguridad.Remove(seguridad);
                if(estados_pacientes != null)
                {
                    db.estados_pacientes.Remove(estados_pacientes);
                }
                auditoria.delete(user,acceso,"usuarios","usuarios");
                db.SaveChanges();
            }
        }
        //borrar usuario tabla citas medicas
        public void eliminar_datos_citas_medico(int id)
        {
            using (var db = new Mapeo("medico"))
            {
                List<U_CitasMedicas> eliminar_citas = db.citas.Where(x => x.Id_paciente == id).ToList<U_CitasMedicas>();
                if (eliminar_citas.Count > 0)
                {
                    foreach (U_CitasMedicas borrar in eliminar_citas)
                    {
                        db.citas.Remove(borrar);
                        db.SaveChanges();
                    }
                }
            }
        }
        public List<U_ControlesIdiomas> obtenerIdioma(U_ControlesIdiomas idioma)
        {
            using (var db = new Mapeo("idioma"))
            {
                var idioma_obtenido = db.controles.Where(x => x.Formulario_id == idioma.Formulario_id 
                && x.Idioma_id == idioma.Idioma_id).ToList<U_ControlesIdiomas>();
                return idioma_obtenido.ToList<U_ControlesIdiomas>();
            }
        }

        public string borrar_foto_al_actualizar(int id)
        {
            using (var db = new Mapeo("usuarios"))
            {
                var foto = db.usuario_medico.Where(x => x.Id == id).Select(x => x.Url);
                string urlaborrar;
                urlaborrar = foto.ToString();
                return urlaborrar;
            }
        }

        public void borrar_usuario(int id, string urlaborrar)
        {
            using (var db = new Mapeo("usuarios"))
            {
                var usuario = db.usuario_medico.Where(x => x.Id == id).FirstOrDefault();
                db.usuario_medico.Remove(usuario);
                db.SaveChanges();
                
            }
        }

        public List<UP_Historia_Clinica> reporteHistoriaClinica(int id)
        {
            using (var db = new Mapeo("medico"))
            {
                var usuario = db.historia.Where(x => x.Id == id).ToList<UP_Historia_Clinica>();
                return usuario.ToList<UP_Historia_Clinica>();
            }
        }

        public void actualizarContraseña(UP_usuarios user)
        {
            using (var db = new Mapeo("usuarios"))
            {
                var usuario = db.token.Where(x => x.User_id == user.Id).FirstOrDefault();
                db.token.Remove(usuario);

                var resul = db.usuario_medico.SingleOrDefault(y => y.Id == user.Id);
                resul.Estado = 1;
                resul.Clave = user.Clave;
                db.SaveChanges();
            }
        }

        public int validacion_recuperar_bloqueo(U_Usuario obj)
        {
            int estado = 0;
            using (var db = new Mapeo("usuarios"))
            {

                var lista = db.usuario_medico.Where(x => x.Id == obj.UserId).ToList<UP_usuarios>();
                foreach (UP_usuarios obj2 in lista)
                {
                    obj2.Estado = estado;
                }
                return estado;
            }
        }

        public void cerrarSesion(UP_Autenticacion obj)
        {
            using (var db = new Mapeo("autenication"))
            {

                var resul = db.autenticacion.FirstOrDefault(x => x.Session == obj.Session);
                resul.Fecha_fin = DateTime.Now;
                db.SaveChanges();
            }
        }
       
        public void guardar_Sesion(UP_Autenticacion datos)
        {
            using (var db = new Mapeo("security"))
            {
                db.autenticacion.Add(datos);
                db.SaveChanges();
            }
        }

        public List<UP_usuarios> loggin(UP_usuarios user)
        {
            using (var db = new Mapeo("usuarios"))
            {
                var usuario = db.usuario_medico.Where(x => x.Identificacion == user.Identificacion && x.Clave==user.Clave && x.Estado == 1).ToList<UP_usuarios>();
                return usuario.ToList<UP_usuarios>();
            }
        }

        public int Validar_usuario(long identificacion)
        {
            using (var db = new Mapeo("usuarios"))
            {
                UP_usuarios user = new UP_usuarios();
                user.Identificacion = identificacion;

                DateTime fecha = DateTime.Now;
   
                var consulta = db.usuario_medico.Where(x => x.Identificacion == user.Identificacion).ToList<UP_usuarios>();
                var consulta2 = (from u in db.usuario_medico
                              join t in db.token
                              on u.Id equals t.User_id
                              where t.User_id!=null
                              select new
                              {
                                  ID = u.Id,
                                  ident = u.Identificacion,
                                  token = t.Token,
                                  fechacreaado = t.Fecha_creado,
                                  fechavigendia = t.Fecha_vigencia
                              }).ToList();

                if (consulta.Count == 0)
                    return -1;
                
                else if (consulta2.Count>0)
                    return -2;
                
                else if (consulta.Count > 0)
                {
                    var resul = db.usuario_medico.FirstOrDefault(x => x.Identificacion == identificacion);
                    resul.Estado = 2;
                    var aux = db.usuario_medico.Where(x => x.Identificacion == user.Identificacion).ToList<UP_usuarios>();
                    db.SaveChanges();
                    return 1;
                }
                else
                    return -1;
                /*(SELECT COUNT(*) FROM usuarios.usuarios uu join usuarios.token_repureacion_usuario ut on ut.user_id = uu.id 
                 * WHERE uu.identificacion =_identificacion and current_timestamp between ut.fecha_creado AND ut.fecha_vigencia) > 0*/
            }
        }

        public int ObtenerUsuarioToken(string token)
        {
            using (var db = new Mapeo("usuarios"))
            {
                DateTime fecha = DateTime.Now;
                var consulta = db.token.Where(x => x.Token == token).ToList<UP_TokenRecuperacion>();
                var consulta2 = db.token.Where(x => x.Token == token && fecha>=x.Fecha_creado && fecha<=x.Fecha_vigencia).ToList<UP_TokenRecuperacion>();
               
                 if (consulta.Count == 0)
                        return -1;
                 else if (consulta2.Count == 0)
                 {
                        var usuario = db.token.Where(x => x.Token == token).FirstOrDefault();
                        db.token.Remove(usuario);
                        db.SaveChanges();
                        return -2;
                 }
                else
                {
                    var columna = db.token.Where(x=>x.Token== token).Select(x => x.User_id).ToList();
                    return 0;
                }
            }
        }

        public List<UP_TokenRecuperacion> ObtenerUserId(String token)
        {
            using (var db = new Mapeo("usuarios"))
            {
                var columna = db.token.Where(x => x.Token == token).Select(x => x.User_id).ToList();
                return db.token.ToList();
            }
        }
        public int ObtenerEstadoUsuario(long identificacion)
        {
            using (var db = new Mapeo("usuarios"))
            {
                var query = db.usuario_medico.Where(x => x.Identificacion == identificacion).Select(x => x.Estado).ToList();
                List<int> user = query;
                UP_usuarios aux = new UP_usuarios();
                int estado = 0;
                foreach (int obj in user)
                {
                    aux.Estado = obj;
                }
                estado = aux.Estado;
                return estado;
            }
        }
        public void SP_DesbloquearUsuario(long identificacion)
        {
            using (var db = new Mapeo("usuarios"))
            {
                var query = db.Database.ExecuteSqlCommand("usuarios.SP_DesbloquearUsuario @id_user",
                    new SqlParameter("@id_user", identificacion));
                db.SaveChanges();
            }
        }

        public string recibir_mensaje(string mensaje)
        {

            return mensaje;
        }




    }
}
