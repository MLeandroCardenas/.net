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
    [Table("datos_horario3", Schema = "administrador")]
    public class UP_datos_horario
    {
        private int id_horario;
        private int id_medico;
        private string hora_inicio;
        private string hora_final;
        private int dia;
        [Key]
        [Column("id_horario")]
        public int Id_horario { get => id_horario; set => id_horario = value; }
        [Column("id_medico")]
        public int Id_medico { get => id_medico; set => id_medico = value; }
        [Column("hora_inicio")]
        public string Hora_inicio { get => hora_inicio; set => hora_inicio = value; }
        [Column("hora_final")]
        public string Hora_final { get => hora_final; set => hora_final = value; }
        [Column("dia")]
        public int Dia { get => dia; set => dia = value; }
    }
}
