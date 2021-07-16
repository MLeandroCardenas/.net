using System;
using System.Collections.Generic;
using System.Data;
using Datos;
using Utilitarios;
using System.Collections;

namespace Logica
{
    public class L_modificar_agenda
    {
        public U_DatosMedicoActualizar mostrar_horario_actualizar(int id, U_DatosUser user)
        {
            U_DatosMedicoActualizar retorno = new U_DatosMedicoActualizar();
            D_Admin ad = new D_Admin();
            List<U_AgendaMedico> agenda = new DP_admin().TraerHorario(id);
            if (agenda.Count<=0)
            {
                Int32 FORMULARIO = 16;
                Int32 Idioma = user.Sessionidioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                string mensajeU;
                mensajeU = compIdioma["MensajeModHorNoCoin"].ToString();
                
                retorno.Datos = null;
                retorno.Mensaje = "<script type='text/javascript'>alert('" + mensajeU + "');window.location=\"ModificarHorarioMedico.aspx\"</script>";
                //retorno.Mensaje = "<script type='text/javascript'>alert('La identificacion ingresada no concuerda con ningun registro en la base de datos......');window.location=\"ModificarHorarioMedico.aspx\"</script>";
                return retorno;
            }
            retorno.Datos = agenda;
            retorno.Mensaje = "";
            return retorno;
        }

        public int? traer_horas_laborales(int id)
        {
            List<UP_estados> estado = new DP_admin().ConsultaEstado2(id);
            UP_estados estadoaux = new UP_estados();

            foreach (UP_estados obj in estado)
            {
                estadoaux.Horas_semana = obj.Horas_semana;
            }
            int? horas = estadoaux.Horas_semana;
            return horas;
        }

        public List<U_AgendaMedico> filtro_borrar_Fechas(int id, string fecha_filtro)
        {
            U_AgendaMedico agenda = new U_AgendaMedico();
            List<U_AgendaMedico> lista = new DP_admin().BusquedaHorario(fecha_filtro, id);
            return lista; 
        }

        public void borrar_fechas(int ident)
        {
            D_Admin ad = new D_Admin();
            ad.borrar_fecha(ident);
        }

        public List<UP_estados> traer_horas(int id)
        {
            UP_estados estado = new UP_estados();
            Consultas con = new Consultas();
            List<UP_estados> lista = new DP_admin().ConsultaEstado2(id);
            return lista;
        }
        public void modificar_horas(int id,int horas)
        {
            DP_admin dp = new DP_admin();
            dp.actualizar_horas(id,horas);
        }
        public void reiniciar_agenda()
        {
            DP_admin dp = new DP_admin();
            dp.reiniciar_agenda();
        }
    }
}
