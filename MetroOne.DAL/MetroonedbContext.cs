using System;
using System.Collections.Generic;
using MetroOne.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MetroOne.DAL;

public partial class MetroonedbContext : DbContext
{
    private readonly IConfiguration _configuration;
    //public MetroonedbContext()
    //{
    //    _configuration = new ConfigurationBuilder()
    //        .SetBasePath(AppContext.BaseDirectory)
    //        .AddJsonFile("appsettings.json")
    //        .Build();
    //}


    public MetroonedbContext(DbContextOptions<MetroonedbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Route> Routes { get; set; }

    public virtual DbSet<RouteLocation> RouteLocations { get; set; }

    public virtual DbSet<Station> Stations { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Train> Trains { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Payment> Payments { get; set; }


    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Server=NEBULA\\SQLEXPRESS;Database=METROONEDB;User Id=sa;Password=123456; Trusted_Connection=True;Encrypt=False; ");
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection"); // DefaultConnection is defined in appsettings.json
            optionsBuilder.UseSqlServer(connectionString);

        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA477A7F2D653");

            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.LocationName).HasMaxLength(100);
        });

        modelBuilder.Entity<Route>(entity =>
        {
            entity.HasKey(e => e.RouteId).HasName("PK__Routes__80979AAD0D2925EC");

            entity.Property(e => e.RouteId).HasColumnName("RouteID");
            entity.Property(e => e.EndStationId).HasColumnName("EndStationID");
            entity.Property(e => e.RouteLocationId).HasColumnName("RouteLocationID");
            entity.Property(e => e.RouteName).HasMaxLength(100);
            entity.Property(e => e.StartStationId).HasColumnName("StartStationID");

            entity.HasOne(d => d.EndStation).WithMany(p => p.RouteEndStations)
                .HasForeignKey(d => d.EndStationId)
                .HasConstraintName("FK__Routes__EndStati__45F365D3");

            entity.HasOne(d => d.RouteLocation).WithMany(p => p.Routes)
                .HasForeignKey(d => d.RouteLocationId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Routes__RouteLoc__46E78A0C");

            entity.HasOne(d => d.StartStation).WithMany(p => p.RouteStartStations)
                .HasForeignKey(d => d.StartStationId)
                .HasConstraintName("FK__Routes__StartSta__44FF419A");
        });

        modelBuilder.Entity<RouteLocation>(entity =>
        {
            entity.HasKey(e => e.RouteLocationId).HasName("PK__RouteLoc__ADC74A46D96938ED");

            entity.ToTable("RouteLocation");

            entity.HasIndex(e => e.LocationId, "UQ__RouteLoc__E7FEA4764EF80374").IsUnique();

            entity.Property(e => e.RouteLocationId).HasColumnName("RouteLocationID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");

            entity.HasOne(d => d.Location).WithOne(p => p.RouteLocation)
                .HasForeignKey<RouteLocation>(d => d.LocationId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__RouteLoca__Locat__4222D4EF");
        });

        modelBuilder.Entity<Station>(entity =>
        {
            entity.HasKey(e => e.StationId).HasName("PK__Stations__E0D8A6DDF89A2067");

            entity.Property(e => e.StationId).HasColumnName("StationID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.StationName).HasMaxLength(100);

            entity.HasOne(d => d.Location).WithMany(p => p.Stations)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Stations__Locati__3E52440B");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__Tickets__712CC62751153BBF");

            entity.Property(e => e.TicketId).HasColumnName("TicketID");
            entity.Property(e => e.BookingTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TripId).HasColumnName("TripID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.ValidTo).HasColumnType("datetime");

            entity.HasOne(d => d.Trip).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.TripId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Tickets__TripID__52593CB8");

            entity.HasOne(d => d.User).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Tickets__UserID__5165187F");
        });

        modelBuilder.Entity<Train>(entity =>
        {
            entity.HasKey(e => e.TrainId).HasName("PK__Trains__8ED2725A8D149518");

            entity.Property(e => e.TrainId).HasColumnName("TrainID");
            entity.Property(e => e.RouteLocationId).HasColumnName("RouteLocationID");
            entity.Property(e => e.TrainName).HasMaxLength(100);

            entity.HasOne(d => d.RouteLocation).WithMany(p => p.Trains)
                .HasForeignKey(d => d.RouteLocationId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Trains__RouteLoc__49C3F6B7");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.TripId).HasName("PK__Trips__51DC711E210B0AA6");

            entity.Property(e => e.TripId).HasColumnName("TripID");
            entity.Property(e => e.ArrivalTime).HasColumnType("datetime");
            entity.Property(e => e.DepartureTime).HasColumnType("datetime");
            entity.Property(e => e.RouteId).HasColumnName("RouteID");
            entity.Property(e => e.TrainId).HasColumnName("TrainID");

            entity.HasOne(d => d.Route).WithMany(p => p.Trips)
                .HasForeignKey(d => d.RouteId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Trips__RouteID__4CA06362");

            entity.HasOne(d => d.Train).WithMany(p => p.Trips)
                .HasForeignKey(d => d.TrainId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Trips__TrainID__4D94879B");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC771F4B79");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D1053400F650C6").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Permission)
                .HasMaxLength(20)
                .HasDefaultValue("Passenger");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Active");
        });
        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId);

            entity.Property(e => e.Method)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsRequired();

            entity.Property(e => e.PaymentDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.HasOne(e => e.Ticket)
                .WithOne(t => t.Payment)
                .HasForeignKey<Payment>(p => p.TicketId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Payment_Ticket");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
