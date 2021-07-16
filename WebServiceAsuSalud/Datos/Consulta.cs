using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;

namespace Datos
{
    public class Consulta
    {
        public List<U_AgendaMedico> mostrar_Agenda_medicina_general()
        {
            using (var db = new Mapeo("medico"))
            {
                var lista_citas = db.agenda.Where(x => x.Usuario_id == null && x.Especialidad == "Medicina General" && x.Fecha_inicio > DateTime.Now).ToList<U_AgendaMedico>();
                return lista_citas.ToList<U_AgendaMedico>();
            }
        }

        public List<UP_usuarios> traer_usuarios()
        {
            using (var db = new Mapeo("usuarios"))
            {
                var lista_usuarios = db.usuario.ToList<UP_usuarios>();
                return lista_usuarios;
            }
        }
    }
}
