using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("idioma", Schema = "idioma")]
    public class U_Idioma
    {
        private int id;
        private string nombre_idioma;
        private string terminacion;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("nombre")]
        public string Nombre_idioma { get => nombre_idioma; set => nombre_idioma = value; }
        [Column("terminacion")]
        public string Terminacion { get => terminacion; set => terminacion = value; }
    }
}
