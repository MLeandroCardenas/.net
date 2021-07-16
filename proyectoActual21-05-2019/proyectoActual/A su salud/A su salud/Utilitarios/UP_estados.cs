using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    [Serializable]
    [Table("estados_medicos", Schema = "administrador")]
    public class UP_estados
    {           
        private int id;
        private int id_medico;
        private string nombre_medico;
        private string apellido_medico;
        private string especialidad;
        private int estado_horario;
        private long ident_medico;
        private int? horas_semana;
        private int estado_agenda;
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
        [Column("estado_horario")]
        public int Estado_horario { get => estado_horario; set => estado_horario = value; }
        [Column("ident_medico")]
        public long Ident_medico { get => ident_medico; set => ident_medico = value; }
        [Column("horas_semana")]
        public int? Horas_semana { get => horas_semana; set => horas_semana = value; }
        [Column("estado_agenda")]
        public int Estado_agenda { get => estado_agenda; set => estado_agenda = value; }
    }
}
