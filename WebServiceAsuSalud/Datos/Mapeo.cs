using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Datos;

namespace Datos
{
    public class Mapeo : DbContext
    {
        static Mapeo()
        {
            Database.SetInitializer<Mapeo>(null);
        }
        private readonly string schema;

        public Mapeo(string schema)
            : base("name=conexion")
        {
            this.schema = schema;
        }
        public DbSet<U_seguridad_cliente> clientes { get; set; }
        public DbSet<UP_Historia_Clinica> historia { get; set; }
        public DbSet<U_CitasMedicas> citas { get; set; }
        public DbSet<UP_usuarios> usuario { get; set; }
        public DbSet<U_AgendaMedico> agenda { get; set; }
        public DbSet<UP_estados_pacientes> estados_pacientes { get; set; }
        public DbSet<UP_Especialidades> especialidades { get; set; }
        //public DbSet<U_Idioma> idiomas { get; set; }
        //public DbSet<U_Formularios> formulario { get; set; }
        //public DbSet<U_ControlesIdiomas> controles { get; set; }
        //public DbSet<UP_Especialidades> especialidad { get; set; }
        //public DbSet<UP_Pqr> pqr { get; set; }
        //public DbSet<UP_TokenRecuperacion> token { get; set; }
        //public DbSet<UP_Autenticacion> autenticacion { get; set; }
        public DbSet<UP_Seguridad> seguridad { get; set; }
        //public DbSet<UP_datos_horario> datos_horario { get; set; }
        //public DbSet<UP_estados> estados { get; set; }
        //public DbSet<UP_parametros> parametros { get; set; }

    
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.HasDefaultSchema(this.schema);

            base.OnModelCreating(builder);
        }
    }
}