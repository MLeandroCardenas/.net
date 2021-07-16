using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class U_retornoEspecialista
    {
        private long id;
        private DataTable datos;
        private string mensaje;

        
        public DataTable Datos { get => datos; set => datos = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }
        public long Id { get => id; set => id = value; }
    }
}
