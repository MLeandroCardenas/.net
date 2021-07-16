using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Utilitarios;
using System.Data;
using System.Collections;

namespace Logica
{
    public class L_ReporteHistoriaClinica
    {
        public U_DatosUser inicioPagina(U_DatosUser user)
        {
            if (user.Sessionuser == null)
            {
                user.Mensaje = "Login.aspx";
            }
            long id = Int64.Parse(user.Sessionidrolvalidacion.ToString());
            if (id != 3)
            {
                user.Mensaje = "Login.aspx";
            }
            return user;
        }

        public infoMedicos reporteHistoria(int aux, Hashtable tabla)
        {
            DataRow fila;
            DataTable informacionPaciente = new DataTable();
            infoMedicos paciente = new infoMedicos();

            int varfila = Convert.ToInt32(aux);
            informacionPaciente = paciente.Tables["historia"];
            D_usuarios reporte = new D_usuarios();
            List<UP_Historia_Clinica> historia = new DP_usuarios().reporteHistoriaClinica(varfila);

            foreach (var aux2 in historia)
            {
                fila = informacionPaciente.NewRow();
                fila["titulo"] = tabla["titulo"].ToString();
                fila["nombreaux"] = tabla["l_nombre"].ToString();
                fila["cedulaaux"] = tabla["L_cedula"].ToString();
                fila["motivoaux"] = tabla["L_motivo"].ToString();
                fila["alergiasaux"] = tabla["L_alergias"].ToString();
                fila["cirugiasaux"] = tabla["L_Ciriguias"].ToString();
                fila["alturaaux"] = tabla["L_altura"].ToString();
                fila["pesoaux"] = tabla["L_Peso"].ToString();
                fila["pielaux"] = tabla["L_piel"].ToString();
                fila["respiracionaux"] = tabla["L_respiracion"].ToString();
                fila["bocaaux"] = tabla["L_boca"].ToString();
                fila["dictamenaux"] = tabla["L_dictamen"].ToString();
                fila["fechaauxs"] = tabla["L_fecha"].ToString();
                fila["nombre"] = aux2.Nombre_paciente.ToString();
                fila["cedula"] = Int32.Parse(aux2.Documento_paciente.ToString());
                fila["motivo"] = aux2.Motivo_consulta.ToString();
                fila["alergias"] = aux2.Alergias.ToString();
                fila["cirugias"] = aux2.Cirugias.ToString();
                fila["altura"] = Int16.Parse(aux2.Altura.ToString());
                fila["peso"] = Int16.Parse(aux2.Peso.ToString());
                fila["piel"] = aux2.Observacion_piel.ToString();
                fila["respiracion"] = aux2.Observacion_respiracion.ToString();
                fila["boca"] = aux2.Observacion_boca.ToString();
                fila["dictamen"] = aux2.Diagnostico.ToString();
                fila["fecha atencion"] = DateTime.Parse(aux2.Fecha_atencion.ToString()).ToString("dddd dd-MM-yyyy");

                informacionPaciente.Rows.Add(fila);
            }
            return paciente;
        }
    }
}