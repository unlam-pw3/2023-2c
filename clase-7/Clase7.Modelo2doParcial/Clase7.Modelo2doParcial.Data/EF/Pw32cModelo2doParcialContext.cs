using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Clase7.Modelo2doParcial.Data.EF;

public partial class Pw32cModelo2doParcialContext : DbContext
{
    public Pw32cModelo2doParcialContext()
    {
    }

    public Pw32cModelo2doParcialContext(DbContextOptions<Pw32cModelo2doParcialContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cadena> Cadenas { get; set; }

    public virtual DbSet<Sucursal> Sucursals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=PW3-2c-modelo-2do-Parcial;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cadena>(entity =>
        {
            entity.ToTable("Cadena");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(50)
                .HasColumnName("Razon_social");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.ToTable("Sucursal");

            entity.Property(e => e.Ciudad).HasMaxLength(50);
            entity.Property(e => e.Direccion).HasMaxLength(50);

            entity.HasOne(d => d.IdCadenaNavigation).WithMany(p => p.Sucursals)
                .HasForeignKey(d => d.IdCadena)
                .HasConstraintName("FK_Sucursal_Sucursal");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
