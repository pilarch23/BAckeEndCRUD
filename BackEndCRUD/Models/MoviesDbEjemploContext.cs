using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackEndCRUD.Models;

public partial class MoviesDbEjemploContext : DbContext
{
    public MoviesDbEjemploContext()
    {
    }

    public MoviesDbEjemploContext(DbContextOptions<MoviesDbEjemploContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Director> Directors { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Director>(entity =>
        {
            entity.HasKey(e => e.IdDirector).HasName("PK__Director__781D9EBF55C7C3D5");

            entity.ToTable("Director");

            entity.Property(e => e.IdDirector)
                .HasColumnName("ID_Director");
            entity.Property(e => e.DirectorName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Director_Name");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.IdMovies).HasName("PK__Movies__2CEFFB2DD82B0614");

            entity.Property(e => e.IdMovies).HasColumnName("ID_Movies");
            entity.Property(e => e.DirectorKey).HasColumnName("Director_Key");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MovieName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Movie_Name");

            entity.HasOne(d => d.DirectorKeyNavigation).WithMany(p => p.Movies)
                .HasForeignKey(d => d.DirectorKey)
                .HasConstraintName("FK__Movies__Director__3A81B327");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
