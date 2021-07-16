using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("historia_clinica", Schema = "medico")]
    public class UP_HistoriaClinica
    {
        private int id;
        private string nombre_paciente;
        private Int64 documento_paciente;
        private string motivo_consulta;
        private string alergias;
        private string cirugias;
        private int altura;
        private int peso;
        private string observacionPiel;
        private string observacionRespiracion;
        private string observacionBoca;
        private string diagnostico;
        private string apellido_paciente;
        private int id_medico;
        private int id_paciente;
        private DateTime fecha_atencion;
        private string asginarEspecialista;
        private int? estado;
        private string session;
        private DateTime ultima_modificacion;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("nombre_paciente")]
        public string Nombre_paciente { get => nombre_paciente; set => nombre_paciente = value; }
        [Column("documento_paciente")]
        public long Documento_paciente { get => documento_paciente; set => documento_paciente = value; }
        [Column("motivo_consulta")]
        public string Motivo_consulta { get => motivo_consulta; set => motivo_consulta = value; }
        [Column("alergias")]
        public string Alergias { get => alergias; set => alergias = value; }
        [Column("cirugias")]
        public string Cirugias { get => cirugias; set => cirugias = value; }
        [Column("altura")]
        public int Altura { get => altura; set => altura = value; }
        [Column("peso")]
        public int Peso { get => peso; set => peso = value; }
        [Column("observacion_piel")]
        public string ObservacionPiel { get => observacionPiel; set => observacionPiel = value; }
        [Column("observacion_respiracion")]
        public string ObservacionRespiracion { get => observacionRespiracion; set => observacionRespiracion = value; }
        [Column("observacion_boca")]
        public string ObservacionBoca { get => observacionBoca; set => observacionBoca = value; }
        [Column("diagnostico")]
        public string Diagnostico { get => diagnostico; set => diagnostico = value; }
        [Column("apellido_paciente")]
        public string Apellido_paciente { get => apellido_paciente; set => apellido_paciente = value; }
        [Column("id_medico")]
        public int Id_medico { get => id_medico; set => id_medico = value; }
        [Column("id_paciente")]
        public int Id_paciente { get => id_paciente; set => id_paciente = value; }
        [Column("fecha_atencion")]
        public DateTime Fecha_atencion { get => fecha_atencion; set => fecha_atencion = value; }
        [Column("asignar_especialista")]
        public string AsginarEspecialista { get => asginarEspecialista; set => asginarEspecialista = value; }
        [Column("session")]
        public string Session { get => session; set => session = value; }
        [Column("last_modified")]
        public DateTime Ultima_modificacion { get => ultima_modificacion; set => ultima_modificacion = value; }
        [Column("estado")]
        public int? Estado { get => estado; set => estado = value; }
    }
}
