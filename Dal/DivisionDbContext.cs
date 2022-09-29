using Divisions.Dal.Dbo;
using Microsoft.EntityFrameworkCore;

namespace Divisions.Dal
{
    public class DivisionDbContext : DbContext
    {
        public DivisionDbContext(DbContextOptions<DivisionDbContext> options) : base(options)
        { }

        public DbSet<DivisionDbo> Divisions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DivisionDbo>(entity =>
            entity.HasCheckConstraint("CK_DivisionDbo_ParentDivisionId", "\"ParentDivisionId\" != \"Id\""));

            modelBuilder.Entity<DivisionDbo>(entity =>
            entity.HasIndex(a => a.Name).IsUnique());
        }
    }
}
