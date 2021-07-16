using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class U_datosRemitirPaciente
    {
        private int medico_id;
        private string nombre_medico;
        private string apellido_medico;
        private string especialidad;
        private string fecha_inicio;
        private string fecha_fin;
        private int id_paciente_remitir;
        private string nombre_paciente;
        private int estado_cita;
        private long documento_paciente;
        private string apellido_paciente;
        private string session;

        public int Medico_id { get => medico_id; set => medico_id = value; }
        public string Nombre_medico { get => nombre_medico; set => nombre_medico = value; }
        public string Apellido_medico { get => apellido_medico; set => apellido_medico = value; }
        public string Especialidad { get => especialidad; set => especialidad = value; }
        public string Fecha_inicio { get => fecha_inicio; set => fecha_inicio = value; }
        public string Fecha_fin { get => fecha_fin; set => fecha_fin = value; }
        public int Id_paciente_remitir { get => id_paciente_remitir; set => id_paciente_remitir = value; }
        public string Nombre_paciente { get => nombre_paciente; set => nombre_paciente = value; }
        public int Estado_cita { get => estado_cita; set => estado_cita = value; }
        public long Documento_paciente { get => documento_paciente; set => documento_paciente = value; }
        public string Apellido_paciente { get => apellido_paciente; set => apellido_paciente = value; }
        public string Session { get => session; set => session = value; }


        /*
    dataAdapter.SelectCommand.Parameters.Add("_nombre_paciente", NpgsqlDbType.Text).Value = cita.Nombres;
                dataAdapter.SelectCommand.Parameters.Add("_estado_cita", NpgsqlDbType.Integer).Value = 1;
                dataAdapter.SelectCommand.Parameters.Add("_documento_paciente", NpgsqlDbType.Integer).Value = cita.Identificacion;
                dataAdapter.SelectCommand.Parameters.Add("_apellido_paciente", NpgsqlDbType.Text).Value = cita.Apellidos;
                dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = cita.Session;
            */

    }
}
