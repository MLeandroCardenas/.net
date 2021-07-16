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
    public class LP_consultas
    {
        public string traer_datos_citas()
        {
            Consulta con = new Consulta();
            //con.mostrar_Agenda_medicina_general();
            var json = JsonConvert.SerializeObject(con.mostrar_Agenda_medicina_general());
            return json;
        }

        public string traer_usuarios()
        {
            Consulta con = new Consulta();
            //con.mostrar_Agenda_medicina_general();
            var json = JsonConvert.SerializeObject(con.traer_usuarios());
            return json;
        }
    }
}