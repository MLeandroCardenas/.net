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
using System.Data.Entity;

namespace Datos
{
    public class DAO_Admin
    {
        public DAO_Admin()
        {

        }
        public void eliminarMedico(int id)
        {
            DataTable user = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(connectionString: ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("administrador.f_borrarmedicos", conection);
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
        public void eliminarPacientes(int id)
        {
            DataTable user = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(connectionString: ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("administrador.f_borrarpacientes", conection);
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
        public DataTable obtenerpacientes()
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("administrador.f_obtener_pacientes", conection);
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
        public void eliminarespecialidad(int id)
        {
            DataTable user = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(connectionString: ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("administrador.f_borrarespecialidades", conection);
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
        public DataTable obtenermedicos()
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("administrador.f_obtener_medicos", conection);
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
        public DataTable obtenerespecialidad()
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("medico.f_obtenerespecialidades", conection);
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
        public DataTable validarEspecialidad(U_DatosUser especialidad)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new Npgsql.NpgsqlDataAdapter("medico.f_validar_especialidad", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlDbType.Text).Value = especialidad.Nombres;

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

        public void CrearEspecialidad(U_DatosUser especialidad)
        {

            DataTable user = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(connectionString: ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("medico.f_crearespecialidad", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_especialidad", NpgsqlDbType.Text).Value = especialidad.Espe;
                dataAdapter.SelectCommand.Parameters.Add("_sesion", NpgsqlDbType.Text).Value = especialidad.Session;
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
        public DataTable validarUsuarios(U_DatosUser userid)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuarios.f_validar_identificacion_correo", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_identificacion", NpgsqlDbType.Integer).Value = userid.Numid;
                dataAdapter.SelectCommand.Parameters.Add("_email", NpgsqlDbType.Text).Value = userid.Email;

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
        public void CrearEstado(U_DatosUser estado)

        {
            DataTable user = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(connectionString: ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("administrador.f_generar_estados", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_medico", NpgsqlDbType.Integer).Value = estado.Numid;
                dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlDbType.Text).Value = estado.Nombres;
                dataAdapter.SelectCommand.Parameters.Add("_apellido", NpgsqlDbType.Text).Value = estado.Apellidos;
                dataAdapter.SelectCommand.Parameters.Add("_especialidad", NpgsqlDbType.Text).Value = estado.Especializacion1;
                dataAdapter.SelectCommand.Parameters.Add("_estado", NpgsqlDbType.Integer).Value = 1;
                dataAdapter.SelectCommand.Parameters.Add("_estado_agenda", NpgsqlDbType.Integer).Value = 1;
                dataAdapter.SelectCommand.Parameters.Add("_horas_semana", NpgsqlDbType.Integer).Value = estado.Horas;

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
        public void CrearMedico(U_DatosUser medico)
        {
            DataTable user = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(connectionString: ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuarios.f_crearmedico", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_apellidos", NpgsqlDbType.Text).Value = medico.Apellidos;
                dataAdapter.SelectCommand.Parameters.Add("_nombres", NpgsqlDbType.Text).Value = medico.Nombres;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = medico.Numid;
                dataAdapter.SelectCommand.Parameters.Add("_email", NpgsqlDbType.Text).Value = medico.Email;
                dataAdapter.SelectCommand.Parameters.Add("_clave", NpgsqlDbType.Text).Value = medico.Clave;
                dataAdapter.SelectCommand.Parameters.Add("_rol", NpgsqlDbType.Integer).Value = medico.Rol;
                dataAdapter.SelectCommand.Parameters.Add("_estado", NpgsqlDbType.Integer).Value = medico.Estado;
                dataAdapter.SelectCommand.Parameters.Add("_sesion", NpgsqlDbType.Text).Value = medico.Session;
                dataAdapter.SelectCommand.Parameters.Add("_especializacion", NpgsqlDbType.Text).Value = medico.Especializacion1;
                dataAdapter.SelectCommand.Parameters.Add("_foto", NpgsqlDbType.Text).Value = medico.Foto;
                dataAdapter.SelectCommand.Parameters.Add("_url", NpgsqlDbType.Text).Value = medico.Url;

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
        public DataTable validacion_cita_agenda(int id)
        {
            DataTable datos = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("administrador.f_validar_cita", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id;
                conection.Open();
                dataAdapter.Fill(datos);
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
            return datos;
        }

        public void actualizarEstadoCita(int id, int _estado)
        {
            
            using (var db = new Mapeo("administrador"))
            {
                List<UP_estados_pacientes> lista = new List<UP_estados_pacientes>();
                lista = traer_datos(id);
                UP_estados_pacientes paciente = new UP_estados_pacientes();
                var estado = id;
                // var consulta = ();
                foreach (UP_estados_pacientes obj in lista)
                {
                    paciente.Id_usuario = obj.Id_usuario;
                    paciente.Nombre_paciente = obj.Nombre_paciente;
                    paciente.Apellido_paciente = obj.Apellido_paciente;
                    paciente.Identificacion_paciente = obj.Identificacion_paciente;
                    paciente.Estado_cita = obj.Estado_cita;
                }
                if (paciente.Estado_cita == 1)
                {
                    paciente.Estado_cita = 2;
                    db.estados_pacientes.Attach(paciente);
                    var entry = db.Entry(paciente);
                    entry.State = EntityState.Modified;
                }
                else
                {
                    paciente.Estado_cita = 1;
                    db.estados_pacientes.Attach(paciente);
                    var entry = db.Entry(paciente);
                    entry.State = EntityState.Modified;
                }
            }
        }

        public List<UP_estados_pacientes> traer_datos(int id)
        {
            using (var db = new Mapeo("administrador"))
            {
                var a = db.estados_pacientes.Where(x => x.Id_usuario == id).ToList<UP_estados_pacientes>();
                return a.ToList<UP_estados_pacientes>();
            }

        }
        //agenda
        public List<U_AgendaMedico> traer_agenda(int id_usuario)
        {
            using (var db = new Mapeo("medico"))
            {
                var a = db.agenda.Where(x => x.Usuario_id == id_usuario).ToList<U_AgendaMedico>();
                return a.ToList<U_AgendaMedico>();
            }

        }

        public void actualizar_cita_agendada(int id)
        {
            DateTime fecha = new DateTime();
            U_AgendaMedico agenda = new U_AgendaMedico();
            List<U_AgendaMedico> lista = new List<U_AgendaMedico>();
            lista = traer_agenda(id);
            foreach (U_AgendaMedico obj in lista)
            {
                agenda.Id = obj.Id;
                agenda.Medico_id = obj.Medico_id;
                agenda.Fecha_inicio = obj.Fecha_inicio;
                agenda.Fecha_fin = obj.Fecha_fin;
                agenda.Usuario_id = obj.Usuario_id;
                agenda.Nombre_medico = obj.Nombre_medico;
                agenda.Especialidad = obj.Especialidad;
                agenda.Apellido_medico = obj.Apellido_medico;
                agenda.Session = obj.Session;
                agenda.Last_modified = obj.Last_modified;
            }
            using (var db = new Mapeo("medico"))
            {
               fecha = DateTime.Now;
               //string fechalm = fecha.ToString();
                agenda.Usuario_id =null;
                agenda.Last_modified = fecha;
               db.agenda.Attach(agenda);
               var entry = db.Entry(agenda);
               entry.State = EntityState.Modified; 
            }
        }

        public void actualizarestado_cita(U_DatosUser id, int a)
        {
            DataTable user = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(connectionString: ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("administrador.f_editar_cita", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id.Id;
                dataAdapter.SelectCommand.Parameters.Add("_estado", NpgsqlDbType.Integer).Value = 1;

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
        public void eliminarestado_cita(U_DatosUser id)
        {
            DataTable user = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(connectionString: ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("medico.f_retorno_eliminar_cita3", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id.Id;

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

      
    }
}
