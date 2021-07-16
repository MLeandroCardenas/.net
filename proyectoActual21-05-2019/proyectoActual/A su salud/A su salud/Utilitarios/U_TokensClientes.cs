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
    [Table("token_cliente", Schema = "security")]
    public class U_TokensClientes
    {
        private int id;
        private string nombre_cliente;
        private string token_generado;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("nombre_cliente")]
        public string Nombre_cliente { get => nombre_cliente; set => nombre_cliente = value; }
        [Column("token_generado")]
        public string Token_generado { get => token_generado; set => token_generado = value; }
    }
}
