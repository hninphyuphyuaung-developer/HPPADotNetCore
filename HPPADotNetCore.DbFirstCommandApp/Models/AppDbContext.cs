using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HPPADotNetCore.DbFirstCommandApp.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblFamily> TblFamilies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.;Database=HppaDotNetCore;User ID=sa;Password=sa@123;Trusted_Connection=True;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblFamily>(entity =>
        {
            entity.HasKey(e => e.FamilyId);

            entity.ToTable("Tbl_Family");

            entity.Property(e => e.DaughterName).HasMaxLength(50);
            entity.Property(e => e.ParentName).HasMaxLength(50);
            entity.Property(e => e.SonName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
