using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Datos;

namespace Logica
{
    public class LP_citas_medicas
    {
        public string traer_cita_medica(int id)
        {
            DateTime fecha_cita = new DateTime();
            string fecha2 = "";
            DP_citas_medicas dp = new DP_citas_medicas();
            List<U_CitasMedicas> lista = dp.traer_citas(id);
            if (lista.Count > 0)
            {
                foreach (U_CitasMedicas ob in lista)
                {
                    fecha_cita = ob.Hora_inicio;
                }
            }
            else
            {
                return fecha2 = null;
            }
            return fecha_cita.ToString() ;
        }
    }
}
