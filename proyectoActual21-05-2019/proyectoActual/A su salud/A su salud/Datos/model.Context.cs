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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class asusaludEntities : DbContext
    {
        public asusaludEntities()
            : base("name=asusaludEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<datos_horario3> datos_horario3 { get; set; }
        public virtual DbSet<controles> controles { get; set; }
        public virtual DbSet<formulario> formulario { get; set; }
        public virtual DbSet<idioma> idioma { get; set; }
        public virtual DbSet<agenda_medico> agenda_medico { get; set; }
        public virtual DbSet<cita_medicas> cita_medicas { get; set; }
        public virtual DbSet<especialidades> especialidades { get; set; }
        public virtual DbSet<historia_clinica> historia_clinica { get; set; }
        public virtual DbSet<auditoria> auditoria { get; set; }
        public virtual DbSet<autenication> autenication { get; set; }
        public virtual DbSet<roles> roles { get; set; }
        public virtual DbSet<seguridad> seguridad { get; set; }
        public virtual DbSet<token_repureacion_usuario> token_repureacion_usuario { get; set; }
        public virtual DbSet<usuarios> usuarios { get; set; }
        public virtual DbSet<estados_pacientes> estados_pacientes { get; set; }
        public virtual DbSet<estados_medicos> estados_medicos { get; set; }
        public virtual DbSet<parametros> parametros { get; set; }
        public virtual DbSet<pqrs> pqrs { get; set; }
        public virtual DbSet<servicios_seguridad> servicios_seguridad { get; set; }
    }
}
