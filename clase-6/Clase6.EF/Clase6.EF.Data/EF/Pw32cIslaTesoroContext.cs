using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Clase6.EF.Data.EF;

public partial class Pw32cIslaTesoroContext : DbContext
{
    public Pw32cIslaTesoroContext()
    {
    }

    public Pw32cIslaTesoroContext(DbContextOptions<Pw32cIslaTesoroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoriaTesoro> CategoriaTesoros { get; set; }

    public virtual DbSet<Tesoro> Tesoros { get; set; }

    public virtual DbSet<Ubicacion> Ubicacions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=Pw3-2c-IslaTesoro;User=sa;Password=pZ#332-V;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriaTesoro>(entity =>
        {
            entity.ToTable("CategoriaTesoro");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TesoroId).HasColumnName("TesoroID");

            entity.HasOne(d => d.Tesoro).WithMany(p => p.CategoriaTesoros)
                .HasForeignKey(d => d.TesoroId)
                .HasConstraintName("FK_CategoriaTesoro_Tesoro");
        });

        modelBuilder.Entity<Tesoro>(entity =>
        {
            entity.ToTable("Tesoro");

            entity.Property(e => e.ImagenRuta).HasMaxLength(300);
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.IdUbicacionNavigation).WithMany(p => p.Tesoros)
                .HasForeignKey(d => d.IdUbicacion)
                .HasConstraintName("FK_Tesoro_Ubicacion");
        });

        modelBuilder.Entity<Ubicacion>(entity =>
        {
            entity.ToTable("Ubicacion");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
