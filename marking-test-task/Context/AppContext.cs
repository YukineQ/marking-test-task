using marking_test_task.Models;
using Microsoft.EntityFrameworkCore;

namespace marking_test_task.Context
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options) { }

        public DbSet<Pallete> Palletes { get; set; }
        public DbSet<Box> Boxes { get; set; }
        public DbSet<Bottle> Bottles { get; set; }
        public DbSet<Mission> Missions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Mission>()
                .HasIndex(m => m.MissionId)
                .IsUnique();

            builder.Entity<Mission>()
                .HasMany(m => m.Palletes)
                .WithOne(p => p.Mission)
                .HasForeignKey(p => p.MissionId)
                .HasPrincipalKey(m => m.MissionId);
        }
    }
}
