using Army.Core.Infrastructure.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace Army.Core.DAL
{
    public class ArmyTechContext : DbContext
    {
        public ArmyTechContext(DbContextOptions<ArmyTechContext> options)
           : base(options)
        {
        }

        public virtual DbSet<CardProduct> CartProducts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}