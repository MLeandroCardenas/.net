using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("agenda_medico", Schema = "medico")]
    public class U_AgendaMedico
    {
        private int id;
        private Int64 medico_id;
        private DateTime fecha_inicio;
        private DateTime fecha_fin;
        private int? usuario_id;
        private string nombre_medico;
        private string especialidad;
        private string apellido_medico;
        private string session;
        private DateTime last_modified;
        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("medico_id")]
        public long Medico_id { get => medico_id; set => medico_id = value; }
        [Column("fecha_inicio")]
        public DateTime Fecha_inicio { get => fecha_inicio; set => fecha_inicio = value; }
        [Column("fecha_fin")]
        public DateTime Fecha_fin { get => fecha_fin; set => fecha_fin = value; }
        [Column("usuario_id")]
        public int? Usuario_id { get => usuario_id; set => usuario_id = value; }
        [Column("nombre_medico")]
        public string Nombre_medico { get => nombre_medico; set => nombre_medico = value; }
        [Column("especialidad")]
        public string Especialidad { get => especialidad; set => especialidad = value; }
        [Column("apellido_medico")]
        public string Apellido_medico { get => apellido_medico; set => apellido_medico = value; }
        [Column("session")]
        public string Session { get => session; set => session = value; }
        [Column("last_modified")]
        public DateTime Last_modified { get => last_modified; set => last_modified = value; }

    }
}
