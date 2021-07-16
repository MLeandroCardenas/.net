using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("seguridad", Schema = "usuarios")]
    public class UP_Seguridad
    {
        private int id;
        private Int64 id_user;
        private int? cantidad_sesiones;
        private int? sesiones_activas;
        private int? intentos_erroneos;
        private int? maximo_intentos;
        private int estado;
        private string sesion;
        private DateTime? last_modified;
        private DateTime? fecha_bloqueo;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("id_user")]
        public long Id_user { get => id_user; set => id_user = value; }
        [Column("cantidad_sesiones")]
        public int? Cantidad_sesiones { get => cantidad_sesiones; set => cantidad_sesiones = value; }
        [Column("sesiones_activas")]
        public int? Sesiones_activas { get => sesiones_activas; set => sesiones_activas = value; }
        [Column("intentos_erroneos")]
        public int? Intentos_erroneos { get => intentos_erroneos; set => intentos_erroneos = value; }
        [Column("maximo_intentos")]
        public int? Maximo_intentos { get => maximo_intentos; set => maximo_intentos = value; }
        [Column("estado")]
        public int Estado { get => estado; set => estado = value; }
        [Column("session")]
        public string Sesion { get => sesion; set => sesion = value; }
        [Column("last_modified")]
        public DateTime? Last_modified { get => last_modified; set => last_modified = value; }
        [Column("fecha_bloqueo")]
        public DateTime? Fecha_bloqueo { get => fecha_bloqueo; set => fecha_bloqueo = value; }
    }
}
