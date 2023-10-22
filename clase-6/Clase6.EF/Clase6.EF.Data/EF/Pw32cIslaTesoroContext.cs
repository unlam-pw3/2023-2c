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

/*
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=Pw3-2c-IslaTesoro;User=sa;Password=pZ#332-V;Encrypt=False");
*/
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.;Database=Pw3-2c-IslaTesoro;Trusted_Connection=True;Encrypt=False");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriaTesoro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC07A6A25CE8");

            entity.ToTable("CategoriaTesoro");

            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tesoro>(entity =>
        {
            entity.ToTable("Tesoro");

            entity.Property(e => e.ImagenRuta).HasMaxLength(300);
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.CategoriaTesoro).WithMany(p => p.Tesoros)
                .HasForeignKey(d => d.CategoriaTesoroId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_Tesoro_CategoriaTesoro");

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
