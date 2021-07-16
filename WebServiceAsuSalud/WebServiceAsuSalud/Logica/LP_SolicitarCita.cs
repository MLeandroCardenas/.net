using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Utilitarios;

namespace Logica
{
    public class LP_SolicitarCita : System.Web.Services.Protocols.SoapHeader
    {
        //int id, int id_medico, string nombre_medico, string apellido_medico, string especialidad, DateTime hora_inicio, DateTime hora_fin, int id_paciente, string nombre_paciente, int estado_cita, string apellido_paciente, string session, DateTime ultima_modificacion, int documento
        public U_CitasMedicas solicitar_cita(long identificacion, int id_cita)
        {
            UP_estados_pacientes estados = new UP_estados_pacientes();
            DP_SolicitarCita dp = new DP_SolicitarCita();
            U_CitasMedicas cita = new U_CitasMedicas();
            UP_usuarios user = new UP_usuarios();
            U_AgendaMedico agenda = new U_AgendaMedico();
            user = dp.traer_usuario(identificacion);
            agenda = dp.traer_cita(id_cita);
            agenda.Usuario_id = user.Id;
            cita.Apellido_medico = agenda.Apellido_medico;
            cita.Apellido_paciente = user.Apellidos;
            cita.Documento = user.Identificacion;
            cita.Especialidad = agenda.Especialidad;
            cita.Estado_cita = 1;
            cita.Hora_fin = agenda.Fecha_fin;
            cita.Hora_inicio = agenda.Fecha_inicio;
            cita.Id_medico = agenda.Medico_id;
            cita.Id_paciente = user.Id;
            cita.Nombre_medico = agenda.Nombre_medico;
            cita.Nombre_paciente = user.Nombres;
            return cita;
        }

        public void agendar_cita(long identificacion, int id_cita)
        {
            UP_estados_pacientes estados = new UP_estados_pacientes();
            DP_SolicitarCita dp = new DP_SolicitarCita();
            U_CitasMedicas cita = new U_CitasMedicas();
            UP_usuarios user = new UP_usuarios();
            U_AgendaMedico agenda = new U_AgendaMedico();
            user = dp.traer_usuario(identificacion);
            agenda = dp.traer_cita(id_cita);
            agenda.Usuario_id = user.Id;
            dp.agendar_cita(agenda);
            cita.Apellido_medico = agenda.Apellido_medico;
            cita.Apellido_paciente = user.Apellidos;
            cita.Documento = user.Identificacion;
            cita.Especialidad = agenda.Especialidad;
            cita.Estado_cita = 1;
            cita.Hora_fin = agenda.Fecha_fin;
            cita.Hora_inicio = agenda.Fecha_inicio;
            cita.Id_medico = agenda.Medico_id;
            cita.Id_paciente = user.Id;
            cita.Nombre_medico = agenda.Nombre_medico;
            cita.Nombre_paciente = user.Nombres;
            cita.Session = agenda.Session;
            cita.Ultima_modificacion = DateTime.Now;
            dp.insertar_cita(cita);
            estados.Id_usuario = user.Id;
            estados.Nombre_paciente = user.Nombres;
            estados.Apellido_paciente = user.Apellidos;
            estados.Identificacion_paciente = user.Identificacion;
            estados.Estado_cita = 1;
            //dp.crear_estado(estados);
        }



    }
}
