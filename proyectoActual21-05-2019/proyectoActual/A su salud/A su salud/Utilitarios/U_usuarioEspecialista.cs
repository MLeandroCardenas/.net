using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class U_usuarioEspecialista
    {

        string apellidos;
        string apellido_medico;
        string nombres;
        string nombre_medico;
        Int64 numid;
        Int64 id;
        Int64 identificacion;
        string email;
        string clave;
        string Especializacion;
        int rol;
        int estado;
        string session;
        string foto;
        string url;
        DateTime fecha_inicio;
        DateTime fecha_fin;
        Int64 edad;
        string motivo;
        string alergias;
        string cirugias;
        Int64 altura;
        Int64 peso;
        string observacionPiel;
        string observacionRespiracion;
        string observacionBoca;
        string diagnostico;
        string asignar_especialista;

        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Apellido_medico { get => apellido_medico; set => apellido_medico = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Nombre_medico { get => nombre_medico; set => nombre_medico = value; }
        public long Numid { get => numid; set => numid = value; }
        public long Id { get => id; set => id = value; }
        public long Identificacion { get => identificacion; set => identificacion = value; }
        public string Email { get => email; set => email = value; }
        public string Clave { get => clave; set => clave = value; }
        public string Especializacion1 { get => Especializacion; set => Especializacion = value; }
        public int Rol { get => rol; set => rol = value; }
        public int Estado { get => estado; set => estado = value; }
        public string Session { get => session; set => session = value; }
        public string Foto { get => foto; set => foto = value; }
        public string Url { get => url; set => url = value; }
        public DateTime Fecha_inicio { get => fecha_inicio; set => fecha_inicio = value; }
        public DateTime Fecha_fin { get => fecha_fin; set => fecha_fin = value; }
        public long Edad { get => edad; set => edad = value; }
        public string Motivo { get => motivo; set => motivo = value; }
        public string Alergias { get => alergias; set => alergias = value; }
        public string Cirugias { get => cirugias; set => cirugias = value; }
        public long Altura { get => altura; set => altura = value; }
        public long Peso { get => peso; set => peso = value; }
        public string ObservacionPiel { get => observacionPiel; set => observacionPiel = value; }
        public string ObservacionRespiracion { get => observacionRespiracion; set => observacionRespiracion = value; }
        public string ObservacionBoca { get => observacionBoca; set => observacionBoca = value; }
        public string Diagnostico { get => diagnostico; set => diagnostico = value; }
        public string Asignar_especialista { get => asignar_especialista; set => asignar_especialista = value; }
    }
}
