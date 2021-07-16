using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Utilitarios;

namespace Logica
{
    public class CoreAgenda
    {

        public List<UP_estados> traer_medicos_sin_horario()
        {
            DP_admin dp = new DP_admin();
            List<UP_estados> lista = new List<UP_estados>();
            lista = dp.traer_medico_sin_horario();
            return lista;

        }

        public List<UP_estados> traer_medicos_con_horario()
        {
            DP_admin dp = new DP_admin();
            List<UP_estados> lista = new List<UP_estados>();
            lista = dp.traer_medico_con_horario();
            return lista;
        }

        public void actualizar_tiempo_agenda(Eusuarios user)
        {
            int valor = user.Valor;
            string sesion = user.Sesion;
            DP_admin con = new DP_admin();
            con.modificarTiempo(valor, sesion);
        }

        public string verificacion_fecha(int mes, string sesion, int id, int Idioma)
        {
            string mensaje = "";
            //string mensaje = "";
            //Consultas con = new Consultas();
            List<UP_datos_horario> lista = new List<UP_datos_horario>();
            //lista = con.traer_datos2(id);
            DP_admin dp = new DP_admin();
            lista = dp.traer_datos_horario(id);
            DateTime fechaactual = new DateTime();
            fechaactual = DateTime.Now;

            int an = int.Parse(fechaactual.Year.ToString());
            if (mes == 2)
            {
                if ((an % 4) == 0 && (an % 100 != 0 || an % 400 == 0))
                {
                    mensaje = ConsFormato(29, 2, an, lista, sesion, Idioma);

                }
                else
                {
                    mensaje = ConsFormato(28, 2, an, lista, sesion, Idioma);

                }
            }
            if ((mes == 1) || (mes == 3) || (mes == 5) || (mes == 7) || (mes == 8) || (mes == 10) || (mes == 12))
            {
                mensaje = ConsFormato(31, mes, an, lista, sesion, Idioma);
            }
            else if ((mes == 4) || (mes == 6) || (mes == 9) || (mes == 11))
            {
                mensaje = ConsFormato(30, mes, an, lista, sesion, Idioma);
            }
            return mensaje;
        }
        /*
        public int consulta_estado_agenda(int id)
        {
            Consultas con = new Consultas();
            
            return con.ConsultarEstadoAgenda(id);
        }
        */
        public string ConsFormato(int dias, int mes, int año, List<UP_datos_horario> lista, string sesion, int Idioma)
        {
            Consultas con = new Consultas();
            string mensaje = "";
            //DAO_Admin d = new DAO_Admin();
            //Horario2 n = lista.ElementAt(0);
            //int identi = n.IdMedico;
            //DAO_Admin ad = new DAO_Admin();


            foreach (UP_datos_horario i in lista)
            {
                DP_admin dp_admin = new DP_admin();
                int tiempo = dp_admin.consulta_intervalo_tiempo();
                int identi = i.Id_medico;
                int estado_agenda = dp_admin.traer_estado_agenda(identi);
                if (estado_agenda == 1)
                {
                    int dia = i.Dia;
                    string fi = i.Hora_inicio;
                    string f = i.Hora_final;
                    if (dia == 1)
                    {
                        for (int j = 1; j <= dias; j++)
                        {
                            DateTime fechaaux = DateTime.Parse(año + "-" + mes + "-" + j + " 07:00:00");

                            if ((int)fechaaux.DayOfWeek == 1)
                            {
                                U_AgendaMedico ea = new U_AgendaMedico();

                                ea.Fecha_inicio = DateTime.Parse(j + "-" + mes + "-" + año + " " + i.Hora_inicio);
                                ea.Fecha_fin = DateTime.Parse(j + "-" + mes + "-" + año + " " + i.Hora_final);
                                U_AgendaMedico datos_agenda = new U_AgendaMedico();
                                DP_admin dp = new DP_admin();
                                List<UP_usuarios> usuario = new List<UP_usuarios>();
                                usuario = dp.traer_datos_medico(identi);
                                DateTime last = DateTime.Now;
                                for (DateTime fecha = ea.Fecha_inicio; fecha < ea.Fecha_fin; fecha = fecha.AddMinutes(tiempo))
                                {
                                    foreach (UP_usuarios obj in usuario)
                                    {
                                        datos_agenda.Medico_id = obj.Id;
                                        datos_agenda.Nombre_medico = obj.Nombres;
                                        datos_agenda.Especialidad = obj.Especialidad;
                                        datos_agenda.Apellido_medico = obj.Apellidos;
                                        datos_agenda.Session = obj.Session;
                                    }

                                    datos_agenda.Fecha_inicio = fecha;
                                    datos_agenda.Fecha_fin = fecha.AddMinutes(tiempo);
                                    datos_agenda.Usuario_id = null;
                                    datos_agenda.Last_modified = last;


                                    dp.insertar_cita_agenda(datos_agenda);
                                }

                            }
                        }
                    }

                    if (dia == 2)
                    {
                        for (int j = 1; j <= dias; j++)
                        {
                            DateTime fechaaux = DateTime.Parse(año + "-" + mes + "-" + j + " 07:00:00");
                            if ((int)fechaaux.DayOfWeek == 2)
                            {
                                U_AgendaMedico ea = new U_AgendaMedico();

                                ea.Fecha_inicio = DateTime.Parse(j + "-" + mes + "-" + año + " " + i.Hora_inicio);
                                ea.Fecha_fin = DateTime.Parse(j + "-" + mes + "-" + año + " " + i.Hora_final);
                                U_AgendaMedico datos_agenda = new U_AgendaMedico();
                                DP_admin dp = new DP_admin();
                                List<UP_usuarios> usuario = new List<UP_usuarios>();
                                usuario = dp.traer_datos_medico(identi);
                                DateTime last = DateTime.Now;
                                for (DateTime fecha = ea.Fecha_inicio; fecha < ea.Fecha_fin; fecha = fecha.AddMinutes(tiempo))
                                {
                                    foreach (UP_usuarios obj in usuario)
                                    {
                                        datos_agenda.Medico_id = obj.Id;
                                        datos_agenda.Nombre_medico = obj.Nombres;
                                        datos_agenda.Especialidad = obj.Especialidad;
                                        datos_agenda.Apellido_medico = obj.Apellidos;
                                        datos_agenda.Session = obj.Session;
                                    }

                                    datos_agenda.Fecha_inicio = fecha;
                                    datos_agenda.Fecha_fin = fecha.AddMinutes(tiempo);
                                    datos_agenda.Usuario_id = null;
                                    datos_agenda.Last_modified = last;


                                    dp.insertar_cita_agenda(datos_agenda);
                                }
                            }
                        }
                    }
                    if (dia == 3)
                    {
                        for (int j = 1; j <= dias; j++)
                        {
                            DateTime fechaaux = DateTime.Parse(año + "-" + mes + "-" + j + " 07:00:00");
                            if ((int)fechaaux.DayOfWeek == 3)
                            {
                                U_AgendaMedico ea = new U_AgendaMedico();

                                ea.Fecha_inicio = DateTime.Parse(j + "-" + mes + "-" + año + " " + i.Hora_inicio);
                                ea.Fecha_fin = DateTime.Parse(j + "-" + mes + "-" + año + " " + i.Hora_final);
                                U_AgendaMedico datos_agenda = new U_AgendaMedico();
                                DP_admin dp = new DP_admin();
                                List<UP_usuarios> usuario = new List<UP_usuarios>();
                                usuario = dp.traer_datos_medico(identi);
                                DateTime last = DateTime.Now;
                                for (DateTime fecha = ea.Fecha_inicio; fecha < ea.Fecha_fin; fecha = fecha.AddMinutes(tiempo))
                                {
                                    foreach (UP_usuarios obj in usuario)
                                    {
                                        datos_agenda.Medico_id = obj.Id;
                                        datos_agenda.Nombre_medico = obj.Nombres;
                                        datos_agenda.Especialidad = obj.Especialidad;
                                        datos_agenda.Apellido_medico = obj.Apellidos;
                                        datos_agenda.Session = obj.Session;
                                    }

                                    datos_agenda.Fecha_inicio = fecha;
                                    datos_agenda.Fecha_fin = fecha.AddMinutes(tiempo);
                                    datos_agenda.Usuario_id = null;
                                    datos_agenda.Last_modified = last;


                                    dp.insertar_cita_agenda(datos_agenda);
                                }
                            }
                        }
                    }
                    if (dia == 4)
                    {
                        for (int j = 1; j <= dias; j++)
                        {
                            DateTime fechaaux = DateTime.Parse(año + "-" + mes + "-" + j + " 07:00:00");
                            if ((int)fechaaux.DayOfWeek == 4)
                            {
                                U_AgendaMedico ea = new U_AgendaMedico();

                                ea.Fecha_inicio = DateTime.Parse(j + "-" + mes + "-" + año + " " + i.Hora_inicio);
                                ea.Fecha_fin = DateTime.Parse(j + "-" + mes + "-" + año + " " + i.Hora_final);
                                U_AgendaMedico datos_agenda = new U_AgendaMedico();
                                DP_admin dp = new DP_admin();
                                List<UP_usuarios> usuario = new List<UP_usuarios>();
                                usuario = dp.traer_datos_medico(identi);
                                DateTime last = DateTime.Now;
                                for (DateTime fecha = ea.Fecha_inicio; fecha < ea.Fecha_fin; fecha = fecha.AddMinutes(tiempo))
                                {
                                    foreach (UP_usuarios obj in usuario)
                                    {
                                        datos_agenda.Medico_id = obj.Id;
                                        datos_agenda.Nombre_medico = obj.Nombres;
                                        datos_agenda.Especialidad = obj.Especialidad;
                                        datos_agenda.Apellido_medico = obj.Apellidos;
                                        datos_agenda.Session = obj.Session;
                                    }

                                    datos_agenda.Fecha_inicio = fecha;
                                    datos_agenda.Fecha_fin = fecha.AddMinutes(tiempo);
                                    datos_agenda.Usuario_id = null;
                                    datos_agenda.Last_modified = last;


                                    dp.insertar_cita_agenda(datos_agenda);
                                }
                            }
                        }
                    }
                    if (dia == 5)
                    {
                        for (int j = 1; j <= dias; j++)
                        {
                            DateTime fechaaux = DateTime.Parse(año + "-" + mes + "-" + j + " 07:00:00");
                            if ((int)fechaaux.DayOfWeek == 5)
                            {
                                U_AgendaMedico ea = new U_AgendaMedico();

                                ea.Fecha_inicio = DateTime.Parse(j + "-" + mes + "-" + año + " " + i.Hora_inicio);
                                ea.Fecha_fin = DateTime.Parse(j + "-" + mes + "-" + año + " " + i.Hora_final);
                                U_AgendaMedico datos_agenda = new U_AgendaMedico();
                                DP_admin dp = new DP_admin();
                                List<UP_usuarios> usuario = new List<UP_usuarios>();
                                usuario = dp.traer_datos_medico(identi);
                                DateTime last = DateTime.Now;
                                for (DateTime fecha = ea.Fecha_inicio; fecha < ea.Fecha_fin; fecha = fecha.AddMinutes(tiempo))
                                {
                                    foreach (UP_usuarios obj in usuario)
                                    {
                                        datos_agenda.Medico_id = obj.Id;
                                        datos_agenda.Nombre_medico = obj.Nombres;
                                        datos_agenda.Especialidad = obj.Especialidad;
                                        datos_agenda.Apellido_medico = obj.Apellidos;
                                        datos_agenda.Session = obj.Session;
                                    }

                                    datos_agenda.Fecha_inicio = fecha;
                                    datos_agenda.Fecha_fin = fecha.AddMinutes(tiempo);
                                    datos_agenda.Usuario_id = null;
                                    datos_agenda.Last_modified = last;


                                    dp.insertar_cita_agenda(datos_agenda);
                                }
                            }
                        }
                    }
                    if (dia == 6)
                    {
                        for (int j = 1; j <= dias; j++)
                        {
                            DateTime fechaaux = DateTime.Parse(año + "-" + mes + "-" + j + " 07:00:00");
                            if ((int)fechaaux.DayOfWeek == 6)
                            {
                                U_AgendaMedico ea = new U_AgendaMedico();

                                ea.Fecha_inicio = DateTime.Parse(j + "-" + mes + "-" + año + " " + i.Hora_inicio);
                                ea.Fecha_fin = DateTime.Parse(j + "-" + mes + "-" + año + " " + i.Hora_final);
                                U_AgendaMedico datos_agenda = new U_AgendaMedico();
                                DP_admin dp = new DP_admin();
                                List<UP_usuarios> usuario = new List<UP_usuarios>();
                                usuario = dp.traer_datos_medico(identi);
                                DateTime last = DateTime.Now;
                                for (DateTime fecha = ea.Fecha_inicio; fecha < ea.Fecha_fin; fecha = fecha.AddMinutes(tiempo))
                                {
                                    foreach (UP_usuarios obj in usuario)
                                    {
                                        datos_agenda.Medico_id = obj.Id;
                                        datos_agenda.Nombre_medico = obj.Nombres;
                                        datos_agenda.Especialidad = obj.Especialidad;
                                        datos_agenda.Apellido_medico = obj.Apellidos;
                                        datos_agenda.Session = obj.Session;
                                    }

                                    datos_agenda.Fecha_inicio = fecha;
                                    datos_agenda.Fecha_fin = fecha.AddMinutes(tiempo);
                                    datos_agenda.Usuario_id = null;
                                    datos_agenda.Last_modified = last;


                                    dp.insertar_cita_agenda(datos_agenda);
                                }
                            }
                        }
                    }

                }
            }
            Int32 FORMULARIO = 8;
            Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
            mensaje = compIdioma["MensajeAgendaExitosaCreada"].ToString();

            mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"DefinirTiempoCitas.aspx\"</script>";

            //mensaje = "<script type='text/javascript'>alert('AGENDA GENERADA EXITOSAMENTE ');window.location=\"DefinirTiempoCitas.aspx\"</script>";
            //ad.actualizarestado_agenda(identi, 1);
            return mensaje;
        }

        public void actualizar_estado(int id, int estado)
        {
            //Consultas con = new Consultas();
            //con.actualizarestado_agenda(id, estado);

            DP_admin dp_admin = new DP_admin();
            dp_admin.actualizar_estado_agenda(id);
        }
        public string consultar_estado(int id, U_DatosUser user)
        {
            int estado = 0;
            string mensaje = "";
            Consultas con = new Consultas();
            DP_admin dp = new DP_admin();
            estado = dp.consulta_estado_horario(id);
            if (estado == 2)
            {
                Int32 FORMULARIO = 4;
                Int32 Idioma = user.Sessionidioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                //string mensaje;
                mensaje = compIdioma["MensajeYaRegHorario"].ToString();

                mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"PrincipalMedico.aspx\"</script>";
                //mensaje ="<script type='text/javascript'>alert('Usted ya registro su horario anteriormente.....Comuniquese con el adminitrador para realizar cambios');window.location=\"PrincipalMedico.aspx\"</script>";
            }
            return mensaje;
        }

        public int consultar_estado_horario_agenda(int id)
        {
            int estado = 0;
            //string mensaje = "";
            Consultas con = new Consultas();
            estado = con.ConsultarEstadohorario(id);
            if (estado == 1)
            {
                estado = 1;
                //mensaje = "<script type='text/javascript'>alert('Este usuario aun no tiene un horario registrado.....');window.location=\"DefinirTiempoCitas.aspx\"</script>";
            }
            return estado;
        }

        public E_diasemana dias_semana(Boolean estado_check)
        {
            E_diasemana dia = new E_diasemana();
            if (estado_check == true)
            {
                dia.Horainicio = true;
                dia.Horafinal = true;
            }
            else
            {
                dia.Horainicio = false;
                dia.Horafinal = false;
            }
            return dia;
        }

        public string Guardar_horario(int id, E_diasSemana dias, U_DatosUser user)
        {
            string mensaje = "";
            int bandera = 0;
            int bandera2 = 0;
            int conteo = 0;
            Consultas con = new Consultas();
            DP_admin dp = new DP_admin();
            List<E_DatosHorario> lista1 = new List<E_DatosHorario>();
            if (dias.Lunes == true)
            {
                E_DatosHorario h = new E_DatosHorario();
                h.IdMedico = id;
                h.Horainicio = (dias.Hora_inicial_lunes);
                h.Horafin = (dias.Hora_final_lunes);
                h.Diasemana = 1;
                if (validarhora2(dias.Valor_lunes_inicio, dias.Valor_lunes_final) == true)
                {
                    if (validarhora(dias.Valor_lunes_inicio, dias.Valor_lunes_final) == true)
                    {
                        bandera++;
                        //admin.insertarhorario(h);
                        lista1.Add(h);
                        conteo = conteo + conteo_horas(dias.Valor_lunes_inicio, dias.Valor_lunes_final);

                    }
                    else
                    {
                        bandera2--;

                        Int32 FORMULARIO = 4;
                        Int32 Idioma = user.Sessionidioma;
                        Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                        //string mensaje;
                        mensaje = compIdioma["MensajeErrorHoras"].ToString();

                        return mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"ConfigurarHorario.aspx\"</script>";
                        //return mensaje="<script type='text/javascript'>alert('Error en las horas selccionadas');window.location=\"ConfigurarHorario.aspx\"</script>";

                    }
                }
                else
                {
                    Int32 FORMULARIO = 4;
                    Int32 Idioma = user.Sessionidioma;
                    Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                    //string mensaje;
                    mensaje = compIdioma["MensajeErrorHorasSel"].ToString();

                    return mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"ConfigurarHorario.aspx\"</script>";
                    //return mensaje = "<script type='text/javascript'>alert('Error en las horas selccionadas........olvido seleccionar un hora de inicio o una hora de finalizacion');window.location=\"ConfigurarHorario.aspx\"</script>";
                }
            }
            if (dias.Martes == true)
            {
                E_DatosHorario h = new E_DatosHorario();
                h.IdMedico = id;
                h.Horainicio = (dias.Hora_inicial_martes);
                h.Horafin = (dias.Hora_final_martes);
                h.Diasemana = 2;
                if (validarhora2(dias.Valor_martes_inicio, dias.Valor_martes_final) == true)
                {
                    if (validarhora(dias.Valor_martes_inicio, dias.Valor_martes_final) == true)
                    {
                        bandera++;
                        //admin.insertarhorario(h);
                        lista1.Add(h);
                        conteo = conteo + conteo_horas(dias.Valor_martes_inicio, dias.Valor_martes_final);

                    }
                    else
                    {
                        bandera2--;
                        Int32 FORMULARIO = 4;
                        Int32 Idioma = user.Sessionidioma;
                        Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                        //string mensaje;
                        mensaje = compIdioma["MensajeErrorHoras"].ToString();

                        return mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"ConfigurarHorario.aspx\"</script>";
                        //return mensaje = "<script type='text/javascript'>alert('Error en las horas selccionadas');window.location=\"ConfigurarHorario.aspx\"</script>";

                    }
                }
                else
                {
                    Int32 FORMULARIO = 4;
                    Int32 Idioma = user.Sessionidioma;
                    Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                    //string mensaje;
                    mensaje = compIdioma["MensajeErrorHorasSel"].ToString();

                    return mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"ConfigurarHorario.aspx\"</script>";
                    //return mensaje = "<script type='text/javascript'>alert('Error en las horas selccionadas........olvido seleccionar un hora de inicio o una hora de finalizacion');window.location=\"ConfigurarHorario.aspx\"</script>";
                }
            }
            if (dias.Miercoles == true)
            {
                E_DatosHorario h = new E_DatosHorario();
                h.IdMedico = id;
                h.Horainicio = (dias.Hora_inicial_miercoles);
                h.Horafin = (dias.Hora_final_miercoles);
                h.Diasemana = 3;
                if (validarhora2(dias.Valor_miercoles_inicio, dias.Valor_miercoles_final) == true)
                {
                    if (validarhora(dias.Valor_miercoles_inicio, dias.Valor_miercoles_final) == true)
                    {
                        bandera++;
                        //admin.insertarhorario(h);
                        lista1.Add(h);
                        conteo = conteo + conteo_horas(dias.Valor_miercoles_inicio, dias.Valor_miercoles_final);

                    }
                    else
                    {
                        bandera2--;
                        Int32 FORMULARIO = 4;
                        Int32 Idioma = user.Sessionidioma;
                        Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                        //string mensaje;
                        mensaje = compIdioma["MensajeErrorHoras"].ToString();

                        return mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"ConfigurarHorario.aspx\"</script>";
                        //return mensaje = "<script type='text/javascript'>alert('Error en las horas selccionadas');window.location=\"ConfigurarHorario.aspx\"</script>";

                    }
                }
                else
                {
                    Int32 FORMULARIO = 4;
                    Int32 Idioma = user.Sessionidioma;
                    Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                    //string mensaje;
                    mensaje = compIdioma["MensajeErrorHorasSel"].ToString();

                    return mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"ConfigurarHorario.aspx\"</script>";
                    //return mensaje = "<script type='text/javascript'>alert('Error en las horas selccionadas........olvido seleccionar un hora de inicio o una hora de finalizacion');window.location=\"ConfigurarHorario.aspx\"</script>";
                }
            }
            if (dias.Jueves == true)
            {
                E_DatosHorario h = new E_DatosHorario();
                h.IdMedico = id;
                h.Horainicio = (dias.Hora_inicial_jueves);
                h.Horafin = (dias.Hora_final_jueves);
                h.Diasemana = 4;
                if (validarhora2(dias.Valor_jueves_inicio, dias.Valor_jueves_final) == true)
                {
                    if (validarhora(dias.Valor_jueves_inicio, dias.Valor_jueves_final) == true)
                    {
                        bandera++;
                        //admin.insertarhorario(h);
                        lista1.Add(h);
                        conteo = conteo + conteo_horas(dias.Valor_jueves_inicio, dias.Valor_jueves_final);

                    }
                    else
                    {
                        bandera2--;
                        Int32 FORMULARIO = 4;
                        Int32 Idioma = user.Sessionidioma;
                        Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                        //string mensaje;
                        mensaje = compIdioma["MensajeErrorHoras"].ToString();

                        return mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"ConfigurarHorario.aspx\"</script>";
                        //return mensaje = "<script type='text/javascript'>alert('Error en las horas selccionadas');window.location=\"ConfigurarHorario.aspx\"</script>";

                    }
                }
                else
                {
                    Int32 FORMULARIO = 4;
                    Int32 Idioma = user.Sessionidioma;
                    Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                    //string mensaje;
                    mensaje = compIdioma["MensajeErrorHorasSel"].ToString();

                    return mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"ConfigurarHorario.aspx\"</script>";
                    //return mensaje = "<script type='text/javascript'>alert('Error en las horas selccionadas........olvido seleccionar un hora de inicio o una hora de finalizacion');window.location=\"ConfigurarHorario.aspx\"</script>";
                }
            }
            if (dias.Viernes == true)
            {
                E_DatosHorario h = new E_DatosHorario();
                h.IdMedico = id;
                h.Horainicio = (dias.Hora_inicial_viernes);
                h.Horafin = (dias.Hora_final_viernes);
                h.Diasemana = 5;
                if (validarhora2(dias.Valor_viernes_inicio, dias.Valor_viernes_final) == true)
                {
                    if (validarhora(dias.Valor_viernes_inicio, dias.Valor_viernes_final) == true)
                    {
                        bandera++;
                        //admin.insertarhorario(h);
                        lista1.Add(h);
                        conteo = conteo + conteo_horas(dias.Valor_viernes_inicio, dias.Valor_viernes_final);

                    }
                    else
                    {
                        bandera2--;
                        Int32 FORMULARIO = 4;
                        Int32 Idioma = user.Sessionidioma;
                        Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                        //string mensaje;
                        mensaje = compIdioma["MensajeErrorHoras"].ToString();

                        return mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"ConfigurarHorario.aspx\"</script>";
                        //return mensaje = "<script type='text/javascript'>alert('Error en las horas selccionadas');window.location=\"ConfigurarHorario.aspx\"</script>";

                    }
                }
                else
                {
                    Int32 FORMULARIO = 4;
                    Int32 Idioma = user.Sessionidioma;
                    Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                    //string mensaje;
                    mensaje = compIdioma["MensajeErrorHorasSel"].ToString();

                    return mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"ConfigurarHorario.aspx\"</script>";
                    //return mensaje = "<script type='text/javascript'>alert('Error en las horas selccionadas........olvido seleccionar un hora de inicio o una hora de finalizacion');window.location=\"ConfigurarHorario.aspx\"</script>";
                }
            }
            if (dias.Sabado == true)
            {
                E_DatosHorario h = new E_DatosHorario();
                h.IdMedico = id;
                h.Horainicio = (dias.Hora_inicial_sabado);
                h.Horafin = (dias.Hora_final_sabado);
                h.Diasemana = 6;
                if (validarhora2(dias.Valor_sabado_inicial, dias.Valor_sabado_final) == true)
                {
                    if (validarhora(dias.Valor_sabado_inicial, dias.Valor_sabado_final) == true)
                    {
                        bandera++;
                        //admin.insertarhorario(h);
                        lista1.Add(h);
                        conteo = conteo + conteo_horas(dias.Valor_sabado_inicial, dias.Valor_sabado_final);

                    }
                    else
                    {
                        bandera2--;
                        Int32 FORMULARIO = 4;
                        Int32 Idioma = user.Sessionidioma;
                        Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                        //string mensaje;
                        mensaje = compIdioma["MensajeErrorHoras"].ToString();

                        return mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"ConfigurarHorario.aspx\"</script>";
                        //return mensaje = "<script type='text/javascript'>alert('Error en las horas selccionadas');window.location=\"ConfigurarHorario.aspx\"</script>";

                    }
                }
                else
                {
                    Int32 FORMULARIO = 4;
                    Int32 Idioma = user.Sessionidioma;
                    Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                    //string mensaje;
                    mensaje = compIdioma["MensajeErrorHorasSel"].ToString();

                    return mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"ConfigurarHorario.aspx\"</script>";
                    //return mensaje = "<script type='text/javascript'>alert('Error en las horas selccionadas........olvido seleccionar un hora de inicio o una hora de finalizacion');window.location=\"ConfigurarHorario.aspx\"</script>";
                }
            }
            // E_HorarioMedico horarioMedico = new E_HorarioMedico();
            //horarioMedico.Lista_horarios = lista1;
            //DAO_Admin ad = new DAO_Admin();
            /*
            foreach(Horario i in lista1)
            {
                int d= i.DiaSemana;
                string ff = i.Horafin;
                string fi = i.Horainicio;
            }
            */
            //ad.insertarhorario(JsonConvert.SerializeObject(horarioMedico));

            if (conteo >= dp.traer_horas_medico(id))//consulta de horas ya esta.
            {
                if (bandera2 == 0)
                {
                    foreach (E_DatosHorario i in lista1)
                    {
                        UP_datos_horario h = new UP_datos_horario();
                        //E_DatosHorario h = new E_DatosHorario();
                        h.Id_medico = i.IdMedico;
                        h.Hora_inicio = i.Horainicio;
                        h.Hora_final = i.Horafin;
                        h.Dia = i.Diasemana;
                        dp.insertar_horario(h);
                        //con.insertarhorario(h);// ya esta migrado........falta por probar.

                    }
                    dp.actualizar_estado_horario(id);//ya  esta

                    Int32 FORMULARIO = 4;
                    Int32 Idioma = user.Sessionidioma;
                    Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                    //string mensaje;
                    mensaje = compIdioma["MensajeAgendaCreExito"].ToString();

                    return mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"PrincipalMedico.aspx\"</script>";
                    //return mensaje = "<script type='text/javascript'>alert('Agenda Creada Exitosamente');window.location=\"PrincipalMedico.aspx\"</script>";
                }
            }
            else
            {
                Int32 FORMULARIO = 4;
                Int32 Idioma = user.Sessionidioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                //string mensaje;
                mensaje = compIdioma["MensajeHorSemNo"].ToString();

                return mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"ConfigurarHorario.aspx\"</script>";
                //return mensaje = "<script type='text/javascript'>alert('Las Horas Semanales no superan lo minimo establecido');window.location=\"ConfigurarHorario.aspx\"</script>";
            }
            return mensaje;
        }

        public Boolean validarhora(int hora1, int hora2)
        {
            int resul = hora1 - hora2;

            if (resul > 0 || resul == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Boolean validarhora2(int hora1, int hora2)
        {
            if (hora1 == 0 || hora2 == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int conteo_horas(int hora1, int hora2)
        {
            int re = hora2 - hora1;

            return re;
        }

    }
}
