using System.Threading.Tasks;
using Medyana.Core.Entity;
using Medyana.Core.Repositories;
using Medyana.Core.UnitOfWorks;
using Medyana.Data.Repositories;

namespace Medyana.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MedyanaDbContext _context;
        private PatientRepository _patientRepository;
        private Repository<Clinic> _clinicRepository;
        private Repository<Doctor> _doctorRepository;

        public IPatientRepository Patient => _patientRepository ??= new PatientRepository(_context);
        public IRepository<Clinic> Clinic => _clinicRepository ??= new Repository<Clinic>(_context);
        public IRepository<Doctor> Doctor => _doctorRepository ??= new Repository<Doctor>(_context);

        public UnitOfWork(MedyanaDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}