using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilitarios;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Datos
{
    public class DP_estados_paciente
    {

        public List<UP_estados_pacientes> traer_datos(int id)
        {
            using (var db = new Mapeo("administrador"))
            {
                var datos = db.estados_pacientes.Where(x => x.Id_usuario == id).ToList<UP_estados_pacientes>();
                return datos.ToList<UP_estados_pacientes>();
            }
        }

        public void actualizar_estado_paciente(int id)
        {
            using (var db = new Mapeo("medico"))
            {
                var resultado = db.estados_pacientes.SingleOrDefault(x => x.Id_usuario == id);
                resultado.Estado_cita = 2;
                db.SaveChanges();
            }
        }
    }
}
