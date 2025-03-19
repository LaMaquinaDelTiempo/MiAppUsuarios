using System;
using System.Collections.Generic;
using MiAppUsuarios.Models;
using Microsoft.EntityFrameworkCore;

namespace MiAppUsuarios.DataContext;

public partial class MiApiUsuariosDbContext : DbContext
{
    public MiApiUsuariosDbContext()
    {
    }

    public MiApiUsuariosDbContext(DbContextOptions<MiApiUsuariosDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=MiApiUsuariosDB;Username=postgres;Password=1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "idx_users_email");

            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Lastname)
                .HasMaxLength(100)
                .HasColumnName("lastname");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Passwordhash).HasColumnName("passwordhash");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
