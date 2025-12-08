using KursProjectISP31.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using WebApi.Model;

namespace WebApi.Model;

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
    public virtual DbSet<Person> Persons { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Admin");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(true);
            entity.Property(e => e.Password)
                .HasMaxLength(2000)
                .IsUnicode(false);
        });

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

        
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
