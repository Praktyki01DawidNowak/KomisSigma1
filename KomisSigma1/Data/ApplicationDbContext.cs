using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KomisSigma1.Models;

namespace KomisSigma1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<KomisSigma1.Models.Samochodzik>? Samochodzik { get; set; }
        public DbSet<KomisSigma1.Models.Marka>? Marka { get; set; }
        public DbSet<KomisSigma1.Models.Model>? Model { get; set; }
        public DbSet<KomisSigma1.Models.RodzajNadwozia>? RodzajNadwozia { get; set; }
        public DbSet<KomisSigma1.Models.RodzajPaliwa>? RodzajPaliwa { get; set; }
    }
}