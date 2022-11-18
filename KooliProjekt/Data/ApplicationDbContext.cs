using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Data;

namespace KooliProjekt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<KooliProjekt.Data.Car> Car { get; set; }
        public DbSet<KooliProjekt.Data.Money> Money { get; set; }
        public DbSet<KooliProjekt.Data.Operations> Operations { get; set; }
        public DbSet<KooliProjekt.Data.Reservationcs> Reservationcs { get; set; }
        
    }
}