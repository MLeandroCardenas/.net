using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    [Serializable]
    [Table("estados_pacientes", Schema = "administrador")]
    public class UP_estados_pacientes
    {
        private int id_usuario;
        private string nombre_paciente;
        private string apellido_paciente;
        private long identificacion_paciente;
        private int estado_cita;
        [Key]
        [Column("id_usuario")]
        public int Id_usuario { get => id_usuario; set => id_usuario = value; }
        [Column("nombre_paciente")]
        public string Nombre_paciente { get => nombre_paciente; set => nombre_paciente = value; }
        [Column("apellido_paciente")]
        public string Apellido_paciente { get => apellido_paciente; set => apellido_paciente = value; }
        [Column("identificacion_paciente")]
        public long Identificacion_paciente { get => identificacion_paciente; set => identificacion_paciente = value; }
        [Column("estado_cita")]
        public int Estado_cita { get => estado_cita; set => estado_cita = value; }
    }
}