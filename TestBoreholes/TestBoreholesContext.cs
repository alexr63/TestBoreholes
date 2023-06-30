using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TestBoreholes.WaterSources;

namespace TestBoreholes;

public partial class TestBoreholesContext : DbContext
{
    public TestBoreholesContext()
    {
    }

    public TestBoreholesContext(DbContextOptions<TestBoreholesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Location> Locations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\sql2019;Initial Catalog=TestBoreholes;Persist Security Info=True;User ID=sa;Password=C130Hercules;TrustServerCertificate=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Location>(entity =>
        {
            entity.ToTable("Locations");

            entity.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Country)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Latitude).HasColumnType("decimal(18, 10)");

            entity.Property(e => e.Longitude).HasColumnType("decimal(18, 10)");

            entity.Property(e => e.WaterSource)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v, Formatting.None, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto
                    }),     // Convert object to JSON string
                    v => JsonConvert.DeserializeObject<WaterSource>(v, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto
                    })  // Convert JSON string to object
                );
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}