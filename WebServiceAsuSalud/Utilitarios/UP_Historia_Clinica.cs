using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("historia_clinica", Schema = "medico")]
    public class UP_Historia_Clinica
    {
        private long id;
        private string nombre_paciente;
        private int documento_paciente;
        private string motivo_consulta;
        private string alergias;
        private string cirugias;
        private int altura;
        private int peso;
        private string observacion_piel;
        private string observacion_respiracion;
        private string observacion_boca;
        private string diagnostico;
        private string apellido_paciente;
        private string nombre_medico;
        private string especialidad;
        private string apellido_medico;
        private int id_medico;
        private int id_paciente;
        private DateTime fecha_atencion;
        private string asignar_especialista;
        private int? estado;
        private string session;
        private DateTime last_modified;

        [Key]
        [Column("id")]
        public long Id { get => id; set => id = value; }
        [Column("nombre_paciente")]
        public string Nombre_paciente { get => nombre_paciente; set => nombre_paciente = value; }
        [Column("documento_paciente")]
        public int Documento_paciente { get => documento_paciente; set => documento_paciente = value; }
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
        public string Observacion_piel { get => observacion_piel; set => observacion_piel = value; }
        [Column("observacion_respiracion")]
        public string Observacion_respiracion { get => observacion_respiracion; set => observacion_respiracion = value; }
        [Column("observacion_boca")]
        public string Observacion_boca { get => observacion_boca; set => observacion_boca = value; }
        [Column("diagnostico")]
        public string Diagnostico { get => diagnostico; set => diagnostico = value; }
        [Column("apellido_paciente")]
        public string Apellido_paciente { get => apellido_paciente; set => apellido_paciente = value; }
        [Column("nombre_medico")]
        public string Nombre_medico { get => nombre_medico; set => nombre_medico = value; }
        [Column("especialidad")]
        public string Especialidad { get => especialidad; set => especialidad = value; }
        [Column("apellido_medico")]
        public string Apellido_medico { get => apellido_medico; set => apellido_medico = value; }
        [Column("id_medico")]
        public int Id_medico { get => id_medico; set => id_medico = value; }
        [Column("id_paciente")]
        public int Id_paciente { get => id_paciente; set => id_paciente = value; }
        [Column("fecha_atencion")]
        public DateTime Fecha_atencion { get => fecha_atencion; set => fecha_atencion = value; }
        [Column("asignar_especialista")]
        public string Asignar_especialista { get => asignar_especialista; set => asignar_especialista = value; }
        [Column("session")]
        public string Session { get => session; set => session = value; }
        [Column("last_modified")]
        public DateTime Last_modified { get => last_modified; set => last_modified = value; }
        [Column("estado")]
        public int? Estado { get => estado; set => estado = value; }
    }
}
