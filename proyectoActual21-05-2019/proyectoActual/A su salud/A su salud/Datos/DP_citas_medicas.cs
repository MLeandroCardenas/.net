using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using Utilitarios;

namespace Datos
{
    public class DP_citas_medicas
    {
        public List<U_CitasMedicas> traer_citas(int id)
        {
            using (var db = new Mapeo("medico"))
            {
                var lista_citas = db.citas.Where(x => x.Id_paciente == id && x.Estado_cita == 1).ToList<U_CitasMedicas>();
                return lista_citas.ToList<U_CitasMedicas>();
            }
        }
        public List<UP_Historia_Clinica> traer_historia_clinica(int id)
        {
            using (var db = new Mapeo("medico"))
            {
                var historia = db.historia.Where(x => x.Id == id).ToList<UP_Historia_Clinica>();
                return historia.ToList<UP_Historia_Clinica>();
            }
        }
        public List<U_CitasMedicas> mostrar_datoscita_atender(int id)
        {
            using (var db = new Mapeo("medico"))
            {
                var lista_citas = db.citas.Where(x => x.Id == id ).ToList<U_CitasMedicas>();
                return lista_citas.ToList<U_CitasMedicas>();
            }
        }
        public List<U_CitasMedicas> mostrar_citas_medico(int id)
        {
            using (var db = new Mapeo("medico"))
            {
                var lista_citas = db.citas.Where(x => x.Id_medico == id && x.Estado_cita == 1).ToList<U_CitasMedicas>();
                return lista_citas.ToList<U_CitasMedicas>();
            }
        }

        public List<U_AgendaMedico> obtener_agenda_medico(int id)
        {
            using (var db = new Mapeo("medico"))
            {
                var lista_citas = db.agenda.Where(x => x.Id == id).ToList<U_AgendaMedico>();
                return lista_citas.ToList<U_AgendaMedico>();
            }
        }
        public List<UP_Historia_Clinica> obtener_historia_remitir(int id)
        {
            using (var db = new Mapeo("medico"))
            {
                var historia = db.historia.Where(x => x.Id == id).ToList<UP_Historia_Clinica>();
                return historia.ToList<UP_Historia_Clinica>();
            }
        }

        public List<U_AgendaMedico> mostrar_Agenda_medicina_general_filtro(DateTime fecha)
        {
            using (var db = new Mapeo("medico"))
            {
                var lista_citas = db.agenda.Where(x => x.Usuario_id == null && x.Especialidad == "Medicina General" && x.Fecha_fin > DateTime.Now && x.Fecha_fin > fecha).OrderBy(x => x.Fecha_inicio).ToList<U_AgendaMedico>();
                if (lista_citas.Count > 0)
                {
                    return lista_citas;

                }
                else
                {
                    var lista_citas2 = db.agenda.Where(x => x.Usuario_id == null && x.Especialidad == "General medicine" && x.Fecha_fin > DateTime.Now && x.Fecha_fin > fecha).OrderBy(x => x.Fecha_inicio).ToList<U_AgendaMedico>();
                    return lista_citas2;
                }
                //var lista_citas = db.agenda.Where(x => x.Usuario_id == null && x.Especialidad == "Medicina General" && x.Fecha_fin > DateTime.Now && x.Fecha_fin>fecha).OrderBy(x=> x.Fecha_inicio).ToList<U_AgendaMedico>();
                //return lista_citas.ToList<U_AgendaMedico>();
            }
        }
        public List<U_AgendaMedico> mostrarAgendaEspecialista_filtro(DateTime fecha)
        {
            using (var db = new Mapeo("medico"))
            {
                var lista_citas = db.agenda.Where(x => x.Usuario_id == null && x.Especialidad != "Medicina General" && x.Fecha_fin > DateTime.Now && x.Fecha_fin > fecha).OrderBy(x => x.Fecha_inicio).ToList<U_AgendaMedico>();
                return lista_citas.ToList<U_AgendaMedico>();
            }
        }
        //validacion sacar cita especialista
        public List<UP_Historia_Clinica> validar_remicion_especialista(long id)
        {
            using (var db = new Mapeo("medico"))
            {
                var list = db.historia.Where(x => x.Id_paciente == id && x.Asignar_especialista != "NO REMITIDO" && x.Estado  == 1).ToList<UP_Historia_Clinica>();
                return list.ToList<UP_Historia_Clinica>();
            }
        }
        //

        public List<U_AgendaMedico> mostrar_Agenda_medicina_general()
        {
            using (var db = new Mapeo("medico"))
            {
                var lista_citas = db.agenda.Where(x => x.Usuario_id == null && x.Especialidad == "Medicina General" && x.Fecha_fin > DateTime.Now).ToList<U_AgendaMedico>();
                if (lista_citas.Count > 0)
                {
                    return lista_citas;
                }
                else
                {
                    var lista_citas2 = db.agenda.Where(x => x.Usuario_id == null && x.Especialidad == "General medicine" && x.Fecha_fin > DateTime.Now).ToList<U_AgendaMedico>();
                    return lista_citas2;
                }
                //return lista_citas.ToList<U_AgendaMedico>();
            }
        }
        public List<U_AgendaMedico> obtener_cita_agenda_medico(Int64 id_cita_agendada)
        {
            using (var db = new Mapeo("medico"))
            {
                var a = db.agenda.ToList<U_AgendaMedico>().Where(x => x.Usuario_id == id_cita_agendada).ToList();
                return a.ToList<U_AgendaMedico>();
            }
        }

        public void agendar_cita(U_AgendaMedico agendar)
        {
            using (var db = new Mapeo("medico"))
            {
                db.agenda.Attach(agendar);

                var entry = db.Entry(agendar);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void editar_cita(U_CitasMedicas agendar)
        {
            using (var db = new Mapeo("medico"))
            {
                db.citas.Attach(agendar);

                var entry = db.Entry(agendar);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void editar_cita_agenda_medico(U_AgendaMedico agendar)
        {
            using (var db = new Mapeo("medico"))
            {
                db.agenda.Attach(agendar);

                var entry = db.Entry(agendar);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void editar_estado_historiaclinica(UP_Historia_Clinica historia)
        {
            using (var db = new Mapeo("medicos"))
            {
                db.historia.Attach(historia);

                var entry = db.Entry(historia);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void insertar_cita(U_CitasMedicas datos)
        {
            using (var db = new Mapeo("medico"))
            {
                db.citas.Add(datos);
                db.SaveChanges();
            }
        }

        public void insertar_historiaclinica(UP_Historia_Clinica datos)
        {
            using (var db = new Mapeo("medico"))
            {
                db.historia.Add(datos);
                db.SaveChanges();
            }
        }
        public void crear_estado(UP_estados_pacientes estado)
        {
            using (var db = new Mapeo("administrador"))
            {
                db.estados_pacientes.Add(estado);
                db.SaveChanges();
            }
        }
        public void borrar_cita(int id)
        {
            using (var db = new Mapeo("usuarios"))
            {
                var usuario = db.estados_pacientes.Where(x => x.Id_usuario == id).FirstOrDefault();
                db.estados_pacientes.Remove(usuario);
                db.SaveChanges();
            }
        }
        public void borrar_cita_agendada(int id)
        {
            using (var db = new Mapeo("medico"))
            {
                var cita = db.citas.Where(x => x.Id_paciente == id && x.Estado_cita == 1).FirstOrDefault();
                db.citas.Remove(cita);
                db.SaveChanges();
            }
        }
        public void borrar_cita_estados_pacientes(int id)
        {
            using (var db = new Mapeo("medico"))
            {
                var cita = db.estados_pacientes.Where(x=> x.Id_usuario == id).FirstOrDefault();
                db.estados_pacientes.Remove(cita);
                db.SaveChanges();
            }
        }

        public void GenerarEstadoPaciente(UP_estados_pacientes paciente)
        {
            using (var db = new Mapeo("administrador"))
            {
                var consulta = db.usuario_medico.Where(x => x.Id == paciente.Id_usuario && x.Id_rol == 3)
                    .Select(x => x.Id).ToList();
                foreach(var obj in consulta)
                {
                    paciente.Id_usuario = (int)obj;
                }
                db.estados_pacientes.Add(paciente);
                db.SaveChanges();
            }
        }

        public void SP_GenerarEstadosPaciente(estados_pacientes user)
        {
            Random aux = new Random();
            int id = aux.Next(1,10000);
            string nombre = user.nombre_paciente;
            long identificacion = user.identificacion_paciente;
            int estadoCita = 1;
            string apellido = user.apellido_paciente;

            using (var db = new Mapeo("administrador"))
            {
                var query = db.Database.ExecuteSqlCommand("administrador.SP_GenerarEstadosPaciente @_id,@_nombre,@_identificacion,@_estadocita,@_apellido",
                     new SqlParameter("@_id", id),
                    new SqlParameter("@_nombre", nombre),
                    new SqlParameter("@_identificacion", identificacion),
                    new SqlParameter("@_estadocita", estadoCita),
                    new SqlParameter("@_apellido", apellido));
                db.SaveChanges();
            }
        }

        public int TraerIdentificacion(int id)
        {
            int estado_horario = 0;
            using (var db = new Mapeo("usuarios"))
            {
                var estado = db.usuario_medico.Where(x => x.Id == id).ToList<UP_usuarios>();
                List<UP_usuarios> lista = new List<UP_usuarios>();
                lista = estado;
                foreach (UP_usuarios consulta in lista)
                {
                    estado_horario = (int)consulta.Identificacion;

                }
                return estado_horario;
            }
        }
    }
}
