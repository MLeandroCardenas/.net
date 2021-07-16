using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Utilitarios
{
    [Serializable]
    [Table("parametros", Schema = "administrador")]
    public class UP_parametros
    {
        private int id;
        private string key;
        private int valor;
        private string session;
        private DateTime last_modified;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("llave")]
        public string Key { get => key; set => key = value; }
        [Column("valor")]
        public int Valor { get => valor; set => valor = value; }
        [Column("session")]
        public string Session { get => session; set => session = value; }
        [Column("last_modified")]
        public DateTime Last_modified { get => last_modified; set => last_modified = value; }
    }
}