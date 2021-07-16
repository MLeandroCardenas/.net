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

    [Table("servicios_seguridad", Schema = "security")]
    public class U_seguridad_cliente
    {
        private int id;
        private string nombre_cliente;
        private string clave_cliente;
        private string token_seguridad;
        private DateTime? fecha_vigencia;
        private string token_generado;
        [Key]
        [Column("id_cliente")]
        public int Id { get => id; set => id = value; }
        [Column("nombre_cliente")]
        public string Nombre_cliente { get => nombre_cliente; set => nombre_cliente = value; }
        [Column("clave_cliente")]
        public string Clave_cliente { get => clave_cliente; set => clave_cliente = value; }
        [Column("token_seguridad")]
        public string Token_seguridad { get => token_seguridad; set => token_seguridad = value; }
        [Column("fecha_vigencia")]
        public DateTime? Fecha_vigencia { get => fecha_vigencia; set => fecha_vigencia = value; }
        [Column("token_generado")]
        public string Token_generado { get => token_generado; set => token_generado = value; }
    }
}
