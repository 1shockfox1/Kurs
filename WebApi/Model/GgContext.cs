using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KursProjectISP31.Model;

public partial class GgContext : DbContext
{
    public GgContext()
    {
        Database.EnsureCreated();
    }

    public GgContext(DbContextOptions<GgContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<Komponent> Komponents { get; set; }

    public virtual DbSet<Sumzakaz> Sumzakazs { get; set; }

    public virtual DbSet<Zakaznakomp> Zakaznakomps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=gg.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Komponent>(entity =>
        {
            entity.HasKey(e => e.Idkomp);

            entity.ToTable("komponent");

            entity.Property(e => e.Kolvonasclade).HasColumnName("kolvonasclade");
            entity.Property(e => e.Namekomp).HasColumnName("namekomp");
            entity.Property(e => e.Neobxodimo).HasColumnName("neobxodimo");
        });

        modelBuilder.Entity<Sumzakaz>(entity =>
        {
            entity.HasKey(e => e.Idzakaza);

            entity.ToTable("sumzakaz");

            entity.Property(e => e.Idzakaza).HasColumnName("idzakaza");
            entity.Property(e => e.Cina).HasColumnName("cina");
            entity.Property(e => e.Client).HasColumnName("client");
            entity.Property(e => e.Datazakaza).HasColumnName("datazakaza");
            entity.Property(e => e.Kolvo).HasColumnName("kolvo");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Tovar).HasColumnName("tovar");
        });

        modelBuilder.Entity<Zakaznakomp>(entity =>
        {
            entity.HasKey(e => e.Idzakazanapost);

            entity.ToTable("zakaznakomp");

            entity.Property(e => e.Cinazatovar).HasColumnName("cinazatovar");
            entity.Property(e => e.Statyspost).HasColumnName("statyspost");

            entity.HasOne(d => d.IdkompNavigation).WithMany(p => p.Zakaznakomps)
                .HasForeignKey(d => d.Idkomp)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
