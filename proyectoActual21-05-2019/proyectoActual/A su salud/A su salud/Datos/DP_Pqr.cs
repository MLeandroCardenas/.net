using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Utilitarios;

namespace Datos
{
    public class DP_Pqr
    {
        public List<UP_Pqr> traer_todos_los_pqr()
        {
            using (var db = new Mapeo("administrador"))
            {
                var pqr = db.pqr.Where(x => x.Estado == 1).ToList<UP_Pqr>();
                return pqr.ToList<UP_Pqr>();
            }
        }

        public List<UP_Pqr> traer_pqr_medicos(int id)
        {
            using (var db = new Mapeo("administrador"))
            {
                var pqr = db.pqr.Where(x => x.Id == id).ToList<UP_Pqr>();
                return pqr.ToList<UP_Pqr>();
            }
        }
        public void borrar_pqr_usuario(int id)
        {
            using (var db = new Mapeo("administrador"))
            {
                var pqr = db.pqr.Where(x => x.Id == id).FirstOrDefault();
                db.pqr.Remove(pqr);
                db.SaveChanges();
            }
        }

        public List<UP_Pqr> traer_respuestas_pqr_usuarios(int id)
        {
            using (var db = new Mapeo("administrador"))
            {
                var a = db.pqr.Where(x => x.Id_usuario == id && x.Estado == 2).ToList<UP_Pqr>();
                return a.ToList<UP_Pqr>();
            }
        }

        public void enviar_respuesta_pqr(U_pqrs pqrs)
        {
            UP_Pqr ob = new UP_Pqr();
            List<UP_Pqr> lista = new List<UP_Pqr>();
            lista = traer_pqr_medicos(pqrs.Id_user);
            foreach (UP_Pqr obj in lista)
            {
                ob.Id = obj.Id;
                ob.Tipo_mensaje = obj.Tipo_mensaje;
                ob.Mensaje = obj.Mensaje;
                ob.Responder_mensaje = pqrs.Nombres;
                ob.Nombres = obj.Nombres;
                ob.Apellidos = obj.Apellidos;
                ob.Session = obj.Session;
                ob.Last_modified = obj.Last_modified;
                ob.Correo = obj.Correo;
                ob.Id_usuario = obj.Id_usuario;
                ob.Estado = 2;
            }
            using (var db = new Mapeo("administrador"))
            {
                db.pqr.Attach(ob);

                var entry = db.Entry(ob);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void insertar_pqr(UP_Pqr datos)
        {
            using (var db = new Mapeo("administrador"))
            {
                db.pqr.Add(datos);
            }
        }
    }
}
