using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Datos;

namespace Logica
{
    public class LP_consultas
    {
        public string traer_datos_citas()
        {
            Consulta con = new Consulta();
            //con.mostrar_Agenda_medicina_general();
            var json = JsonConvert.SerializeObject(con.mostrar_Agenda_medicina_general());
            return json;
        }
    }
}