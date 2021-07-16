using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilitarios;
using System.Threading.Tasks;
using System.Data.Entity;
using Npgsql;
using System.Configuration;
using System.Data;
using NpgsqlTypes;

namespace Datos
{
    public class DP_SolicitarCita
    {
        public U_AgendaMedico traer_cita(int id_cita)
        {
            U_AgendaMedico datos = new U_AgendaMedico();
            using (var consulta = new Mapeo("medico"))
            {

                var cita = consulta.agenda.Where(x => x.Id == id_cita).ToList<U_AgendaMedico>();
                foreach (U_AgendaMedico obj in cita)
                {
                    datos.Id = obj.Id;
                    datos.Last_modified = datos.Last_modified;
                    datos.Medico_id = obj.Medico_id;
                    datos.Nombre_medico = obj.Nombre_medico;
                    datos.Session = obj.Session;
                    datos.Usuario_id = obj.Usuario_id;
                    datos.Apellido_medico = obj.Apellido_medico;
                    datos.Especialidad = obj.Especialidad;
                    datos.Fecha_fin = obj.Fecha_fin;
                    datos.Fecha_inicio = obj.Fecha_inicio;

                }
                return datos;
            }
        }

        public UP_usuarios traer_usuario(long identificacion)
        {
            UP_usuarios user = new UP_usuarios();
            using (var consulta = new Mapeo("usuarios"))
            {
                var datos = consulta.usuario.Where(x => x.Identificacion == identificacion).ToList<UP_usuarios>();
                foreach (UP_usuarios obj in datos)
                {
                    user.Id = obj.Id;
                    user.Nombres = obj.Nombres;
                    user.Apellidos = obj.Apellidos;
                    user.Identificacion = obj.Identificacion;
                    user.Session = obj.Session;
                    user.Last_modified = obj.Last_modified;

                }
                return user;
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

        public void insertar_cita(U_CitasMedicas datos)
        {
            using (var db = new Mapeo("medico"))
            {
                db.citas.Add(datos);
                db.SaveChanges();
            }
        }
        // no sirve
        
        public void crear_estado(UP_estados_pacientes estado)
        {           
               
                NpgsqlConnection conection = new NpgsqlConnection(connectionString: ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

                try
                {
                    NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("administrador.f_generar_estado_paciente", conection);
                    dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dataAdapter.SelectCommand.Parameters.Add("_identificacion", NpgsqlDbType.Integer).Value = estado.Identificacion_paciente;
                    dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlDbType.Text).Value = estado.Nombre_paciente;
                    dataAdapter.SelectCommand.Parameters.Add("_apellido", NpgsqlDbType.Text).Value = estado.Apellido_paciente;
                    dataAdapter.SelectCommand.Parameters.Add("_estado_cita", NpgsqlDbType.Integer).Value = 1;
                    conection.Open();
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
                finally
                {
                    if (conection != null)
                    {
                        conection.Close();
                    }
                }
        }
        
            
        public List<UP_estados_pacientes> traer_datos(int id)
        {
            using (var db = new Mapeo("administrador"))
            {
                var datos = db.estados_pacientes.Where(x => x.Id_usuario == id).ToList<UP_estados_pacientes>();
                return datos.ToList<UP_estados_pacientes>();
            }

        }

        public void actualizar_estado_paciente(int id)
        {
            using (var db = new Mapeo("medico"))
            {
                UP_estados_pacientes objeto = new UP_estados_pacientes();
                List<UP_estados_pacientes> lista = new List<UP_estados_pacientes>();
                lista = traer_datos(id);
                foreach (UP_estados_pacientes obj in lista)
                {
                    objeto.Id_usuario = obj.Id_usuario;
                    objeto.Nombre_paciente = obj.Nombre_paciente;
                    objeto.Apellido_paciente = obj.Apellido_paciente;
                    objeto.Identificacion_paciente = obj.Identificacion_paciente;
                    objeto.Estado_cita = 2;
                }
                db.estados_pacientes.Attach(objeto);

                var entry = db.Entry(objeto);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public List<UP_estados_pacientes> traer_estado(long identificacion)
        {
            using (var db = new Mapeo("administrador"))
            {
                var estado = db.estados_pacientes.Where(x => x.Identificacion_paciente == identificacion).ToList<UP_estados_pacientes>();
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

    }

}