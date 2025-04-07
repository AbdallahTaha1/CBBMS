using CBBMS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CBBMS.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DonationRequest> DonationRequests { get; set; }
        public DbSet<BloodRequest> BloodRequests { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<BloodBank> BloodBanks { get; set; }
        public DbSet<BloodStock> BloodStocks { get; set; }
    }
}
