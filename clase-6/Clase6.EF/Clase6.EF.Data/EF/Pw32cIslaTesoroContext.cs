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

    public virtual DbSet<Tesoro> Tesoros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=Pw3-2c-IslaTesoro;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tesoro>(entity =>
        {
            entity.ToTable("Tesoro");

            entity.Property(e => e.ImagenRuta).HasMaxLength(300);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
