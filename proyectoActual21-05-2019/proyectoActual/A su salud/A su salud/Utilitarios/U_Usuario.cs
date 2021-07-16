using System;

namespace Utilitarios
{
    public class U_Usuario
    {
        private Int32 userId;
        private String session;
        private String ip;
        private String mac;
        private String clave;
        private int rolId;
        private int valor;
        private Int64 identificacion;
        private string nombres;
        private string apellidos;
        private string mensaje;
        private string mensajeDos;
        private Int32 estado;
        private string correo;
        private long fecha;
        private string token;
        private string user_id;
        private string cajaTexto;
        private int peticion;
        private string peticionDos;
        private string claveDos;
        private int session_idioma;
        private string Ruta_foto_perfil;

        public int UserId { get => userId; set => userId = value; }
        public string Session { get => session; set => session = value; }
        public string Ip { get => ip; set => ip = value; }
        public string Mac { get => mac; set => mac = value; }
        public string Clave { get => clave; set => clave = value; }
        public int RolId { get => rolId; set => rolId = value; }
        public int Valor { get => valor; set => valor = value; }
        public long Identificacion { get => identificacion; set => identificacion = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }
        public string MensajeDos { get => mensajeDos; set => mensajeDos = value; }
        public int Estado { get => estado; set => estado = value; }
        public string Correo { get => correo; set => correo = value; }
        public long Fecha { get => fecha; set => fecha = value; }
        public string Token { get => token; set => token = value; }
        public string User_id { get => user_id; set => user_id = value; }
        public string CajaTexto { get => cajaTexto; set => cajaTexto = value; }
        public int Peticion { get => peticion; set => peticion = value; }
        public string PeticionDos { get => peticionDos; set => peticionDos = value; }
        public string ClaveDos { get => claveDos; set => claveDos = value; }
        public int Session_idioma { get => session_idioma; set => session_idioma = value; }
        public string Ruta_foto_perfil1 { get => Ruta_foto_perfil; set => Ruta_foto_perfil = value; }
    }
}
