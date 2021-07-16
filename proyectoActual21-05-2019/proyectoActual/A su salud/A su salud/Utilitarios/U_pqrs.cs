using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class U_pqrs
    {
        private string tipo;
        private string mensaje;
        private string mensajeDos;
        private string nombres;
        private string apellidos;
        private string correo;
        private string session;
        private int id_user;
        private int estado = 1;
        private int id;

        public string Tipo { get => tipo; set => tipo = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Session { get => session; set => session = value; }
        public int Id_user { get => id_user; set => id_user = value; }
        public int Estado { get => estado; set => estado = value; }
        public int Id { get => id; set => id = value; }
        public string MensajeDos { get => mensajeDos; set => mensajeDos = value; }
    }
}

