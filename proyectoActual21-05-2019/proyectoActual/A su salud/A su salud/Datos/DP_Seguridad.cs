using System;
using System.Collections.Generic;
using System.Linq;
using Utilitarios;

namespace Datos
{
    public class DP_Seguridad
    {
        public List<UP_Seguridad> traerUsuarios()
        {
            using (var db = new Mapeo("usuarios"))
            {
                return db.seguridad.Select(x => new { iden = x.Id_user, sesiones = x.Cantidad_sesiones }).ToList()
                    .Select(x => new UP_Seguridad() { Id_user = x.iden, Cantidad_sesiones = x.sesiones }).ToList();
            }
        }

        public void editarSesion(UP_Seguridad segur)
        {
            using (var db = new Mapeo("usuarios"))
            {
                var resul = db.seguridad.SingleOrDefault(x=> x.Id_user == segur.Id_user);
                resul.Cantidad_sesiones = segur.Cantidad_sesiones;
                db.SaveChanges();
            }
        }

        public List<UP_Seguridad> traerSesiones(UP_Seguridad segur)
        {
            using (var db = new Mapeo("usuarios"))
            {
                var usuario1 = db.seguridad.Where(x => x.Id_user == segur.Id_user).ToList<UP_Seguridad>();
                return usuario1.ToList<UP_Seguridad>();
            }
        }

        public void actualizarSesionesActivas(UP_Seguridad segur)
        {
            using (var db = new Mapeo("usuarios"))
            {
                var resul = db.seguridad.SingleOrDefault(x => x.Id_user == segur.Id_user);
                resul.Sesiones_activas = segur.Sesiones_activas;
                db.SaveChanges();
            }
        }

        public List<UP_Seguridad> obtenersesionesactivas(UP_Seguridad segur)
        {
            using (var db = new Mapeo("usuarios"))
            {
                var usuario = db.seguridad.Where(x => x.Id_user == segur.Id_user).ToList<UP_Seguridad>();
                return usuario.ToList<UP_Seguridad>();
            }
        }

        public void actualizarFechaBloqueo(UP_Seguridad segur)
        {
            using (var db = new Mapeo("usuarios"))
            {
                var resul = db.seguridad.SingleOrDefault(x => x.Id_user == segur.Id_user);
                resul.Fecha_bloqueo = segur.Fecha_bloqueo;

                var dato = db.usuario_medico.Where(x => x.Identificacion == segur.Id_user).ToList<UP_usuarios>();
                foreach (UP_usuarios obj in dato)
                {
                    obj.Estado = 2;
                }
                
                db.SaveChanges();


            }
        }

        public void actualizarIntentos(UP_Seguridad segur)
        {
            using (var db = new Mapeo("usuarios"))
            {
                var resul = db.seguridad.SingleOrDefault(x => x.Id_user == segur.Id_user);
                if (resul != null)
                {
                    resul.Intentos_erroneos = segur.Intentos_erroneos;
                    db.SaveChanges();
                }                
            }
        }
        public void actualizarEstado(long iden)
        {
            using (var db = new Mapeo("usuarios"))
            {
                List<UP_usuarios> lista  = new DP_usuarios().obtener_usuarios(iden);
                if (lista.Count!=0)
                {
                    var resul = db.usuario_medico.SingleOrDefault(x => x.Identificacion == iden);
                    resul.Estado = 1;
                    db.SaveChanges();
                }
            }
        }
    }
}
