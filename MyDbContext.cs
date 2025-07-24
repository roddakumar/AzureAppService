
using Microsoft.EntityFrameworkCore;

namespace AppService
{
    using Microsoft.EntityFrameworkCore;

    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Standard> Standards { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        // ✅ Correct method to override
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>()
        .ToTable("Teacher"); // Map entity to exact table name

            // Optional: also map Standard if needed
            modelBuilder.Entity<Standard>()
                .ToTable("Standard");

            modelBuilder.Entity<Standard>(entity =>
            {
                entity.HasKey(e => e.StandardId);
                entity.Property(e => e.StandardName).HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(100);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.TeacherId);
                entity.Property(e => e.FirstName).HasMaxLength(100);
                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.HasOne(d => d.Standard)
                      .WithMany(p => p.Teachers)
                      .HasForeignKey(d => d.StandardId);
            });
        }
    }

}
