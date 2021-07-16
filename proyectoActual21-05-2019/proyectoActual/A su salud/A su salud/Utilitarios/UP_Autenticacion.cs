using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Utilitarios
{
    [Serializable]
    [Table("autenication", Schema = "security")]
    public class UP_Autenticacion
    {
        private long id;
        private int? user_id;
        private string ip;
        private string mac;
        private DateTime? fecha_inicio;
        private string session;
        private DateTime? fecha_fin;

        [Key]
        [Column("id")]
        public long Id { get => id; set => id = value; }
        [Column("fecha_fin")]
        public DateTime? Fecha_fin { get => fecha_fin; set => fecha_fin = value; }
        [Column("ip")]
        public string Ip { get => ip; set => ip = value; }
        [Column("mac")]
        public string Mac { get => mac; set => mac = value; }
        [Column("session")]
        public string Session { get => session; set => session = value; }
        [Column("user_id")]
        public int? User_id { get => user_id; set => user_id = value; }
        [Column("fecha_inicio")]
        public DateTime? Fecha_inicio { get => fecha_inicio; set => fecha_inicio = value; }

    }
}
