using System;
using System.Collections.Generic;
using Utilitarios;
using Datos;
using System.Collections;

namespace Logica
{
    public class L_ConfirmarCita
    {
        public U_AgendaMedico mostrarDatosDeSolicitarCita(U_DatosUser IdSolicitarCita)
        {
            List<U_AgendaMedico> prueba = new Datos.DP_citas_medicas().obtener_agenda_medico(IdSolicitarCita.IdSolicitarCita);
            U_AgendaMedico muestra = new U_AgendaMedico();
            foreach(U_AgendaMedico mostrar in prueba)
            {
                muestra.Medico_id = mostrar.Medico_id;
                muestra.Nombre_medico = mostrar.Nombre_medico;
                muestra.Apellido_medico = mostrar.Apellido_medico;
                muestra.Especialidad = mostrar.Especialidad;
                muestra.Fecha_inicio = mostrar.Fecha_inicio;
                muestra.Fecha_fin = mostrar.Fecha_fin;
            }
            return muestra;
        }

        public void confirmarcita(U_DatosUser citam, U_DatosUser agenda)
        {
            U_AgendaMedico cita = new U_AgendaMedico();
            U_CitasMedicas cita_medica = new U_CitasMedicas();
            UP_estados_pacientes esta_paci = new UP_estados_pacientes();
            //DataTable retorno = new DataTable();
            DP_admin dp = new DP_admin();
            List<U_AgendaMedico> retorno = new List<U_AgendaMedico>();

            // retorno = new Datos.DAO_Admin().validacion_cita_agenda(agenda.Id_age);
            retorno = dp.validar_cita(agenda.Id);
            if (retorno.Count > 0)
            { 
                //Agendar Cita Tabla Agenda Medico
                cita.Id = agenda.Id;
                cita.Medico_id = citam.Id;
                cita.Fecha_inicio = citam.FechaInicio;
                cita.Fecha_fin = citam.FechaFin;
                cita.Usuario_id = agenda.Identificacion;
                cita.Nombre_medico = citam.NombreMedico;
                cita.Especialidad = citam.Especializacion1;
                cita.Apellido_medico = citam.ApellidoMedico;
                cita.Session = citam.Session;
                cita.Last_modified = DateTime.Now;
                
                //No Inserta
                cita_medica.Id_medico = citam.Id;
                cita_medica.Nombre_medico = citam.NombreMedico;
                cita_medica.Apellido_medico = citam.ApellidoMedico;
                cita_medica.Especialidad = citam.Especializacion1;
                cita_medica.Hora_inicio = citam.FechaInicio;
                cita_medica.Hora_fin = citam.FechaFin;
                cita_medica.Id_paciente = agenda.Identificacion;
                cita_medica.Nombre_paciente = citam.Nombres;
                cita_medica.Estado_cita = 1;
                cita_medica.Documento = Convert.ToInt32(citam.Identificacion);
                cita_medica.Apellido_paciente = citam.Apellidos;
                cita_medica.Session = agenda.Session;
                cita_medica.Ultima_modificacion = DateTime.Now;
     
                //*********------------------------************************** 
                esta_paci.Nombre_paciente = citam.Nombres;
                esta_paci.Apellido_paciente= citam.Apellidos;
                esta_paci.Estado_cita = 1;

                estados_pacientes estado = new estados_pacientes();
                estado.nombre_paciente = esta_paci.Nombre_paciente;
                estado.identificacion_paciente = new DP_citas_medicas().TraerIdentificacion(agenda.Identificacion);
                estado.estado_cita = 1;
                estado.apellido_paciente = esta_paci.Apellido_paciente;

                new Datos.DP_citas_medicas().agendar_cita(cita); //actualizar tabla agenda_medico
                new Datos.DP_citas_medicas().insertar_cita(cita_medica);// insercion en la tabla citas_medicas
                new DP_citas_medicas().SP_GenerarEstadosPaciente(estado);
                new Datos.DP_estados_paciente().actualizar_estado_paciente(agenda.Identificacion);//actualizacion en la tabla estados_pacientes.

                Int32 FORMULARIO = 5;
                Int32 Idioma = agenda.Sessionidioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                string mensaje;
                mensaje = compIdioma["MensajeAgendarCita"].ToString();

                agenda.Mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"PrincipalPaciente.aspx\"</script>";
                //agenda.Mensaje = "<script type='text/javascript'>alert('Se ha agendado la cita exitosamente.');window.location=\"PrincipalPaciente.aspx\"</script>";
            }
            else
            {
                Int32 FORMULARIO = 5;
                Int32 Idioma = agenda.Sessionidioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                string mensaje;
                mensaje = compIdioma["MensajeCitaAsignada"].ToString();

                agenda.Mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"SolicitarCita.aspx\"</script>";
                //agenda.Mensaje = "<script type='text/javascript'>alert('La cita ya fue asiganada ....Por favor seleccione una nueva cita');window.location=\"SolicitarCita.aspx\"</script>";
            }
            
        }
        public List<U_AgendaMedico> mostrar_agenda_medicina_general_filtro(DateTime fecha_filtro)
        {
            DP_citas_medicas us = new DP_citas_medicas();
            List<U_AgendaMedico> datos = new List<U_AgendaMedico>();
            datos = us.mostrar_Agenda_medicina_general_filtro(fecha_filtro);
            return datos;
        }

        public List<U_AgendaMedico> filtrar_cita_medicina_Especialidad(DateTime fecha_filtro)
        {
            DP_citas_medicas us = new DP_citas_medicas();
            List<U_AgendaMedico> datos = new List<U_AgendaMedico>();
            datos = us.mostrarAgendaEspecialista_filtro(fecha_filtro);
            return datos;
        }
        public List<U_AgendaMedico> mostrar_agenda_medicina_general()
        {
            DP_citas_medicas us = new DP_citas_medicas();
            List<U_AgendaMedico> datos = new List<U_AgendaMedico>();
            datos = us.mostrar_Agenda_medicina_general();
            return datos;
        }
    }
}


