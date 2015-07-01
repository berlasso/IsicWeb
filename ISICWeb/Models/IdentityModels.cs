using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Web.Helpers;
using System.Linq;
using System.Data.Entity.Infrastructure;
using ISIC.Persistence.Context;
using System.Web.Mvc;
using ISIC.Entities;
using MPBA.DataAccess;

namespace ISICWeb.Models
{
    // Puede agregar datos del perfil del usuario agregando más propiedades a la clase ApplicationUser. Para más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public string idPuntoGestion { get; set; }
        public string subCodBarra { get; set; }
        //public string NombreUsuario { get; set; }
        
        //public string ClaveUsuario { get; set; }
        public string UsuarioSicViejo { get; set; }
        public string idPersonalPoderJudicial { get; set; }
        public bool activo { get; set; }
        public int? idGrupoUsuario { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public string Dependencia { get; set; }
        public bool? UsuarioMPBA { get; set; }

     
      
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            subCodBarra = subCodBarra ?? "";
            idPuntoGestion = idPuntoGestion ?? "";
            
            // Agregar reclamaciones de usuario personalizado aquí
            userIdentity.AddClaim(new Claim("idPuntoGestion", this.idPuntoGestion));
            userIdentity.AddClaim(new Claim("subCodBarra", this.subCodBarra));
            

            return userIdentity;
        }


    }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ISICDS", throwIfV1Schema: false)
        {
            Database.SetInitializer<ApplicationDbContext>(new SecurityContextInitializer());
        }


        public static ApplicationDbContext Create()
        {
            var ctx = new ApplicationDbContext();
            return ctx;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>().ToTable("UsuariosIsic");
            modelBuilder.Entity<ApplicationUser>().ToTable("UsuariosIsic");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UsuariosRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("Logins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("Claims");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");

        }
    }

    
    public class SecurityContextInitializer : IDatabaseInitializer<ApplicationDbContext>
    {
        public void InitializeDatabase(ApplicationDbContext context)
        {
            // Me aseguro que la base ISIC este creada
           // IDbContext ctx = DependencyResolver.Current.GetService<IDbContext>();
            //if (!ctx.Database.Exists())
            //{
            //    ctx.Database.Initialize(true);
            //}

            //if (!CheckIfTableUsersExists(context))
            //{
            //    // create all model tables
            //    var dbCreationScript = ((IObjectContextAdapter)context).ObjectContext.CreateDatabaseScript();
            //    context.Database.ExecuteSqlCommand(dbCreationScript);
            //}
            //CreateUserPrueba(context);
        }

        public void CreateUserPrueba(ApplicationDbContext context)
        {
            var u = context.Users.Where(b => b.UserName == "prueba").FirstOrDefault();
            if (u == null)
            
            {

                var UserManager = new UserManager<ApplicationUser>(new
                                               UserStore<ApplicationUser>(context));

                var RoleManager = new RoleManager<IdentityRole>(new
                                         RoleStore<IdentityRole>(context));
                string roleName = "Admin";
                //Create Role Admin if it does not exist
                if (!RoleManager.RoleExists(roleName))
                {
                    var roleresult = RoleManager.Create(new IdentityRole(roleName));
                }
                //Create User=Admin with password=123456
                
                var user = new ApplicationUser();
                user.Email = "prueba@mpba.gov.ar";
                user.EmailConfirmed = true;
                user.activo = true;
                //user.PasswordHash = Crypto.HashPassword("pa$$w0rd");
                user.UserName = "prueba@mpba.gov.ar";
                var adminresult = UserManager.Create(user, "pa$$w0rd");

                //Add User Admin to Role Admin
                if (adminresult.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, roleName);
                }
            }
        }
        public bool CheckIfTableUsersExists(ApplicationDbContext context)
        {
            int result = context.Database.SqlQuery<int>(@"
                IF EXISTS (SELECT * FROM sys.tables WHERE name = 'UsuariosIsic') 
                    SELECT 1
                ELSE
                    SELECT 0
            ").SingleOrDefault();

            if (result == 1)
                return true;
            else
                return false;
        }
    }
}