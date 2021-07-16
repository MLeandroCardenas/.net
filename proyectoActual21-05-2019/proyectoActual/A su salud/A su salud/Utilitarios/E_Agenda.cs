using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class E_Agenda
    {
        private DateTime fechainicio;
        private DateTime fechafinal;
        private int id;
        private string sesion;

        public DateTime Fechainicio { get => fechainicio; set => fechainicio = value; }
        public DateTime Fechafinal { get => fechafinal; set => fechafinal = value; }
        public int Id { get => id; set => id = value; }
        public string Sesion { get => sesion; set => sesion = value; }
    }
}
