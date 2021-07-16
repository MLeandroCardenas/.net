using System;
using System.Collections.Generic;
using Utilitarios;
using Datos;
using System.Collections;

namespace Logica
{
    public class L_VerMisCitas
    {
        public List<U_CitasMedicas> vermisCitas(int id_paciente)
        {
            DAO_Medico medico = new DAO_Medico();
            List<U_CitasMedicas> vermiscitas = medico.obtenerCitasPacientes(id_paciente);
            return vermiscitas;
        }

        public DateTime retorno_fecha(List<U_CitasMedicas> datos)
        {
            DateTime fecha_inicial = new DateTime();
            foreach (U_CitasMedicas obj in datos) {
                fecha_inicial=obj.Hora_inicio;
            }
            return fecha_inicial;
        }

        public U_DatosUser borrarcita(U_DatosUser borrarcitas, int id_cita_agendada)
        {
            if (borrarcitas.Fecha_actual <= borrarcitas.Fecha_new)
            {
                List<U_CitasMedicas> cita = new List<U_CitasMedicas>();
                U_EstadosPacientes paciente = new U_EstadosPacientes();
                int a = 2;
                int id_paciente = borrarcitas.Id;
                new Datos.DAO_Admin().actualizarEstadoCita(id_paciente,a);//estados_pacientes
                //Editar cita agendada de la tabla de agenda medico 
                List<U_AgendaMedico> cita_agendada = new List<U_AgendaMedico>();
                cita_agendada = new DP_citas_medicas().obtener_cita_agenda_medico(id_cita_agendada);
                U_AgendaMedico ag = new U_AgendaMedico();
                foreach (U_AgendaMedico ob in cita_agendada)
                {
                    ag.Id = ob.Id;
                    ag.Medico_id = ob.Medico_id;
                    ag.Fecha_inicio = ob.Fecha_inicio;
                    ag.Fecha_fin = ob.Fecha_fin;
                    ag.Usuario_id = ob.Usuario_id;
                    ag.Nombre_medico = ob.Nombre_medico;
                    ag.Especialidad = ob.Especialidad;
                    ag.Apellido_medico = ob.Apellido_medico;
                    ag.Session = ob.Session;
                    ag.Last_modified = ob.Last_modified;
                }
                DP_citas_medicas dp = new DP_citas_medicas();
                U_AgendaMedico cita_ag = new U_AgendaMedico();

                cita_ag.Id = ag.Id;
                cita_ag.Medico_id = ag.Medico_id;
                cita_ag.Fecha_inicio = ag.Fecha_inicio;
                cita_ag.Fecha_fin = ag.Fecha_fin;
                //cita_ag.Usuario_id = ag.Usuario_id;
                cita_ag.Nombre_medico = ag.Nombre_medico;
                cita_ag.Especialidad = ag.Especialidad;
                cita_ag.Apellido_medico = ag.Apellido_medico;
                cita_ag.Session = ag.Session;
                cita_ag.Last_modified = ag.Last_modified;
                new Datos.DP_citas_medicas().editar_cita_agenda_medico(cita_ag);
                new Datos.DP_citas_medicas().borrar_cita_agendada(borrarcitas.Id);
                new Datos.DP_citas_medicas().borrar_cita_estados_pacientes(borrarcitas.Id);
               
                DAO_Medico medico = new DAO_Medico();
                cita = medico.obtenerCitasPacientes(id_paciente);
            }
            else
            {
                Int32 FORMULARIO = 33;
                Int32 Idioma = borrarcitas.Sessionidioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                string mensajeU;
                mensajeU = compIdioma["MensajeEliminarCitas"].ToString();

                borrarcitas.Mensaje = "<script type='text/javascript'>alert('" + mensajeU + "');window.location=\"VerMisCitas.aspx\"</script>";
                //borrarcitas.Mensaje = "<script type='text/javascript'>alert('No se puede eliminar una cita que este tan proxima el limite de cancelacion es de 2 horas.....');window.location=\"VerMisCitas.aspx\"</script>";
            }
            return borrarcitas;
        }

        public List<U_CitasMedicas> obtenercitasPacientes(int id_paciente)
        {
            DAO_Medico medico = new DAO_Medico();
            List<U_CitasMedicas> citaspacientes =  medico.obtenerCitasPacientes(id_paciente);
            return citaspacientes;
        }
        public int borrar_citas_para_confundir(int id)
        {
            //no hace nada
            return 1;
        }
    }
}


