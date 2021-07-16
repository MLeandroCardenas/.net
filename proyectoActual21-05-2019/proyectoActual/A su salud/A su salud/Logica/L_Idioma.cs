using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Utilitarios;


namespace Logica
{
    public class L_Idioma
    {
        /*MOSTRAR*/
        public List<U_ControlesIdiomas> mostrarControlesTextbox(int idcontrol)
        {
            List<U_ControlesIdiomas> prueba = new DP_Medicos().obtenerControles(idcontrol);
            return prueba;
        }

        public Hashtable obtenerIdioma(int formulario, int idioma_id)
        {
            U_ControlesIdiomas idioma = new U_ControlesIdiomas();
            idioma.Formulario_id = formulario;
            idioma.Idioma_id = idioma_id;

            List<U_ControlesIdiomas> resul = new DP_usuarios().obtenerIdioma(idioma);
            Hashtable compIdioma = new Hashtable();
            foreach (var aux in resul)
            {
                compIdioma.Add(aux.Control, aux.Texto);
            }
            return compIdioma;
        }


        public List<U_ControlesIdiomas> traer_controles(int formulario)
        {
            Idioma2 idi = new Idioma2();
            return  idi.obtenerTodosLosControles(formulario);
        }
        /*public DataTable traer_todos_los_controles(int formulario)
        {
            DataTable datos = new DataTable();
            Idioma idi = new Idioma();
            datos = idi.obtener_todos_los_controles(formulario);
            return datos;

        }*/

        public List<U_Idioma> traer_idiomas()
        {
            Idioma2 idioma = new Idioma2();
            return idioma.obtenerIdiomas();
        }

        public List<U_Formularios> traer_formularios()
        {
           
            Idioma2 idi = new Idioma2();
            return idi.obtenerFormularios();
        }

        public void traeridiomasnombre(int id)
        {
            DAO_Medico idio = new DAO_Medico();
            idio.obteneridioma();
        }

        /*INSERTAR*/
        public void insertar_idioma(string nombre,string terminacion)
        {
            U_Idioma idioma = new U_Idioma();
            idioma.Nombre_idioma = nombre;
            idioma.Terminacion = terminacion;
            Idioma2 idio = new Idioma2();
            idio.insertarIdioma(idioma);
        }

        public void insertar_formulario(string nombre,string url)
        {
            Idioma2 idio = new Idioma2();
            U_Formularios formulario = new U_Formularios();
            formulario.Nombre = nombre;
            formulario.Url = url;
            idio.insertarFormulario(formulario);
        }
        
        public void eliminar_control(U_ControlesIdiomas idioma)
        {
            Idioma2 idio = new Idioma2();
            idio.eliminarControles(idioma);
        }

        public void eliminar_idioma(U_Idioma idioma)
        {
            if (idioma.Id != 1)
            {
                Idioma2 idio = new Idioma2();
                idio.eliminar_Idioma(idioma);
            }
        }

        public void eliminar_formulario(U_Formularios form)
        {
            Idioma2 idio = new Idioma2();
            idio.eliminarFormularios(form);
        }

        /*EDITAR*/
        public void actualizar_control(U_ControlesIdiomas idioma)
        {
            Idioma2 idio = new Idioma2();
            idio.actualizarControles(idioma);
        }

        public void actualizar_idioma(U_Idioma idioma)
        {
            Idioma2 idio = new Idioma2();
            idio.actualizaridioma(idioma);
        }

        public void actualizar_formulario(U_Formularios form)
        {
            Idioma2 idio = new Idioma2();
            idio.actualizarFormularios(form);
        }

        /*VALIDAR QUE NO INSERTEN CONTROLES CON MAS DE 1 DIOMA*/
        public void validarControl(U_ControlesIdiomas user, U_DatosUser idi)
        {
           
           List<U_ControlesIdiomas> validarcontrol = new DP_Medicos().ValidarControl(user);
                        
            if (validarcontrol.Count == 0)
            {
                U_ControlesIdiomas idio = new U_ControlesIdiomas();
                //idio.Id = 27777;
                idio.Control = user.Control;
                idio.Idioma_id = user.Idioma_id;
                idio.Formulario_id = user.Formulario_id;
                idio.Texto = user.Texto;                

                new Datos.Idioma2().insertarControl(idio);

                Int32 FORMULARIO = 73;
                Int32 Idioma = idi.Sessionidioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                string mensaje;
                mensaje = compIdioma["MensajeRegExit"].ToString();

                idi.Mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"Inter_idiomas.aspx\"</script>";
                //user.Mensaje = "<script type='text/javascript'>alert('Registro Exitoso');window.location=\"Inter_idiomas.aspx\"</script>";
            }
            else
            {
                Int32 FORMULARIO = 73;
                Int32 Idioma = idi.Sessionidioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                string mensaje;
                mensaje = compIdioma["MensajeRegNoControl"].ToString();

                idi.Mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"Inter_idiomas.aspx\"</script>";
                //user.Mensaje = "<script type='text/javascript'>alert('El control ya tiene asignado un idioma...');window.location=\"Inter_idiomas.aspx\"</script>";
            }
        }
        public void validarControl(U_DatosUser user)
        {
            U_ControlesIdiomas obj = new U_ControlesIdiomas();
            obj.Control = user.Nombrecontrol;
            obj.Idioma_id = user.Ididioma;
            List<U_ControlesIdiomas> idio2 = new DP_Medicos().ValidarControl(obj);

            if (idio2.Count == 0)
            {
                U_ControlesIdiomas idio = new U_ControlesIdiomas();
                idio.Control = user.Nombrecontrol;
                idio.Idioma_id = user.Ididioma;
                idio.Formulario_id = user.Formulario_id;
                idio.Texto = user.Textocontrol;

                new Datos.Idioma2().insertarControl(idio);

                Int32 FORMULARIO = 73;
                Int32 Idioma = user.Sessionidioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                string mensaje;
                mensaje = compIdioma["MensajeRegExit"].ToString();

                user.Mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"Inter_idiomas.aspx\"</script>";
                //user.Mensaje = "<script type='text/javascript'>alert('Registro Exitoso');window.location=\"Inter_idiomas.aspx\"</script>";
            }
            else
            {
                Int32 FORMULARIO = 73;
                Int32 Idioma = user.Sessionidioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                string mensaje;
                mensaje = compIdioma["MensajeRegNoControl"].ToString();

                user.Mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"Inter_idiomas.aspx\"</script>";
                //user.Mensaje = "<script type='text/javascript'>alert('El control ya tiene asignado un idioma...');window.location=\"Inter_idiomas.aspx\"</script>";
            }
        }

    }
}
