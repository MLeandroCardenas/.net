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
    
    public partial class token_repureacion_usuario
    {
        public int id { get; set; }
        public Nullable<long> user_id { get; set; }
        public string token { get; set; }
        public Nullable<System.DateTime> fecha_creado { get; set; }
        public Nullable<System.DateTime> fecha_vigencia { get; set; }
    
        public virtual usuarios usuarios { get; set; }
    }
}
