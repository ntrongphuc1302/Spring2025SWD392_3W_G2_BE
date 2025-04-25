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


    public virtual DbSet<Pass> Passes { get; set; }

    public virtual DbSet<PaymentStatus> PaymentStatuses { get; set; }

    public virtual DbSet<Station> Stations { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Train> Trains { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<User> Users { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Server=(local);Database=METROONEDB;User Id=sa;Password=pass; Trusted_Connection=True;Encrypt=False;");

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
        modelBuilder.Entity<Pass>(entity =>
        {
            entity.HasKey(e => e.PassId).HasName("PK__Passes__C6740948D56535F2");

            entity.Property(e => e.PassId).HasColumnName("PassID");
            entity.Property(e => e.PassType).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Passes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Passes__UserID__3A81B327");
        });

        modelBuilder.Entity<PaymentStatus>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__PaymentS__9B556A585DC4EE80");

            entity.ToTable("PaymentStatus");

            entity.HasIndex(e => e.TicketId, "UQ__PaymentS__712CC62662DA0492").IsUnique();

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.PaymentStatus1)
                .HasMaxLength(50)
                .HasColumnName("PaymentStatus");
            entity.Property(e => e.PaymentTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TicketId).HasColumnName("TicketID");

            entity.HasOne(d => d.Ticket).WithOne(p => p.PaymentStatus)
                .HasForeignKey<PaymentStatus>(d => d.TicketId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__PaymentSt__Ticke__4E88ABD4");
        });

        modelBuilder.Entity<Station>(entity =>
        {
            entity.HasKey(e => e.StationId).HasName("PK__Stations__E0D8A6DDFD19AA1E");

            entity.Property(e => e.StationId).HasColumnName("StationID");
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.StationCode).HasMaxLength(20);
            entity.Property(e => e.StationName).HasMaxLength(100);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__Tickets__712CC627BFE3C37A");

            entity.Property(e => e.TicketId).HasColumnName("TicketID");
            entity.Property(e => e.BookingTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EndStationId).HasColumnName("EndStationID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Qrcode)
                .HasMaxLength(255)
                .HasColumnName("QRCode");
            entity.Property(e => e.StartStationId).HasColumnName("StartStationID");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TripId).HasColumnName("TripID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.EndStation).WithMany(p => p.TicketEndStations)
                .HasForeignKey(d => d.EndStationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tickets__EndStat__49C3F6B7");

            entity.HasOne(d => d.StartStation).WithMany(p => p.TicketStartStations)
                .HasForeignKey(d => d.StartStationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tickets__StartSt__48CFD27E");

            entity.HasOne(d => d.Trip).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.TripId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tickets__TripID__47DBAE45");

            entity.HasOne(d => d.User).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tickets__UserID__46E78A0C");
        });

        modelBuilder.Entity<Train>(entity =>
        {
            entity.HasKey(e => e.TrainId).HasName("PK__Train__8ED2725A69305F0E");

            entity.ToTable("Train");

            entity.Property(e => e.TrainId).HasColumnName("TrainID");
            entity.Property(e => e.EndStationId).HasColumnName("EndStationID");
            entity.Property(e => e.StartStationId).HasColumnName("StartStationID");
            entity.Property(e => e.TrainName).HasMaxLength(100);

            entity.Property(e => e.Capacity).HasColumnName("Capacity").HasColumnType("int");

            entity.HasOne(d => d.EndStation).WithMany(p => p.TrainEndStations)
                .HasForeignKey(d => d.EndStationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Train__EndStatio__403A8C7D");

            entity.HasOne(d => d.StartStation).WithMany(p => p.TrainStartStations)
                .HasForeignKey(d => d.StartStationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Train__StartStat__3F466844");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.TripId).HasName("PK__Trips__51DC711EA65A7046");

            entity.Property(e => e.TripId).HasColumnName("TripID");
            entity.Property(e => e.ArrivalTime).HasColumnType("datetime");
            entity.Property(e => e.DepartureTime).HasColumnType("datetime");
            entity.Property(e => e.TrainId).HasColumnName("TrainID");

            entity.HasOne(d => d.Train).WithMany(p => p.Trips)
                .HasForeignKey(d => d.TrainId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Trips__TrainID__4316F928");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC603571B7");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105345F5E05B1").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValueSql("('Active')");
        });
        modelBuilder.Entity<User>()
                    .Property(u => u.UserId)
                    .ValueGeneratedOnAdd();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
