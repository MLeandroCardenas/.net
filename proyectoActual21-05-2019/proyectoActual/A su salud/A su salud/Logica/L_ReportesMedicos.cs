using System;
using Datos;
using Utilitarios;
using System.Data;
using System.Collections;
using System.Collections.Generic;

namespace Logica
{
    public class L_ReporteMedicos
    {
        public U_DatosUser inicioReporteMedico(U_DatosUser user)
        {
            if (user.Sessionuser == null)
            {
                user.Mensaje = "Login.aspx";
            }
            long id = Int64.Parse(user.Sessionidrolvalidacion.ToString());
            if (id != 1)
            {
                user.Mensaje = "Login.aspx";
            }
            return user;
        }

        public infoMedicos reporteMedicos(String urlBase,Hashtable tabla)
        {
            DataRow fila;
            DataTable informacionMedico = new DataTable();
            infoMedicos medico = new infoMedicos();

            informacionMedico = medico.Tables["medicos"];

            D_Admin admin = new D_Admin();
            List<UP_usuarios> user = new DP_admin().ReporteMedico();

            foreach(UP_usuarios obj in user)
            {
                string urlb = urlBase;
                fila = informacionMedico.NewRow();
                fila["apellidosaux"] = tabla["L_apellidos"].ToString();
                fila["nombresaux"] = tabla["L_nombres"].ToString();
                fila["identificacionaux"] = tabla["L_identificacion"].ToString();
                fila["emailaux"] = tabla["L_email"].ToString();
                fila["especialidadaux"] = tabla["L_especialidad"].ToString();
                fila["fotoaux"] = tabla["L_foto"].ToString();
                fila["apellidos"] = obj.Apellidos.ToString();
                fila["nombres"] = obj.Nombres.ToString();
                fila["identificacion"] = obj.Identificacion.ToString();
                fila["email"] = obj.Email.ToString();
                fila["especialidad"] = obj.Especialidad.ToString();

                string fotoruta = obj.Foto.ToString();
                urlBase = (urlBase + fotoruta);
                fila["foto"] = obtenerImagen(urlBase);
                informacionMedico.Rows.Add(fila);
                urlBase=urlb;

            }
            return medico;
        }

        protected byte[] obtenerImagen(String url)
        {
            string urlImagen = url;

            byte[] fileBytes = System.IO.File.ReadAllBytes(urlImagen);

            return fileBytes;
        }
    }
}