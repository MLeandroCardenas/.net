using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class E_DatosHorario
    {
        private int idMedico;
        private string horainicio;
        private string horafin;
        private int diasemana;

        public int IdMedico { get => idMedico; set => idMedico = value; }
        public string Horainicio { get => horainicio; set => horainicio = value; }
        public string Horafin { get => horafin; set => horafin = value; }
        public int Diasemana { get => diasemana; set => diasemana = value; }
    }
}
