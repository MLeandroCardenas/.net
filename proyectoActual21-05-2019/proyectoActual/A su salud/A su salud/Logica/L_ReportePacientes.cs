using System;
using Utilitarios;
using Datos;
using System.Data;
using System.Collections;
using System.Collections.Generic;

namespace Logica
{
    public class L_ReportePacientes
    {

        public U_Usuario inicioPagina(U_Usuario user)
        {
            if (user.Session == null)
            {
                user.Mensaje = "Login.aspx";
            }
            long id = user.RolId;
            if (id != 2)
            {
                user.Mensaje = "Login.aspx";
            }
            return user;
        }

        public infoMedicos obtenerInformePaciente(int id,Hashtable tabla)
        {
            DataRow fila;
            DataTable informacionMedico = new DataTable();
            infoMedicos medico = new infoMedicos();
            informacionMedico = medico.Tables["pacientes"];
            D_medicos reporte = new D_medicos();
           // DataTable intermedio = reporte.reportePacientes(id);
            List < U_CitasMedicas > intermedio = new DP_Medicos().reportePaciente(id);

            foreach (U_CitasMedicas obj in intermedio)
            {
                fila = informacionMedico.NewRow();
                fila["TituloAux"] = tabla["L_Titulo"].ToString();
                fila["nombreAux"] = tabla["L_nombre"].ToString();
                fila["ApellidoAux"] = tabla["L_apellido"].ToString();
                fila["CedulaAux"] = tabla["L_cedula"].ToString();
                fila["nombre"] = obj.Nombre_paciente.ToString();
                fila["apellido"] = obj.Apellido_paciente.ToString();
                fila["cedula"] = obj.Documento.ToString();
                informacionMedico.Rows.Add(fila);
            }
            return medico;
        }

    }
}
