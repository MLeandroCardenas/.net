using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class U_DatosMedicoActualizar
    {
        private List<U_AgendaMedico> datos;
        private string mensaje;

        public string Mensaje { get => mensaje; set => mensaje = value; }
        public List<U_AgendaMedico> Datos { get => datos; set => datos = value; }
    }
}
