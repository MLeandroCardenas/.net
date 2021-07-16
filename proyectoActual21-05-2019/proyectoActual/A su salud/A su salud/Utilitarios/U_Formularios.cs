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
    [Table("formulario", Schema = "idioma")]
    public class U_Formularios
    {
        private int id;
        private string nombre;
        private string url;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }

        [Column("nombre")]
        public string Nombre { get => nombre; set => nombre = value; }

        [Column("url")]
        public string Url { get => url; set => url = value; }
    }
}
