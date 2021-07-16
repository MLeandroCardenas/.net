using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilitarios;
using Datos;
using System.Threading.Tasks;

namespace Logica
{
    public class LP_especialidad
    {
        public List<U_ControlesIdiomas> traer_lista(int idioma)
        {
            List<U_ControlesIdiomas> lista = new List<U_ControlesIdiomas>();
            List<U_ControlesIdiomas> lista2 = new List<U_ControlesIdiomas>();
            DP_especialidad dp = new DP_especialidad();
            lista = dp.traer_datos_especialidad();
            foreach (U_ControlesIdiomas obj in lista)
            {
                if (obj.Idioma_id == idioma && obj.Formulario_id == 76)
                {
                    lista2.Add(obj);
                }
            }
            return lista2;
        }

        public List<U_ControlesIdiomas> traer_lista_meses(int idioma)
        {
            List<U_ControlesIdiomas> lista = new List<U_ControlesIdiomas>();
            List<U_ControlesIdiomas> lista2 = new List<U_ControlesIdiomas>();
            DP_especialidad dp = new DP_especialidad();
            lista = dp.traer_datos_meses();
            foreach (U_ControlesIdiomas obj in lista)
            {
                if (obj.Idioma_id == idioma && obj.Formulario_id == 77)
                {
                    lista2.Add(obj);
                }
            }
            return lista2;
        }
        public List<UP_Especialidades> traer_especialidades()
        {
            DP_especialidad dp = new DP_especialidad();
            return dp.traer_todas_especialidad();
        }
        public void eliminar_especialidad(int id)
        {
            DP_especialidad dp = new DP_especialidad();
            dp.borrar_especialidad(id);
        }
        public List<UP_Especialidades> traer_especialidades_diferentes_a_medicina_general()
        {
            DP_especialidad dp = new DP_especialidad();
            return dp.obtener_especialidades_especialistas();
        }
    }
}