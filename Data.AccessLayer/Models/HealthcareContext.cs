using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Data.AccessLayer.Models;

public partial class HealthcareContext : DbContext
{
    public HealthcareContext()
    {
    }

    public HealthcareContext(DbContextOptions<HealthcareContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Doctors__3214EC27F579237C");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.First_Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Last_Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.Specialization)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patients__3214EC27E4D5622D");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Date_Of_Birth)
                .HasColumnType("datetime")
                .HasColumnName("Date_Of_Birth");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.First_Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Last_Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Prescrip__3214EC276E62B2AF");

            entity.ToTable("Prescription");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.D_ID).HasColumnName("D_ID");
            entity.Property(e => e.D_Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("D_Name");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Medicine)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.P_ID).HasColumnName("P_ID");
            entity.Property(e => e.Symptoms)
                .HasMaxLength(255)
                .IsUnicode(false);

            //entity.HasOne(d => d.DIdNavigation).WithMany(p => p.Prescriptions)
            //    .HasForeignKey(d => d.D_ID)
            //    .HasConstraintName("FK__Prescripti__D_ID__3B75D760");

            //entity.HasOne(d => d.PIdNavigation).WithMany(p => p.Prescriptions)
            //    .HasForeignKey(d => d.P_ID)
            //    .HasConstraintName("FK__Prescripti__P_ID__3A81B327");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
