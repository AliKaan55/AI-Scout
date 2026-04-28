using AIScoutProject.AIScout.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AIScoutProject.AIScout.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<ScoutRecommendation> Recommendations { get; set; }
    }
}