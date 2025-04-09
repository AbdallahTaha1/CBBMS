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
        public DbSet<Donor> Donors { get; set; }
        public DbSet<DonationRequest> DonationRequests { get; set; }
        public DbSet<HospitalRequest> HospitalRequests { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<BloodBank> BloodBanks { get; set; }
        public DbSet<BloodStockUnits> BloodStockUnits { get; set; }
    }
}
