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
    [Table("especialidades", Schema = "medico")]
    public class UP_Especialidades
    {
        private int id;
        private string nombre;
        private string session;
        private DateTime last_modified;


        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("nombre")]
        public string Nombre { get => nombre; set => nombre = value; }
        [Column("session")]
        public string Session { get => session; set => session = value; }
        [Column("last_modified")]
        public DateTime Last_modified { get => last_modified; set => last_modified = value; }
    }
}
