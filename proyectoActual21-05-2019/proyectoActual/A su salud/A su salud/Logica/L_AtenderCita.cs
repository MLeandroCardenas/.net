using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Datos;
using System.Data;
using System.Collections;

namespace Logica
{
    public class L_AtenderCita
    {
        public void historiaclinica(bool historia, U_DatosUser historiaclinica, U_DatosUser editarcitam, int id_paciente, int id_cita)
        {
            U_CitasMedicas cita = new U_CitasMedicas();
            DP_citas_medicas obj2 = new DP_citas_medicas();
            List<U_CitasMedicas> lista = obj2.traer_citas(id_paciente);
            if (historia == true)
            {
                foreach (U_CitasMedicas citam in lista)
                {
                    cita.Id = id_cita;
                    cita.Id_medico = citam.Id;
                    cita.Nombre_medico = citam.Nombre_medico;
                    cita.Apellido_medico = citam.Apellido_medico;
                    cita.Especialidad = citam.Especialidad;
                    cita.Hora_inicio = citam.Hora_inicio;
                    cita.Hora_fin = citam.Hora_fin;
                    cita.Id_paciente = citam.Id_paciente;
                    cita.Nombre_paciente = citam.Nombre_paciente;
                    cita.Estado_cita = 2;
                    cita.Documento = citam.Documento;
                    cita.Apellido_paciente = citam.Apellido_paciente;
                    cita.Session = citam.Session;
                    cita.Ultima_modificacion = DateTime.Now;
                }
                int a = 1;
                U_CitasMedicas atender = new U_CitasMedicas();
                atender.Id = id_cita;
                atender.Id_medico = cita.Id_medico;
                atender.Nombre_medico = cita.Nombre_medico;
                atender.Apellido_medico = cita.Apellido_medico;
                atender.Especialidad = cita.Especialidad;
                atender.Hora_inicio = cita.Hora_inicio;
                atender.Hora_fin = cita.Hora_fin;
                atender.Id_paciente = cita.Id_paciente;
                atender.Nombre_paciente = cita.Nombre_paciente;
                atender.Estado_cita = 2;
                atender.Documento = cita.Documento;
                atender.Apellido_paciente = cita.Apellido_paciente;
                atender.Session = cita.Session;
                atender.Ultima_modificacion = DateTime.Now;

                //new Datos.DAO_Admin().actualizarestado_cita(historiaclinica, a);
                new Datos.DP_citas_medicas().editar_cita(atender);
                //insertar historia clinica
                UP_Historia_Clinica historiac = new UP_Historia_Clinica();
                historiac.Id_medico = historiaclinica.Id;
                historiac.Nombre_paciente = historiaclinica.Nombres;
                historiac.Documento_paciente = historiaclinica.Identificacion;
                historiac.Motivo_consulta = historiaclinica.Motivo;
                historiac.Alergias = historiaclinica.Alergias;
                historiac.Cirugias = historiaclinica.Cirugias;
                historiac.Altura = int.Parse(historiaclinica.Altura.ToString());
                historiac.Peso = int.Parse(historiaclinica.Peso.ToString());
                historiac.Observacion_piel = historiaclinica.ObservacionPiel;
                historiac.Observacion_respiracion = historiaclinica.ObservacionRespiracion;
                historiac.Observacion_boca = historiaclinica.ObservacionBoca;
                historiac.Diagnostico = historiaclinica.Diagnostico;
                historiac.Apellido_paciente = historiaclinica.Apellidos;
                historiac.Nombre_medico = historiaclinica.NombreMedico;
                historiac.Especialidad = historiaclinica.Especializacion1;
                historiac.Apellido_medico = historiaclinica.ApellidoMedico;
                historiac.Id_paciente = int.Parse(historiaclinica.Numid.ToString());
                historiac.Fecha_atencion = historiaclinica.FechaFin;
                historiac.Asignar_especialista = historiaclinica.AsignarEspecialista;
                historiac.Session = historiaclinica.Session;
                historiac.Estado = 1;
                historiac.Last_modified = DateTime.Now;
                new DP_citas_medicas().insertar_historiaclinica(historiac);
                //new Datos.DAO_Medico().insertarHistoriaClinica(historiaclinica);
                U_EstadosPacientes id = new U_EstadosPacientes();
                id.Id_usuario = int.Parse(historiaclinica.Numid.ToString());
                int id1 = id.Id_usuario;
                new DP_citas_medicas().borrar_cita(id1);

                Int32 FORMULARIO = 2;
                Int32 Idioma = historiaclinica.Sessionidioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                string mensaje;
                mensaje = compIdioma["MensajeInsercionHistoriaC"].ToString();

                historiaclinica.Mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"PacientesPorAtender.aspx\"</script>";
            }
            else
            {
                int a = 1;
                foreach (U_CitasMedicas citam in lista)
                {
                    cita.Id = id_cita;
                    cita.Id_medico = citam.Id_medico;
                    cita.Nombre_medico = citam.Nombre_medico;
                    cita.Apellido_medico = citam.Apellido_medico;
                    cita.Especialidad = citam.Especialidad;
                    cita.Hora_inicio = citam.Hora_inicio;
                    cita.Hora_fin = citam.Hora_fin;
                    cita.Id_paciente = citam.Id_paciente;
                    cita.Nombre_paciente = citam.Nombre_paciente;
                    cita.Estado_cita = 2;
                    cita.Documento = citam.Documento;
                    cita.Apellido_paciente = citam.Apellido_paciente;
                    cita.Session = citam.Session;
                    cita.Ultima_modificacion = DateTime.Now;
                }

                U_CitasMedicas atender = new U_CitasMedicas();
                atender.Id = id_cita;
                atender.Id_medico = cita.Id_medico;
                atender.Nombre_medico = cita.Nombre_medico;
                atender.Apellido_medico = cita.Apellido_medico;
                atender.Especialidad = cita.Especialidad;
                atender.Hora_inicio = cita.Hora_inicio;
                atender.Hora_fin = cita.Hora_fin;
                atender.Id_paciente = cita.Id_paciente;
                atender.Nombre_paciente = cita.Nombre_paciente;
                atender.Estado_cita = 2;
                atender.Documento = cita.Documento;
                atender.Apellido_paciente = cita.Apellido_paciente;
                atender.Session = cita.Session;
                atender.Ultima_modificacion = DateTime.Now;

                //new Datos.DAO_Admin().actualizarestado_cita(historiaclinica, a);
                new Datos.DP_citas_medicas().editar_cita(atender);
                //insertar historia clinica
                UP_Historia_Clinica historiac = new UP_Historia_Clinica();
                historiac.Id_medico = historiaclinica.Id;
                historiac.Nombre_paciente = historiaclinica.Nombres;
                historiac.Documento_paciente = historiaclinica.Identificacion;
                historiac.Motivo_consulta = historiaclinica.Motivo;
                historiac.Alergias = historiaclinica.Alergias;
                historiac.Cirugias = historiaclinica.Cirugias;
                historiac.Altura = int.Parse(historiaclinica.Altura.ToString());
                historiac.Peso = int.Parse(historiaclinica.Peso.ToString());
                historiac.Observacion_piel = historiaclinica.ObservacionPiel;
                historiac.Observacion_respiracion = historiaclinica.ObservacionRespiracion;
                historiac.Observacion_boca = historiaclinica.ObservacionBoca;
                historiac.Diagnostico = historiaclinica.Diagnostico;
                historiac.Apellido_paciente = historiaclinica.Apellidos;
                historiac.Nombre_medico = historiaclinica.NombreMedico;
                historiac.Especialidad = historiaclinica.Especializacion1;
                historiac.Apellido_medico = historiaclinica.ApellidoMedico;
                historiac.Id_paciente = int.Parse(historiaclinica.Numid.ToString());
                historiac.Fecha_atencion = historiaclinica.FechaFin;
                historiac.Asignar_especialista = historiaclinica.AsignarEspecialista;
                historiac.Session = historiaclinica.Session;
                historiac.Estado = 1;
                historiac.Last_modified = DateTime.Now;
                new DP_citas_medicas().insertar_historiaclinica(historiac);
                //new Datos.DAO_Medico().insertarHistoriaClinica(historiaclinica);
                U_EstadosPacientes id = new U_EstadosPacientes();
                id.Id_usuario = int.Parse(historiaclinica.Numid.ToString());
                int id1 = id.Id_usuario;
                new DP_citas_medicas().borrar_cita(id1);

                Int32 FORMULARIO = 2;
                Int32 Idioma = historiaclinica.Sessionidioma;
                Hashtable compIdioma = new L_Idioma().obtenerIdioma(FORMULARIO, Idioma);
                string mensaje;
                mensaje = compIdioma["MensajeInsercionHistoriaC"].ToString();

                historiaclinica.Mensaje = "<script type='text/javascript'>alert('" + mensaje + "');window.location=\"PacientesPorAtender.aspx\"</script>";
                //historiaclinica.Mensaje = "<script type='text/javascript'>alert('Se ha insertado la historia clínica exitosamente.');window.location=\"PacientesPorAtender.aspx\"</script>";
            }
        }
        public U_CitasMedicas obtenercita(int idcita)
        {
            List<U_CitasMedicas> prueba = new Datos.DP_citas_medicas().mostrar_datoscita_atender(idcita);
            U_CitasMedicas muestra = new U_CitasMedicas();
            foreach (U_CitasMedicas mostrar in prueba)
            {
                muestra.Nombre_paciente = mostrar.Nombre_paciente;
                muestra.Apellido_paciente = mostrar.Apellido_paciente;
                muestra.Documento = mostrar.Documento;
                muestra.Nombre_medico = mostrar.Nombre_medico;
                muestra.Apellido_medico = mostrar.Apellido_medico;
                muestra.Especialidad = mostrar.Especialidad;
                muestra.Id_medico = mostrar.Id_medico;
                muestra.Id_paciente = mostrar.Id_paciente;
                muestra.Hora_fin = mostrar.Hora_fin;
            }
            return muestra;
        }
        public bool checkboxAlergias(bool checkbox_alergias)
        {
            bool chequeadoAlergias;
            if (checkbox_alergias == true)
            {
                chequeadoAlergias = true;
            }
            else
            {
                chequeadoAlergias = false;
            }
            return chequeadoAlergias;
        }
        public bool checkboxCirugias(bool checkbox_cirugias)
        {
            bool chequeadoCirugias;
            if (checkbox_cirugias == true)
            {
                chequeadoCirugias = true;
            }
            else
            {
                chequeadoCirugias = false;
            }
            return chequeadoCirugias;
        }
        public bool checkboxRemitir(bool checkbox_remitir)
        {
            if (checkbox_remitir == true)
            {
                checkbox_remitir = true;
            }
            else
            {
                checkbox_remitir = false;                        
            }
            return checkbox_remitir;
        }

        public List<U_CitasMedicas> pacientesPorAtender(int userid)
        {
            List<U_CitasMedicas> citas = new Datos.DP_citas_medicas().mostrar_citas_medico(userid);
            return citas;
        }

    }
}

