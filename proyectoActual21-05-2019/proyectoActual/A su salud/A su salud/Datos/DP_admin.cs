using System;
using System.Collections.Generic;
using System.Linq;
using Utilitarios;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Datos
{
    public class DP_admin
    {
        //Especialidad-----ods
        public void borrar_usuario(int id)
        {
            using (var db = new Mapeo("administrador"))
            {
                var especialidad = db.especialidad.Where(x => x.Id == id).FirstOrDefault();
                db.especialidad.Remove(especialidad);
                db.SaveChanges();
            }
        }


        //Especialidad-------

        //MEDICO---------ods

        public void borrar_medico(int id)
        {
            using (var db = new Mapeo("administrador"))
            {
                try
                {
                    DP_Auditoria auditoria = new DP_Auditoria();
                    var pqr = db.pqr.Where(x => x.Id == id).FirstOrDefault();
                    var obj_eliminar = db.pqr.Find(id);
                    UP_Pqr espe = new UP_Pqr();
                    UP_Acceso acceso = new UP_Acceso();
                    DP_Pqr a = new DP_Pqr();
                    List<UP_Pqr> e = new List<UP_Pqr>();
                    e = a.traer_pqr_medicos(id);
                    foreach (UP_Pqr obj in e)
                    {
                        espe.Id = obj.Id;
                        espe.Session = obj.Session;
                    }
                    acceso.Id = (int)espe.Id;
                    acceso.Session = espe.Session;
                    if(obj_eliminar != null)
                    {
                        auditoria.delete(obj_eliminar, acceso, "administrador", "pqrs");
                        db.pqr.Remove(pqr);
                    }
                    //eliminar horario medico
                    eliminar_datos_horario_medico(id);
                    //eliminar estados medico
                    var estados = db.estados.Where(x => x.Ident_medico == id).FirstOrDefault();
                    db.estados.Remove(estados);
                    //eliminar agenda medico
                    eliminar_datos_agenda_medico(id);

                    db.SaveChanges();
                }
                catch (Exception e)
                {

                }
                //db.SaveChanges();
            }

        }

        //borrarmedicostodos los datos de todas las tablas
        public void eliminar_datos_horario_medico(int id)
        {
            using (var db = new Mapeo("administrador"))
            {
                List<UP_datos_horario> eliminar_horario = db.datos_horario.Where(x => x.Id_medico == id).ToList<UP_datos_horario>();

                foreach (UP_datos_horario borrar in eliminar_horario)
                {
                    db.datos_horario.Remove(borrar);
                    db.SaveChanges();
                }
            }
        }

        public void eliminar_datos_agenda_medico(int id)
        {
            using (var db = new Mapeo("medico"))
            {
                List<U_AgendaMedico> eliminar_agenda = db.agenda.Where(x => x.Medico_id == id).ToList<U_AgendaMedico>();

                foreach (U_AgendaMedico borrar in eliminar_agenda)
                {
                    db.agenda.Remove(borrar);
                    db.SaveChanges();
                }
            }
        }

        //Medico--------

        //Pacientes-----ods

        public void borrar_paciente(int id)
        {
            using (var db = new Mapeo("administrador"))
            {
                try
                {
                    var pqr = db.pqr.Where(x => x.Id_usuario == id).FirstOrDefault();
                    DP_Auditoria auditoria = new DP_Auditoria();
                    var obj_eliminar = db.pqr.Find(id);
                    UP_Pqr espe = new UP_Pqr();
                    UP_Acceso acceso = new UP_Acceso();
                    DP_Pqr a = new DP_Pqr();
                    List<UP_Pqr> e = new List<UP_Pqr>();
                    e = a.traer_pqr_medicos(id);
                    foreach (UP_Pqr obj in e)
                    {
                        espe.Id = obj.Id;
                        espe.Session = obj.Session;
                    }
                    acceso.Id = (int)espe.Id;
                    acceso.Session = espe.Session;
                    if (obj_eliminar != null && pqr != null)
                    {
                        auditoria.delete(obj_eliminar, acceso, "administrador", "pqrs");
                        db.pqr.Remove(pqr);
                    }                    
                    //
                    var usuario = db.usuario_medico.Where(x => x.Id == id).FirstOrDefault();
                    var obj_eliminaru = db.usuario_medico.Find(id);
                    UP_usuarios usu = new UP_usuarios();
                    UP_Acceso accesou = new UP_Acceso();
                    DP_usuarios u = new DP_usuarios();
                    List<UP_usuarios> traer = new List<UP_usuarios>();
                    traer = u.obtener_usuarios(id);
                    foreach (UP_usuarios obju in traer)
                    {
                        usu.Id = obju.Id;
                        usu.Session = obju.Session;
                    }
                    accesou.Id = (int)espe.Id;
                    accesou.Session = espe.Session;
                    auditoria.delete(obj_eliminaru, accesou, "usuarios", "usuarios");
                    db.usuario_medico.Remove(usuario);
                    //
                    var estados_pacientes = db.estados_pacientes.Where(x => x.Id_usuario == id).FirstOrDefault();
                    db.estados_pacientes.Remove(estados_pacientes);

                    var agenda = db.agenda.Where(x => x.Usuario_id == id).FirstOrDefault();
                    db.agenda.Remove(agenda);

                    var cita = db.citas.Where(x => x.Id_paciente == id).FirstOrDefault();
                    db.citas.Remove(cita);
                    //
                    var obj_eliminarh = db.historia.Find(id);
                    var historia = db.historia.Where(x => x.Id_paciente == id).FirstOrDefault();
                    UP_Historia_Clinica his = new UP_Historia_Clinica();
                    UP_Acceso accesoh = new UP_Acceso();
                    DP_citas_medicas h = new DP_citas_medicas();
                    List<UP_Historia_Clinica> traerh = new List<UP_Historia_Clinica>();
                    traerh = h.traer_historia_clinica(id);
                    foreach (UP_Historia_Clinica objh in traerh)
                    {
                        usu.Id = Convert.ToInt32(objh.Id);
                        usu.Session = objh.Session;
                    }
                    accesoh.Id = (int)espe.Id;
                    accesoh.Session = espe.Session;
                    auditoria.delete(obj_eliminarh, accesoh, "medico", "historia_clinica");
                    db.historia.Remove(historia);

                    db.SaveChanges();
                }
                catch (Exception e)
                {

                }
                //db.SaveChanges();
            }

        }

        // Citas Especialidad

        public List<UP_Historia_Clinica> validacion(int identificacion)
        {
            using (var db = new Mapeo("administrador"))
            {
                var usuario = db.historia.Where(x => x.Documento_paciente == identificacion && x.Asignar_especialista != "" && x.Estado == null).ToList<UP_Historia_Clinica>();
                return usuario.ToList<UP_Historia_Clinica>();
            }
        }

        //

        //estados pacientes

        public List<UP_estados_pacientes> traer_estado(int id)
        {
            using (var db = new Mapeo("administrador"))
            {
                var estado = db.estados_pacientes.Where(x => x.Id_usuario == id).ToList<UP_estados_pacientes>();
                return estado.ToList<UP_estados_pacientes>();
            }
        }




        //SELECT * FROM medico.agenda_medico WHERE _id=id and usuario_id is null;
        public List<U_AgendaMedico> validar_cita(int id)
        {
            using (var db = new Mapeo("medico"))
            {
                var cita = db.agenda.Where(x => x.Id == id && x.Usuario_id == null).ToList<U_AgendaMedico>();
                return cita.ToList<U_AgendaMedico>();
            }
        }

        //INSERT INTO administrador.estados_pacientes(id_usuario,nombre_paciente,apellido_paciente,identificacion_paciente,estado_cita)
        //VALUES
        //((select id from usuarios.usuarios where _identificacion = identificacion and id_rol = 3),_nombre,_apellido,_identificacion,_estado_cita);


        public void insertar_estado_paciente(U_DatosUser datos)
        {
            UP_estados_pacientes datos2 = new UP_estados_pacientes();
            datos.Id = datos2.Id_usuario;
            datos.Nombrepaciente = datos2.Nombre_paciente;
            datos.Apellidopaciente = datos2.Apellido_paciente;
            datos.Identificacion2 = datos2.Identificacion_paciente;
            datos.Estado = datos2.Estado_cita;
            using (var db = new Mapeo("administrador"))
            {
                db.estados_pacientes.Add(datos2);
                db.SaveChanges();
            }
        }

        //INSERT INTO administrador.estados(id_medico,nombre_medico,apellido_medico,especialidad_medico,estado_horario,ident_medico,estado_agenda,horas_semana)
        //VALUES
        //(_id_medico, _nombre, _apellido, _especialidad, _estado, (select id from usuarios.usuarios where _id_medico = identificacion and id_rol = 2),_estado_agenda,_horas_semana);

        public void crear_estado_medico(U_DatosUser insertaruser, UP_estados estados)
        {
            UP_estados dt = new UP_estados();
            dt = enviar_datos(insertaruser);

            using (var db = new Mapeo("administrador"))
            {
                db.estados.Add(estados);
                db.SaveChanges();
            }
        }

        public UP_estados enviar_datos(U_DatosUser insertaruser)
        {
            UP_estados datos = new UP_estados();
            List<UP_usuarios> lista = new List<UP_usuarios>();
            lista = traer_dato_estado(insertaruser.Numid);
            foreach (UP_usuarios ob in lista)
            {
                datos.Nombre_medico = ob.Nombres;
                datos.Apellido_medico = ob.Apellidos;
                datos.Especialidad = ob.Especialidad;
                datos.Estado_horario = 1;
                datos.Ident_medico = ob.Identificacion;
                datos.Horas_semana = insertaruser.Horas;
                datos.Estado_agenda = 1;
                datos.Id_medico = (int)ob.Id;
            }
            //  datos.Horas_semana = insertaruser.Horas;

            return datos;
        }

        public List<UP_usuarios> traer_dato_estado(long identificacion)
        {
            using (var db = new Mapeo("usuarios"))
            {
                var datos = db.usuario_medico.Where(x => x.Identificacion == identificacion).ToList<UP_usuarios>();
                return datos.ToList<UP_usuarios>();
            }
        }

        //INSERT INTO administrador.datos_horario3 (id_medico,hora_inicio,hora_final,dia) VALUES (_id,_hora_inicio,_hora_final,_dia);
        public void insertar_horario(UP_datos_horario datos)
        {

            using (var db = new Mapeo("administrador"))
            {
                db.datos_horario.Add(datos);
                db.SaveChanges();
            }
        }

        public List<UP_estados> traer_estados(int id)
        {
            using (var db = new Mapeo("administrador"))
            {
                var estado = db.estados.Where(x => x.Id_medico == id).ToList<UP_estados>();
                return estado.ToList<UP_estados>();
            }
        }

        public int traer_estado_horario(int id)
        {
            int estado_h = 0;
            using (var db = new Mapeo("administrador"))
            {
                var estado = db.estados.Where(x => x.Ident_medico == id).ToList<UP_estados>();
                foreach (UP_estados obj in estado)
                {
                    estado_h = obj.Estado_horario;
                }
                return estado_h;
            }
        }
        public int traer_estado_agenda(int id)
        {
            int estado_h = 0;
            using (var db = new Mapeo("administrador"))
            {
                var estado = db.estados.Where(x => x.Ident_medico == id).ToList<UP_estados>();
                foreach (UP_estados obj in estado)
                {
                    estado_h = obj.Estado_agenda;
                }
                return estado_h;
            }
        }

        //UPDATE administrador.estados SET horas_semana=_horas WHERE _id=id_medico;

        public void actualizar_horas(int id, int horas)
        {
            UP_estados esta = new UP_estados();
            List<UP_estados> lista = new List<UP_estados>();
            lista = traer_estados(id);
            foreach (UP_estados ob in lista)
            {
                esta.Id = ob.Id;
                esta.Id_medico = ob.Id_medico;
                esta.Nombre_medico = ob.Nombre_medico;
                esta.Apellido_medico = ob.Apellido_medico;
                esta.Especialidad = ob.Especialidad;
                esta.Estado_horario = ob.Estado_horario;
                esta.Estado_agenda = ob.Estado_agenda;
                esta.Ident_medico = ob.Ident_medico;
                esta.Horas_semana = ob.Horas_semana;
            }
            esta.Horas_semana = horas;
            using (var db = new Mapeo("administrador"))
            {
                db.estados.Attach(esta);

                var actualizacion = db.Entry(esta);
                actualizacion.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        

        public int? traer_horas_medico(int id)
        {
            int? horas = 0;
            using (var db = new Mapeo("administrador"))
            {
                var estado = db.estados.Where(x => x.Ident_medico == id).ToList<UP_estados>();
                List<UP_estados> lista = new List<UP_estados>();
                lista = estado;
                foreach (UP_estados consulta in lista)
                {
                    horas = consulta.Horas_semana;
                }
                return horas;
            }

        }

        public void actualizar_estado_agenda(int id)
        {
            UP_estados estado = new UP_estados();
            List<UP_estados> lista_datos = new List<UP_estados>();
            using (var consulta_estado = new Mapeo("administrador"))
            {
                var estado_medico = consulta_estado.estados.Where(x => x.Ident_medico == id).ToList<UP_estados>();
                lista_datos = estado_medico.ToList<UP_estados>();
            }
            foreach (UP_estados obj in lista_datos)
            {
                estado.Id = obj.Id;
                estado.Id_medico = obj.Id_medico;
                estado.Ident_medico = obj.Ident_medico;
                estado.Nombre_medico = obj.Nombre_medico;
                estado.Apellido_medico = obj.Apellido_medico;
                estado.Especialidad = obj.Especialidad;
                estado.Estado_agenda = obj.Estado_agenda;
                estado.Estado_horario = obj.Estado_horario;
                estado.Horas_semana = obj.Horas_semana;
            }
            estado.Estado_agenda = 2;

            using (var estado_medico = new Mapeo("administrador"))
            {
                estado_medico.estados.Attach(estado);

                var actualizacion = estado_medico.Entry(estado);
                actualizacion.State = EntityState.Modified;
                estado_medico.SaveChanges();
            }

        }

        public void actualizar_estado_horario(int id)
        {
            UP_estados estado = new UP_estados();
            List<UP_estados> lista_datos = new List<UP_estados>();
            using (var consulta_estado = new Mapeo("administrador"))
            {
                var estado_medico = consulta_estado.estados.Where(x => x.Ident_medico == id).ToList<UP_estados>();
                lista_datos = estado_medico.ToList<UP_estados>();
            }
            foreach (UP_estados obj in lista_datos)
            {
                estado.Id = obj.Id;
                estado.Id_medico = obj.Id_medico;
                estado.Ident_medico = obj.Ident_medico;
                estado.Nombre_medico = obj.Nombre_medico;
                estado.Apellido_medico = obj.Apellido_medico;
                estado.Especialidad = obj.Especialidad;
                estado.Horas_semana = obj.Horas_semana;
                estado.Estado_agenda = obj.Estado_agenda;
                estado.Estado_horario = obj.Estado_horario;
            }
            estado.Estado_horario = 2;

            using (var estado_medico = new Mapeo("administrador"))
            {
                estado_medico.estados.Attach(estado);

                var actualizacion = estado_medico.Entry(estado);
                actualizacion.State = EntityState.Modified;
                estado_medico.SaveChanges();
            }

        }

        public List<UP_usuarios> traer_datos_medico(int id)
        {
            using (var consulta_medico = new Mapeo("usuarios"))
            {
                //UP_usuarios datos = new UP_usuarios();
                var datos = consulta_medico.usuario_medico.Where(x => x.Id == id).ToList<UP_usuarios>();
                return datos.ToList<UP_usuarios>();
            }
        }

        public void insertar_cita_agenda(U_AgendaMedico datos)
        {
            using (var insercion = new Mapeo("usuarios"))
            {
                insercion.agenda.Add(datos);
                insercion.SaveChanges();

            }
        }


        public int consulta_estado_horario(int id)
        {
            int estado_horario = 0;
            using (var db = new Mapeo("administrador"))
            {
                var estado = db.estados.Where(x => x.Ident_medico == id).ToList<UP_estados>();
                List<UP_estados> lista = new List<UP_estados>();
                lista = estado;
                foreach (UP_estados consulta in lista)
                {
                    estado_horario = consulta.Estado_horario;

                }
                return estado_horario;
            }
        }

        public List<UP_estados> traer_medico_con_horario()
        {
            //int estado_horario = 0;
            using (var db = new Mapeo("administrador"))
            {
                var estado = db.estados.Where(x => x.Estado_horario == 2 && x.Estado_agenda == 1).ToList<UP_estados>();
                return estado;
            }
        }

        public List<UP_estados> traer_medico_sin_horario()
        {
            //int estado_horario = 0;
            using (var db = new Mapeo("administrador"))
            {
                var estado = db.estados.Where(x => x.Estado_horario == 1).ToList<UP_estados>();
                return estado;
            }
        }


        public List<UP_datos_horario> traer_datos_horario(int id)
        {

            using (var consulta = new Mapeo("administrador"))
            {
                var horario = consulta.datos_horario.Where(x => x.Id_medico == id).ToList<UP_datos_horario>();
                return horario.ToList<UP_datos_horario>();
            }
        }

        public void reiniciar_agenda()
        {
            using (var conex = new Mapeo("administrador"))
            {
                UP_datos_horario datos_delete = new UP_datos_horario();
                var datos = conex.datos_horario.ToList<UP_datos_horario>();


                foreach (UP_datos_horario dato in datos)
                {
                    conex.datos_horario.Remove(dato);
                }

                var estado = conex.estados.ToList<UP_estados>();
                foreach (UP_estados dato2 in estado)
                {
                    dato2.Estado_agenda = 1;
                    dato2.Estado_horario = 1;
                    dato2.Horas_semana = null;
                    var actualizacion = conex.Entry(dato2);
                    actualizacion.State = EntityState.Modified;

                }
                conex.SaveChanges();
            }
        }

        public int consulta_intervalo_tiempo()
        {
            int tiempo = 0;
            using (var consulta = new Mapeo("administrador"))
            {
                var dato = consulta.parametros.Where(x => x.Id == 1).ToList<UP_parametros>();
                foreach (UP_parametros obj in dato)
                {
                    tiempo = obj.Valor;
                }
                return tiempo;
            }
        }

        public void actualizar_intervalo_tiempo(int tiempo)
        {
            using (var bd = new Mapeo("administrador"))
            {
                DP_Auditoria auditoria = new DP_Auditoria();
                UP_parametros datos = new UP_parametros();
                UP_Acceso acceso = new UP_Acceso();
                var dato = bd.parametros.Where(x => x.Id == 1).ToList<UP_parametros>();
                foreach (UP_parametros obj in dato)
                {
                    datos.Id = obj.Id;
                    datos.Key = obj.Key;
                    datos.Valor = obj.Valor;
                    datos.Session = obj.Session;
                    datos.Last_modified = DateTime.Now;
                }
                datos.Valor = tiempo;
                acceso.Id = datos.Id;
                acceso.Session = datos.Session;
                bd.parametros.Attach(datos);
                var actualizacion = bd.Entry(datos);
                actualizacion.State = EntityState.Modified;
                auditoria.update(dato, datos, acceso, "administrador", "parametros");
                bd.SaveChanges();
            }
        }

          public void GenerarEstados(U_DatosUser user)
            {
                using (var db = new Mapeo("administrador"))
                {
                    UP_estados estado = new UP_estados();

                    var consulta = db.usuario_medico.Where(x => x.Identificacion == user.Numid && x.Id_rol == 2).Select(x => x.Id).ToList();
                    List<long> aux = consulta;
                    foreach (long obj in aux)
                    {
                        estado.Ident_medico = obj;
                    }
                    long idaux = estado.Ident_medico;

                    estado.Id_medico = (int)user.Numid;
                    estado.Nombre_medico = user.Nombres;
                    estado.Apellido_medico = user.Apellidos;
                    estado.Especialidad = user.Especializacion1;
                    estado.Estado_horario = 1;
                    estado.Ident_medico = idaux;
                    estado.Estado_agenda = 1;
                    estado.Horas_semana = user.Horas;

                    db.estados.Add(estado);
                    db.SaveChanges();
                }
            }

        public void SP_GenerarEstadoMedico(estados_medicos user)
        {
            Random aux = new Random();
            int id = aux.Next(1,10000);
            int? id_medico = user.id_medico;
            string _nombre = user.nombre_medico;
            string _apellidos = user.apellido_medico;
            string _especialidad = user.especialidad;
            int? _estado = user.estado_horario;
            int? _estado_agenda = 1;
            int? p_horas_semana = user.horas_semana;
            using (var db = new Mapeo("administrador"))
            {
                var query = db.Database.ExecuteSqlCommand("administrador.SP_GenerarEstadosMedicos @id,@id_medico,@_nombre," +
                    "@_apellido,@_estadoagenda,@_estado,@_especialidad,@_horas_semana",
                    new SqlParameter("@id", id),
                    new SqlParameter("@id_medico", id_medico),
                    new SqlParameter("@_nombre", _nombre),
                    new SqlParameter("@_apellido", _apellidos),
                    new SqlParameter("@_estadoagenda",_estado_agenda),
                    new SqlParameter("@_estado", _estado),
                    new SqlParameter("@_especialidad", _especialidad),
                    new SqlParameter("@_horas_semana", p_horas_semana));
                    db.SaveChanges();
            }
        }

        public List<UP_usuarios> ReporteMedico()
        {
            using (var db = new Mapeo("usuarios"))
            {
                var datos = db.usuario_medico.Where(x => x.Id_rol ==2).ToList<UP_usuarios>();
                return datos.ToList<UP_usuarios>();
            }
        }

        public List<U_AgendaMedico> TraerHorario(int identificacion)
        {
            using (var db = new Mapeo("medico"))
            {
                List<long> lista = db.estados.Where(x=>x.Id_medico == identificacion).Select(x => x.Ident_medico).ToList();
                long iden_medico = 0;
                foreach(long obj in lista)
                {
                    iden_medico = obj;
                }

                var listafinal = db.agenda.Where(x => x.Medico_id == iden_medico && x.Fecha_fin > DateTime.Now && x.Usuario_id == null).ToList();
                
                return listafinal.ToList<U_AgendaMedico>();
            }
        }

        public List<UP_estados> ConsultaEstado2(int identificacion)
        {
            using (var db = new Mapeo("medico"))
            {
                var listafinal = db.estados.Where(x=>x.Id_medico==identificacion).ToList();
                return listafinal.ToList<UP_estados>();
            }
        }

        public List<U_AgendaMedico> BusquedaHorario(string fecha, int identificacion)
        {
            using (var db = new Mapeo("medico"))
            {
                long id_medi = 0;
                DateTime fecha_filtro;

                fecha_filtro = DateTime.Parse(fecha);
                List<long> lista = db.estados.Where(x => x.Id_medico == identificacion).Select(x => x.Ident_medico).ToList();
                foreach(long obj in lista)
                {
                    id_medi = obj;
                }

                var listafinal = db.agenda.Where(x => x.Usuario_id == null
                && x.Medico_id == id_medi && x.Fecha_fin > fecha_filtro).OrderBy(x => x.Fecha_inicio);
                return listafinal.ToList<U_AgendaMedico>();   
            }
        }
        public List<UP_parametros> traerParametros()
        {
            using (var db = new Mapeo("administrador"))
            {
                var estado = db.parametros.Where(x => x.Key == "tiempo-consulta").ToList<UP_parametros>();
                return estado.ToList<UP_parametros>();
            }
        }

        public void modificarTiempo(int valor, string session)
        {
            using (var db = new Mapeo("administrador"))
            {
                DP_Auditoria auditoria = new DP_Auditoria();
                UP_Acceso acceso = new UP_Acceso();
                UP_parametros obj_ant = new UP_parametros();
                List<UP_parametros> lista = new List<UP_parametros>();
                lista = traerParametros();
                foreach (UP_parametros ob in lista)
                {
                    obj_ant.Id = ob.Id;
                    obj_ant.Key = ob.Key;
                    obj_ant.Valor = ob.Valor;
                    obj_ant.Session = ob.Session;
                    obj_ant.Last_modified = ob.Last_modified;
                }
                //nuevo objeto
                UP_parametros obj_new = new UP_parametros();
                obj_new.Id = obj_ant.Id;
                obj_new.Key = obj_ant.Key;
                obj_new.Valor = valor;
                obj_new.Session = session;
                obj_new.Last_modified = obj_ant.Last_modified;
                //acceso
                acceso.Id = obj_new.Id;
                acceso.Session = obj_new.Session;
                //
                db.parametros.Attach(obj_new);
                var actualizacion = db.Entry(obj_new);
                actualizacion.State = EntityState.Modified;
                auditoria.update(obj_new,obj_ant, acceso,"administrador","parametros");
                db.SaveChanges();
            }
        }
        public void EnviarPqrUser(UP_Pqr datos)
        {

            using (var db = new Mapeo("administrador"))
            {
                db.pqr.Add(datos);
                db.SaveChanges();
            }
        }



    }
}

