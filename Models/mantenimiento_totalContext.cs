using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WSMantenimiento.Models
{
    public partial class mantenimiento_totalContext : DbContext
    {
        public mantenimiento_totalContext()
        {
        }

        public mantenimiento_totalContext(DbContextOptions<mantenimiento_totalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actividade> Actividades { get; set; }
        public virtual DbSet<AlmacenRefaccione> AlmacenRefacciones { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<ListaRefaccionesActvProg> ListaRefaccionesActvProgs { get; set; }
        public virtual DbSet<ListaRefaccionesMc> ListaRefaccionesMcs { get; set; }
        public virtual DbSet<ListaStatus> ListaStatuses { get; set; }
        public virtual DbSet<Maquinarium> Maquinaria { get; set; }
        public virtual DbSet<Refaccione> Refacciones { get; set; }
        public virtual DbSet<RegistroActividade> RegistroActividades { get; set; }
        public virtual DbSet<RegistroMantenimientoCorrectivo> RegistroMantenimientoCorrectivos { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Trabajadore> Trabajadores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=mantenimiento_total;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Actividade>(entity =>
            {
                entity.HasKey(e => e.IdActividad)
                    .HasName("pk_actividades");

                entity.ToTable("actividades");

                entity.Property(e => e.IdActividad).HasColumnName("idActividad");

                entity.Property(e => e.Asignada)
                    .HasColumnName("asignada")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaProgramada)
                    .HasColumnType("date")
                    .HasColumnName("fechaProgramada");

                entity.Property(e => e.IdArea).HasColumnName("idArea");

                entity.Property(e => e.IdMaquina).HasColumnName("idMaquina");

                entity.Property(e => e.NombreActividad)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombreActividad");

                entity.Property(e => e.Periodo).HasColumnName("periodo");

                entity.Property(e => e.RecursoHumano).HasColumnName("recursoHumano");

                entity.Property(e => e.Tiempo).HasColumnName("tiempo");

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Actividades)
                    .HasForeignKey(d => d.IdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_actividades_area");

                entity.HasOne(d => d.IdMaquinaNavigation)
                    .WithMany(p => p.Actividades)
                    .HasForeignKey(d => d.IdMaquina)
                    .HasConstraintName("fk_actividades_maquinaria");
            });

            modelBuilder.Entity<AlmacenRefaccione>(entity =>
            {
                entity.HasKey(e => e.IdSerial)
                    .HasName("pk_almacen_refacciones");

                entity.ToTable("almacen_refacciones");

                entity.Property(e => e.IdSerial).HasColumnName("idSerial");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.FechaMovimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaMovimiento");

                entity.Property(e => e.IdRefaccion).HasColumnName("idRefaccion");

                entity.Property(e => e.IdStatus).HasColumnName("idStatus");

                entity.HasOne(d => d.IdRefaccionNavigation)
                    .WithMany(p => p.AlmacenRefacciones)
                    .HasForeignKey(d => d.IdRefaccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_almacenR_refacciones");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.AlmacenRefacciones)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_almacenR_status");
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.IdArea)
                    .HasName("pk_area");

                entity.ToTable("area");

                entity.Property(e => e.IdArea).HasColumnName("idArea");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<ListaRefaccionesActvProg>(entity =>
            {
                entity.HasKey(e => e.IdSerial)
                    .HasName("pk_lista_r");

                entity.ToTable("lista_refacciones_actvProg");

                entity.Property(e => e.IdSerial).HasColumnName("idSerial");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdActividad).HasColumnName("idActividad");

                entity.Property(e => e.IdRefaccion).HasColumnName("idRefaccion");

                entity.HasOne(d => d.IdActividadNavigation)
                    .WithMany(p => p.ListaRefaccionesActvProgs)
                    .HasForeignKey(d => d.IdActividad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_listaR_actividades");

                entity.HasOne(d => d.IdRefaccionNavigation)
                    .WithMany(p => p.ListaRefaccionesActvProgs)
                    .HasForeignKey(d => d.IdRefaccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_listaR_refacciones");
            });

            modelBuilder.Entity<ListaRefaccionesMc>(entity =>
            {
                entity.HasKey(e => e.IdSerial)
                    .HasName("pk_lista_rMC");

                entity.ToTable("lista_refacciones_MC");

                entity.Property(e => e.IdSerial).HasColumnName("idSerial");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdOrden)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("idOrden");

                entity.Property(e => e.IdRefaccion).HasColumnName("idRefaccion");

                entity.HasOne(d => d.IdRefaccionNavigation)
                    .WithMany(p => p.ListaRefaccionesMcs)
                    .HasForeignKey(d => d.IdRefaccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_listaRM_refacciones");
            });

            modelBuilder.Entity<ListaStatus>(entity =>
            {
                entity.HasKey(e => e.IdStatus)
                    .HasName("pk_lista_status");

                entity.ToTable("lista_status");

                entity.Property(e => e.IdStatus).HasColumnName("idStatus");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Maquinarium>(entity =>
            {
                entity.HasKey(e => e.IdMaquina)
                    .HasName("pk_maquinaria");

                entity.ToTable("maquinaria");

                entity.Property(e => e.IdMaquina).HasColumnName("idMaquina");

                entity.Property(e => e.AñoFabricacion).HasColumnName("añoFabricacion");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.IdArea).HasColumnName("idArea");

                entity.Property(e => e.Modelo)
                    .HasColumnType("text")
                    .HasColumnName("modelo");

                entity.Property(e => e.NumeroSerie)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("numeroSerie");

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Maquinaria)
                    .HasForeignKey(d => d.IdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_maquinaria_area");
            });

            modelBuilder.Entity<Refaccione>(entity =>
            {
                entity.HasKey(e => e.IdRefaccion)
                    .HasName("pk_refacciones");

                entity.ToTable("refacciones");

                entity.Property(e => e.IdRefaccion).HasColumnName("idRefaccion");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.Unidad)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("unidad");
            });

            modelBuilder.Entity<RegistroActividade>(entity =>
            {
                entity.ToTable("registro_actividades");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaProgramada)
                    .HasColumnType("date")
                    .HasColumnName("fechaProgramada");

                entity.Property(e => e.FechaRealizacion)
                    .HasColumnType("date")
                    .HasColumnName("fechaRealizacion");

                entity.Property(e => e.IdActividad).HasColumnName("idActividad");

                entity.Property(e => e.IdMaquina).HasColumnName("idMaquina");

                entity.Property(e => e.IdOrden)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("idOrden");

                entity.Property(e => e.IdTrabajador).HasColumnName("idTrabajador");

                entity.Property(e => e.IdTrabajadorSupervisor).HasColumnName("idTrabajadorSupervisor");

                entity.Property(e => e.Notas)
                    .HasColumnType("text")
                    .HasColumnName("notas");

                entity.HasOne(d => d.IdActividadNavigation)
                    .WithMany(p => p.RegistroActividades)
                    .HasForeignKey(d => d.IdActividad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_registro_actividades_actividades");

                entity.HasOne(d => d.IdMaquinaNavigation)
                    .WithMany(p => p.RegistroActividades)
                    .HasForeignKey(d => d.IdMaquina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_registroA_maquinaria");

                entity.HasOne(d => d.IdTrabajadorNavigation)
                    .WithMany(p => p.RegistroActividades)
                    .HasForeignKey(d => d.IdTrabajador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_registroA_trabajadores");
            });

            modelBuilder.Entity<RegistroMantenimientoCorrectivo>(entity =>
            {
                entity.ToTable("registro_mantenimiento_correctivo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdMaquina).HasColumnName("idMaquina");

                entity.Property(e => e.IdOrden)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("idOrden");

                entity.Property(e => e.IdTrabajador).HasColumnName("idTrabajador");

                entity.Property(e => e.TiempoParo).HasColumnName("tiempoParo");

                entity.HasOne(d => d.IdMaquinaNavigation)
                    .WithMany(p => p.RegistroMantenimientoCorrectivos)
                    .HasForeignKey(d => d.IdMaquina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_registroM_maquinaria");

                entity.HasOne(d => d.IdTrabajadorNavigation)
                    .WithMany(p => p.RegistroMantenimientoCorrectivos)
                    .HasForeignKey(d => d.IdTrabajador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_registroM_trabajadores");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Trabajadore>(entity =>
            {
                entity.HasKey(e => e.IdTrabajador)
                    .HasName("pk_trabajadores");

                entity.ToTable("trabajadores");

                entity.Property(e => e.IdTrabajador).HasColumnName("idTrabajador");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.IdArea).HasColumnName("idArea");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Pass)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("pass");

                entity.Property(e => e.Puesto)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("puesto");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("usuario");

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Trabajadores)
                    .HasForeignKey(d => d.IdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_trabajadores_area");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Trabajadores)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK_trabajadores_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
