using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("pqrs", Schema = "administrador")]
    public class UP_Pqr
    {
        private long id;
        private string tipo_mensaje;
        private string mensaje;
        private string responder_mensaje;
        private string nombres;
        private string apellidos;
        private string session;
        private DateTime last_modified;
        private int id_usuario;
        private int estado;
        private string correo;

        [Key]
        [Column("id")]
        public long Id { get => id; set => id = value; }
        [Column("tipo_mensaje")]
        public string Tipo_mensaje { get => tipo_mensaje; set => tipo_mensaje = value; }
        [Column("mensaje")]
        public string Mensaje { get => mensaje; set => mensaje = value; }
        [Column("responder_mensaje")]
        public string Responder_mensaje { get => responder_mensaje; set => responder_mensaje = value; }
        [Column("nombres")]
        public string Nombres { get => nombres; set => nombres = value; }
        [Column("apellidos")]
        public string Apellidos { get => apellidos; set => apellidos = value; }
        [Column("session")]
        public string Session { get => session; set => session = value; }
        [Column("last_modified")]
        public DateTime Last_modified { get => last_modified; set => last_modified = value; }
        [Column("id_usuario")]
        public int Id_usuario { get => id_usuario; set => id_usuario = value; }
        [Column("estado")]
        public int Estado { get => estado; set => estado = value; }
        [Column("correo")]
        public string Correo { get => correo; set => correo = value; }
    }
}