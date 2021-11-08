using Medyana.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Medyana.Data
{
    public class MedyanaDbContext : DbContext
    {
        public MedyanaDbContext(DbContextOptions<MedyanaDbContext> options) : base(options)
        {
        }

        public DbSet<Clinic> Clinic { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Patient> Patient { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}