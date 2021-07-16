using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Datos;
using Utilitarios;

namespace Logica
{
    public class L_especialista
    {

        public U_retornoEspecialista validacion_cita_especialista(long id)
        {
            U_retornoEspecialista usuario = new U_retornoEspecialista();
            D_usuarios us = new D_usuarios();
            DataTable datos = new DataTable();
            datos = us.consultar_cita_especialista(id);
            if (datos.Rows.Count > 0)
            {
                usuario.Id = id;
                usuario.Datos = datos;
                usuario.Mensaje = "";
                return usuario;
            }
            else
            {
                /*Int32 FORMULARIO = 3;
                Int32 Idioma = ret.Sessionidioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                string mensaje;
                mensaje = compIdioma["MensajeNoRem"].ToString();

                usuario.Mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"PrincipalPaciente.aspx\"</script>";*/

                usuario.Mensaje = "<script type='text/javaScript'>alert('Usted no ha sido remitido a un especialista...........');window.location=\"PrincipalPaciente.aspx\"</script>";
                return usuario;
            }
        }

        public UP_Historia_Clinica mostrarDatosDeSolicitarCitaEspecialista(int idCitaEspecialista)
        {
            DP_citas_medicas us = new DP_citas_medicas();
            UP_Historia_Clinica muestra = new UP_Historia_Clinica();
            List<UP_Historia_Clinica> dataTable = us.obtener_historia_remitir(idCitaEspecialista);
            if (dataTable != null)
            {
                foreach (UP_Historia_Clinica mostrar in dataTable)
                {
                    muestra.Id_paciente = mostrar.Id_paciente;
                    muestra.Nombre_paciente = mostrar.Nombre_paciente;
                    muestra.Apellido_paciente = mostrar.Apellido_paciente;
                    muestra.Documento_paciente = mostrar.Documento_paciente;
                }
            }
            return muestra;
        }

        public U_AgendaMedico mostrarDatosEspecialista(int idAsignarCitaEspecialista)
        {
            List<U_AgendaMedico> prueba = new Datos.DP_citas_medicas().obtener_agenda_medico(idAsignarCitaEspecialista);
            U_AgendaMedico muestra = new U_AgendaMedico();
            if (prueba != null)
            {
                foreach (U_AgendaMedico mostrar in prueba)
                {
                    muestra.Medico_id = mostrar.Medico_id;
                    muestra.Nombre_medico = mostrar.Nombre_medico;
                    muestra.Apellido_medico = mostrar.Apellido_medico;
                    muestra.Especialidad = mostrar.Especialidad;
                    muestra.Fecha_inicio = mostrar.Fecha_inicio;
                    muestra.Fecha_fin = mostrar.Fecha_fin;
                }
            }
            return muestra;
        }

        public string Aceptar_Remicion(int id_paciente,int id_age, U_DatosUser agenda, U_DatosUser citaEspecialista, U_DatosUser historiaclinica)
        {
            DAO_Medico d =new DAO_Medico();
            D_usuarios du = new D_usuarios();
            DataTable retorno = new DataTable();
            U_AgendaMedico cita = new U_AgendaMedico();
            retorno = du.validacion_cita_agenda(id_age);
            if (retorno.Rows.Count > 0)
            {
                //agendar cita
                cita.Id = id_age;
                cita.Medico_id = citaEspecialista.Id;
                cita.Fecha_inicio = citaEspecialista.FechaInicio;
                cita.Fecha_fin = citaEspecialista.FechaFin;
                cita.Usuario_id = int.Parse(citaEspecialista.Numid.ToString());
                cita.Nombre_medico = citaEspecialista.NombreMedico;
                cita.Especialidad = citaEspecialista.Especialidad;
                cita.Apellido_medico = citaEspecialista.ApellidoMedico;
                cita.Session = citaEspecialista.Session;
                cita.Last_modified = DateTime.Now;
                //actualizar estado historia clinica

                DP_citas_medicas h = new DP_citas_medicas();
                List<UP_Historia_Clinica> historia_editar = new List<UP_Historia_Clinica>();
                historia_editar = h.traer_historia_clinica(historiaclinica.Id);
                UP_Historia_Clinica obj2 = new UP_Historia_Clinica();
                foreach (UP_Historia_Clinica ob in historia_editar)
                {
                    obj2.Id = ob.Id;
                    obj2.Nombre_paciente = ob.Nombre_paciente;
                    obj2.Documento_paciente = ob.Documento_paciente;
                    obj2.Motivo_consulta = ob.Motivo_consulta;
                    obj2.Alergias = ob.Alergias;
                    obj2.Especialidad = ob.Especialidad;
                    obj2.Cirugias = ob.Cirugias;
                    obj2.Altura = ob.Altura;
                    obj2.Peso = ob.Peso;
                    obj2.Observacion_piel = ob.Observacion_piel;
                    obj2.Observacion_respiracion = ob.Observacion_respiracion;
                    obj2.Observacion_boca = ob.Observacion_boca;
                    obj2.Diagnostico = ob.Diagnostico;
                    obj2.Apellido_paciente = ob.Apellido_paciente;
                    obj2.Nombre_medico = ob.Nombre_medico;
                    obj2.Especialidad = ob.Especialidad;
                    obj2.Apellido_medico = ob.Apellido_medico;
                    obj2.Id_medico = ob.Id_medico;
                    obj2.Id_paciente= ob.Id_paciente;
                    obj2.Fecha_atencion = ob.Fecha_atencion;
                    obj2.Asignar_especialista = ob.Asignar_especialista;
                    obj2.Estado = 2;
                    obj2.Session = ob.Session;
                    obj2.Last_modified = ob.Last_modified;
                }
                //parametros para crear estado_paciente
                estados_pacientes e_pacientes = new estados_pacientes();
                e_pacientes.nombre_paciente = citaEspecialista.Nombres;
                e_pacientes.apellido_paciente = citaEspecialista.Apellidos;
                e_pacientes.identificacion_paciente= citaEspecialista.Identificacion;
                //
                new Datos.DP_citas_medicas().agendar_cita(cita);
                du.insertarCita(citaEspecialista);
                new Datos.DP_citas_medicas().editar_estado_historiaclinica(obj2);
                new DP_citas_medicas().SP_GenerarEstadosPaciente(e_pacientes);
                //new Datos.DAO_Usuarios().CrearEstado_Pacientes(citaEspecialista);
                //du.actualizar_Estado_Pacientes(id_paciente, 1);
                //new DP_citas_medicas().borrar_cita(id_paciente);


                Int32 FORMULARIO = 6;
                Int32 Idioma = agenda.Sessionidioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                string mensaje;
                mensaje = compIdioma["MensajeAgenCitaExitosa"].ToString();

                return mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"PrincipalPaciente.aspx\"</script>";
                //return mensaje="<script type='text/javascript'>alert('Se ha agendado la cita exitosamente.');window.location=\"PrincipalPaciente.aspx\"</script>";

            }
            else
            {
                Int32 FORMULARIO = 6;
                Int32 Idioma = agenda.Sessionidioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                string mensaje;
                mensaje = compIdioma["MensajeAgenCitaNoExitosa"].ToString();

                return mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"SolicitarCita.aspx\"</script>";

                //return mensaje = "<script type='text/javascript'>alert('La cita ya fue asiganada ....Por favor seleccione una nueva cita');window.location=\"SolicitarCita.aspx\"</script>";
            }
        }
        public List<U_AgendaMedico> mostrar_Agenda_especialista(DateTime fecha)
        {
            DP_citas_medicas dp = new DP_citas_medicas();
            return dp.mostrarAgendaEspecialista_filtro(fecha);
        }
        public List<UP_Historia_Clinica> obtener_historia_remitir(int id)
        {
            DP_citas_medicas dp = new DP_citas_medicas();
            return dp.obtener_historia_remitir(id);
        }
        public string validar_solicitar_cita_especialista(long id, U_DatosUser user)
        {
            DP_citas_medicas dp = new DP_citas_medicas();
            List<UP_Historia_Clinica> historia = new List<UP_Historia_Clinica>();
            historia = dp.validar_remicion_especialista(id);
            if(historia.Count > 0)
            {
                user.Mensaje = ""; 
            }
            else
            {
                Int32 FORMULARIO = 30;
                Int32 Idioma = user.Sessionidioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                string mensaje;
                mensaje = compIdioma["MensajeYaTieCita"].ToString();

                //user.Mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"PrincipalPaciente.aspx\"</script>";
                user.Mensaje = "<script type='text/javascript'>alert('DEBE SOLICITAR UNA CITA DE MEDICINA GENERAL PRIMERO');window.location=\"PrincipalPaciente.aspx\"</script>";
            }
            return user.Mensaje;
        }
    }
}
