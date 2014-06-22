
using Celulares.Models.Seguridad;
using Celulares.Util.Entity;
using Celulares.Areas.Registro.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Celulares
{
    public partial class DBContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public BDGeneric<Usuario> T_Usuario { get; set; }

        public DbSet<Rol> Rol { get; set; }
        public BDGeneric<Rol> T_Rol { get; set; }

        public DbSet<Demandante> Demandante { get; set; }
        public BDGeneric<Demandante> T_Demandante { get; set; }

        public DbSet<Demandado> Demandado { get; set; }
        public BDGeneric<Demandado> T_Demandado { get; set; }

        public DbSet<Denuncia> Denuncia { get; set; }
        public BDGeneric<Denuncia> T_Denuncia { get; set; }

        public void Seed()
        {
            Rol tablaRoles = (new Rol {Nombre="Invitado", Estado=true, Eliminado=false, FechaCreacion=DateTime.Now, FechaModificacion=DateTime.Now});
            T_Rol.Add(tablaRoles);
        }

        private void RegistrarTablas()
        {
            T_Usuario = new BDGeneric<Usuario>(this, Usuario);
            T_Rol = new BDGeneric<Rol>(this, Rol);
            T_Demandado = new BDGeneric<Demandado>(this, Demandado);
            T_Demandante = new BDGeneric<Demandante>(this, Demandante);
            T_Denuncia = new BDGeneric<Denuncia>(this, Denuncia);
        }

        private class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
        {
            public UsuarioConfiguration()
            {
                Property(p => p.Id).IsRequired();
                Property(p => p.FechaCreacion).IsRequired().HasColumnType("datetime2");
                Property(p => p.FechaModificacion).IsRequired().HasColumnType("datetime2");
                ToTable(Celulares.Models.Seguridad.Usuario.TABLENAME);
            }
        }

        private class RolConfiguration : EntityTypeConfiguration<Rol>
        {
            public RolConfiguration()
            {
                Property(p => p.Id).IsRequired();
                Property(p => p.FechaCreacion).IsRequired().HasColumnType("datetime2");
                Property(p => p.FechaModificacion).IsRequired().HasColumnType("datetime2");
                ToTable(Celulares.Models.Seguridad.Rol.TABLENAME);
            }
        }

        private class DemandadoConfiguration : EntityTypeConfiguration<Demandado>
        {
            public DemandadoConfiguration()
            {
                Property(p => p.Id).IsRequired();
                Property(p => p.FechaCreacion).IsRequired().HasColumnType("datetime2");
                Property(p => p.FechaModificacion).IsRequired().HasColumnType("datetime2");
                ToTable(Celulares.Areas.Registro.Models.Demandado.TABLENAME);
            }
        }

        private class DemandanteConfiguration : EntityTypeConfiguration<Demandante>
        {
            public DemandanteConfiguration()
            {
                Property(p => p.Id).IsRequired();
                Property(p => p.FechaCreacion).IsRequired().HasColumnType("datetime2");
                Property(p => p.FechaModificacion).IsRequired().HasColumnType("datetime2");
                ToTable(Celulares.Areas.Registro.Models.Demandante.TABLENAME);
            }
        }

        private class DenunciaConfiguration : EntityTypeConfiguration<Denuncia>
        {
            public DenunciaConfiguration()
            {
                Property(p => p.Id).IsRequired();
                Property(p => p.FechaCreacion).IsRequired().HasColumnType("datetime2");
                Property(p => p.FechaModificacion).IsRequired().HasColumnType("datetime2");
                ToTable(Celulares.Areas.Registro.Models.Denuncia.TABLENAME);
            }
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new RolConfiguration());
            modelBuilder.Configurations.Add(new DenunciaConfiguration());
            modelBuilder.Configurations.Add(new DemandadoConfiguration());
            modelBuilder.Configurations.Add(new DemandanteConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}