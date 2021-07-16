using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Utilitarios
{
    [Serializable]
    [Table("token_repureacion_usuario", Schema = "usuarios")]
    public class UP_TokenRecuperacion
    {
        private int id;
        private long? user_id;
        private string token;
        private DateTime? fecha_creado;
        private DateTime? fecha_vigencia;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("user_id")]
        public long? User_id { get => user_id; set => user_id = value; }
        [Column("token")]
        public string Token { get => token; set => token = value; }
        [Column("fecha_creado")]
        public DateTime? Fecha_creado { get => fecha_creado; set => fecha_creado = value; }
        [Column("fecha_vigencia")]
        public DateTime? Fecha_vigencia { get => fecha_vigencia; set => fecha_vigencia = value; }

    }
}
