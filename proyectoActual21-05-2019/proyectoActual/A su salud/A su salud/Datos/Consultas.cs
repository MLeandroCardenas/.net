using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Utilitarios;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Consultas
    {

        public DataTable obtenerUsuarios(int userid)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuarios.f_obtener_usuarios", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_userid", NpgsqlDbType.Integer).Value = userid;

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

        public DataTable obtenerMedicos(int userid)
        {
            DataTable Medico = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("medico.f_obtener_medicos", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_userid", NpgsqlDbType.Integer).Value = userid;

                conection.Open();
                dataAdapter.Fill(Medico);
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
            return Medico;
        }


        public DataTable consutar_estados(int estado)
        {
            DataTable user = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(connectionString: ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("administrador.f_traer_medicos", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_estado", NpgsqlDbType.Integer).Value = estado;
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

            return user;

        }

        public DataTable consutar_estados_horario(int estado)
        {
            DataTable user = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(connectionString: ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("administrador.f_traer_medicos2", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_estado", NpgsqlDbType.Integer).Value = estado;
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

            return user;

        }



        public void actualizarTiempoCitas(Eusuarios datos)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("administrador.f_modificar_tiempo", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_valor", NpgsqlDbType.Integer).Value = datos.Valor;
                dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = datos.Sesion;

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

        }

        public List<E_DatosHorario> traer_datos()
        {
            DataTable datos = new DataTable();
            List<E_DatosHorario> lista = new List<E_DatosHorario>();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("administrador.traer_datos", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
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

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                E_DatosHorario data = new E_DatosHorario();
                data.IdMedico = int.Parse(datos.Rows[i]["id_medico"].ToString());
                data.Horainicio = datos.Rows[i]["hora_inicio"].ToString();
                data.Horafin = datos.Rows[i]["hora_final"].ToString();
                data.Diasemana = int.Parse(datos.Rows[i]["dia"].ToString());

                lista.Add(data);
                // JsonConvert.DeserializeObject<Horario>(datos.Rows[i]["datos_horario_medico"].ToString());
            }

            return lista;
        }

        public List<E_DatosHorario> traer_datos2(int id)
        {
            DataTable datos = new DataTable();
            List<E_DatosHorario> lista = new List<E_DatosHorario>();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("administrador.traer_datos2", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("id", NpgsqlDbType.Integer).Value = id;
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

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                E_DatosHorario data = new E_DatosHorario();
                data.IdMedico = int.Parse(datos.Rows[i]["id_medico"].ToString());
                data.Horainicio = datos.Rows[i]["hora_inicio"].ToString();
                data.Horafin = datos.Rows[i]["hora_final"].ToString();
                data.Diasemana = int.Parse(datos.Rows[i]["dia"].ToString());

                lista.Add(data);
                // JsonConvert.DeserializeObject<Horario>(datos.Rows[i]["datos_horario_medico"].ToString());
            }

            return lista;
        }

        public int ConsultarEstadoAgenda(int iden)
        {
            DataTable user = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(connectionString: ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
            int esta = 0;
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("administrador.f_consulta_estado", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = iden;
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
            for (int i = 0; i < user.Rows.Count; i++)
            {
                esta = int.Parse(user.Rows[i]["estado_agenda"].ToString());
            }
            return esta;

        }

        public int ConsultarHoras(int iden)
        {
            DataTable user = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(connectionString: ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
            int esta = 0;
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("administrador.f_consulta_estado2", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = iden;
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
            for (int i = 0; i < user.Rows.Count; i++)
            {
                esta = int.Parse(user.Rows[i]["horas_semana"].ToString());
            }
            return esta;

        }

        public int ConsultarEstadohorario(int iden)
        {
            DataTable user = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(connectionString: ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
            int esta = 0;
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("administrador.f_consulta_estado", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = iden;
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
            for (int i = 0; i < user.Rows.Count; i++)
            {
                esta = int.Parse(user.Rows[i]["estado_horario"].ToString());
            }
            return esta;

        }

        public void generar_agenda(E_Agenda Uagenda)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("medico.f_generar_agenda", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = Uagenda.Id;
                dataAdapter.SelectCommand.Parameters.Add("_fecha_inicio", NpgsqlDbType.Timestamp).Value = Uagenda.Fechainicio;
                dataAdapter.SelectCommand.Parameters.Add("_fecha_fin", NpgsqlDbType.Timestamp).Value = Uagenda.Fechafinal;
                dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = Uagenda.Sesion;

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

        }

        public void actualizarestado_agenda(int id, int estado)
        {
            DataTable user = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(connectionString: ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("administrador.f_actualizar_estado_agenda", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id;
                dataAdapter.SelectCommand.Parameters.Add("_estado_agenda", NpgsqlDbType.Integer).Value = estado;

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

        public void insertarhorario(E_DatosHorario dato)
        {
            DataTable datosH = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
            int i = dato.IdMedico;
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("administrador.f_insertar_horario2", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = i;
                //dataAdapter.SelectCommand.Parameters.Add("_id_medico", NpgsqlDbType.Integer).Value = dato.IdMedico;
                dataAdapter.SelectCommand.Parameters.Add("_hora_inicio", NpgsqlDbType.Text).Value = dato.Horainicio;
                dataAdapter.SelectCommand.Parameters.Add("_hora_final", NpgsqlDbType.Text).Value = dato.Horafin;
                dataAdapter.SelectCommand.Parameters.Add("_dia", NpgsqlDbType.Integer).Value = dato.Diasemana;
                //dataAdapter.SelectCommand.Parameters.Add("_laboral", NpgsqlDbType.Json).Value = laboral;

                conection.Open();
                dataAdapter.Fill(datosH);
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
        public void actualizarestado_horario(int id, int estado)
        {
            DataTable user = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(connectionString: ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("administrador.f_actualizar_estado", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id;
                dataAdapter.SelectCommand.Parameters.Add("_estado", NpgsqlDbType.Integer).Value = estado;


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
