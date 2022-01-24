using Microsoft.EntityFrameworkCore;

namespace HomeWorkWeek9
{
    public class HomeWorkDbContext : DbContext 
    {
        public HomeWorkDbContext(DbContextOptions<HomeWorkDbContext> options) : base(options) { }

        public DbSet<Employ> Employs { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Possition> Possitions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employ>()
                .HasOne(s => s.Company)
                .WithMany(g => g.Employs)
                .HasForeignKey(s => s.CompanyId);
            modelBuilder.Entity<Employ>()
                .HasOne(s => s.Possition)
                .WithMany(g => g.Employs)
                .HasForeignKey(s => s.PossitionId);
            base.OnModelCreating(modelBuilder);
        }
    }
}

