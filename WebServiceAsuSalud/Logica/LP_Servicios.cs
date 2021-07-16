using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Datos;
using Newtonsoft.Json;

namespace Logica
{
    public class LP_Servicios
    {
        public string traer_roles_nombres(int id)
        {
            DP_Servicios dp = new DP_Servicios();
        
            var json = JsonConvert.SerializeObject(dp.traer_nombres_segun_rol(id));
            return json;
            
        }
        public string traer_historia_clinica_servicio(int id)
        {
            DP_Servicios dp = new DP_Servicios();
           
            var json = JsonConvert.SerializeObject(dp.traer_historia_servicio(id));
            return json;
        }
        public string traer_citas_pendientes(int id)
        {
            DP_Servicios dp = new DP_Servicios();          
            var json = JsonConvert.SerializeObject(dp.traer_citas_pendientes(id));
            return json;
        }

        public string traer_especialidades_servicio()
        {
            DP_Servicios dp = new DP_Servicios();
            
            var json = JsonConvert.SerializeObject(dp.traer_especialidades_servicio());
            return json;
        }
    }
}
