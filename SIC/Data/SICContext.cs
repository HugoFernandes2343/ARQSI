using Microsoft.EntityFrameworkCore;

namespace SIC.Models
{
    public class SICContext : DbContext
    {
        public SICContext(DbContextOptions<SICContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restriction>()
                        .HasDiscriminator<string>("type")
                        .HasValue<RestrictionSizes>("ResSIZES")
                        .HasValue<RestrictionMat>("ResMAT");
        }

        public DbSet<SIC.Models.Product> Product { get; set; }

        public DbSet<SIC.Models.Restriction> Restriction { get; set; }

        public DbSet<SIC.Models.Catalog> Catalog { get; set; }

        public DbSet<SIC.Models.Material> Material { get; set; }

        public DbSet<SIC.Models.Dimensions> Dimensions { get; set; }

        public DbSet<SIC.Models.Category> Category { get; set; }

        public DbSet<SIC.Models.Finish> Finish { get; set; }

        public DbSet<SIC.Models.Aggregation> Aggregation { get; set; }
    }
}