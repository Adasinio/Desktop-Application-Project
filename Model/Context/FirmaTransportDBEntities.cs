using System;
using System.Collections.Generic;
using Firma_Transport.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Firma_Transport.Model.Context;

public partial class FirmaTransportDBEntities : DbContext
{
    public FirmaTransportDBEntities()
    {
    }

    public FirmaTransportDBEntities(DbContextOptions<FirmaTransportDBEntities> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Availability> Availabilities { get; set; }

    public virtual DbSet<CargoNature> CargoNatures { get; set; }

    public virtual DbSet<CargoType> CargoTypes { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmploymentForm> EmploymentForms { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobTitle> JobTitles { get; set; }

    public virtual DbSet<PassangerType> PassangerTypes { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Reccurency> Reccurencies { get; set; }

    public virtual DbSet<Route> Routes { get; set; }

    public virtual DbSet<RouteStop> RouteStops { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    public virtual DbSet<VehicleType> VehicleTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-39THBIL\\SQLEXPRESS;TrustServerCertificate=True;Integrated Security=True;Database=FirmaTransportDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CargoType>(entity =>
        {
            entity.HasMany(d => d.CargoNatures).WithMany(p => p.CargoTypes)
                .UsingEntity<Dictionary<string, object>>(
                    "CargoTypeNature",
                    r => r.HasOne<CargoNature>().WithMany()
                        .HasForeignKey("CargoNatureId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CargoType__Cargo__46B27FE2"),
                    l => l.HasOne<CargoType>().WithMany()
                        .HasForeignKey("CargoTypeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CargoType__Cargo__45BE5BA9"),
                    j =>
                    {
                        j.HasKey("CargoTypeId", "CargoNatureId");
                        j.ToTable("CargoTypeNature");
                        j.IndexerProperty<int>("CargoTypeId").HasColumnName("CargoTypeID");
                        j.IndexerProperty<int>("CargoNatureId").HasColumnName("CargoNatureID");
                    });
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.Property(e => e.Pesel).IsFixedLength();

            entity.HasOne(d => d.AddressNavigation).WithMany(p => p.Clients)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Client_Address");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasOne(d => d.AddressNavigation).WithMany(p => p.Employees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Address");

            entity.HasOne(d => d.AvailabilityNavigation).WithMany(p => p.Employees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Availability");

            entity.HasOne(d => d.EmploymentFormNavigation).WithMany(p => p.Employees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_EmploymentForm");

            entity.HasOne(d => d.JobTitleNavigation).WithMany(p => p.Employees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_JobTitle");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasOne(d => d.ClientNavigation).WithMany(p => p.Invoices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoice_Client");

            entity.HasOne(d => d.PaymentMethodNavigation).WithMany(p => p.Invoices).HasConstraintName("FK_Invoice_PaymentMethod");

            entity.HasMany(d => d.Jobs).WithMany(p => p.Invoices)
                .UsingEntity<Dictionary<string, object>>(
                    "InvoiceObject",
                    r => r.HasOne<Job>().WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__InvoiceOb__JobID__3D2915A8"),
                    l => l.HasOne<Invoice>().WithMany()
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__InvoiceOb__Invoi__3C34F16F"),
                    j =>
                    {
                        j.HasKey("InvoiceId", "JobId");
                        j.ToTable("InvoiceObject");
                        j.IndexerProperty<int>("InvoiceId").HasColumnName("InvoiceID");
                        j.IndexerProperty<int>("JobId").HasColumnName("JobID");
                    });
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.Property(e => e.Discount).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.CargoTypeNavigation).WithMany(p => p.Jobs).HasConstraintName("FK_Job_CargoType");

            entity.HasOne(d => d.JobDriverNavigation).WithMany(p => p.Jobs).HasConstraintName("FK_Job_Employee");

            entity.HasOne(d => d.JobRouteNavigation).WithMany(p => p.Jobs).HasConstraintName("FK_Job_Route");

            entity.HasOne(d => d.JobVehicleNavigation).WithMany(p => p.Jobs).HasConstraintName("FK_Job_Vehicle");

            entity.HasOne(d => d.PassangerTypeNavigation).WithMany(p => p.Jobs).HasConstraintName("FK_Job_PassangerType");

            entity.HasOne(d => d.ReccurencyNavigation).WithMany(p => p.Jobs).HasConstraintName("FK_Job_Reccurency");
        });

        modelBuilder.Entity<RouteStop>(entity =>
        {
            entity.Property(e => e.EndLocation).HasDefaultValueSql("((0))");
            entity.Property(e => e.StartLocation).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.Address).WithMany(p => p.RouteStops)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RouteStop__Addre__40F9A68C");

            entity.HasOne(d => d.Route).WithMany(p => p.RouteStops)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RouteStop__Route__40058253");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasOne(d => d.VehicleTypeNavigation).WithMany(p => p.Vehicles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehicle_VehicleType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
