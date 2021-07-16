using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using System.Web;

namespace Datos
{
    public class DAO_Medico
    {
        public DAO_Medico()
        {

        }
        
        public DataTable obtenerAgendaMedico(int idCita)
        {
            DataTable dataTable = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("medico.f_obtener_agendamedico", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                dataAdapter.SelectCommand.Parameters.AddWithValue("_id", NpgsqlDbType.Integer, idCita);

                conection.Open();
                dataAdapter.Fill(dataTable);

                return dataTable.Rows.Count != 0 ? dataTable : null;
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
        public DataTable obtenerControlesIdioma(int idCita)
        {
            DataTable dataTable = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_obtener_controles", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                dataAdapter.SelectCommand.Parameters.AddWithValue("_id", NpgsqlDbType.Integer, idCita);

                conection.Open();
                dataAdapter.Fill(dataTable);

                return dataTable.Rows.Count != 0 ? dataTable : null;
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
        /*Borrada*/public DataTable agendarCita(U_DatosUser agenda)
        {
            DataTable cita = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(connectionString: ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("medico.f_agendar_cita", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = agenda.Id;
                dataAdapter.SelectCommand.Parameters.Add("_usuario_id", NpgsqlDbType.Integer).Value = agenda.Identificacion;
                dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = agenda.Session;

                conection.Open();
                dataAdapter.Fill(cita);
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
            return cita;
        }
        public DataTable insertarCita(U_CitasMedicas cita)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("medico.f_insertar_cita", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_medico", NpgsqlDbType.Integer).Value = cita.Id_medico;
                dataAdapter.SelectCommand.Parameters.Add("_nombre_medico", NpgsqlDbType.Text).Value = cita.Nombre_medico;
                dataAdapter.SelectCommand.Parameters.Add("_apellido_medico", NpgsqlDbType.Text).Value = cita.Apellido_medico;
                dataAdapter.SelectCommand.Parameters.Add("_especialidad", NpgsqlDbType.Text).Value = cita.Especialidad;
                dataAdapter.SelectCommand.Parameters.Add("_hora_inicio", NpgsqlDbType.Timestamp).Value = cita.Hora_inicio;
                dataAdapter.SelectCommand.Parameters.Add("_hora_fin", NpgsqlDbType.Timestamp).Value = cita.Hora_fin;
                dataAdapter.SelectCommand.Parameters.Add("_id_paciente", NpgsqlDbType.Integer).Value = cita.Id_paciente;
                dataAdapter.SelectCommand.Parameters.Add("_nombre_paciente", NpgsqlDbType.Text).Value = cita.Nombre_paciente;
                dataAdapter.SelectCommand.Parameters.Add("_estado_cita", NpgsqlDbType.Integer).Value = 1;
                dataAdapter.SelectCommand.Parameters.Add("_documento_paciente", NpgsqlDbType.Integer).Value = cita.Documento;
                dataAdapter.SelectCommand.Parameters.Add("_apellido_paciente", NpgsqlDbType.Text).Value = cita.Apellido_paciente;
                dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = cita.Session;

                conection.Open();
                dataAdapter.Fill(Usuario);
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
            return Usuario;
        }
        public DataTable mostrarAgendaMedicinaGeneral()
        {
            DataTable Agenda = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("medico.f_mostraragenda_medicinageneral", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                conection.Open();
                dataAdapter.Fill(Agenda);
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
            return Agenda;
        }

        /*Borrada*/public void borrarCitaAgendada3(long id)
        {
            DataTable user = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(connectionString: ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("medico.f_retorno_eliminar_cita3", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id;
                conection.Open();
                dataAdapter.Fill(user);
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

        public List<U_CitasMedicas> obtenerCitasPacientes(int id_paciente)
        {
            using (var db = new Mapeo("medico"))
            {
                var a = db.citas.ToList<U_CitasMedicas>().Where(x => x.Id_paciente == id_paciente && x.Estado_cita==1).ToList();
                return a.ToList<U_CitasMedicas>();
            }
        }

        
        public void borrarCitaAgendada(int id)
        {
            DataTable user = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(connectionString: ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("medico.f_retorno_cita", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id;
                conection.Open();
                dataAdapter.Fill(user);
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
        public void borrarCitaAgendada2(int id)
        {
            DataTable user = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(connectionString: ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("medico.f_retorno_eliminar_cita", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id;
                conection.Open();
                dataAdapter.Fill(user);
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
        public DataTable obtenerCita(int idCita)
        {
            DataTable dataTable = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("medico.f_obtener_cita", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                dataAdapter.SelectCommand.Parameters.AddWithValue("_id", NpgsqlDbType.Integer, idCita);

                conection.Open();
                dataAdapter.Fill(dataTable);

                return dataTable.Rows.Count != 0 ? dataTable : null;
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
        public void editarcita(U_DatosUser id)
        {
            DataTable cita = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(connectionString: ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("medico.f_editar_cita", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_cita", NpgsqlDbType.Integer).Value = id.Numid;

                conection.Open();
                dataAdapter.Fill(cita);
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
        public DataTable insertarHistoriaClinica(U_DatosUser hclinica)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("medico.f_insert_historia_clinica", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_nombre_paciente", NpgsqlDbType.Text).Value = hclinica.Nombres;
                dataAdapter.SelectCommand.Parameters.Add("_documento_paciente", NpgsqlDbType.Integer).Value = hclinica.Identificacion;
                dataAdapter.SelectCommand.Parameters.Add("_motivo_consulta", NpgsqlDbType.Text).Value = hclinica.Motivo;
                dataAdapter.SelectCommand.Parameters.Add("_alergias", NpgsqlDbType.Text).Value = hclinica.Alergias;
                dataAdapter.SelectCommand.Parameters.Add("_cirugias", NpgsqlDbType.Text).Value = hclinica.Cirugias;
                dataAdapter.SelectCommand.Parameters.Add("_altura", NpgsqlDbType.Integer).Value = hclinica.Altura;
                dataAdapter.SelectCommand.Parameters.Add("_peso", NpgsqlDbType.Integer).Value = hclinica.Peso;
                dataAdapter.SelectCommand.Parameters.Add("_observacion_piel", NpgsqlDbType.Text).Value = hclinica.ObservacionPiel;
                dataAdapter.SelectCommand.Parameters.Add("_observacion_respiracion", NpgsqlDbType.Text).Value = hclinica.ObservacionRespiracion;
                dataAdapter.SelectCommand.Parameters.Add("_observacion_boca", NpgsqlDbType.Text).Value = hclinica.ObservacionBoca;
                dataAdapter.SelectCommand.Parameters.Add("_diagnostico", NpgsqlDbType.Text).Value = hclinica.Diagnostico;
                dataAdapter.SelectCommand.Parameters.Add("_apellido_paciente", NpgsqlDbType.Text).Value = hclinica.Apellidos;
                dataAdapter.SelectCommand.Parameters.Add("_nombre_medico", NpgsqlDbType.Text).Value = hclinica.NombreMedico;
                dataAdapter.SelectCommand.Parameters.Add("_especialidad", NpgsqlDbType.Text).Value = hclinica.Especializacion1;
                dataAdapter.SelectCommand.Parameters.Add("_apellido_medico", NpgsqlDbType.Text).Value = hclinica.ApellidoMedico;
                dataAdapter.SelectCommand.Parameters.Add("_id_medico", NpgsqlDbType.Integer).Value = hclinica.Id;
                dataAdapter.SelectCommand.Parameters.Add("_id_paciente", NpgsqlDbType.Integer).Value = hclinica.Numid;
                dataAdapter.SelectCommand.Parameters.Add("_fecha_atencion", NpgsqlDbType.Timestamp).Value = hclinica.FechaFin;
                dataAdapter.SelectCommand.Parameters.Add("_asignar_especialista", NpgsqlDbType.Text).Value = hclinica.AsignarEspecialista;
                dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = hclinica.Session;

                conection.Open();
                dataAdapter.Fill(Usuario);
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
            return Usuario;
        }
        public DataTable insertarHistoriaClinica1(U_DatosUser hclinica)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("medico.f_insert_historia_clinica1", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_nombre_paciente", NpgsqlDbType.Text).Value = hclinica.Nombres;
                dataAdapter.SelectCommand.Parameters.Add("_documento_paciente", NpgsqlDbType.Integer).Value = hclinica.Identificacion;
                dataAdapter.SelectCommand.Parameters.Add("_motivo_consulta", NpgsqlDbType.Text).Value = hclinica.Motivo;
                dataAdapter.SelectCommand.Parameters.Add("_alergias", NpgsqlDbType.Text).Value = hclinica.Alergias;
                dataAdapter.SelectCommand.Parameters.Add("_cirugias", NpgsqlDbType.Text).Value = hclinica.Cirugias;
                dataAdapter.SelectCommand.Parameters.Add("_altura", NpgsqlDbType.Integer).Value = hclinica.Altura;
                dataAdapter.SelectCommand.Parameters.Add("_peso", NpgsqlDbType.Integer).Value = hclinica.Peso;
                dataAdapter.SelectCommand.Parameters.Add("_observacion_piel", NpgsqlDbType.Text).Value = hclinica.ObservacionPiel;
                dataAdapter.SelectCommand.Parameters.Add("_observacion_respiracion", NpgsqlDbType.Text).Value = hclinica.ObservacionRespiracion;
                dataAdapter.SelectCommand.Parameters.Add("_observacion_boca", NpgsqlDbType.Text).Value = hclinica.ObservacionBoca;
                dataAdapter.SelectCommand.Parameters.Add("_diagnostico", NpgsqlDbType.Text).Value = hclinica.Diagnostico;
                dataAdapter.SelectCommand.Parameters.Add("_apellido_paciente", NpgsqlDbType.Text).Value = hclinica.Apellidos;
                dataAdapter.SelectCommand.Parameters.Add("_nombre_medico", NpgsqlDbType.Text).Value = hclinica.NombreMedico;
                dataAdapter.SelectCommand.Parameters.Add("_especialidad", NpgsqlDbType.Text).Value = hclinica.Especializacion1;
                dataAdapter.SelectCommand.Parameters.Add("_apellido_medico", NpgsqlDbType.Text).Value = hclinica.ApellidoMedico;
                dataAdapter.SelectCommand.Parameters.Add("_id_medico", NpgsqlDbType.Integer).Value = hclinica.Id;
                dataAdapter.SelectCommand.Parameters.Add("_id_paciente", NpgsqlDbType.Integer).Value = hclinica.Numid;
                dataAdapter.SelectCommand.Parameters.Add("_fecha_atencion", NpgsqlDbType.Timestamp).Value = hclinica.FechaFin;
                dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = hclinica.Session;
                //dataAdapter.SelectCommand.Parameters.Add("_asignar_especialista", NpgsqlDbType.Text).Value = hclinica.Asignar_especialista;

                conection.Open();
                dataAdapter.Fill(Usuario);
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
            return Usuario;
        }

        public DataTable obteneridioma()
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_mostraridioma", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                conection.Open();
                dataAdapter.Fill(Usuario);
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
            return Usuario;
        }

        public DataTable obtenerCitas(int userid)
        {
            DataTable Agenda = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("medico.f_obtenercitas", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_medico", NpgsqlDbType.Integer).Value = userid;

                conection.Open();
                dataAdapter.Fill(Agenda);
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
            return Agenda;
        }
        public DataTable obtenerespecialidadtres()
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("medico.f_obtenerespecialidades3", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                conection.Open();
                dataAdapter.Fill(Usuario);
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
            return Usuario;
        }

    }
}