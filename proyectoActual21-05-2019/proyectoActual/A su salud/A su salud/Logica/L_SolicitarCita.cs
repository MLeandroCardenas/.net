using System;
using System.Collections.Generic;
using Utilitarios;
using Datos;
using System.Collections;

namespace Logica
{
    public class L_SolicitarCita
    {
        public void consultarEstadoPacientes(int id,U_DatosUser idcita)
        {
            UP_estados_pacientes usuario = new UP_estados_pacientes();
            List<UP_estados_pacientes> lista = new List<UP_estados_pacientes>();
            DP_admin dp = new DP_admin();
            lista = dp.traer_estado(id);
            foreach (UP_estados_pacientes ob in lista)
            {
                usuario.Id_usuario = ob.Id_usuario;
                usuario.Identificacion_paciente = ob.Identificacion_paciente;
                usuario.Nombre_paciente = ob.Nombre_paciente;
                usuario.Apellido_paciente = ob.Apellido_paciente;
                usuario.Estado_cita = ob.Estado_cita;
            }

            if (usuario.Estado_cita == 2)
            {
                Int32 FORMULARIO = 30;
                Int32 Idioma = idcita.Sessionidioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                string mensaje;
                mensaje = compIdioma["MensajeYaTieCita"].ToString();

                idcita.Mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"PrincipalPaciente.aspx\"</script>";
                //idcita.Mensaje = "<script type='text/javascript'>alert('YA TIENE CITA AGENDADA.... :(');window.location=\"PrincipalPaciente.aspx\"</script>";
            }
        }
    }
}
