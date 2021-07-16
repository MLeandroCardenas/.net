using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using Datos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Utilitarios;

namespace Datos
{
    public class DP_Auditoria
    {
        public static void add(UP_Auditoria eAuditoria)
        {
            using (var dbc = new Mapeo("security"))
            {
                dbc.Entry(eAuditoria).State = EntityState.Added;
                dbc.SaveChanges();
            }
        }

        public static UP_Auditoria get(int id)
        {
            using (var dbc = new Mapeo("security"))
            {
                UP_Auditoria eAuditoria = dbc.auditoria.Find(id);
                return eAuditoria != null ? eAuditoria : new UP_Auditoria();
            }
        }

        public static List<UP_Auditoria> getAll(int id)
        {
            using (var dbc = new Mapeo("security"))
            {
                return dbc.auditoria.ToList();
            }
        }

        public static List<UP_Auditoria> getAuditoriaTabla(string nombreTabla)
        {
            using (var dbc = new Mapeo("security"))
            {
                return (from x in dbc.auditoria where x.Tabla == nombreTabla select x).ToList();
            }
        }

        public void insert(Object obj, UP_Acceso acceso, string esquema, string tabla)
        {
            UP_Auditoria eAuditoria = new UP_Auditoria();
            eAuditoria.Fecha = DateTime.Now;
            eAuditoria.Accion = "INSERT";
            eAuditoria.User_bd = "Postgres";
            eAuditoria.Schema = esquema;
            eAuditoria.Tabla = tabla;
            eAuditoria.Pk = acceso.Id.ToString();
            eAuditoria.Session = acceso.Session;

            JObject jObject = new JObject();

            foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties())
            {
                if (propertyInfo.PropertyType == typeof(string) || propertyInfo.PropertyType == typeof(int) || propertyInfo.PropertyType == typeof(Boolean))
                {
                    jObject[propertyInfo.Name] = propertyInfo.GetValue(obj).ToString();
                }
            }
            string todo = "Nuevo:" + JsonConvert.SerializeObject(jObject);
            eAuditoria.Data = JsonConvert.SerializeObject(todo);
            DP_Auditoria.add(eAuditoria);
        }

        public void update(Object newObj, Object oldObj, UP_Acceso acceso, string esquema, string tabla)
        {
            UP_Auditoria eAuditoria = new UP_Auditoria();
            eAuditoria.Fecha = DateTime.Now;
            eAuditoria.Accion = "UPDATE";
            eAuditoria.User_bd = "Postgres";
            eAuditoria.Schema = esquema;
            eAuditoria.Tabla = tabla;
            eAuditoria.Pk = acceso.Id.ToString();
            eAuditoria.Session = acceso.Session;

            JObject jObject = new JObject();

            Boolean sinCambios = true;
            foreach (PropertyInfo propertyInfo in newObj.GetType().GetProperties())
            {
                if (propertyInfo.PropertyType == typeof(string) || propertyInfo.PropertyType == typeof(int) || propertyInfo.PropertyType == typeof(Boolean))
                {
                    if (propertyInfo.Name.Equals("Id"))
                    {
                        jObject[propertyInfo.Name] = propertyInfo.GetValue(newObj).ToString();
                    }
                    if (!propertyInfo.GetValue(newObj).ToString().Equals(propertyInfo.GetValue(oldObj).ToString()) && !propertyInfo.Name.Equals("IdAcceso"))
                    {
                        jObject["new_" + propertyInfo.Name] = propertyInfo.GetValue(newObj).ToString();
                        jObject["old_" + propertyInfo.Name] = propertyInfo.GetValue(oldObj).ToString();
                        sinCambios = false;
                    }
                }
                else if (propertyInfo.PropertyType == typeof(List<int>) && !JsonConvert.SerializeObject(propertyInfo.GetValue(newObj)).Equals(JsonConvert.SerializeObject(propertyInfo.GetValue(oldObj))))
                {
                    jObject["new_" + propertyInfo.Name] = JsonConvert.SerializeObject(propertyInfo.GetValue(newObj));
                    jObject["old_" + propertyInfo.Name] = JsonConvert.SerializeObject(propertyInfo.GetValue(oldObj));
                    sinCambios = false;
                }
            }

            if (sinCambios)
            {
                return;
            }

            eAuditoria.Data = JsonConvert.SerializeObject(jObject);
            DP_Auditoria.add(eAuditoria);
        }

        public void delete(Object obj, UP_Acceso acceso, string esquema, string tabla)
        {
            UP_Auditoria eAuditoria = new UP_Auditoria();
            eAuditoria.Fecha = DateTime.Now;
            eAuditoria.Accion = "DELETE";
            eAuditoria.User_bd = "Postgres";
            eAuditoria.Schema = esquema;
            eAuditoria.Tabla = tabla;
            eAuditoria.Pk = acceso.Id.ToString();
            eAuditoria.Session = acceso.Session;

            JObject jObject = new JObject();

            foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties())
            {
                if (propertyInfo.PropertyType == typeof(string) || propertyInfo.PropertyType == typeof(int) || propertyInfo.PropertyType == typeof(Boolean))
                {
                    jObject[propertyInfo.Name] = propertyInfo.GetValue(obj).ToString();
                }
            }
            string todo = "Anterior:" + JsonConvert.SerializeObject(jObject);
            eAuditoria.Data = JsonConvert.SerializeObject(todo);
            DP_Auditoria.add(eAuditoria);
        }
    }
}

