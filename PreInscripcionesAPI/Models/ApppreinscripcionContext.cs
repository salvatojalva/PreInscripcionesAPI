using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PreInscripcionesAPI.Models;

public partial class ApppreinscripcionContext : DbContext
{
    public ApppreinscripcionContext()
    {
    }

    public ApppreinscripcionContext(DbContextOptions<ApppreinscripcionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carrera> Carreras { get; set; }

    public virtual DbSet<Jornadum> Jornada { get; set; }

    public virtual DbSet<PreinscripcionAlumno> PreinscripcionAlumnos { get; set; }

    public virtual DbSet<Sede> Sedes { get; set; }

    public virtual DbSet<SedeCarreraJornadum> SedeCarreraJornada { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost; Database=APPPreinscripcion; User=sa; Password=Password.;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Modern_Spanish_CI_AS");

        modelBuilder.Entity<Carrera>(entity =>
        {
            entity.HasKey(e => e.IdCarrera).HasName("PK__carrera__085DCEF60AD2A005");

            entity.ToTable("carrera");

            entity.Property(e => e.IdCarrera)
                .HasMaxLength(5)
                .HasColumnName("ID_Carrera");
            entity.Property(e => e.NomCarrera)
                .HasMaxLength(200)
                .HasColumnName("Nom_Carrera");
        });

        modelBuilder.Entity<Jornadum>(entity =>
        {
            entity.HasKey(e => e.IdJornada).HasName("PK__jornada__6BD46D1AF0383134");

            entity.ToTable("jornada");

            entity.Property(e => e.IdJornada).HasColumnName("id_jornada");
            entity.Property(e => e.NombreJornada)
                .HasMaxLength(50)
                .HasColumnName("nombre_jornada");
        });

        modelBuilder.Entity<PreinscripcionAlumno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Preinscripcion");

            entity.ToTable("Preinscripcion_Alumno");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .HasColumnName("ID");
            entity.Property(e => e.Apellido1).HasMaxLength(20);
            entity.Property(e => e.Apellido2).HasMaxLength(20);
            entity.Property(e => e.Celular).HasMaxLength(20);
            entity.Property(e => e.CorreoPersonal)
                .HasMaxLength(50)
                .HasColumnName("Correo_personal");
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.Dpi)
                .HasMaxLength(15)
                .HasColumnName("dpi");
            entity.Property(e => e.EstadoCivil)
                .HasMaxLength(10)
                .HasColumnName("Estado_Civil");
            entity.Property(e => e.FechaPre)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Pre");
            entity.Property(e => e.Fechanac).HasColumnType("smalldatetime");
            entity.Property(e => e.Genero).HasMaxLength(20);
            entity.Property(e => e.IdSedeCarreraJornada).HasColumnName("id_sede_carrera_jornada");
            entity.Property(e => e.Nombre1).HasMaxLength(20);
            entity.Property(e => e.Nombre2).HasMaxLength(50);

            entity.HasOne(d => d.IdSedeCarreraJornadaNavigation).WithMany(p => p.PreinscripcionAlumnos)
                .HasForeignKey(d => d.IdSedeCarreraJornada)
                .HasConstraintName("FK_Preinscripcion_Alumno_Sede_Carrera_Jornada");
        });

        modelBuilder.Entity<Sede>(entity =>
        {
            entity.HasKey(e => e.IdSede);

            entity.ToTable("Sede");

            entity.Property(e => e.IdSede)
                .HasMaxLength(5)
                .HasColumnName("id_sede");
            entity.Property(e => e.NombreSede)
                .HasMaxLength(50)
                .HasColumnName("nombre_sede");
        });

        modelBuilder.Entity<SedeCarreraJornadum>(entity =>
        {
            entity.HasKey(e => e.IdSedeCarreraJornada);

            entity.ToTable("Sede_Carrera_Jornada");

            entity.Property(e => e.IdSedeCarreraJornada).HasColumnName("id_sede_carrera_jornada");
            entity.Property(e => e.IdCarrera)
                .HasMaxLength(5)
                .HasColumnName("id_carrera");
            entity.Property(e => e.IdJornada).HasColumnName("id_jornada");
            entity.Property(e => e.IdSede)
                .HasMaxLength(5)
                .HasColumnName("id_sede");

            entity.HasOne(d => d.IdCarreraNavigation).WithMany(p => p.SedeCarreraJornada)
                .HasForeignKey(d => d.IdCarrera)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sede_Carrera_Jornada_carrera");

            entity.HasOne(d => d.IdJornadaNavigation).WithMany(p => p.SedeCarreraJornada)
                .HasForeignKey(d => d.IdJornada)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sede_Carrera_Jornada_jornada");

            entity.HasOne(d => d.IdSedeNavigation).WithMany(p => p.SedeCarreraJornada)
                .HasForeignKey(d => d.IdSede)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sede_Carrera_Jornada_Sede");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
