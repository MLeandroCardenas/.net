//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class seguridad
    {
        public int id { get; set; }
        public Nullable<long> id_user { get; set; }
        public Nullable<int> cantidad_sesiones { get; set; }
        public Nullable<int> sesiones_activas { get; set; }
        public Nullable<int> intentos_erroneos { get; set; }
        public Nullable<int> maximo_intentos { get; set; }
        public Nullable<int> estado { get; set; }
        public string session { get; set; }
        public Nullable<System.DateTime> last_modified { get; set; }
        public Nullable<System.DateTime> fecha_bloqueo { get; set; }
    }
}
