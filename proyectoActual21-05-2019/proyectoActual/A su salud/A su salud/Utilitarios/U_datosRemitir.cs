using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class U_datosRemitir
    {
        private int id_remitir;
        private string nombre_remitir;
        private string apellido_remitir;
        private long documento_remitir;

        public int Id_remitir { get => id_remitir; set => id_remitir = value; }
        public string Nombre_remitir { get => nombre_remitir; set => nombre_remitir = value; }
        public string Apellido_remitir { get => apellido_remitir; set => apellido_remitir = value; }
        public long Documento_remitir { get => documento_remitir; set => documento_remitir = value; }
    }
}
