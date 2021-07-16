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
    [Table("controles", Schema = "idioma")]
    public class U_ControlesIdiomas
    {
        private int id;
        private string control;
        private int idioma_id;
        private int formulario_id;
        private string texto;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("control")]
        public string Control { get => control; set => control = value; }
        [Column("idioma_id")]
        public int Idioma_id { get => idioma_id; set => idioma_id = value; }
        [Column("formulario_id")]
        public int Formulario_id { get => formulario_id; set => formulario_id = value; }
        [Column("texto")]
        public string Texto { get => texto; set => texto = value; }
    }
}
