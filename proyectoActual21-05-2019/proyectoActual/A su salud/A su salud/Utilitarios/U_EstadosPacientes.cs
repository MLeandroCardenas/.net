using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("estados_pacientes", Schema = "administrador")]
    public class U_EstadosPacientes
    {
        private int id_usuario;
        private string nombrePaciente;
        private string apellidoPaciente;
        private Int64 identificacion;
        private int estadocita;

        [Key]
        [Column("id_usuario")]
        public int Id_usuario { get => id_usuario; set => id_usuario = value; }
        [Column("nombre_paciente")]
        public string NombrePaciente { get => nombrePaciente; set => nombrePaciente = value; }
        [Column("apellido_paciente")]
        public string ApellidoPaciente { get => apellidoPaciente; set => apellidoPaciente = value; }
        [Column("identificacion_paciente")]
        public long Identificacion { get => identificacion; set => identificacion = value; }
        [Column("estado_cita")]
        public int Estadocita { get => estadocita; set => estadocita = value; }
    }
}
