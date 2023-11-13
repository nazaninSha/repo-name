using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace repo_name.Models;

public partial class RoiDatabaseContext : DbContext
{
    public RoiDatabaseContext()
    {
    }

    public RoiDatabaseContext(DbContextOptions<RoiDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC07A80C3C56");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__People__3214EC076B6B572F");

            entity.Property(e => e.City).HasMaxLength(255);
            entity.Property(e => e.Country).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.State).HasMaxLength(255);
            entity.Property(e => e.Street).HasMaxLength(255);
            entity.Property(e => e.Zip)
                .HasMaxLength(10)
                .HasColumnName("ZIP");

            entity.HasOne(d => d.Department).WithMany(p => p.People)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__People__Departme__300424B4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
