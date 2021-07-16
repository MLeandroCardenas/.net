using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;

namespace Datos
{
    public class DP_especialidad
    {
        public List<U_ControlesIdiomas> traer_datos_especialidad()
        {
            using (var db = new Mapeo("medico"))
            {
                var datos = db.controles.ToList<U_ControlesIdiomas>();
                return datos.ToList<U_ControlesIdiomas>();
            }
        }

        public List<UP_Especialidades> traer_espe_auditoria(int id)
        {
            using (var db = new Mapeo("medico"))
            {
                var datos = db.especialidad.Where(x=> x.Id== id).ToList<UP_Especialidades>();
                return datos.ToList<UP_Especialidades>();
            }
        }
        public List<UP_Especialidades> traer_todas_especialidad()
        {
            using (var db = new Mapeo("medico"))
            {
                var datos = db.especialidad.ToList<UP_Especialidades>();
                return datos.ToList<UP_Especialidades>();
            }
        }

        public List<U_ControlesIdiomas> traer_datos_meses()
        {
            using (var db = new Mapeo("idioma"))
            {
                var datos_meses = db.controles.ToList<U_ControlesIdiomas>();
                return datos_meses.ToList<U_ControlesIdiomas>();
            }
        }
        public void borrar_especialidad(int id)
        {
            using (var db = new Mapeo("medico"))
            {
                DP_Auditoria auditoria = new DP_Auditoria();
                UP_Acceso acceso = new UP_Acceso();
                UP_Especialidades e = new UP_Especialidades();
                List<UP_Especialidades> espe = traer_espe_auditoria(id);
                foreach (UP_Especialidades ob in espe)
                {
                    e.Id = ob.Id;
                    e.Session = ob.Session;
                }
                acceso.Id = e.Id;
                acceso.Session = e.Session;
                var especialidad = db.especialidad.Where(x => x.Id == id).FirstOrDefault();
                db.especialidad.Remove(especialidad);
                db.SaveChanges();
                auditoria.delete(especialidad,acceso,"medico","especialidades");
            }
        }

        public List<UP_Especialidades> obtener_especialidades_especialistas()
        {
            using (var db = new Mapeo("medico"))
            {
                var especialidades = db.especialidad.Where(x => x.Nombre != "Medicina General");
                return especialidades.ToList<UP_Especialidades>();
            }
        }
    }
}
