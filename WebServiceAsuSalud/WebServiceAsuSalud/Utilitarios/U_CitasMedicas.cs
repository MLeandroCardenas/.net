using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("cita_medicas", Schema = "medico")]
    public class U_CitasMedicas
    {

        private int id;
        private int id_medico;
        private string nombre_medico;
        private string apellido_medico;
        private string especialidad;
        private DateTime hora_inicio;
        private DateTime hora_fin;
        private int id_paciente;
        private string nombre_paciente;
        private int estado_cita;
        private string apellido_paciente;
        private string session;
        private DateTime ultima_modificacion;
        private long documento;



        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("id_medico")]
        public int Id_medico { get => id_medico; set => id_medico = value; }
        [Column("nombre_medico")]
        public string Nombre_medico { get => nombre_medico; set => nombre_medico = value; }
        [Column("apellido_medico")]
        public string Apellido_medico { get => apellido_medico; set => apellido_medico = value; }
        [Column("especialidad")]
        public string Especialidad { get => especialidad; set => especialidad = value; }
        [Column("hora_inicio")]
        public DateTime Hora_inicio { get => hora_inicio; set => hora_inicio = value; }
        [Column("hora_fin")]
        public DateTime Hora_fin { get => hora_fin; set => hora_fin = value; }
        [Column("id_paciente")]
        public int Id_paciente { get => id_paciente; set => id_paciente = value; }
        [Column("nombre_paciente")]
        public string Nombre_paciente { get => nombre_paciente; set => nombre_paciente = value; }
        [Column("estado_cita")]
        public int Estado_cita { get => estado_cita; set => estado_cita = value; }
        [Column("documento")]
        public long Documento { get => documento; set => documento = value; }
        [Column("apellido_paciente")]
        public string Apellido_paciente { get => apellido_paciente; set => apellido_paciente = value; }
        [Column("session")]
        public string Session { get => session; set => session = value; }
        [Column("last_modified")]
        public DateTime Ultima_modificacion { get => ultima_modificacion; set => ultima_modificacion = value; }
    }
}