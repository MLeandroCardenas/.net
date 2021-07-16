using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;

namespace Datos
{

    public class DP_Servicios
    {
        public List<UP_usuarios> traer_nombres_segun_rol(int id)
        {
            using (var db = new Mapeo("usuarios"))
            {
                var nombres = db.usuario.Where(x => x.Id_rol == id).ToList<UP_usuarios>();
                return nombres.ToList<UP_usuarios>();
            }
        }
        public List<UP_Historia_Clinica> traer_historia_servicio(int id)
        {
            using (var db = new Mapeo("medico"))
            {
                var historia = db.historia.Where(x => x.Documento_paciente == id).ToList<UP_Historia_Clinica>();
                return historia.ToList<UP_Historia_Clinica>();
            }
        }
        public List<U_CitasMedicas> traer_citas_pendientes(int id)
        {
            using (var db = new Mapeo("medico"))
            {
                var citas = db.citas.Where(x => x.Documento == id && x.Estado_cita == 1).ToList<U_CitasMedicas>();
                return citas.ToList<U_CitasMedicas>();
            }
        }

        public List<UP_Especialidades> traer_especialidades_servicio()
        {
            using (var db = new Mapeo("medico"))
            {
                var especialidades = db.especialidades.ToList<UP_Especialidades>();
                return especialidades.ToList<UP_Especialidades>();
            }
        }
    }
}
