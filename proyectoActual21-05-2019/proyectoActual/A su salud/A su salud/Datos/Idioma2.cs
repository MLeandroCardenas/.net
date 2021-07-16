using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Utilitarios;
namespace Datos
{
    public class Idioma2
    {
        public DataTable obtenerIdioma(int formulario, int idioma)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_obtener_idioma_formulario", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_formulario_id", NpgsqlDbType.Integer).Value = formulario;
                dataAdapter.SelectCommand.Parameters.Add("_idioma_id", NpgsqlDbType.Integer).Value = idioma;

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

        public DataTable obtener_controles(int formulario)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_mostrar_controles", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_formulario", NpgsqlDbType.Integer).Value = formulario;


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

        public List<U_ControlesIdiomas> obtenerTodosLosControles(int formulario)
        {
            using (var db = new Mapeo("idioma"))
            {
                var a = db.controles.ToList<U_ControlesIdiomas>().Where(x => x.Formulario_id == formulario);
                return a.ToList<U_ControlesIdiomas>();
            }
        }

        public List<U_Idioma> obtenerIdiomas()
        {
            using (var db = new Mapeo("idioma"))
            {
                var a = db.idiomas.ToList<U_Idioma>();
                return a.ToList<U_Idioma>();
            }
        }

        public List<U_Formularios> obtenerFormularios()
        {
            using (var db = new Mapeo("idioma"))
            {
                var a = db.formulario.ToList<U_Formularios>();
                return a.ToList<U_Formularios>();
            }
        }

        public void traer_controles(int id, int id_idioma)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_traer_controles", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id;
                dataAdapter.SelectCommand.Parameters.Add("_id_idioma", NpgsqlDbType.Integer).Value = id_idioma;
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

        public void actualizarControles(U_ControlesIdiomas control)
        {
            using (var db = new Mapeo("idioma"))
            {
                db.controles.Attach(control);
                var entry = db.Entry(control);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void actualizaridioma(U_Idioma idioma)
        {
            using (var db = new Mapeo("idioma"))
            {
                db.idiomas.Attach(idioma);

                var entry = db.Entry(idioma);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void actualizarFormularios(U_Formularios idioma)
        {
            using (var db = new Mapeo("idioma"))
            {
                db.formulario.Attach(idioma);
                var entry = db.Entry(idioma);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void insertarControl(U_ControlesIdiomas control)
        {
            using (var db = new Mapeo("idioma"))
            {
                db.controles.Add(control);
                db.SaveChanges();
            }
        }

        public void insertarIdioma(U_Idioma idioma)
        {
            using (var db = new Mapeo("idioma"))
            {
                db.idiomas.Add(idioma);
                db.SaveChanges();
            }
        }

        public void insertarFormulario(U_Formularios form)
        {
            using (var db = new Mapeo("idioma"))
            {
                db.formulario.Add(form);
                db.SaveChanges();
            }
        }




        public void eliminarControles(U_ControlesIdiomas control)
        {
            if (control.Idioma_id != 1)
            {
                using (var db = new Mapeo("idioma"))
                {
                    U_ControlesIdiomas idi = db.controles.Find(control.Id);
                    db.controles.Remove(idi);
                    db.SaveChanges();
                }
            }
        }
        public void eliminar_todos_los_controles_para_eliminar_idioma(int id_idioma)
        {
            using (var db = new Mapeo("idioma"))
            {
                List<U_ControlesIdiomas> eliminar_controles_idioma = db.controles.Where(x => x.Idioma_id == id_idioma).ToList();

                foreach (U_ControlesIdiomas borrar in eliminar_controles_idioma)
                {
                    db.controles.Remove(borrar);
                    db.SaveChanges();
                }
            }
        }

        public void eliminar_Idioma(U_Idioma idio)
        {
            new Datos.Idioma2().eliminar_todos_los_controles_para_eliminar_idioma(idio.Id);
            using (var db = new Mapeo("idioma"))
            {
                U_Idioma idioma = db.idiomas.Find(idio.Id);
                db.idiomas.Remove(idioma);
                db.SaveChanges();
            }
        }


        public void eliminarFormularios(U_Formularios formula)
        {
            List<U_ControlesIdiomas> form = obtenerTodosLosControles(formula.Id);
            if (form.Count == 0)
            {
                using (var db = new Mapeo("idioma"))
                {
                    U_Formularios idioma = db.formulario.Find(formula.Id);
                    db.formulario.Remove(idioma);
                    db.SaveChanges();
                }
            }
        }

        /*VALIDACION*/
        public DataTable validarControl(U_ControlesIdiomas control, U_DatosUser idioma)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_validar_control", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_control", NpgsqlDbType.Text).Value = control.Control;
                dataAdapter.SelectCommand.Parameters.Add("_idioma_id", NpgsqlDbType.Integer).Value = idioma.Ididioma;

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
        //----------------------------------------------------------------------------------------
    }
}
