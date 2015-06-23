using ISIC.Entities;
using ISIC.Persistence.Mappings;
using MPBA.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPBA.Jira;
using ISIC.Services;
using MPBA.Jira.Model;


namespace ISIC.Persistence.Context
{
    public class ISICContext : DbContext, IDbContext
    {
       
        public ISICContext()
            : base("ISICDS")
        {
            Database.SetInitializer<ISICContext>(new ContextInitializer());
            
        }
        

        public IQueryable<T> Find<T>() where T : class
        {
            return this.Set<T>();
        }

        public void Rollback()
        {
            this.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new DepartamentoMapping());
            modelBuilder.Configurations.Add(new LocalidadMapping());
            modelBuilder.Configurations.Add(new PartidoMapping());
            modelBuilder.Configurations.Add(new ProvinciaMapping());
            modelBuilder.Configurations.Add(new SeniaParticularMapping());
            modelBuilder.Configurations.Add(new PersonaMapping());
            modelBuilder.Configurations.Add(new DomicilioMapping());
            modelBuilder.Configurations.Add(new ImputadoMapping());
            modelBuilder.Configurations.Add(new DelitoMapping());
            modelBuilder.Configurations.Add(new TatuajePersonaMapping());
            modelBuilder.Configurations.Add(new IPPMapping());
            modelBuilder.Configurations.Add(new ArchivoMapping());
            modelBuilder.Configurations.Add(new ClaseEstadoCivilMapping());
            modelBuilder.Configurations.Add(new ClaseEstudiosCursadosMapping());
            modelBuilder.Configurations.Add(new ClaseSeniaParticularMapping());
            modelBuilder.Configurations.Add(new ClaseSexoMapping());
            modelBuilder.Configurations.Add(new ClaseTatuajeMapping());
            modelBuilder.Configurations.Add(new ClaseTipoPersonaMapping());
            modelBuilder.Configurations.Add(new ClaseUbicacionSeniaPartMapping());
            modelBuilder.Configurations.Add(new PuntoGestionMapping());
            modelBuilder.Configurations.Add(new PersonalPoderJudicialMapping());
            modelBuilder.Configurations.Add(new ClaseCodBarraPuntoGestionMapping());
            modelBuilder.Configurations.Add(new UsuariosMapping());
            modelBuilder.Configurations.Add(new AutorMapping());
            modelBuilder.Configurations.Add(new AFISMapping());
            modelBuilder.Configurations.Add(new GNAMapping());
            modelBuilder.Configurations.Add(new MigracionesMapping());
            base.OnModelCreating(modelBuilder);

        }
        //public virtual DbSet<Autor> Autor { get; set; } 
        public virtual DbSet<BioDactilar> BioDactilar { get; set; }
        public virtual DbSet<Imputado> Imputado { get; set; }
        public virtual DbSet<ClaseProfesion> Profesion { get; set; }
        public virtual DbSet<AutoresAlias> AutoresAlias { get; set; }
        public virtual DbSet<ClaseDelito> ClaseDelito { get; set; }
        public virtual DbSet<ClaseEstadoCivil> ClaseEstadoCivil { get; set; }
        public virtual DbSet<ClaseEstudiosCursados> ClaseEstudiosCursados { get; set; }
        public virtual DbSet<ClaseSeniaParticular> ClaseSeniaParticular { get; set; }
        public virtual DbSet<ClaseSexo> ClaseSexo { get; set; }
        public virtual DbSet<ClaseTatuaje> ClaseTatuaje { get; set; }
        public virtual DbSet<ClaseTipoDNI> ClaseTipoDNI { get; set; }
        public virtual DbSet<ClaseTipoPersona> ClaseTipoPersona { get; set; }
        public virtual DbSet<ClaseUbicacionSeniaPart> ClaseUbicacionSeniaPart { get; set; }
        public virtual DbSet<ClaseNombre> ClaseNombre { get; set; }
        public virtual DbSet<Delito> Delito { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<DescripcionTemporal> DescripcionTemporal { get; set; }
        public virtual DbSet<Domicilio> Domicilio { get; set; }
        public virtual DbSet<ImputadoEstadoTramite> ImputadoEstadosTramite { get; set; }
        public virtual DbSet<IPP> IPP { get; set; }
        public virtual DbSet<ClaseTipoArchivo> ClaseTipoArchivo { get; set; }
        public virtual DbSet<Archivo> Archivo { get; set; }
        public virtual DbSet<Localidad> Localidad { get; set; }
        public virtual DbSet<NNClaseModusOperandi> NNClaseModusOperandi { get; set; }
        public virtual DbSet<NNClaseTipoAutor> NNClaseTipoAutor { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Partido> Partido { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<ClaseDepartamentoJudicial> ClaseDepartamentoJudicial { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<PersonaIdentidad> PersonaIdentidad { get; set; }
        public virtual DbSet<SeniaParticular> SeniaParticular { get; set; }
        public virtual DbSet<SICClaseEstatura> SicClaseEstatura { get; set; }
        public virtual DbSet<SICClaseCejasDimension> SICClaseCejasDimension { get; set; }
        public virtual DbSet<SICClaseCejasTipo> SICClaseCejasTipo { get; set; }
        public virtual DbSet<SICClaseColorCabello> SICClaseColorCabello { get; set; }
        public virtual DbSet<SICClaseColorOjos> SICClaseColorOjos { get; set; }
        public virtual DbSet<SICClaseColorPiel> SICClaseColorPiel { get; set; }
        public virtual DbSet<SICClaseFormaBoca> SICClaseFormaBoca { get; set; }
        public virtual DbSet<SICClaseFormaCara> SICClaseFormaCara { get; set; }
        public virtual DbSet<SICClaseFormaLabioInferior> SICClaseFormaLabioInferior { get; set; }
        public virtual DbSet<SICClaseFormaLabioSuperior> SICClaseFormaLabioSuperior { get; set; }
        public virtual DbSet<SICClaseFormaMenton> SICClaseFormaMenton { get; set; }
        public virtual DbSet<SICClaseFormaNariz> SICClaseFormaNariz { get; set; }
        public virtual DbSet<SICClaseFormaOreja> SICClaseFormaOreja { get; set; }
        public virtual DbSet<SICClaseRobustez> SICClaseRobustez { get; set; }
        public virtual DbSet<SICClaseTipoCabello> SICClaseTipoCabello { get; set; }
        public virtual DbSet<SICClaseTipoCalvicie> SICClaseTipoCalvicie { get; set; }
        public virtual DbSet<SICEstadoTramite> SICEstadosTramite { get; set; }
        public virtual DbSet<TatuajePersona> TatuajesPersona { get; set; }
        public virtual DbSet<VucClasificacion> VucClasificacion { get; set; }
        public virtual DbSet<VucSubClasificacion> VucSubClasificacion { get; set; }
        public virtual DbSet<CotejoRenaper> CotejoRenaper { get; set; }
        public virtual DbSet<PuntoGestion> PuntoGestion { get; set; }
        public virtual DbSet<ClasePuntoGestion> ClasePuntoGestion { get; set; }
        public virtual DbSet<PersonalPoderJudicial> PersonalPoderJudicial { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<GrupoUsuario> GrupoUsuario { get; set; }
        public virtual DbSet<ClaseCodBarraPuntoGestion> ClaseCodBarraPuntoGestion { get; set; }
        public virtual DbSet<ClaseCodigoRestriccionPoliciaFederal> ClaseCodigoRestriccionesPoliciaFederal { get; set; }
        public virtual DbSet<ClaseProntuarioPoliciaFederal> ClaseProntuariosPoliciaFederal { get; set; }
        public virtual DbSet<IdgxDatosPersona> IdgxDatosPersona { get; set; }
        public virtual DbSet<IdgxDetalle> IdgxDetalle { get; set; }
        public virtual DbSet<IdgxProntuario> IdgxProntuario { get; set; }
        public virtual DbSet<AFIS> AFIS { get; set; }
        public virtual DbSet<GNA> GNA { get; set; }
        public virtual DbSet<Prontuario> Prontuario { get; set; }
        public virtual DbSet<Migraciones> Migraciones { get; set; }
        public virtual DbSet<ClaseExpedienteMigraciones> ClaseExpedienteMigraciones { get; set; }

    }
}