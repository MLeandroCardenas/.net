using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Configuration;
using NpgsqlTypes;
using System.Data;
using Utilitarios;

namespace Datos
{
    public class D_medicos
    {
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

        public void enviarPqrUsuarios(UP_Pqr usuario)
        {
            DataTable user = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(connectionString: ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("administrador.f_enviarpqruser", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_tipo", NpgsqlDbType.Text).Value = usuario.Tipo_mensaje;
                dataAdapter.SelectCommand.Parameters.Add("_mensaje", NpgsqlDbType.Text).Value = usuario.Mensaje;
                dataAdapter.SelectCommand.Parameters.Add("_nombres", NpgsqlDbType.Text).Value = usuario.Nombres;
                dataAdapter.SelectCommand.Parameters.Add("_apellidos", NpgsqlDbType.Text).Value = usuario.Apellidos;
                dataAdapter.SelectCommand.Parameters.Add("_correo", NpgsqlDbType.Text).Value = usuario.Correo;
                dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = usuario.Session;
                dataAdapter.SelectCommand.Parameters.Add("_iduser", NpgsqlDbType.Integer).Value = usuario.Id_usuario;
                dataAdapter.SelectCommand.Parameters.Add("_estado", NpgsqlDbType.Integer).Value = usuario.Estado;

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

        public DataTable obtenerHistoriaClinica(int Numid)
        {
            DataTable Agenda = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("medico.f_obtener_historia_clinica", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_documento_paciente", NpgsqlDbType.Integer).Value = Numid;
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

    }
}
