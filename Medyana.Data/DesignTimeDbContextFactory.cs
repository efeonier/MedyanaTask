using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Medyana.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MedyanaDbContext>
    {
        public MedyanaDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MedyanaDbContext>();
            var connectionString =
                "Server=localhost;Database=MedyanaDB;User=sa;Password=E21f90e!;persist security info=True;Connection Timeout=1000";
            builder.UseSqlServer(connectionString);
            return new MedyanaDbContext(builder.Options);
        }
    }
}