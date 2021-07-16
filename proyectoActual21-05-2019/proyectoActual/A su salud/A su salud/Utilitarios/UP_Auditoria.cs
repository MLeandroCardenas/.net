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
    [Table("auditoria", Schema = "security")]
    public class UP_Auditoria
    {
        private long id;
        private DateTime fecha;
        private string accion;
        private string schema;
        private string tabla;
        private string session;
        private string user_bd;
        private string data;
        private string pk;

        [Key]
        [Column("id")]
        public long Id { get => id; set => id = value; }
        [Column("fecha")]
        public DateTime Fecha { get => fecha; set => fecha = value; }
        [Column("accion")]
        public string Accion { get => accion; set => accion = value; }
        [Column("schema")]
        public string Schema { get => schema; set => schema = value; }
        [Column("tabla")]
        public string Tabla { get => tabla; set => tabla = value; }
        [Column("session")]
        public string Session { get => session; set => session = value; }
        [Column("user_bd")]
        public string User_bd { get => user_bd; set => user_bd = value; }
        [Column("data")]
        public string Data { get => data; set => data = value; }
        [Column("pk")]
        public string Pk { get => pk; set => pk = value; }
    }
}
