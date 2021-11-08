using System.Threading.Tasks;
using Medyana.Core.Entity;
using Medyana.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Medyana.Data.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private MedyanaDbContext _dbContext => _context as MedyanaDbContext;

        public PatientRepository(MedyanaDbContext context) : base(context)
        {
        }

        public async Task<Patient> GetWithDoctorIdAsync(int doctorId)
        {
            return await _dbContext.Patient.Include(x => x.Doctor).Include(x => x.Clinic).Include(x => x.Notes)
                .FirstOrDefaultAsync(x => x.Doctor.Id == doctorId);
        }
    }
}