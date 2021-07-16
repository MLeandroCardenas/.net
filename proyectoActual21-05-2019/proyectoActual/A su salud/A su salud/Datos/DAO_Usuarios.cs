using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Utilitarios;

namespace Datos
{
    public class DAO_Usuarios
    {
        public DAO_Usuarios()
        {

        }
        public void CrearUsuarios(U_DatosUser usuarios)
        {
            DataTable user = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(connectionString: ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuarios.f_insertaruser", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_apellidos", NpgsqlDbType.Text).Value = usuarios.Apellidos;
                dataAdapter.SelectCommand.Parameters.Add("_nombres", NpgsqlDbType.Text).Value = usuarios.Nombres;
                dataAdapter.SelectCommand.Parameters.Add("_identificacion", NpgsqlDbType.Integer).Value = usuarios.Numid;
                dataAdapter.SelectCommand.Parameters.Add("_email", NpgsqlDbType.Text).Value = usuarios.Email;
                dataAdapter.SelectCommand.Parameters.Add("_clave", NpgsqlDbType.Text).Value = usuarios.Clave;
                dataAdapter.SelectCommand.Parameters.Add("_rol", NpgsqlDbType.Integer).Value = 3;
                dataAdapter.SelectCommand.Parameters.Add("_sesion", NpgsqlDbType.Text).Value = usuarios.Session;
                dataAdapter.SelectCommand.Parameters.Add("_estado", NpgsqlDbType.Integer).Value = 1;
                dataAdapter.SelectCommand.Parameters.Add("_foto", NpgsqlDbType.Text).Value = usuarios.Foto;
                dataAdapter.SelectCommand.Parameters.Add("_url", NpgsqlDbType.Text).Value = usuarios.Url;

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
        public void CrearEstado_Pacientes(U_DatosUser estado)
        {
            DataTable user = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(connectionString: ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("administrador.f_generar_estado_paciente", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_identificacion", NpgsqlDbType.Integer).Value = estado.Identificacion;
                dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlDbType.Text).Value = estado.Nombres;
                dataAdapter.SelectCommand.Parameters.Add("_apellido", NpgsqlDbType.Text).Value = estado.Apellidos;
                dataAdapter.SelectCommand.Parameters.Add("_estado_cita", NpgsqlDbType.Integer).Value = 1;


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
        public int Concultar_Estado_Pacientes(int id)
        {
            DataTable user = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(connectionString: ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
            int estado = 0;
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("administrador.f_consultar_estado_paciente", conection);
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
            for (int i = 0; i < user.Rows.Count; i++)
            {
                estado = int.Parse(user.Rows[i]["estado_cita"].ToString());
            }
            return estado;
        }
        public void actualizar_Estado_Pacientes(int id, int estado)
        {
            DataTable user = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(connectionString: ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("administrador.f_actualizar_estado_paciente", conection);
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

    }
}
