using System;

namespace Utilitarios
{
    public class U_DatosUser
    {
        private string nombrecontrol;
        private int ididioma;
        private int formulario_id;
        private string textocontrol;
        private int id_control;
        private string mensajeremitir;
        private string email;
        private Int64 numid;
        private string foto;
        private string url;
        private string nombres;
        private string clave;
        private string apellidos;
        private string session;
        private string mensaje;
        private string mensaje1;
        private string mensaje2;
        private string mensaje_error;
        private string nombreArchivo;
        private string extension;
        private string saveLocation;
        private int estado;
        private string ruta;
        private string sessionuser;
        private Int64 sessionidrolvalidacion;
        private Int64 su;
        private string especialidad;
        private string espe;
        private string sesion;
        private string especializacion1;
        private int rol;
        private int horas;
        private string guardadofoto;
        private int id;
        private int idSolicitarCita;
        private string fechaini;
        private string fechaf;
        private string nombrepaciente;
        private string apellidopaciente;
        private string documentopaciente;
        private int identificacion;
        private long identificacion2;
        private string nombreMedico;
        private string apellidoMedico;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private int id_age;
        private DateTime fecha_actual;
        private DateTime fecha;
        private DateTime fecha_new;
        private int f;
        private string fecha_completa;
        private DateTime fecha_completa1;
        private int id2;
        private int idcita;
        private bool checkhistoria;
        private string motivo;
        private string alergias;
        private string cirugias;
        private Int64 altura;
        private Int64 peso;
        private string observacionPiel;
        private string observacionRespiracion;
        private string observacionBoca;
        private string diagnostico;
        private string asignarEspecialista;
        private string saveLocation1;
        private bool checkremitir;
        private int sessionidioma;

        public string Email { get => email; set => email = value; }
        public long Numid { get => numid; set => numid = value; }
        public string Foto { get => foto; set => foto = value; }
        public string Url { get => url; set => url = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Clave { get => clave; set => clave = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Session { get => session; set => session = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }
        public string Mensaje_error { get => mensaje_error; set => mensaje_error = value; }
        public string NombreArchivo { get => nombreArchivo; set => nombreArchivo = value; }
        public string Extension { get => extension; set => extension = value; }
        public string SaveLocation { get => saveLocation; set => saveLocation = value; }
        public int Estado { get => estado; set => estado = value; }
        public string Ruta { get => ruta; set => ruta = value; }
        public string Sessionuser { get => sessionuser; set => sessionuser = value; }
        public long Sessionidrolvalidacion { get => sessionidrolvalidacion; set => sessionidrolvalidacion = value; }
        public long Su { get => su; set => su = value; }
        public string Especialidad { get => especialidad; set => especialidad = value; }
        public string Espe { get => espe; set => espe = value; }
        public string Sesion { get => sesion; set => sesion = value; }
        public string Especializacion1 { get => especializacion1; set => especializacion1 = value; }
        public int Rol { get => rol; set => rol = value; }
        public int Horas { get => horas; set => horas = value; }
        public string Guardadofoto { get => guardadofoto; set => guardadofoto = value; }
        public int Id { get => id; set => id = value; }
        public int IdSolicitarCita { get => idSolicitarCita; set => idSolicitarCita = value; }
        public string Fechaini { get => fechaini; set => fechaini = value; }
        public string Fechaf { get => fechaf; set => fechaf = value; }
        public string Nombrepaciente { get => nombrepaciente; set => nombrepaciente = value; }
        public string Apellidopaciente { get => apellidopaciente; set => apellidopaciente = value; }
        public string Documentopaciente { get => documentopaciente; set => documentopaciente = value; }
        public string Mensaje1 { get => mensaje1; set => mensaje1 = value; }
        public string Mensaje2 { get => mensaje2; set => mensaje2 = value; }
        public int Identificacion { get => identificacion; set => identificacion = value; }
        public string NombreMedico { get => nombreMedico; set => nombreMedico = value; }
        public string ApellidoMedico { get => apellidoMedico; set => apellidoMedico = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
        public int Id_age { get => id_age; set => id_age = value; }
        public DateTime Fecha_actual { get => fecha_actual; set => fecha_actual = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public DateTime Fecha_new { get => fecha_new; set => fecha_new = value; }
        public int F { get => f; set => f = value; }
        public string Fecha_completa { get => fecha_completa; set => fecha_completa = value; }
        public int Id2 { get => id2; set => id2 = value; }
        public int Idcita { get => idcita; set => idcita = value; }
        public bool Checkhistoria { get => checkhistoria; set => checkhistoria = value; }
        public string Motivo { get => motivo; set => motivo = value; }
        public string Alergias { get => alergias; set => alergias = value; }
        public string Cirugias { get => cirugias; set => cirugias = value; }
        public long Altura { get => altura; set => altura = value; }
        public long Peso { get => peso; set => peso = value; }
        public string ObservacionPiel { get => observacionPiel; set => observacionPiel = value; }
        public string ObservacionRespiracion { get => observacionRespiracion; set => observacionRespiracion = value; }
        public string ObservacionBoca { get => observacionBoca; set => observacionBoca = value; }
        public string Diagnostico { get => diagnostico; set => diagnostico = value; }
        public string AsignarEspecialista { get => asignarEspecialista; set => asignarEspecialista = value; }
        public string SaveLocation1 { get => saveLocation1; set => saveLocation1 = value; }
        public bool Checkremitir { get => checkremitir; set => checkremitir = value; }
        public string Mensajeremitir { get => mensajeremitir; set => mensajeremitir = value; }
        public int Sessionidioma { get => sessionidioma; set => sessionidioma = value; }
        public int Id_control { get => id_control; set => id_control = value; }
        public string Nombrecontrol { get => nombrecontrol; set => nombrecontrol = value; }
        public int Ididioma { get => ididioma; set => ididioma = value; }
        public int Formulario_id { get => formulario_id; set => formulario_id = value; }
        public string Textocontrol { get => textocontrol; set => textocontrol = value; }
        public DateTime Fecha_completa1 { get => fecha_completa1; set => fecha_completa1 = value; }
        public long Identificacion2 { get => identificacion2; set => identificacion2 = value; }
    }
}

