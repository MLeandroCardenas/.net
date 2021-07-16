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
    [Table("usuarios", Schema = "usuarios")]
    public class UP_usuarios
    {
        private long id;
        private string apellidos;
        private string nombres;
        private Int64 identificacion;
        private string email;
        private string clave;
        private int id_rol;
        private string session;
        private int estado;
        private DateTime last_modified;
        private string especialidad;
        private string foto;
        private string url;

        [Key]
        [Column("id")]
        public long Id { get => id; set => id = value; }
        [Column("apellidos")]
        public string Apellidos { get => apellidos; set => apellidos = value; }
        [Column("nombres")]
        public string Nombres { get => nombres; set => nombres = value; }
        [Column("identificacion")]
        public long Identificacion { get => identificacion; set => identificacion = value; }
        [Column("email")]
        public string Email { get => email; set => email = value; }
        [Column("clave")]
        public string Clave { get => clave; set => clave = value; }
        [Column("id_rol")]
        public int Id_rol { get => id_rol; set => id_rol = value; }
        [Column("session")]
        public string Session { get => session; set => session = value; }
        [Column("estado")]
        public int Estado { get => estado; set => estado = value; }
        [Column("last_modified")]
        public DateTime Last_modified { get => last_modified; set => last_modified = value; }
        [Column("especialidad")]
        public string Especialidad { get => especialidad; set => especialidad = value; }
        [Column("foto")]
        public string Foto { get => foto; set => foto = value; }
        [Column("url")]
        public string Url { get => url; set => url = value; }

    }
}
