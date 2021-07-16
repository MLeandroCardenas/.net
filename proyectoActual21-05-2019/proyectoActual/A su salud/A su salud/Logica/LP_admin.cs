using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Datos;

namespace Logica
{
    public class LP_admin
    {

        public List<UP_Historia_Clinica> traer_datos_citas_especialistas(int identificacion)
        {
            DP_admin dp = new DP_admin();
            return dp.validacion(identificacion);
        }
        
        public UP_estados_pacientes traer_estado(int id)
        {
            //   int estado;
            UP_estados_pacientes usuario = new UP_estados_pacientes();
            List<UP_estados_pacientes> lista = new List<UP_estados_pacientes>();
            DP_admin dp = new DP_admin();
            lista = dp.traer_estado(id);
            foreach (UP_estados_pacientes ob in lista)
            {
                usuario.Id_usuario = ob.Id_usuario;
                usuario.Identificacion_paciente = ob.Identificacion_paciente;
                usuario.Nombre_paciente = ob.Nombre_paciente;
                usuario.Apellido_paciente = ob.Apellido_paciente;
                usuario.Estado_cita = ob.Estado_cita;

            }
            return usuario;
        }

        public List<U_AgendaMedico> validar_cita(int id)
        {
            DP_admin dp = new DP_admin();
            return dp.validar_cita(id);
        }


        public int? validacion_horas(int id)
        {
            int? horas = 0;
            DP_admin dp = new DP_admin();
            List<UP_estados> lista = new List<UP_estados>();
            lista = dp.traer_estados(id);
            foreach (UP_estados obj in lista)
            {
                horas = obj.Horas_semana;
            }

            return horas;
        }
    }
}
